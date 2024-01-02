using System.Diagnostics;
using System.Drawing;

namespace ForEachParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long FilesByte = 0;
            int deger=0;
            #region ParallelForeach    //İşlem 00:00:00.1861995 sürede Tamamlandı !
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //string picturePath = @"C:\Users\Umut.Sahinkaya\Desktop\Pictures";

            //var files = Directory.GetFiles(picturePath);

            //Parallel.ForEach(files, (item) =>
            //{
            //    Console.WriteLine("Thread No: " + Thread.CurrentThread.ManagedThreadId);
            //    Image img = new Bitmap(item);

            //    var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

            //    thumbnail.Save(Path.Combine(picturePath, "thumbnail", Path.GetFileName(item)));
            //});
            //sw.Stop();
            //Console.WriteLine($"İşlem{sw} sürede Tamamlandı !");//İşlem00:00:00.1861995 sürede Tamamlandı !
            #endregion
            #region NormalForeach     //İşlem 00:00:00.4351508 sürede Tamamlandı !
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //string picturePath = @"C:\Users\Umut.Sahinkaya\Desktop\Pictures";

            //var files = Directory.GetFiles(picturePath);

            //files.ToList().ForEach(x =>
            //{
            //    Console.WriteLine("Thread No: " + Thread.CurrentThread.ManagedThreadId);
            //    Image img = new Bitmap(x);

            //    var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

            //    thumbnail.Save(Path.Combine(picturePath, "thumbnail", Path.GetFileName(x)));
            //});
            //sw.Stop();
            //Console.WriteLine($"İşlem{sw} sürede Tamamlandı !");//İşlem00:00:00.4351508 sürede Tamamlandı !
            #endregion
            #region ParallelForeach Race Condition Engelleme  //Toplam boyut: 4626340

            //string picturePath = @"C:\Users\Umut.Sahinkaya\Desktop\Pictures";

            //var files = Directory.GetFiles(picturePath);

            //Parallel.ForEach(files, (item) =>
            //{
            //    Console.WriteLine("Thread No: " + Thread.CurrentThread.ManagedThreadId);
            //    FileInfo f = new FileInfo(item);
            //    Interlocked.Add(ref FilesByte, f.Length);
            //});
            
            //Console.WriteLine("Toplam boyut: {0}",FilesByte.ToString());
            #endregion
            #region RaceCondition Ornek
            //Parallel.ForEach(Enumerable.Range(1, 100000).ToList(), (x) =>
            //{
            //    deger = x;

            //});
            //Console.WriteLine("Değer:" + deger); Bu haliyle alıyor.
            #endregion
        }
    }
}
