namespace BackProp;

public partial class zad1 : Form
{
    private double paramB;
    private double paramU;
    private int iterations;
    private Dictionary<double[], double[]> inOut;
    private NeuralNetwork neuralNetwork;
    
    public zad1()
    {
        InitializeComponent();
        paramB = double.Parse(textParamB.Text);
        paramU = double.Parse(textParamU.Text);
        iterations = int.Parse(textIterations.Text);
        inOut = new Dictionary<double[], double[]>
        {
            { [0, 0], [0] },
            { [0, 1], [1] },
            { [1, 0], [1] },
            { [1, 1], [0] },
        };
        neuralNetwork = new NeuralNetwork(2, 1, 2, [2,1], paramB, paramU);
        neuralNetwork.GenerateWeights(-5,5);
    }

    private void buttonLoadWeights_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
    }

    private void buttonSingleCalc_Click(object sender, EventArgs e)
    {
        textOutput.Text = null;
        textOutput.Text = "Oczekiwany wynik - Uzyskany wynik" + Environment.NewLine;
        for (int i = 0; i < inOut.Count ; i++)
        {
            var expected = inOut.ElementAt(i).Value;
            var result = neuralNetwork.ProcessInputsGetOutputs(inOut.ElementAt(i).Key);
            for (int j = 0; j < result.Length; j++)
            {
                textOutput.Text += expected[j].ToString() + " - " + $"{result[j]:F2}" + Environment.NewLine;
            }
        }
    }

    private void buttonTrainNetwork_Click(object sender, EventArgs e)
    {
        iterations = int.Parse(textIterations.Text);
        textOutput.Text = null;
        for (int i = 0; i < iterations; i++)
        {
            textOutput.Text = $"Epoka {i+1}" + Environment.NewLine;
            textOutput.Refresh();
            Application.DoEvents();
            for (int inputNumber = 0; inputNumber < inOut.Count; inputNumber++)
            {
                neuralNetwork.BackPropagation(inOut.ElementAt(inputNumber).Key, inOut.ElementAt(inputNumber).Value);
            }
        }

        textOutput.Text += Environment.NewLine + "ZAKOŃCZONO TRENOWANIE SIECI NEURONOWEJ";
        textOutput.Refresh();
    }
}