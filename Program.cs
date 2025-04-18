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
        Application.Run(new Form1());
        Neuron neuron = new Neuron();
        int[] inputs = new int[2] { 1, 0 };
        neuron.GenerateWeights(inputs.Length + 1, -5, 5);
        neuron.CalculateSumOfTheProduct(inputs);
        foreach (var weight in neuron.weights)
        {
            Console.WriteLine(weight.ToString());
        }
        Console.WriteLine(neuron.sumOfTheProduct);
    }
}