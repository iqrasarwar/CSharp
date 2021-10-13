using System;

namespace Task2
{
    class Program
    {
        public static void sendEmail(String Message, string to, String cc = "", bool attachment = false)
        {
            Console.WriteLine("{0} {1}", Message, to);
        }
        static void Main(string[] args)
        {
            sendEmail("This is message", "to abc@gmail.com.");
        }
    }
}
