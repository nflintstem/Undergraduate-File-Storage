//a simple OpenCL kernel which copies all pixels from A to B
kernel void hist_atomic(global const int* A, local int* H, int nr_bins) {
	int id = get_global_id(0);
	int lid = get_local_id(0);
	int bin_index = A[id]*(nr_bins/256.0f);
	//clear the scratch bins
	if (lid < nr_bins)
		H[lid] = 0;
	barrier(CLK_LOCAL_MEM_FENCE);
	atomic_inc(&H[bin_index]);
	//copy H from local to global
}

kernel void hist_simple(global const uchar* A, global int* H) { 
	int id = get_global_id(0);

	//assumes that H has been initialised to 0
	int bin_index = A[id];//take value as a bin index

	atomic_inc(&H[bin_index]);//serial operation, not very efficient!
}

kernel void hist_local_simple(global const uchar* A, global uint* H, local uint* LH, int nr_bins) {
	/* A - input image 
	H - Histogram
	LH - local Histogram
	nr_bins - number of bins*/
	int id = get_global_id(0);
	int lid = get_local_id(0);
	int bin_index = A[id]*(nr_bins/256.0f);
	LH[lid] =0;

	//clear the scratch bins
	barrier(CLK_LOCAL_MEM_FENCE);
	atomic_inc(&LH[bin_index]);
	barrier(CLK_LOCAL_MEM_FENCE);
	if (lid < nr_bins) //combine all local hist into a global one
		atomic_add(&H[lid], LH[lid]);
}

//Hillis-Steele basic inclusive scan
//requires additional buffer B to avoid data overwrite 
kernel void scan_hs(global int* A, global int* B) {
	int id = get_global_id(0);
	int N = get_global_size(0);
	global int* C;

	for (int stride = 1; stride <= N; stride *= 2) {
		B[id] = A[id];
		if (id >= stride)
			B[id] += A[id - stride];

		barrier(CLK_GLOBAL_MEM_FENCE); //sync the step

		C = A; A = B; B = C; //swap A & B between steps
	}
}

kernel void scan_bl(global int* A) {
	int id = get_global_id(0);
	int N = get_global_size(0);
	int t;

	//up-sweep
	for (int stride = 1; stride < N; stride *= 2) {
		if (((id + 1) % (stride*2)) == 0)
			A[id] += A[id - stride];

		barrier(CLK_GLOBAL_MEM_FENCE); //sync the step
	}

	//down-sweep
	if (id == 0)
		A[N-1] = 0;//exclusive scan

	barrier(CLK_GLOBAL_MEM_FENCE); //sync the step

	for (int stride = N/2; stride > 0; stride /= 2) {
		if (((id + 1) % (stride*2)) == 0) {
			t = A[id];
			A[id] += A[id - stride]; //reduce 
			A[id - stride] = t;		 //move
		}

		barrier(CLK_GLOBAL_MEM_FENCE); //sync the step
	}
}

kernel void norm_hs(global int* A, global int* B, float scale){
	int id = get_global_id(0);
	B[id] = A[id]*scale; //divide by image input size *255
}

kernel void makeImg(global int* NH, global uchar* A, global uchar* B, int nr_bins){
	int id = get_global_id(0);
	int bin_index = A[id]*(nr_bins/256.0f);
	B[id] = NH[bin_index];