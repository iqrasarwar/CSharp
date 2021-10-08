                    
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
