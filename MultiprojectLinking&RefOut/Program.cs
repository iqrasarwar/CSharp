using System;
using ConsoleApp3;

namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Cgpa = 3,
                Age = 4
            };
            Console.WriteLine(p.ToString());
            int z;
            string c;
            int d = 2;
            int a = 0;
            p.test(1, ref d, out z, out c);
            Console.WriteLine($"{a} {d} {z} {c}");
        }
    }
}
