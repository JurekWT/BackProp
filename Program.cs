namespace BackProp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        //Application.Run(new Form1());
        var inputsOutputs = new Dictionary<double[], double[]>();
        NeuralNetwork neuralNetwork = new NeuralNetwork(3, 1, 3, [3,2,1], 1, 0.3);
        foreach (var neuron in neuralNetwork.network)
        {
            Console.WriteLine(neuron.Count);
        }
        neuralNetwork.GenerateWeights(-5,5);
        

    }
}