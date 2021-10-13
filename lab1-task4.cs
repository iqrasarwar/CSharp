using System;

namespace task4
{
    class Customer
    {
        public string CustomerId;
        public string Name;
        public double Units;

        public double CalculateBill()
        {
            double BillToPay;
            if( Units <= 199)
            {
                BillToPay = 1.20 * Units;
            }
            else if(Units < 400)
            {
                BillToPay = 1.50 * Units;
            }
            else if (Units < 600)
            {
                BillToPay = 1.80 * Units;
            }
            else
            {
                BillToPay = 2.00 * Units;
            }

            if (BillToPay < 100)
                BillToPay = 100;
            if(BillToPay>400)
            {
                double SurCharge = 0.15 * BillToPay;
                BillToPay += SurCharge;
            }
            return BillToPay;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tCalulating bill");
            Console.WriteLine("Enter customer id");
            string id = Console.ReadLine();
            Console.WriteLine("Enter customer name");
            string name = Console.ReadLine();
            Console.WriteLine("enter units consumed:");
            string units = Console.ReadLine();
            Customer obj = new Customer
            {
                CustomerId = id,
                Name = name,
                Units = Convert.ToDouble(units)
            };
            double bill = obj.CalculateBill();
            Console.WriteLine($"Bill is = {bill}");
        }
    }
}
