using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tTable of X upto N");
            string x, n;
            Console.WriteLine("Enter X:");
            x = Console.ReadLine();
            Console.WriteLine("Enter N:");
            n = Console.ReadLine();
            int X = Convert.ToInt32(x);
            int N = Convert.ToInt32(n);
            int M = 1;
            Console.WriteLine("Table");
            while (N >= M)
            {
                int c = X * M;
                Console.WriteLine("{0}  *  {1}  =  {2}", X, M, c);
                M++;
            }
        }
    }
}
