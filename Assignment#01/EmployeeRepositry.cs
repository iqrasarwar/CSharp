using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Employe;
using System.Linq;

namespace EmployeRepository
{
    public class EmployeeRepository
    {
        private List<Employee> emp;
        static int count = 1;

        public List<Employee> Emp
        {
            get { return emp; }
        }

        public EmployeeRepository()
        {
            emp = new List<Employee>();
            List<Employee> e = ReadEmployeeInfoFromFile();
            if (e.Count > 0)
                count = e.Last().Id + 1;
        }

        public void AddEmployee(Employee e)
        {
            e.Id = EmployeeRepository.count;
            emp.Add(e);
            EmployeeRepository.count++;
        }

        public bool DeleteEmployee(int id)
        {
            for (int i = 0; i < emp.Count(); i++)
            {
                if (i < emp.Count())
                {
                    if (emp[i].Id == id)
                    {
                        emp.Remove(emp[i]);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool UpdateEmployee(int id)
        {
            foreach (Employee e in emp)
            {
                if (e.Id == id)
                {
                    Console.WriteLine(e.ToString());
                    Console.Write("Update Name:");
                    do
                    {
                        e.Name = Console.ReadLine();
                    } while (e.Name == "");
                    Console.Write("update Salary:");
                    double Salary;
                    int error = 0;
                    do
                    {
                        error = 0;
                        string sal = Console.ReadLine();
                        if (Double.TryParse(sal, out Salary))
                        {
                            error = 1;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid salary!");
                        }
                    } while (error == 0);
                    e.Salary = Salary;
                    Console.Write("update dapartment:");
                    do
                    {
                        e.Department = Console.ReadLine();
                    } while (e.Department == "");
                    Console.WriteLine(e.ToString());
                    return true;
                }
            }
            return false;
        }

        public Employee SearchEmployee(int id)
        {
            foreach (Employee e in emp)
            {
                if (e.Id == id)
                {
                    Console.WriteLine(e.ToString());
                    return e;
                }
            }
            return new Employee("N/A", 0, "N/A");
        }

        public string CalculateTax(int id, out double tax)
        {
            tax = 0;
            foreach (Employee e in emp)
            {
                tax = (e.TaxPercentage / 100) * e.Salary;
                if (e.Id == id)
                {
                    return $"Tax amount is {tax}\n";
                }
            }
            return "Emp not found!\n";
        }

        public void SaveEmployeeInfoToFile()
        {
            StreamWriter sw = new StreamWriter("emp.txt", append:true);
            foreach (Employee e in emp)
            {
                sw.WriteLine(JsonSerializer.Serialize<Employee>(e));
            }
            sw.Close();
        }
        public List<Employee> ReadEmployeeInfoFromFile()
        {
            List<Employee> Elist = new List<Employee>();
            if (File.Exists("emp.txt"))
            {
                StreamReader sr = new StreamReader("emp.txt");
                string read = string.Empty;
                while ((read = sr.ReadLine()) != null)
                {
                    Elist.Add(JsonSerializer.Deserialize<Employee>(read));
                }
                sr.Close();
                return Elist;
            }
            return Elist;
        }

        public void DisplayEmployeeInformation()
        {
            //i have overloaded tostring unction for ease
            foreach (Employee e in emp)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }

}
