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
        panel1 = new System.Windows.Forms.Panel();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Location = new System.Drawing.Point(12, 14);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(774, 62);
        panel1.TabIndex = 0;
        // 
        // zad1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(panel1);
        Text = "Propagacja wsteczna - Zadanie 1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel1;

    #endregion
}