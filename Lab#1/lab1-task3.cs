using System;

namespace task3
{
    class Program
    {
        public static float calculateGPA(params int[] marks )
        {
            var len = marks.Length;
            int sum = 0,
                i = 0;
            while (len > 0)
            {
                sum += marks[i];
                i++;
                len--;
            }
            return (sum/i);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(calculateGPA(8, 2, 5));
            Console.WriteLine(calculateGPA(8, 2));
        }
    }
}
