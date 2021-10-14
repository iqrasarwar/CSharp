using System;
namespace linked
{
    class Program
    {
        public static (string, int) GetNameAndAge()
        {
            return ("iqra", 12);
        }

        public static (string s, int z) GetNameAndAge1()
        {
            return ("iqra1", 122);
        }

        static void Main(string[] args)
        {
            string name = GetNameAndAge().Item1;
            int age = GetNameAndAge().Item2;
            string name1 = GetNameAndAge1().s;
            int age1 = GetNameAndAge1().z;
            var per = GetNameAndAge1();
            string name2 = per.s;
            (string name_, int age_) = GetNameAndAge();
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(name1);
            Console.WriteLine(age1);
            Console.WriteLine(per);
            Console.WriteLine(name2);
            Console.WriteLine(name_);
            Console.WriteLine(age_);
        }
    }
}
