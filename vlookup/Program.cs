using System;

namespace vlookup
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProcess process = new MainProcess();
            var result = process.DiffFiles("./file1.csv", "./file2.csv");
            Console.Write(result);
        }
    }
}
