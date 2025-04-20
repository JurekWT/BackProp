namespace BackProp;

public partial class zad1 : Form
{
    private double paramB;
    private double paramU;
    private int iterations;
    private int lowerBound;
    private int upperBound;
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
        neuralNetwork.learningParamB = double.Parse(textParamB.Text);
        neuralNetwork.learningParamU = double.Parse(textParamU.Text);
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

    private void buttonGenerateWeights_Click(object sender, EventArgs e)
    {
        lowerBound = int.Parse(textBoxLowerBound.Text);
        upperBound = int.Parse(textBoxUpperBound.Text);
        neuralNetwork.GenerateWeights(lowerBound, upperBound);;
    }
    
    private void buttonLoadWeights_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            neuralNetwork.LoadWeights(openFileDialog1.FileName);
            textOutput.Text = $"Wczytano wagi z pliku {openFileDialog1.FileName}";
        }
    }


    private void buttonSaveWeights_Click(object sender, EventArgs e)
    {
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            neuralNetwork.SaveWeights(openFileDialog1.FileName);
            textOutput.Text = $"Zapisano wagi do pliku {openFileDialog1.FileName}";
        }
    }
}