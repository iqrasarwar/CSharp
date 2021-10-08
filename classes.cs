class myClass
    {
        public string name;
        public int age;
        public static string rollno;

        public string getname()
        {
            return name;
        }
        public string getRollno()
        {
            return rollno;
        }
        public int getAge()
        {
            return age;
        }
        public static void setrollno(string roll) => rollno = roll;
    };
    
    class Program
    {
        static void Main(string[] args)
        {
            myClass obj= new myClass();
            myClass.setrollno("bsef19m012");
            Console.WriteLine(obj.getRollno());
        }
    }
