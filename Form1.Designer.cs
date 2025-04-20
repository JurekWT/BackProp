namespace BackProp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        buttonZadanie1 = new System.Windows.Forms.Button();
        buttonZadanie2 = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        buttonZadanie3 = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // buttonZadanie1
        // 
        buttonZadanie1.Cursor = System.Windows.Forms.Cursors.Hand;
        buttonZadanie1.Location = new System.Drawing.Point(61, 51);
        buttonZadanie1.Name = "buttonZadanie1";
        buttonZadanie1.Size = new System.Drawing.Size(264, 84);
        buttonZadanie1.TabIndex = 0;
        buttonZadanie1.Text = "Zadanie 1\r\nXOR";
        buttonZadanie1.UseVisualStyleBackColor = true;
        buttonZadanie1.Click += buttonZadanie1_Click;
        // 
        // buttonZadanie2
        // 
        buttonZadanie2.Cursor = System.Windows.Forms.Cursors.Hand;
        buttonZadanie2.Location = new System.Drawing.Point(61, 141);
        buttonZadanie2.Name = "buttonZadanie2";
        buttonZadanie2.Size = new System.Drawing.Size(264, 84);
        buttonZadanie2.TabIndex = 1;
        buttonZadanie2.Text = "Zadanie 2\r\nXOR + NOR";
        buttonZadanie2.UseVisualStyleBackColor = true;
        buttonZadanie2.Click += buttonZadanie2_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(61, 349);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(264, 45);
        label1.TabIndex = 3;
        label1.Text = "Jerzy Tymofiejczyk\r\nMIW 2025";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // buttonZadanie3
        // 
        buttonZadanie3.Cursor = System.Windows.Forms.Cursors.Hand;
        buttonZadanie3.Location = new System.Drawing.Point(61, 231);
        buttonZadanie3.Name = "buttonZadanie3";
        buttonZadanie3.Size = new System.Drawing.Size(264, 84);
        buttonZadanie3.TabIndex = 4;
        buttonZadanie3.Text = "Zadanie 3\r\nSUMATOR";
        buttonZadanie3.UseVisualStyleBackColor = true;
        buttonZadanie3.Click += buttonZadanie3_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(390, 424);
        Controls.Add(buttonZadanie3);
        Controls.Add(label1);
        Controls.Add(buttonZadanie2);
        Controls.Add(buttonZadanie1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = " Propagacja wsteczna MIW 2025";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button buttonZadanie3;


    private System.Windows.Forms.Button buttonZadanie2;
    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button buttonZadanie1;

    #endregion
}