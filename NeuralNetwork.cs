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

    public NeuralNetwork(double[] inputs, double[] outputs, int layers, int[] numberOfNeuronsForLayer, double learningParamB, double learningParamU)
    {
        this.inputs = inputs;
        this.outputs = outputs;
        this.layers = layers;
        this.numberOfNeuronsForLayer = numberOfNeuronsForLayer;
        this.learningParamB = learningParamB;
        this.learningParamU = learningParamU;
    }

    public void CreateNetwork()
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

    public void GenerateWeights(int lowerBound, int upperBound)
    {
        for (int layerNumber = 0; layerNumber < network.Count; layerNumber++)
        {
            for (int neuronNumber = 0; neuronNumber < network[layerNumber].Count; neuronNumber++)
            {
                if (layerNumber == 0)
                {
                    network[layerNumber][neuronNumber].GenerateWeights(inputs.Length, lowerBound, upperBound);
                }
                else
                {
                    network[layerNumber][neuronNumber].GenerateWeights(network[layerNumber - 1].Count, lowerBound, upperBound);
                }
            }
        }
    }
    
}