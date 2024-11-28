using System.ComponentModel;

namespace GameTimeLimiter;

partial class AddGameForm
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
        comboBox1 = new ComboBox();
        button1 = new Button();
        SuspendLayout();
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(0, 0);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(336, 33);
        comboBox1.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
        comboBox1.BackColor = Color.LightBlue;
        comboBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new Point(342, -2);
        button1.Name = "button1";
        button1.Size = new Size(73, 34);
        button1.TabIndex = 1;
        button1.Text = "hinzufügen";
        button1.BackColor = Color.DarkOrange;
        button1.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
        button1.UseVisualStyleBackColor = true;
        button1.Click += this.button1_Click;
        // 
        // AddGameForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(416, 403);
        Controls.Add(button1);
        Controls.Add(comboBox1);
        Name = "AddGameForm";
        BackColor = Color.AliceBlue;
        Text = "AddGame";
        ResumeLayout(false);
    }


    #endregion

    private ComboBox comboBox1;
    private Button button1;
}