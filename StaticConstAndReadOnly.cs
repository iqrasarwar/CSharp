//person.cs

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp3
{
    public class Person
    {
        public static string name = "iqra"; //can be assigned in constructor too
        public const int year = 2021;//can't be assigned anywhere else
        public readonly int rollno = 12;//can be assigned in constructor too

        public Person(string n, int p)
        {
            name = n;
            rollno = p;
        }
    }
}


//program.cs

using System;
using ConsoleApp3;
using System.Collections.Generic;
namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("iqraa",13);
            Console.WriteLine(p.rollno);
            Console.WriteLine(Person.name);
        }
    }
}
