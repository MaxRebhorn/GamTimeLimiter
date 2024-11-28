using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace GameTimeLimiter
{
    public partial class AddGameForm : Form
    {
        public string SelectedGame { get; private set; }
        

        public AddGameForm()
        {
            InitializeComponent();
            button1 = new Button();

            // Set control properties like Size, Location etc.
            // e.g. comboBox1.Size = new System.Drawing.Size(200, 25);



            // Get the list of all processes, sorted by name and without duplicates.
            var processes = Process.GetProcesses();
            var processNames = processes.Select(p => p.ProcessName).Distinct().OrderBy(p => p).ToArray();

            foreach (var process in processNames)
            {
                comboBox1.Items.Add(process);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                SelectedGame = comboBox1.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Handle the case when no item is selected
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}