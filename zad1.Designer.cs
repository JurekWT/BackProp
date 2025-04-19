using System.ComponentModel;

namespace BackProp;

partial class zad1
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        groupBox1 = new System.Windows.Forms.GroupBox();
        groupBox2 = new System.Windows.Forms.GroupBox();
        buttonSaveWeights = new System.Windows.Forms.Button();
        buttonLoadWeights = new System.Windows.Forms.Button();
        textIterations = new System.Windows.Forms.TextBox();
        label4 = new System.Windows.Forms.Label();
        textParamU = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        textParamB = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        textOutput = new System.Windows.Forms.TextBox();
        buttonSingleCalc = new System.Windows.Forms.Button();
        buttonTrainNetwork = new System.Windows.Forms.Button();
        saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        groupBox1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(groupBox2);
        groupBox1.Controls.Add(textIterations);
        groupBox1.Controls.Add(label4);
        groupBox1.Controls.Add(textParamU);
        groupBox1.Controls.Add(label3);
        groupBox1.Controls.Add(textParamB);
        groupBox1.Controls.Add(label2);
        groupBox1.Location = new System.Drawing.Point(13, 45);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new System.Drawing.Size(216, 393);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "Parametry";
        // 
        // groupBox2
        // 
        groupBox2.Controls.Add(buttonSaveWeights);
        groupBox2.Controls.Add(buttonLoadWeights);
        groupBox2.Location = new System.Drawing.Point(12, 191);
        groupBox2.Name = "groupBox2";
        groupBox2.Size = new System.Drawing.Size(190, 191);
        groupBox2.TabIndex = 6;
        groupBox2.TabStop = false;
        groupBox2.Text = "Wagi";
        // 
        // buttonSaveWeights
        // 
        buttonSaveWeights.Location = new System.Drawing.Point(10, 105);
        buttonSaveWeights.Name = "buttonSaveWeights";
        buttonSaveWeights.Size = new System.Drawing.Size(170, 49);
        buttonSaveWeights.TabIndex = 1;
        buttonSaveWeights.Text = "Zapisz";
        buttonSaveWeights.UseVisualStyleBackColor = true;
        // 
        // buttonLoadWeights
        // 
        buttonLoadWeights.Location = new System.Drawing.Point(9, 50);
        buttonLoadWeights.Name = "buttonLoadWeights";
        buttonLoadWeights.Size = new System.Drawing.Size(170, 49);
        buttonLoadWeights.TabIndex = 0;
        buttonLoadWeights.Text = "Wczytaj";
        buttonLoadWeights.UseVisualStyleBackColor = true;
        buttonLoadWeights.Click += buttonLoadWeights_Click;
        // 
        // textIterations
        // 
        textIterations.Location = new System.Drawing.Point(114, 116);
        textIterations.Name = "textIterations";
        textIterations.Size = new System.Drawing.Size(78, 27);
        textIterations.TabIndex = 5;
        textIterations.Text = "20000";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(21, 116);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(87, 27);
        label4.TabIndex = 4;
        label4.Text = "Epoki";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textParamU
        // 
        textParamU.Location = new System.Drawing.Point(114, 83);
        textParamU.Name = "textParamU";
        textParamU.Size = new System.Drawing.Size(78, 27);
        textParamU.TabIndex = 3;
        textParamU.Text = "0,3";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(21, 83);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(87, 27);
        label3.TabIndex = 2;
        label3.Text = "Param. u";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textParamB
        // 
        textParamB.Location = new System.Drawing.Point(114, 50);
        textParamB.Name = "textParamB";
        textParamB.Size = new System.Drawing.Size(78, 27);
        textParamB.TabIndex = 1;
        textParamB.Text = "1";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(21, 50);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(87, 27);
        label2.TabIndex = 0;
        label2.Text = "Param. B";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(137, 6);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(556, 36);
        label1.TabIndex = 1;
        label1.Text = "XOR - sieć składająca się z 2 wejść, 1 wyjścia i 2+1 neuronów.";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // textOutput
        // 
        textOutput.Location = new System.Drawing.Point(235, 219);
        textOutput.Multiline = true;
        textOutput.Name = "textOutput";
        textOutput.ReadOnly = true;
        textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textOutput.Size = new System.Drawing.Size(554, 218);
        textOutput.TabIndex = 2;
        // 
        // buttonSingleCalc
        // 
        buttonSingleCalc.Location = new System.Drawing.Point(244, 56);
        buttonSingleCalc.Name = "buttonSingleCalc";
        buttonSingleCalc.Size = new System.Drawing.Size(172, 40);
        buttonSingleCalc.TabIndex = 3;
        buttonSingleCalc.Text = "Przelicz wartości";
        buttonSingleCalc.UseVisualStyleBackColor = true;
        buttonSingleCalc.Click += buttonSingleCalc_Click;
        // 
        // buttonTrainNetwork
        // 
        buttonTrainNetwork.Location = new System.Drawing.Point(244, 115);
        buttonTrainNetwork.Name = "buttonTrainNetwork";
        buttonTrainNetwork.Size = new System.Drawing.Size(172, 40);
        buttonTrainNetwork.TabIndex = 4;
        buttonTrainNetwork.Text = "Trenuj sieć";
        buttonTrainNetwork.UseVisualStyleBackColor = true;
        buttonTrainNetwork.Click += buttonTrainNetwork_Click;
        // 
        // saveFileDialog1
        // 
        saveFileDialog1.DefaultExt = "wagiZadanie1";
        saveFileDialog1.Filter = "plik json|*.json";
        // 
        // openFileDialog1
        // 
        openFileDialog1.DefaultExt = "wagiZadanie1";
        openFileDialog1.FileName = "openFileDialog1";
        openFileDialog1.Filter = "pliki json|*.json";
        // 
        // zad1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(buttonTrainNetwork);
        Controls.Add(buttonSingleCalc);
        Controls.Add(textOutput);
        Controls.Add(label1);
        Controls.Add(groupBox1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Propagacja wsteczna - Zadanie 1";
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        groupBox2.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.GroupBox groupBox2;

    private System.Windows.Forms.Button buttonLoadWeights;
    private System.Windows.Forms.Button buttonSaveWeights;

    private System.Windows.Forms.OpenFileDialog openFileDialog1;

    private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    private System.Windows.Forms.Button buttonSingleCalc;
    private System.Windows.Forms.Button buttonTrainNetwork;

    private System.Windows.Forms.TextBox textOutput;

    private System.Windows.Forms.TextBox textParamU;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textIterations;
    private System.Windows.Forms.Label label4;

    private System.Windows.Forms.TextBox textParamB;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.GroupBox groupBox1;

    #endregion
}