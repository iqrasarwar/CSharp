using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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
        [JsonIgnore] //to ignore it while serializing
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
            StreamWriter sw = new StreamWriter("file.txt");
            foreach (Person person in p)
            {
                sw.WriteLine(JsonSerializer.Serialize(person));
            }
            sw.Close();
        }
        public List<Person> PrintPersonsToConsole()
        {
            List<Person> p = new List<Person>();
            StreamReader sr = new StreamReader("file.txt");
            string s = string.Empty;
            while ((s = sr.ReadLine()) != null)
            {
                Person per = JsonSerializer.Deserialize<Person>(s);
                p.Add(per);
            }
            sr.Close();
            return p;
        }
    }
}
