namespace BackProp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void buttonZadanie1_Click(object sender, EventArgs e)
    {
        zad1 zad1 = new zad1();
        this.Hide();
        zad1.ShowDialog();
        this.Show();
    }
}