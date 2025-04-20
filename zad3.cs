namespace BackProp;

public partial class zad3 : Form
{
    private double paramB;
    private double paramU;
    private int iterations;
    private int lowerBound;
    private int upperBound;
    private bool inProgess;
    private Dictionary<double[], double[]> inOut;
    private NeuralNetwork neuralNetwork;
    
    public zad3()
    {
        InitializeComponent();
        paramB = double.Parse(textParamB.Text);
        paramU = double.Parse(textParamU.Text);
        lowerBound = int.Parse(textBoxLowerBound.Text);
        upperBound = int.Parse(textBoxUpperBound.Text);
        iterations = int.Parse(textIterations.Text);
        inOut = new Dictionary<double[], double[]>
        {
            { [0, 0, 0], [0, 0] },
            { [0, 1, 0], [1, 0] },
            { [1, 0, 0], [1 ,0] },
            { [1, 1, 0], [0, 1] },
            { [0, 0, 1], [1, 0] },
            { [0, 1, 1], [0, 1] },
            { [1, 0, 1], [0, 1] },
            { [1, 1, 1], [1, 1] }
        };
        neuralNetwork = new NeuralNetwork(3, 2, 3, [3,2,2], paramB, paramU);
        neuralNetwork.GenerateWeights(lowerBound,upperBound);
    }

    private void buttonSingleCalc_Click(object sender, EventArgs e)
    {
        textOutput.Text = null;
        textOutput.Text = "Wejście - Oczekiwany wynik - Uzyskany wynik" + Environment.NewLine;
        for (int i = 0; i < inOut.Count ; i++)
        {
            var input = inOut.ElementAt(i).Key;
            var expected = inOut.ElementAt(i).Value;
            var result = neuralNetwork.ProcessInputsGetOutputs(inOut.ElementAt(i).Key);
            for (int j = 0; j < input.Length; j++)
            {
                textOutput.Text += $" {input[j]} ";
            }

            textOutput.Text += "--";
            for (int j = 0; j < expected.Length; j++)
            {
                textOutput.Text += $" {expected[j]} ";
            }

            textOutput.Text += "--";
            for (int j = 0; j < result.Length; j++)
            {
                textOutput.Text += $" {result[j]:F2} ";
            }
            textOutput.Text += Environment.NewLine;
        }
    }

    private void buttonTrainNetwork_Click(object sender, EventArgs e)
    {
        inProgess = true;
        buttonTrainNetwork.Enabled = false;
        buttonSingleCalc.Enabled = false;
        buttonStopTraining.Enabled = true;
        DisableInputs(inProgess);
        iterations = int.Parse(textIterations.Text);
        neuralNetwork.learningParamB = double.Parse(textParamB.Text);
        neuralNetwork.learningParamU = double.Parse(textParamU.Text);
        textOutput.Text = null;
        for (int i = 0; i < iterations && inProgess; i++)
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
        inProgess = false;
        DisableInputs(inProgess);
        buttonTrainNetwork.Enabled = true;
        buttonSingleCalc.Enabled = true;
        buttonStopTraining.Enabled = false;
    }
    
    private void buttonStopTraining_Click(object sender, EventArgs e)
    {
        inProgess = false;
        buttonTrainNetwork.Enabled = true;
        buttonSingleCalc.Enabled = true;
        buttonStopTraining.Enabled = false;
        DisableInputs(inProgess);
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
            neuralNetwork.SaveWeights(saveFileDialog1.FileName);
            textOutput.Text = $"Zapisano wagi do pliku {saveFileDialog1.FileName}";
        }
    }

    private void DisableInputs(bool disable)
    {
        textBoxLowerBound.Enabled = !disable;
        textBoxUpperBound.Enabled = !disable;
        textIterations.Enabled = !disable;
        textParamB.Enabled = !disable;;
        textParamU.Enabled = !disable;;
        buttonGenerateWeights.Enabled = !disable;;
        buttonLoadWeights.Enabled = !disable;;
        buttonSaveWeights.Enabled = !disable;;
    }
}