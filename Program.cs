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
        NeuralNetwork network = new NeuralNetwork([1, 0, 3], [2, 0], 3, [3, 3, 1], 1, 0.3, -5, 5);
        foreach (var neuron in network.network)
        {
            Console.WriteLine(neuron.Count);
        }
    }
}