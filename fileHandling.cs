                    
                    //create a file copy it to a new file and print to console
                    
            FileStream f = new FileStream("file.txt",FileMode.Create);
            f.WriteByte((byte)'a');
            f.WriteByte((byte)'b');
            f.WriteByte((byte)'c');
            f.Close();
            FileStream f1 = new FileStream("file.txt", FileMode.Open);
            FileStream f2 = new FileStream("copy.txt", FileMode.Create);
            int res = f1.ReadByte();
            while(res!=-1)
            {
                f2.WriteByte((byte)res);
                Console.WriteLine("{0} {1} {2}", res,(byte)res,(char)res);
                res = f1.ReadByte();
            }
            f1.Close();
            f2.Close();

                               //using streams writer/reader
                               
            FileStream f = new FileStream("file.txt",FileMode.Create);
            StreamWriter sr = new StreamWriter(f);
            sr.WriteLine("i am iqra sarwar");
            sr.WriteLine("aneesa sarwar");
            sr.WriteLine("nimra haq");
            sr.Close();
            f.Close();
            FileStream f1 = new FileStream("file.txt", FileMode.Open);
            FileStream f2 = new FileStream("copy.txt", FileMode.Create);
            StreamReader s1 = new StreamReader(f1);
            StreamWriter s2 = new StreamWriter(f2);
            string res = s1.ReadLine();
            while(res!=null)
            {
                s2.WriteLine(res);
                Console.WriteLine(res);
                res = s1.ReadLine();
            }
            s1.Close();
            s2.Close();
            f1.Close();
            f2.Close();

                        //reading writing bjects using strings(not objcet serializaion)


using System.IO;

namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            string cgpa, age;
            FileStream f = new FileStream("file.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            for(int i=0;i<2;i++)
            {
                Console.WriteLine("Input cgpa");
                cgpa = Console.ReadLine();
                Console.WriteLine("Input age");
                age = Console.ReadLine();
                sw.WriteLine($"{cgpa}, {age}");
            }
            sw.Close();
            f.Close();
            FileStream f1 = new FileStream("file.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);
            string fileData = sr.ReadLine();
            while(fileData != null)
            {
                Console.WriteLine("Person's data");
                string[] personData = fileData.Split(",");
                foreach(string i in personData)
                {
                    Console.WriteLine(i);
                }
                fileData = sr.ReadLine();
            }
            sr.Close();
            f1.Close();
            
        }
    }
}

                      //reading writing objects using strings by class functions(not objcet serializaion)
//person.cs
using System;
using System.Collections.Generic;
using System.IO;
namespace ConsoleApp3
{
    public class Person
    {
        private int age;
        private int cgpa;

        public int Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public override string ToString()
        {
            return $"Cgpa: {this.cgpa} , Age: {this.age}";
        }
        
        public void WritePersons(List<Person> p)
        {
            StreamWriter sw = new StreamWriter("file.txt",append:true);
            foreach(Person person in p)
            {
                sw.WriteLine($"{person.cgpa},{person.age}");
            }
            sw.Close();
        }
        public List<Person> PrintPersonsToConsole()
        {
            List<Person> p = new List<Person>();
            StreamReader sr = new StreamReader("file.txt");
            string s = string.Empty;
            while((s=sr.ReadLine())!=null)
            {
                string[] data = s.Split(",");
                Int32.TryParse(data[0], out int c);
                Int32.TryParse(data[1], out int z);
                p.Add(new Person() {cgpa = c , age = z });
            }
            sr.Close();
            return p;
        }
    }
}


//main file program.cs
using System;
using ConsoleApp3;
using System.IO;
using System.Collections.Generic;

namespace linked
{
    class Program
    {
        static void Main(string[] args)
        {
            string cgpa, age;
            List<Person> p = new List<Person>();
            for (int i=0;i<2;i++)
            {
                Console.WriteLine("Input cgpa");
                cgpa = Console.ReadLine();
                Console.WriteLine("Input age");
                age = Console.ReadLine();
                p.Add(new Person(){
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
