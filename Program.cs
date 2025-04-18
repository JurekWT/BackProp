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
        NeuralNetwork neuralNetwork = new NeuralNetwork([1, 2, 3, 4], [1, 3], 5, [4, 3, 4, 5, 1], 1, 0.3);
        neuralNetwork.CreateNetwork();
        foreach (var neuron in neuralNetwork.network)
        {
            Console.WriteLine(neuron.Count);
        }
        neuralNetwork.GenerateWeights(-5,5);

        foreach (var layer in neuralNetwork.network)
        {
            foreach (var neuron in layer)
            {
                Console.WriteLine(neuron.weights.Length);
            }
        }
    }
}