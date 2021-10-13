using System;

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
        public void test(int x, ref int y, out int z, out string c)
        {
            z = 0;
            x++;
            y++;
            z++;
            c = "iqra";
        }
    }
}
