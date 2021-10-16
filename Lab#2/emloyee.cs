
using System;
using System.Collections.Generic;
namespace Employe
{
    public class Employee
    {
        private string name;
        private int id;
        private double salary;
        private string department;
        private readonly double taxPercentage = 15;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id 
        {
            get { return id; }
            set { id = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public double TaxPercentage 
        {
            get { return taxPercentage; }
        }


        public Employee(string name, double salary, string department)
        {
            
            this.name = name;
            this.department = department;
            this.salary = salary;
            double taxx = (taxPercentage / 100) * this.salary;
            this.salary -= taxx;
        }
        public override string ToString()
        {
            string dat = string.Format(
                        format: "Employee Name: {0} \nEmployee Department: {1} \nEmployee Salary: {2}",
                        arg0: this.Name,
                        arg1: this.Department,
                        arg2: this.Salary
                    );
            string dat1 = string.Format(
                format: "\nEmployee Id: {0}\n\n",
                arg0: this.Id
            );
            string f = dat + dat1;
            return f;
        }
    }
}
