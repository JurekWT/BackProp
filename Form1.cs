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

    private void buttonZadanie2_Click(object sender, EventArgs e)
    {
        zad2 zad2 = new zad2();
        this.Hide();
        zad2.ShowDialog();
        this.Show();
    }

    private void buttonZadanie3_Click(object sender, EventArgs e)
    {
        zad3 zad3 = new zad3();
        this.Hide();
        zad3.ShowDialog();
        this.Show();
    }
}