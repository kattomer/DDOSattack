using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_DDoS
{
    public partial class Form1 : Form
    {
        private List<Process> browsers;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            int numBrowsers = Convert.ToInt32(textBox1.Text);
            var url = textBox1.Text;
            var sanitizedUrl = url.Replace(";", string.Empty)
                                  .Replace("'", string.Empty)
                                  .Replace("\"", string.Empty);
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = "chrome.exe";
            psi.Arguments = sanitizedUrl;
         
            for (int i = 0; i < 5; i++)
            {
                Process process = System.Diagnostics.Process.Start(psi);
                browsers.Add(process);

            }
            */
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            browsers = new List<Process>();
            int numBrowsers = Convert.ToInt32(textBox1.Text);
            var url = textBox2.Text;
            var sanitizedUrl = url.Replace(";", string.Empty)
                                  .Replace("'", string.Empty)
                                  .Replace("\"", string.Empty);
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = "chrome.exe";
            psi.Arguments = sanitizedUrl;
            for (int i = 0; i < numBrowsers; i++)
            {
                try
                {
                    Process process = System.Diagnostics.Process.Start(psi);
                    browsers.Add(process);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");

            foreach (Process p in chromeInstances)
                p.Kill();

        }
    }
}