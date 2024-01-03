using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using PLINQ.EFCore.Models;

namespace PLINQ.EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2017Context _context = new AdventureWorks2017Context();
            _context.Products.Take(10).ToList().ForEach(x =>
            {
                Console.WriteLine(x.Name);
            });
        }
    }
}

