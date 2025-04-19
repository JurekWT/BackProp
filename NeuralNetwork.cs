using System.Text.Json;
using Microsoft.VisualBasic.Devices;

namespace BackProp;

public class NeuralNetwork
{
    
    //public double[] inputs; //wejścia sieci neuronowej
    public int inputsCount;
    //public double[] outputs; //wyjścia sieci neuronowej
    public int outputsCount;
    public int layers; //ilość warstw
    public int[] numberOfNeuronsForLayer; //ilość neuronów w każdej warstwie
    public double learningParamB; //parametr uczenia B
    public double learningParamU; //parametr uczenia u
    public List<List<Neuron>> network; //lista neuronów każdej warstwy

    public NeuralNetwork(int inputsCount, int outputsCount, int layers, int[] numberOfNeuronsForLayer, double learningParamB, double learningParamU)
    {
        this.inputsCount = inputsCount;
        this.outputsCount = outputsCount;
        this.layers = layers;
        this.numberOfNeuronsForLayer = numberOfNeuronsForLayer;
        this.learningParamB = learningParamB;
        this.learningParamU = learningParamU;
        CreateNetwork();
    }

    private void CreateNetwork() //tworzenie warstw i neuronów w każdej warstwie
    {
        this.network = new List<List<Neuron>>();
        for (int layerNumber = 0; layerNumber < layers; layerNumber++)
        {
            network.Add(new List<Neuron>());
            for (int neuronNumber = 0; neuronNumber < numberOfNeuronsForLayer[layerNumber]; neuronNumber++)
            {
                network[layerNumber].Add(new Neuron());
            }
        }
    }

    public void GenerateWeights(int lowerBound, int upperBound) //generowanie wag dla każdego neurona (ilość wag = wejścia każdej warstwy + 1)
    {
        for (int layerNumber = 0; layerNumber < network.Count; layerNumber++)
        {
            for (int neuronNumber = 0; neuronNumber < network[layerNumber].Count; neuronNumber++)
            {
                if (layerNumber == 0) //wagi dla pierwszej warstwy
                {
                    network[layerNumber][neuronNumber].GenerateWeights(inputsCount, lowerBound, upperBound);
                }
                else //wagi każdej kolejnej warstwy
                {
                    network[layerNumber][neuronNumber].GenerateWeights(network[layerNumber - 1].Count, lowerBound, upperBound);
                }
            }
        }
    }

    private void ProcessInputs(double[] input) //przepuszczenie wejść przez sieci i obliczenie wartości neuronów
    {
        double[] hiddenInputs = null;
        for (int layerNumber = 0; layerNumber < network.Count; layerNumber++)
        {
            
            if (layerNumber != 0)
            {
                hiddenInputs = new double[network[layerNumber - 1].Count];
                for (int neuronNumber = 0; neuronNumber < network[layerNumber - 1].Count; neuronNumber++)
                {
                    hiddenInputs[neuronNumber] = network[layerNumber - 1][neuronNumber].neuronValue;
                }
            }
            for (int neuronNumber = 0; neuronNumber < network[layerNumber].Count; neuronNumber++)
            {
                if (layerNumber == 0)
                {
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(input);
                    
                }
                else
                {
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(hiddenInputs);
                }
                network[layerNumber][neuronNumber].ActivationFunction(learningParamB);
            }
        }
    }

    private double[] GetLayerOutputs(int layer) //zwraca wartości neuronów wyjściowych
    {
        var outputs = new double[network[layer].Count];
        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i] = network[layer][i].neuronValue;
        }
        return outputs;
    }

    public double[] ProcessInputsGetOutputs(double[] inputs)
    {
        ProcessInputs(inputs);
        return GetLayerOutputs(network.Count - 1);
    }

    private void ComputeDeltas()
    {
        for (int layerNumber = network.Count - 2; layerNumber >= 0; layerNumber--) //przechodzimy przez warstwy od tyłu z pominięciem ostatniej
        {
            for (int neuronNumber = 0; neuronNumber < network[layerNumber].Count; neuronNumber++)
            {
                double sumOfDeltas = 0;

                for (int neuronNextLayer = 0; neuronNextLayer < network[layerNumber + 1].Count; neuronNextLayer ++) //suma delt pomnożonych przez wagi dla następnej warstwy
                {
                    sumOfDeltas += network[layerNumber + 1][neuronNextLayer].delta * network[layerNumber + 1][neuronNextLayer].weights[neuronNumber];
                }
                var neuron = network[layerNumber][neuronNumber];
                neuron.delta = sumOfDeltas * (learningParamB * neuron.neuronValue * (1 - neuron.neuronValue));
            }
        }
    }

    private void UpdateWeights(double[] inputs)
    {
        for (int layerNumber = 0; layerNumber < network.Count; layerNumber++)
        {
            double[] previousOutputs;
            if (layerNumber == 0)
            {
                previousOutputs = inputs;
            }
            else
            {
                previousOutputs = GetLayerOutputs(layerNumber - 1);
            }

            foreach (var neuron in network[layerNumber]) //aktualizacja wag
            {
                for (int weightNumber = 0; weightNumber < previousOutputs.Length; weightNumber++)
                {
                    neuron.weights[weightNumber] += learningParamU * neuron.delta * previousOutputs[weightNumber];
                }
                
                neuron.weights[neuron.weights.Length - 1] += learningParamU * neuron.delta; //aktualizacja biasu
            }
        }
    }

    public void SaveWeights(string fileName)
    {
        string json = JsonSerializer.Serialize(network);
        File.WriteAllText(fileName, json);
    }

    public void LoadWeights(string fileName)
    {
        string json = File.ReadAllText(fileName);
        network = JsonSerializer.Deserialize<List<List<Neuron>>>(json);
    }
    
    public void BackPropagation(double[] inputs, double[] expectedOutputs)
    {
        ProcessInputs(inputs);
        for (int output = 0; output < network[network.Count - 1].Count; output++) // wyliczenie błędów i pochodnej w warstwie wyjściowej
        {
            var neuron = network[network.Count - 1][output];
            var adjustment = learningParamU * (expectedOutputs[output] - neuron.neuronValue);
            neuron.delta = adjustment * (learningParamB * neuron.neuronValue * (1 - neuron.neuronValue));
        }

        ComputeDeltas();
        UpdateWeights(inputs);
    }
    
}