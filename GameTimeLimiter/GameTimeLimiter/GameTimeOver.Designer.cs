namespace GameTimeLimiter
{
    partial class GameTimeOver
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
            code_input = new TextBox();
            label1 = new Label();
            submit_button = new Button();
            resend_email = new Button();
            SuspendLayout();
            // 
            // code_input
            // 
            code_input.Location = new Point(148, 97);
            code_input.Name = "code_input";
            code_input.Size = new Size(156, 23);
            code_input.TabIndex = 0;
            code_input.PlaceholderText = "XXXXX";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 45);
            label1.Name = "label1";
            label1.Size = new Size(167, 15);
            label1.TabIndex = 1;
            label1.Text = "Deine Spielzeit ist Ausgelaufen";
            // 
            // submit_button
            // 
            submit_button.Location = new Point(187, 126);
            submit_button.Name = "submit_button";
            submit_button.Size = new Size(75, 23);
            submit_button.TabIndex = 2;
            submit_button.Text = "submit";
            submit_button.UseVisualStyleBackColor = true;
            submit_button.Click += submit_button_Click;
            // 
            // resend_email
            // 
            resend_email.Location = new Point(120, 200);
            resend_email.Name = "resend_email";
            resend_email.Size = new Size(215, 24);
            resend_email.TabIndex = 3;
            resend_email.Text = "Email erneut senden";
            resend_email.UseVisualStyleBackColor = true;
            resend_email.Click += resend_email_click;
            
            // 
            // GameTimeOver
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 236);
            Controls.Add(resend_email);
            Controls.Add(submit_button);
            Controls.Add(label1);
            Controls.Add(code_input);
            Name = "GameTimeOver";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox code_input;
        private Label label1;
        private Button submit_button;
        private Button resend_email;
    }
}