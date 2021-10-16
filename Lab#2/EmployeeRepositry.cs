
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using Employe;
using System.Linq;

namespace EmployeRepository
{
    public class EmployeeRepository
    {
        private List<Employee> emp;
        static int count = 1;

        public EmployeeRepository()
        {
            emp = new List<Employee>();
        }
        //public List<Employee> Emp
        //{
        //    get { return emp; }
        //    set { emp = value; }
        //}

        public void AddEmployee(Employee e)
        {
            e.Id = EmployeeRepository.count;
            emp.Add(e);
            EmployeeRepository.count++;
        }

        public void DeleteEmployee(int id)
        {
            for(int i =0; i < emp.Count();i++)
            {
                if(i < emp.Count())
                {
                    if (emp[i].Id == id)
                    {
                        emp.Remove(emp[i]);
                    }
                }
            }
        }

        public void UpdateEmployee(int id)
        {
            foreach (Employee e in emp)
            {
                if (e.Id == id)
                {
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Update Name:");
                    e.Name = Console.ReadLine();
                    Console.WriteLine("update Salary:");
                    e.Salary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("update dapartment:");
                    e.Department = Console.ReadLine();
                    Console.WriteLine(e.ToString());
                }
            }
        }

        public void SearchEmployee(int id)
        {
            foreach (Employee e in emp)
            {
                if (e.Id == id)
                {
                    Console.WriteLine(e.ToString());
                    //string dat = string.Format(
                    //    format: "Employee Name: {0} \n Employee Department: {1} \n Employee Salary: {2}",
                    //    arg0: e.Name,
                    //    arg1: e.Department,
                    //    arg2: e.Salary
                    //);
                    //string dat1 = string.Format(
                    //    format: "Employee Id: {0}",
                    //    arg0: e.Id
                    //);
                    //Console.WriteLine(dat1);
                    //Console.WriteLine(dat);
                }
            }
        }

        public string CalculateTax(int id,out double tax)
        {
            tax = 0;
            foreach (Employee e in emp)
            {
                tax = (e.TaxPercentage / 100) * e.Salary;
                if (e.Id == id)
                {
                    return $"Tax amount is {tax}";
                }
            }
            return "Emp not found";
        }

        public void SaveEmployeeInfoToFile()
        {
            StreamWriter sw = new StreamWriter("emp.txt");
            foreach(Employee e in emp)
            {
                sw.WriteLine(JsonSerializer.Serialize<Employee>(e));
            }
            sw.Close();
        }
        public List<Employee> ReadEmployeeInfoFromFile()
        {
            StreamReader sr = new StreamReader("emp.txt");
            string read = string.Empty;
            List<Employee> Elist = new List<Employee>();
            while((read = sr.ReadLine()) != null)
            {
                Elist.Add(JsonSerializer.Deserialize<Employee>(read));
            }
            sr.Close();
            return Elist;
        }

        public void DisplayEmployeeInformation()
        {
           foreach(Employee e in emp)
            {
               Console.WriteLine(e.ToString());
            }
        }
        static void Main(string[] args)
        {
            Employee e = new Employee("iqra", 100000, "it");
            Employee e1 = new Employee("iqra1", 1000, "it");
            EmployeeRepository erep = new EmployeeRepository();
            erep.AddEmployee(e);
            Console.WriteLine("Added:");
            erep.DisplayEmployeeInformation();
            Console.WriteLine("Added:");
            erep.AddEmployee(e1);
            //erep.DisplayEmployeeInformation();
            //erep.SaveEmployeeInfoToFile();
            //Console.WriteLine("Searched:");
            //erep.SearchEmployee(e1.Id);
            //Console.WriteLine("Updating following record:");
            //erep.UpdateEmployee(e1.Id);
            //erep.DisplayEmployeeInformation();
            //Console.WriteLine("Tax Calculation:");
            //Console.WriteLine(erep.CalculateTax(e.Id, out double tax));
            //List<Employee> elist = erep.ReadEmployeeInfoFromFile();
            //Console.WriteLine("Read from file:");
            //foreach (Employee em in elist)
            //{
            //    Console.WriteLine(em.ToString());
            //}
            erep.DisplayEmployeeInformation();
            Console.WriteLine("after deleting 1");
            erep.DeleteEmployee(e1.Id);
            erep.DisplayEmployeeInformation();
            Console.WriteLine("after deleting 2");
            erep.DeleteEmployee(e.Id);
            erep.DisplayEmployeeInformation();
        }
    }
    
}
