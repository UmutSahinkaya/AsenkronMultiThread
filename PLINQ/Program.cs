namespace PLINQ
{
    internal class Program
    {
        //100 5 thread
        //1. thread 1-20 
        //2. thread 21-40
        //.
        //.
        //.
        //.

        private static bool Islem(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {
            var array = Enumerable.Range(1, 500).ToList();

            var newArray=array.AsParallel().Where(Islem);

            newArray.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });

        }
    }
    
}
