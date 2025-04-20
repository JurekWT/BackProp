using System.Text.Json.Serialization;

namespace BackProp;

public class Neuron
{
    private static Random random = new Random();
    
    public double[] weights { get; set; } // lista wag neuronu, ostatnia to bias (ilość wag = ilość wejść + 1)
    public double sumOfTheProduct { get; set; } // suma iloczynu wag i wejść
    public double neuronValue { get; set; } // wartość wyjściowa neuronu
    public double delta { get; set; }

    public Neuron()
    {
    }

    public void GenerateWeights(int inputsCount, int lowerBound, int upperBound)
    {
        this.weights = new double[inputsCount + 1];
        for (int inputNumber = 0; inputNumber <= inputsCount; inputNumber++)
        {
            this.weights[inputNumber] = random.NextDouble() * (upperBound - lowerBound) + lowerBound;
        }
    }

    public void CalculateSumOfTheProduct(double[] inputs)
    {
        this.sumOfTheProduct = 0;
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