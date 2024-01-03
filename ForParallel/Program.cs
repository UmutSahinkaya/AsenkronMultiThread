namespace ForParallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Parallel.For
            //long totalByte = 0;

            //var files = Directory.GetFiles(@"C:\Users\Umut.Sahinkaya\Desktop\Pictures");
            //Parallel.For(0, files.Length, (index) =>
            //{
            //    Console.WriteLine("Thread No:" + Thread.CurrentThread.ManagedThreadId);
            //    var file = new FileInfo(files[index]);
            //    Interlocked.Add(ref totalByte, file.Length);
            //});

            //Console.WriteLine("Total Byte: " + totalByte.ToString());
            #endregion

            #region Parallel.ForEach SharedData
            //int total = 0;
            //Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subTotal) =>
            //{
            //    subTotal += x;
            //    return subTotal;
            //},(y)=>Interlocked.Add(ref total,y));
            //Console.WriteLine(total);
            #endregion
            #region Parallel.For SharedData
            int total = 0;
            Parallel.For(0, 100, () => 0, (x, loop, subTotal) =>
            {
                subTotal += x;
                return subTotal;
            }, (y) => Interlocked.Add(ref total, y));
            Console.WriteLine(total);
            #endregion
        }
    }
}
