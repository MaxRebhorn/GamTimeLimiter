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
using System.Configuration;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameTimeLimiter
{
    public class CodeDetails
    {
        public string Code { get; set; }
        public DateTime? LastUpdated { get; set; }
        
        public bool valid { get; set; }
    }

    public class DailyCodes
    {
        public CodeDetails OneHourCode { get; set; }
        public CodeDetails TwoHourCode { get; set; }
        public CodeDetails RestOfTheDayCode { get; set; }
    }

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

            LoadEmailData();

            addDailyCodes();

            string mail_string = build_mail_string();

            send_mail("Spielzeit Vorbei", mail_string);
        }

        private void LoadEmailData()
        {
            try
            {
                var emailDataPath = ConfigurationManager.AppSettings["EmailDataPath"];
                string jsonString = System.IO.File.ReadAllText(emailDataPath);
                emailData = JsonSerializer.Deserialize<EmailData>(jsonString);
            }
            catch (Exception e)
            {
                // Consider logging the exception message to a log file
                Console.WriteLine("An error occurred while loading the email data: " + e.Message);
            }
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

        private void addDailyCodes()
        {
            // Load the dailyCodes JSON
            var dailyCodesPath = ConfigurationManager.AppSettings["DailyCodesPath"];
            string jsonString = System.IO.File.ReadAllText(dailyCodesPath);
            var dailyCodes = JsonSerializer.Deserialize<DailyCodes>(jsonString);

            // Get the current date (without the time)
            DateTime currentDate = DateTime.Today;

            // Check if the codes have been set today
            if (dailyCodes.OneHourCode.LastUpdated.GetValueOrDefault().Date != currentDate && dailyCodes.OneHourCode.valid == false)
            {
                OneHourCode = generate_code();
                dailyCodes.OneHourCode.Code = OneHourCode;
                dailyCodes.OneHourCode.LastUpdated = currentDate;
            }
            else
            {
                OneHourCode = dailyCodes.OneHourCode.Code;
            }

            if (dailyCodes.TwoHourCode.LastUpdated.GetValueOrDefault().Date != currentDate && dailyCodes.TwoHourCode.valid == false)
            {
                TwoHourCode = generate_code();
                dailyCodes.TwoHourCode.Code = TwoHourCode;
                dailyCodes.TwoHourCode.LastUpdated = currentDate;
            }
            else
            {
                TwoHourCode = dailyCodes.TwoHourCode.Code;
            }

            if (dailyCodes.RestOfTheDayCode.LastUpdated.GetValueOrDefault().Date != currentDate && dailyCodes.RestOfTheDayCode.valid == false)
            {
                RestOfTheDayCode = generate_code();
                dailyCodes.RestOfTheDayCode.Code = RestOfTheDayCode;
                dailyCodes.RestOfTheDayCode.LastUpdated = currentDate;
            }
            else
            {
                RestOfTheDayCode = dailyCodes.RestOfTheDayCode.Code;
            }

            // Save the daily codes back to the JSON file
            jsonString = JsonConvert.SerializeObject(dailyCodes);
            Console.WriteLine($"Attempting to write to {dailyCodesPath}");
            System.IO.File.WriteAllText(dailyCodesPath, jsonString);
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

        private void submit_button_Click(object? sender, EventArgs e)
        {
           
            string userCode = code_input.Text.Replace(" ", "").ToUpper();
            // Load user setting JSON
            var userSettingsPath = ConfigurationManager.AppSettings["UserDataPath"];
            string jsonString = System.IO.File.ReadAllText(userSettingsPath);
            var userSettings = JsonSerializer.Deserialize<UserSettings>(jsonString);
            bool correct = false;
            DateTime currentTime = DateTime.Now;
            double hoursRemainingToMidnight = (24 - currentTime.Hour) - (currentTime.Minute/60.0);
            var dailyCodesPath = ConfigurationManager.AppSettings["DailyCodesPath"];
            string json = System.IO.File.ReadAllText(dailyCodesPath);
            var dailyCodes = JsonSerializer.Deserialize<DailyCodes>(json);

            // If the entered code matches, increase the DailyTimeExtra field accordingly
            if(userCode == OneHourCode)
            {
                userSettings.User.DailyTimeExtra += 1;
                label1.Text = "Eine Stunde wurde zur Spielzeit hinzugefügt";
                dailyCodes.OneHourCode.valid = false;
                correct = true;
            }
            else if(userCode == TwoHourCode)
            {
                userSettings.User.DailyTimeExtra += 2;
                label1.Text = "Zwei Stunden wurden zur Spielzeit hinzugefügt";
                dailyCodes.TwoHourCode.valid = false;
                correct = true;
            }
            else if(userCode == RestOfTheDayCode)
            {
                userSettings.User.DailyTimeExtra += hoursRemainingToMidnight;
                label1.Text = "Du kannst jetzt noch den restlichen Tag spielen";
                dailyCodes.RestOfTheDayCode.valid = false;
                correct = true;
            }
            if (correct)
            {
                submit_button.Enabled = false;
                resend_email.Enabled = false;
            }
            // Save the updated settings back to the JSON file
            jsonString = JsonSerializer.Serialize(userSettings);
            System.IO.File.WriteAllText(userSettingsPath, jsonString);
            
            
            
            
          
            
            json = JsonConvert.SerializeObject(dailyCodes);
            Console.WriteLine($"Attempting to write to {dailyCodesPath}");
            System.IO.File.WriteAllText(dailyCodesPath, json);
            
            
            this.Close();
        }

    }
}