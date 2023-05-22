import math
import matplotlib.pyplot as plt
import random
train_file = open("data-CMP2020M-item1-train.txt", "r")
weightvals = open("weightsTable.txt","w")


learn_rate = 0.1
epoch = 800
ErrorPlot = []
ErrorAdd = []

def sigmoid(net):
        return 1 / (1 + (math.e ** -net))

def calcNets(weight, inp):
    net = weight[0]*1 #bias is 1, and weight[0] should always be set to w0x
    i=1
    for i in range(len(inp)-1):
        net = net + (weight[i]*inp[i]) 
    return net

def calcOutErrors(target, output):
    return target - output

def calcHidErrors(output, weight, o_err):
    errors = 0
    for i in range(len(weight)):
        for j in range(len(o_err)):
            errors += weight[i] * o_err[j]
    return output*(1-output)*errors

def new_Weights(w,delt):
    return w+delt

def arrayEdit(editArray, learnrate, error, input):
    delta = learnrate*error*input
    for i in range(len(editArray)):
        editArray[i] = new_Weights(editArray[i], delta)
        i += 1
    return editArray

def softmax(net_i,net_k):
    return (math.e**net_i)/(math.e**net_i + math.e**net_k)

def errorsAdd(output, hidden):
    value = 0
    for i in range(len(output)-1):
        value += output[i] ** 2
    for j in range(len(hidden)-1):
        value += hidden[j] ** 2
    return value/2

def trainAI(network,learnWeights):
    targets = network[1]
    net1 = calcNets (learnWeights[0], network[0])
    net2 = calcNets(learnWeights[1], network[0])
    net3 = calcNets(learnWeights[2], network[0])

    data2 = [sigmoid(net1),sigmoid(net2),sigmoid(net3)]
    outputs = [calcNets(learnWeights[3],data2),calcNets(learnWeights[4],data2)]
    probDist = [softmax(outputs[0],outputs[1]),softmax(outputs[1],outputs[0])]

    if targets != probDist:
        outputErrors = [calcOutErrors(targets[0], outputs[0]),calcOutErrors(targets[1],outputs[1])]
        hiddenErrors = [calcHidErrors(outputs[0],learnWeights[3],outputErrors),calcHidErrors(outputs[1],learnWeights[4],outputErrors)]
        print(str(errorsAdd(outputErrors,hiddenErrors)) + "\n")
        ErrorAdd.append(errorsAdd(outputErrors,hiddenErrors))
        learnWeights[0] = arrayEdit(learnWeights[0],learn_rate,hiddenErrors[1],net1)
        learnWeights[1] = arrayEdit(learnWeights[1],learn_rate,hiddenErrors[0],net2)
        learnWeights[2] = arrayEdit(learnWeights[2],learn_rate,hiddenErrors[1],net3)
        learnWeights[3] = arrayEdit(learnWeights[3], learn_rate,outputErrors[0],outputs[0])
        learnWeights[4] = arrayEdit(learnWeights[4], learn_rate,outputErrors[1],outputs[1])
    print("\n\n")

def runAI(weights, data):
    wx4 = weights[0] #going from w04 to w34
    wx5 = weights[1] #this and the line below follow the same convention as above
    wx6 = weights[2]
    wx7 = weights[3] #going from w07 to w67
    wx8 = weights[4] #same convention as above
    net1 = calcNets (wx4, data)
    net2 = calcNets(wx5, data)
    net3 = calcNets(wx6, data)

    data2 = [sigmoid(net1),sigmoid(net2),sigmoid(net3)]
    outputs = [calcNets(wx7,data2),calcNets(wx8,data2)]
    probDist = [softmax(outputs[0],outputs[1]), softmax(outputs[1],outputs[0])]
    return probDist

def makeNetwork(line):
    dl1Network = list()
    dataline = line.split("\t") 
    dlInput = [float(feat) for feat in dataline[0].split(" ")]
    dlTargets = [int(feat) for feat in dataline[1].split(" ")]
    dlNetwork = [dlInput, dlTargets]
    return dlNetwork

def roundvals(weightslist):
    for iArray in range (len(weightslist)):
        for weight in range(len(weightslist[iArray])):
            weightslist[iArray][weight] = round(weightslist[iArray][weight],2)
    return weightslist

        
learnweights = [[0.90,0.74,0.80, 0.35] , [0.45,0.13,0.40,0.97] , [0.36,0.68,0.10,0.96], [0.98,0.35,0.50,0.90], [0.92,0.80,0.13,0.80]]
weightvals.write(str(learnweights))
weightvals.write("\n")

set1 = makeNetwork(train_file.readline())
set2 = makeNetwork(train_file.readline())
set3 = makeNetwork(train_file.readline())
set4 = makeNetwork(train_file.readline())
set5 = makeNetwork(train_file.readline())
set6 = makeNetwork(train_file.readline())

epochNums = []
for i in range(epoch):
    ErrorAdd.clear()
    trainAI(set1,learnweights)
    trainAI(set2,learnweights)
    trainAI(set3,learnweights)
    trainAI(set4,learnweights)
    trainAI(set5,learnweights)
    trainAI(set6,learnweights)
    #print(learnweights)
    if i%(epoch/10) == 0: #every 160 epochs append the weights to a file to make the table in the report
            weightvals.write(str(learnweights)) #add the weights to the weightvals text file every epoch/10 epochs to get 10 weights
            weightvals.write("\n \n")
    GraphAppend = 0
    for c in range(len(ErrorAdd)-1):
        GraphAppend += ErrorAdd[c]
    #print("Appending: " +str(GraphAppend))
    ErrorPlot.append(GraphAppend)

plt.plot(ErrorPlot)
plt.title("Learning Curve of the Neural Network")
plt.axis([0,epoch,0,1])
plt.xlabel("Epochs")
plt.ylabel("Error")
plt.show()
        

train_file.close()
test_file = open("data-CMP2020M-item1-test.txt", "r")
testline = test_file.readline().split("\t")
testInput = [float(feat) for feat in testline[0].split(" ")]
testresult = runAI(learnweights, testInput)
print("Test Data Probability Distribution is:" + str(testresult))
test_file.close()