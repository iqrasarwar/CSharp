                                                          //input and output
            //output
            Console.WriteLine("what's your name?");
            //input
            string name = Console.ReadLine();
            //output
            Console.WriteLine("what's your age?");
            //input
            string age = Console.ReadLine();
            //output
            Console.WriteLine("what's your cgpa?");
            //input
            string cgpa = Console.ReadLine();
            //interpolation string
            Console.WriteLine($"{name} you are {age} years old with cgpa {cgpa}.");
            //output
            Console.WriteLine("my name is {0} and this is {1}", "iqra", "csharp");//output is "my name is iqra and this is csharp"
            
                                                                      //numeric data types
            //byte
            Console.WriteLine(Byte.MaxValue);//255
            Console.WriteLine(Byte.MinValue);//0
            //sbyte
            Console.WriteLine(SByte.MaxValue);//127
            Console.WriteLine(SByte.MinValue);//-128
            //short
            Console.WriteLine(Int16.MaxValue);//32767
            Console.WriteLine(Int16.MinValue);//-32768
            //ushort
            Console.WriteLine(UInt16.MaxValue);//65535
            Console.WriteLine(UInt16.MinValue);//0
            //int
            Console.WriteLine(Int32.MaxValue);//2147483647
            Console.WriteLine(Int32.MinValue);//-2147483648
            //uint
            Console.WriteLine(UInt32.MaxValue);//4294967295
            Console.WriteLine(UInt32.MinValue);//0
            //long
            Console.WriteLine(Int64.MaxValue);//9223372036854775807
            Console.WriteLine(Int64.MinValue);//-9223372036854775808
            //ulong
            Console.WriteLine(UInt64.MaxValue);//18446744073709551615
            Console.WriteLine(UInt64.MinValue);//0
            //double
            Console.WriteLine(Double.MaxValue);
            Console.WriteLine(Double.MinValue);
            //float
            Console.WriteLine(float.MaxValue);
            Console.WriteLine(float.MinValue);
            //decimal
            Console.WriteLine(Decimal.MaxValue);
            Console.WriteLine(Decimal.MinValue);
            //scientific notation
            double d = 0.12e2;
            Console.WriteLine(d);  // 12;

            float f = 123.45e-2f;
            Console.WriteLine(f);  // 1.2345

            decimal m = 1.2e6m;
            Console.WriteLine(m);// 1200000
            /*
             * The int data type is also used for hexadecimal and binary numbers. A hexadecimal number starts with 0x or 0X prefix. C# 7.2 onwards, a binary number starts with 0b or 0B.
             * */
            int hex = 0x2F;
            int binary = 0b_0010_1111;

            Console.WriteLine(hex);
            Console.WriteLine(binary);
                                                      //strings
            string pat = "\\\\mypc\\ shared\\project";
            string path = @"\\mypc\shared\project";
            string str = @"this is a 
multi line 
string";
            Console.WriteLine(" {0} \n {1} \n {2}", pat, path, str);

            //string text = @"This is a "string." in C#."; // error
            //string text = @"This is a \"string\" in C#."; // error
            string text = "This is a \"string\" in C#."; // valid
            Console.WriteLine(text);

            string code = "007";

            Console.WriteLine($"the Code:{{{code}}}");//the code:{{007}}

                                                                //dynamic data type
            dynamic MyDynamicVar = 100;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = "Hello World!!";
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = true;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

            MyDynamicVar = DateTime.Now;
            Console.WriteLine("Value: {0}, Type: {1}", MyDynamicVar, MyDynamicVar.GetType());

                                                                 //null data type
            //if i is null assign zero to j

            int? i = null;

            int j = i ?? 0;
            Console.WriteLine(j);
