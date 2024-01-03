using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelForForEachCancellationFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource ct;
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ct=new CancellationTokenSource(); // iptal ettikten sonra devam ettirmiyor. bunu yaptığımızda devam edebilecek
            List<string> urls = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com"
            };

            HttpClient client = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = ct.Token;

            //ParallelForeach i main thread den alıp farklı bir thread de çalıştırıyor ki form bloklanmasın.
            Task.Run(() => 
            {
                try
                {
                    Parallel.ForEach<string>(urls, parallelOptions, (url) =>
                    {
                        string content = client.GetStringAsync(url).Result; //async olayını Result ile blokladık. Çünkü her bir thread kendi içinde dönecek eğer async olursa 

                        string data = $"{url}:{content.Length}";

                        //ct.Token.ThrowIfCancellationRequested();//Cancel çalıştığı anda bir hata fırlatıyor
                        parallelOptions.CancellationToken.ThrowIfCancellationRequested(); // ct ye ulaşamadığında alternatif olarak bunuda kullanabilirsin.

                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });
                    });
                }
                catch( OperationCanceledException ex2)
                {
                    MessageBox.Show("işlem iptal edildi: " + ex2.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata meydana geldi: " + ex.Message);
                }
                
            });
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = counter++.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
