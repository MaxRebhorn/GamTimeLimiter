namespace GameTimeLimiter
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            password_input = new TextBox();
            login_button = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();

            password_input.Location = new Point(331, 298);
            password_input.Name = "password_input";
            password_input.PlaceholderText = "password";
            password_input.Size = new Size(150, 31);
            password_input.Font = new Font("Century Gothic", 10);
            password_input.BackColor = Color.LightGray;
            password_input.TabIndex = 0;

            login_button.Location = new Point(348, 335);
            login_button.Name = "login_button";
            login_button.Size = new Size(112, 34);
            login_button.TabIndex = 1;
            login_button.Text = "Login";
            login_button.BackColor = Color.DarkTurquoise;
            login_button.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;

            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Admin", "User" });
            comboBox1.Location = new Point(316, 259);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.Font = new Font("Century Gothic", 10);
            comboBox1.BackColor = Color.LightGray;
            comboBox1.TabIndex = 2;
            comboBox1.Tag = "";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            BackColor = Color.WhiteSmoke;
            Font = new Font("Century Gothic", 12);
            Controls.Add(comboBox1);
            Controls.Add(login_button);
            Controls.Add(password_input);
            Name = "Login";
            Text = "Login";

            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox password_input;
        private Button login_button;
        private ComboBox comboBox1;
    }
}