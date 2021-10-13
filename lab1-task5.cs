using System;
using System.IO;

namespace console
{
    
    class Program
    {
        static void Main(String[] args)
        {
            FileStream f = new FileStream("file.txt", FileMode.Create);
            f.WriteByte((byte)'A');
            f.WriteByte((byte)'B');
            f.Close();
            FileStream f1 = new FileStream("file.txt", FileMode.Open);
            Console.WriteLine((char)f1.ReadByte());
            Console.WriteLine((char)f1.ReadByte());
            f1.Close();
        }
    }
}

