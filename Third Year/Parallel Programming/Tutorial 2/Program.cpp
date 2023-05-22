#include <iostream>
#include <vector>

#include "Utils.h"
#include "CImg.h"

using namespace cimg_library;

void print_help() {
	std::cerr << "Application usage:" << std::endl;

	std::cerr << "  -p : select platform " << std::endl;
	std::cerr << "  -d : select device" << std::endl;
	std::cerr << "  -l : list all platforms and devices" << std::endl;
	std::cerr << "  -f : input image file (default: test.ppm)" << std::endl;
	std::cerr << "  -h : print this message" << std::endl;
}

int main(int argc, char **argv) {
	//Part 1 - handle command line options such as device selection, verbosity, etc.
	int platform_id = 0;
	int device_id = 0;
	string image_filename;
	bool Col;
	bool blelloch;


	for (int i = 1; i < argc; i++) {
		if ((strcmp(argv[i], "-p") == 0) && (i < (argc - 1))) { platform_id = atoi(argv[++i]); }
		else if ((strcmp(argv[i], "-d") == 0) && (i < (argc - 1))) { device_id = atoi(argv[++i]); }
		else if (strcmp(argv[i], "-l") == 0) { std::cout << ListPlatformsDevices() << std::endl; }
		else if ((strcmp(argv[i], "-f") == 0) && (i < (argc - 1))) { image_filename = argv[++i]; }
		else if (strcmp(argv[i], "-h") == 0) { print_help(); return 0; }
	}

	int imgOpt;

	cout << "Which option would you like? \n";
	cout << "1. Regular greyscale image \n";
	cout << "2. Regular colour image \n";
	cout << "3. Large greyscale image \n";
	cout << "4. Large colour image \n";
	cin >> imgOpt;

	ofstream StatFile("metrics.txt");

	switch (imgOpt) {
	case 1:
		image_filename = "test.pgm";
		Col = false;
		StatFile << "SMALL GREYSCALE IMAGE: " << image_filename << std::endl;
		break;
	case 2:
		image_filename = "testColour.ppm";
		Col = true;
		StatFile << "SMALL COLOUR IMAGE: " << image_filename << std::endl;
		break;
	case 3:
		image_filename = "test_large.pgm";
		Col = false;
		StatFile << "LARGE GREYSCALE IMAGE: " << image_filename << std::endl;
		break;
	case 4:
		image_filename = "test_largeColour.ppm";
		Col = true;
		StatFile << "LARGE COLOUR IMAGE: " << image_filename << std::endl;
		break;
	default:
		image_filename = "test.pgm";
		Col = false;
		StatFile << "SMALL GREYSCALE IMAGE: " << image_filename << std::endl;
		break;
	}
	int num_bins;
	cout << "How many bins should we run on: ";
	cin >> num_bins;

	char histOpt;
	cout << "Press the L key for the local method, any other key for global: ";
	cin >> histOpt;
	histOpt = toupper(histOpt);

	char scOpt;
	cout << "Enter the B key for Blelloch method canning, any other key for Hillis-Steele: ";
	cin >> scOpt;
	scOpt = toupper(scOpt);


	cimg::exception_mode(0);

	//detect any potential exceptions
	try {

		CImg<unsigned char> image_input(image_filename.c_str());
		if (Col) {
			image_input.RGBtoYCbCr();
		}

		//a 3x3 convolution mask implementing an averaging filter
		std::vector<float> convolution_mask = { 1.f / 9, 1.f / 9, 1.f / 9,
												1.f / 9, 1.f / 9, 1.f / 9,
												1.f / 9, 1.f / 9, 1.f / 9 };

		//Part 3 - host operations
		//3.1 Select computing devices
		cl::Context context = GetContext(platform_id, device_id);

		//display the selected device
		std::cout << "Runing on " << GetPlatformName(platform_id) << ", " << GetDeviceName(platform_id, device_id) << std::endl;

		//create a queue to which we will push commands for the device
		cl::CommandQueue queue(context, CL_QUEUE_PROFILING_ENABLE);
		//3.2 Load & build the device code
		cl::Program::Sources sources;

		AddSources(sources, "kernels/my_kernels.cl");

		cl::Program program(context, sources);

		//build and debug the kernel code
		try {
			program.build();
		}
		catch (const cl::Error& err) {
			std::cout << "Build Status: " << program.getBuildInfo<CL_PROGRAM_BUILD_STATUS>(context.getInfo<CL_CONTEXT_DEVICES>()[0]) << std::endl;
			std::cout << "Build Options:\t" << program.getBuildInfo<CL_PROGRAM_BUILD_OPTIONS>(context.getInfo<CL_CONTEXT_DEVICES>()[0]) << std::endl;
			std::cout << "Build Log:\t " << program.getBuildInfo<CL_PROGRAM_BUILD_LOG>(context.getInfo<CL_CONTEXT_DEVICES>()[0]) << std::endl;
			throw err;
		}

		//Part 4 - device operations


		size_t histogramSize = num_bins * sizeof(unsigned int);
		vector<int> histogram(num_bins, 0);

		//device - buffers
		cl::Buffer dev_image_input(context, CL_MEM_READ_ONLY, image_input.size());
		cl::Buffer dev_image_output(context, CL_MEM_READ_WRITE, image_input.size()); //should be the same as input image
//		cl::Buffer dev_convolution_mask(context, CL_MEM_READ_ONLY, convolution_mask.size()*sizeof(float));
		cl::Buffer dev_Histo(context, CL_MEM_READ_WRITE, histogramSize);
		cl::Buffer dev_cHisto(context, CL_MEM_READ_WRITE, histogramSize);
		cl::Buffer dev_nHisto(context, CL_MEM_READ_WRITE, histogramSize);



		//4.1 Copy images to device memory
		queue.enqueueWriteBuffer(dev_image_input, CL_TRUE, 0, image_input.size(), &image_input.data()[0]);
		//		queue.enqueueWriteBuffer(dev_convolution_mask, CL_TRUE, 0, convolution_mask.size()*sizeof(float), &convolution_mask[0]);
		//4.2 Setup and execute the kernel (i.e. device code)
		cl::Event hist_event;
		if (histOpt == 'L') {
			cl::Kernel Hkernel = cl::Kernel(program, "hist_local_simple");
			StatFile << "STATS RUNNING LOCAL HISTOGRAM GENERATION" << std::endl;
			Hkernel.setArg(0, dev_image_input);
			Hkernel.setArg(1, dev_Histo); // should be histo
			Hkernel.setArg(2, cl::Local(histogramSize));
			Hkernel.setArg(3, num_bins);
			queue.enqueueNDRangeKernel(Hkernel, cl::NullRange, cl::NDRange(image_input.size()), cl::NullRange, NULL, &hist_event);
			queue.enqueueReadBuffer(dev_Histo, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(hist_event, ProfilingResolution::PROF_US) << std::endl;
		}
		else {
			cl::Kernel Hkernel = cl::Kernel(program, "hist_simple");
			StatFile << "STATS RUNNING GLOBAL HISTOGRAM GENERATION" << std::endl;
			Hkernel.setArg(0, dev_image_input);
			Hkernel.setArg(1, dev_Histo); // should be histo
			queue.enqueueNDRangeKernel(Hkernel, cl::NullRange, cl::NDRange(image_input.size()), cl::NullRange, NULL, &hist_event);
			queue.enqueueReadBuffer(dev_Histo, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(hist_event, ProfilingResolution::PROF_US) << std::endl;
		}
		cl::Event scan_event;
		cl::Event norm_event;
		if (scOpt == 'B') {
			StatFile << "STATS RUNNING BLELLOCH ALGORITHM" << std::endl;
			cl::Kernel scanKernel = cl::Kernel(program, "scan_bl");
			scanKernel.setArg(0, dev_Histo);
			queue.enqueueNDRangeKernel(scanKernel, cl::NullRange, cl::NDRange(histogramSize), cl::NullRange, NULL, &scan_event);
			queue.enqueueReadBuffer(dev_Histo, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(scan_event, ProfilingResolution::PROF_US) << std::endl;
			StatFile << "HISTOGRAM: " << std::endl << histogram << std::endl;

			float thing = 255.0f / histogram[num_bins - 1];

			cl::Kernel normHist = cl::Kernel(program, "norm_hs");
			normHist.setArg(0, dev_Histo);
			normHist.setArg(1, dev_nHisto);
			normHist.setArg(2, thing);
			queue.enqueueNDRangeKernel(normHist, cl::NullRange, cl::NDRange(num_bins), cl::NullRange, NULL, &norm_event);
			queue.enqueueReadBuffer(dev_nHisto, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(norm_event, ProfilingResolution::PROF_US) << std::endl;
			StatFile << "HISTOGRAM POST NORMALISATION" << std::endl << histogram << std::endl;
		}
		else {
			StatFile << "STATS RUNNING HILLIS-STEELE ALGORITHM" << std::endl;
			cl::Kernel scanKernel = cl::Kernel(program, "scan_hs");
			scanKernel.setArg(0, dev_Histo);
			scanKernel.setArg(1, dev_cHisto);
			queue.enqueueNDRangeKernel(scanKernel, cl::NullRange, cl::NDRange(histogramSize), cl::NullRange, NULL, &scan_event);
			queue.enqueueReadBuffer(dev_cHisto, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(scan_event, ProfilingResolution::PROF_US) << std::endl;
			StatFile << "HISTOGRAM: " << std::endl << histogram << std::endl;
			float thing = 255.0f / histogram[num_bins - 1];

			cl::Kernel normHist = cl::Kernel(program, "norm_hs");
			normHist.setArg(0, dev_cHisto);
			normHist.setArg(1, dev_nHisto);
			normHist.setArg(2, thing);
			queue.enqueueNDRangeKernel(normHist, cl::NullRange, cl::NDRange(num_bins), cl::NullRange, NULL, &norm_event);
			queue.enqueueReadBuffer(dev_nHisto, CL_TRUE, 0, histogramSize, &histogram[0], NULL);
			StatFile << GetFullProfilingInfo(norm_event, ProfilingResolution::PROF_US) << std::endl;
			StatFile << "HISTOGRAM POST NORMALISATION" << std::endl << histogram << std::endl;
		}

		cl::Kernel outputImg = cl::Kernel(program, "makeImg");
		outputImg.setArg(0, dev_nHisto);
		outputImg.setArg(1, dev_image_input);
		outputImg.setArg(2, dev_image_output);
		outputImg.setArg(3, num_bins);
		queue.enqueueNDRangeKernel(outputImg, cl::NullRange, cl::NDRange(image_input.size()), cl::NullRange);
		vector<unsigned char> output_buffer(image_input.size());
		//4.3 Copy the result from device to host
		queue.enqueueReadBuffer(dev_image_output, CL_TRUE, 0, output_buffer.size(), &output_buffer.data()[0]);

		/*

		*/

		CImg<unsigned char> output_image(output_buffer.data(), image_input.width(), image_input.height(), image_input.depth(), image_input.spectrum());
		if (Col) output_image.YCbCrtoRGB();

		CImgDisplay disp_input(image_input, "input");
		CImgDisplay disp_output(output_image, "output");


		while (!disp_input.is_closed() && !disp_output.is_closed()
			&& !disp_input.is_keyESC() && !disp_output.is_keyESC()) {
			disp_input.wait(1);
			disp_output.wait(1);
		}

	}
	catch (const cl::Error& err) {
		std::cerr << "ERROR: " << err.what() << ", " << getErrorString(err.err()) << std::endl;
	}
	catch (CImgException& err) {
		std::cerr << "ERROR: " << err.what() << std::endl;
	}

	return 0;
}
