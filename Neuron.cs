namespace BackProp;

public class Neuron
{
    Random random = new Random();
    
    
    public double[] weights; // lista wag neuronu, ostatnia to bias (ilość wag = ilość wejść + 1)
    public double sumOfTheProduct; // suma iloczynu wag i wejść
    public double neuronValue; // wartość wyjściowa neuronu

    public Neuron()
    {
    }

    public void GenerateWeights(int inputsCount, int lowerBound, int upperBound)
    {
        this.weights = new double[inputsCount + 1];
        for (int inputNumber = 0; inputNumber < inputsCount; inputNumber++)
        {
            this.weights[inputNumber] = random.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }
    }

    public void CalculateSumOfTheProduct(double[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            this.sumOfTheProduct += inputs[i] * this.weights[i]; 
        }
        this.sumOfTheProduct += this.weights[this.weights.Length - 1]; //dodaje ostatnią wagę jako bias
    }

    public void ActivationFunction(double learningParamB) //sigmoid
    {
        this.neuronValue = 1 / (1 + Math.Exp(-(learningParamB * this.sumOfTheProduct)));
    }
    
}