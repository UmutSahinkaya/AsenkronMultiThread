using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFromApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            //string data=ReadFile();
            string data=await ReadFileAsync();
            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text =counter++.ToString();
        }

        private string ReadFile()
        {
            string data=string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                //Thread.Sleep(5000);
                data = s.ReadToEnd();
            }
            return data;
        }
        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                //Thread.Sleep(5000);
                data = await s.ReadToEndAsync(); 
                 
                await Task.Delay(4000);
                return data;
            }
           
        }
    }
}
