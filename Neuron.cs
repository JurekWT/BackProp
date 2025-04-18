namespace BackProp;

public class Neuron
{
    Random random = new Random();
    
    // lista wag neuronu, ostatnia to bias (ilość wag = ilość wejść + 1)
    public double[] weights;
    // suma iloczynu wag i wejść
    public double sumOfTheProduct;
    // wartość wyjściowa neuronu
    public double neuronValue;

    public Neuron(int numberOfWeights, int lowerBound, int upperBound)
    {
        this.weights = new double[numberOfWeights];
        for (int i = 0; i < weights.Length; i++)
        {
            this.weights[i] = random.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }
    }

    public void CalculateSumOfTheProduct(double[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            this.sumOfTheProduct += inputs[i] * this.weights[i];
        }
        this.sumOfTheProduct += this.weights[this.weights.Length - 1];
    }

    public void ActivationFunction(double learningParamB)
    {
        this.neuronValue = 1 / (1 + Math.Exp(-(learningParamB * this.sumOfTheProduct)));
    }
    
}