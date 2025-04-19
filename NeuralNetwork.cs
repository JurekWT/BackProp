namespace BackProp;

public class NeuralNetwork
{
    
    public double[] inputs; //wejścia sieci neuronowej
    public double[] outputs; //wyjścia sieci neuronowej
    public int layers; //ilość warstw
    public int[] numberOfNeuronsForLayer; //ilość neuronów w każdej warstwie
    public double learningParamB; //parametr uczenia B
    public double learningParamU; //parametr uczenia u
    public List<List<Neuron>> network; //lista neuronów każdej warstwy

    public NeuralNetwork(double[] inputs, double[] outputs, int layers, int[] numberOfNeuronsForLayer, double learningParamB, double learningParamU)
    {
        this.inputs = inputs;
        this.outputs = outputs;
        this.layers = layers;
        this.numberOfNeuronsForLayer = numberOfNeuronsForLayer;
        this.learningParamB = learningParamB;
        this.learningParamU = learningParamU;
    }

    public void CreateNetwork() //tworzenie warstw i neuronów w każdej warstwie
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
                    network[layerNumber][neuronNumber].GenerateWeights(inputs.Length, lowerBound, upperBound);
                }
                else //wagi każdej kolejnej warstwy
                {
                    network[layerNumber][neuronNumber].GenerateWeights(network[layerNumber - 1].Count, lowerBound, upperBound);
                }
            }
        }
    }

    public void ProcessInputs() //wprowadzenie wejść do sieci i obliczenie wartości neuronów
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
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(inputs);
                    
                }
                else
                {
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(hiddenInputs);
                }
                network[layerNumber][neuronNumber].ActivationFunction(learningParamB);
            }
        }
    }

    public double[] GetNetworkOutputs() //zwraca wartości neuronów wyjściowych
    {
        var outputs = new double[network[network.Count - 1].Count];
        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i] = network[network.Count - 1][i].neuronValue;
        }
        return outputs;
    }
    
}