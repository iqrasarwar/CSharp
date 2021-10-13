                    
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

