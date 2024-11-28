using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text.Json;
using System.Configuration;

namespace GameTimeLimiter
{
    public class EmailData
        // Data For 
    {
        public string SmtpServer { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public int SmtpPort { get; set; }
        public string EmailAddress { get; set; }
    }

    public partial class GameTimeOver : Form
    {
        private EmailData emailData;
        private string OneHourCode;
        private string TwoHourCode;
        private string RestOfTheDayCode;

        public GameTimeOver()
        {
            InitializeComponent();

            var emailDataPath = ConfigurationManager.AppSettings["EmailDataPath"];
            string jsonString = System.IO.File.ReadAllText(emailDataPath);
            emailData = JsonSerializer.Deserialize<EmailData>(jsonString);


            OneHourCode = generate_code();
            TwoHourCode = generate_code();
            RestOfTheDayCode = generate_code();

            string mail_string = build_mail_string();

            send_mail("Spielzeit Vorbei", mail_string);
        }

        private string generate_code()
        {
            string code = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                char randomLetter = (char)rnd.Next(65, 91);
                code += randomLetter;
            }

            return code;
        }

        private void send_mail(string subject, string body)
        {
            MailMessage mail = new MailMessage(emailData.SmtpUsername, emailData.EmailAddress);

            // Setting the email subject.
            mail.Subject = subject;

            // Setting the email body.
            mail.Body = body;

            mail.IsBodyHtml = true;

            // Email settings
            SmtpClient client = new SmtpClient(emailData.SmtpServer, emailData.SmtpPort)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailData.SmtpUsername, emailData.SmtpPassword),
                EnableSsl = true
            };

            // Sending the email.
            client.Send(mail);
        }

        private string build_mail_string()
        {
            string mail_string = $@"
    <html>
        <head>
            <meta charset='UTF-8'>
            <title>Wichtige Nachricht</title>
            <style>
                /* Grundlegende Styles */
                body {{
                    font-family: Arial, sans-serif;
                    background-color: #f5f5f5;
                    margin: 0;
                    padding: 20px;
                }}

                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    background-color: #fff;
                    padding: 20px;
                    border-radius: 5px;
                    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
                }}

                h1 {{
                    color: #333;
                    font-size: 24px;
                    margin-bottom: 10px;
                }}

                p {{
                    color: #666;
                    font-size: 16px;
                    line-height: 1.5;
                }}

                .code-block {{
                    background-color: #f0f0f0;
                    padding: 10px;
                    border-radius: 3px;
                    margin-bottom: 15px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <h1>Hallo liebe Eltern,</h1>
                <p>Ihr Kind hat nun die maximale Spielzeit für heute erreicht.</p>

                <div class='code-block'>
                    Code für eine Stunde: {OneHourCode}
                </div>
                <div class='code-block'>
                    Code für zwei Stunden: {TwoHourCode}
                </div>
                <div class='code-block'>
                    Code für den restlichen Tag: {RestOfTheDayCode}
                </div>
            </div>
        </body>
    </html>";

            return mail_string;
        }

        private void resend_email_click(object sender, EventArgs e)
        {
            string mail_string = build_mail_string();
            send_mail("Spielzeit Vorbei", mail_string);
        }
    }
}