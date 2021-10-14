
using System;
using ConsoleApp3;
using System.Collections.Generic;
namespace linked
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string n1 = "iqra sarwar";
            string n3 = "amna azam";
            string n2 = "nimra haq";
            double val = 12.7;
            string data = string.Format(
                format: "we are {0}, {1}, {2}.",
                arg0: n1,
                arg1: n2,
                arg2: n3);
            Console.WriteLine(data);
            data = string.Format(
                format: "{0}, {1}, {2}.",
                arg0: n1,
                arg1: val,
                arg2: n3);
            Console.WriteLine(data);
            //:c will print numeric value in currrency of sys
            data = string.Format(
                format: "{0}, {1:c}, {2}.",
                arg0: n1,
                arg1: val,
                arg2: n3);
            Console.WriteLine(data);
            data = string.Format(
                format: "   {0}, {1:c}, {2}.",
                arg0: n1,
                arg1: val,
                arg2: n3);
            Console.WriteLine(data);
            //{a,b} b here align to left or right by adding spaces, 10 will add 10 spaces to right and -10 to left.
            //but it is only working for numeric data not strings.
            data = string.Format(
                format: "   {0}, {1,10}, {2,10}.",
                arg0: n1,
                arg1: n2,
                arg2: val);
            Console.WriteLine(data);
        }
    }
}
