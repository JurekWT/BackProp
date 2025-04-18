namespace BackProp;

public class NeuralNetwork
{
    //wejścia sieci neuronowej
    public double[] inputs;
    
    //wyjścia sieci neuronowej
    public double[] outputs;
    
    //ilość warstw
    public int layers;
    
    //ilość neuronów w każdej warstwie
    public int[] numberOfNeuronsForLayer;
    
    //parametry uczenia
    public double learningParamB;
    public double learningParamU;
    
    //lista neuronów każdej warstwy
    public List<List<Neuron>> network;

    public NeuralNetwork(double[] inputs, double[] outputs, int layers, int[] numberOfNeuronsForLayer, double learningParamB, double learningParamU, int lowerBound, int upperBound)
    {
        this.inputs = inputs;
        this.outputs = outputs;
        this.layers = layers;
        this.numberOfNeuronsForLayer = numberOfNeuronsForLayer;
        this.learningParamB = learningParamB;
        this.learningParamU = learningParamU;
        this.network = new List<List<Neuron>>();

        for (int layerNumber = 0; layerNumber < layers; layerNumber++)
        {
            network.Add(new List<Neuron>());
            for (int neuronNumber = 0; neuronNumber < numberOfNeuronsForLayer[layerNumber]; neuronNumber++)
            {
                if (layerNumber == 0)
                {
                    network[layerNumber].Add(new Neuron(inputs.Length + 1, lowerBound, upperBound));
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(inputs);
                    network[layerNumber][neuronNumber].ActivationFunction(learningParamB);
                }
                else
                {
                    network[layerNumber].Add(new Neuron(network[layerNumber - 1].Count + 1, lowerBound, upperBound));
                    double[] layerinputs = new double[network[layerNumber - 1].Count];
                    for (int i = 0; i < network[layerNumber - 1].Count; i++)
                    {
                        layerinputs[i] = network[layerNumber - 1][i].neuronValue;
                    }
                    network[layerNumber][neuronNumber].CalculateSumOfTheProduct(layerinputs);
                    network[layerNumber][neuronNumber].ActivationFunction(learningParamB);
                }
            }
        }
    }
    
    public void 
}