
using System;
using ConsoleApp3;
using System.Collections.Generic;
namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            string cgpa, age;
            List<Person> p = new List<Person>();
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Input cgpa");
                cgpa = Console.ReadLine();
                Console.WriteLine("Input age");
                age = Console.ReadLine();
                p.Add(new Person()
                {
                    Cgpa = Convert.ToInt32(cgpa),
                    Age = Convert.ToInt32(age),
                });
            }
            Person per = new Person();
            per.WritePersons(p);
            p.Clear();
            p = per.PrintPersonsToConsole();
            foreach (Person personn in p)
            {
                Console.WriteLine(personn.ToString());
            }
        }
    }
}
