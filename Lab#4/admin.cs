using Microsoft.Data.SqlClient;
using System;
using Donor;
using DonationRepo;
using System.Collections.Generic;
using System.Data;

namespace AdminClass
{
    public class admin
    {
        SqlConnection con;
       public admin()
        {
            //initiallizing connections
            string ConStr = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(ConStr);
        }
        //these few functions are created to just avoid repetition and manage complexity

        //this function receives a string and return true if that is a valid bld grp
        private static bool isValidBloodGrp(string b)
        {
            string[] bldGps = { "A+", "B+", "O+", "A-", "B-", "O-", "AB+", "AB-", "a-", "a+", "b-", "b+", "o-", "o+", "ab-", "ab+", "Ab-", "Ab+", "aB-", "aB+" };
            foreach (string bld in bldGps)
            {
                if (bld == b)
                    return true;
            }
            Console.WriteLine("Enter a valid bloodgrp!\n");
            return false;
        }
        //this function takes input from user with all boundary checks for invalid inputs
        private static donor makeObj()
        {
            Console.Write("Enter Donor Name:");
            string Name = "";
            do
            {                                     //loop exectutes until user enters a valid name string
                Name = Console.ReadLine();
            } while (Name == "");
            Console.Write("Enter Age:");
            int ageofDonor = 0;
            int error = 0;
            do
            {                                           //loop exectutes until user enters a valid age in int is entered
                error = 0;
                string Age = Console.ReadLine();
                if (Int32.TryParse(Age, out ageofDonor))
                {
                    error = 1;
                }
                else
                {
                    Console.Write("Enter a valid Age!");
                }
            } while (error == 0);
            Console.Write("is blood donated?0/1: ");
            string is_donated = "";
            bool isDonated = false;
            do
            {                                           //loop exectutes until user enters a input
                is_donated = Console.ReadLine();
            } while (is_donated != "1" && is_donated != "0");
            if (is_donated == "1")
                isDonated = true;
            Console.Write("Enter BloodGroup:");
            string bld_grp = "";
            do
            {                                     //loop exectutes until user enters a valid bld grp string
                bld_grp = Console.ReadLine();
            } while (!isValidBloodGrp(bld_grp));
            Console.Write("Enter phone:");
            long Phone = 0;
            do
            {                                           //loop exectutes until user enters a valid phone in long is entered
                error = 0;
                string Age = Console.ReadLine();
                if (Int64.TryParse(Age, out Phone))
                {
                    error = 1;
                }
                else
                {
                    Console.Write("Enter a valid phone Number!");
                }
            } while (error == 0);
            Console.Write("Enter email:");
            string email = Console.ReadLine();
            donor don = new donor(Name, ageofDonor, bld_grp, isDonated, Phone, email);
            return don;
        }
        //this function takes id with validation check
        private static int inputId()
        {
            Console.Write("Enter ID:");
            string Id;
            int error = 0, id = 0;
            do
            {                                           //loop exectutes until user enters a valid id in int
                Id = Console.ReadLine();
                error = 0;
                if (Int32.TryParse(Id, out id))
                {
                    error = 1;

                }
                else
                {
                    Console.WriteLine("Enter a valid ID!");
                }
            } while (error == 0);
            return id;
        }

        public bool validateAdmin(string name, string password)
        {
            con.Open();
            string query = $"Select * FROM Admin where Name = @name and Password = @password";
            SqlParameter p1 = new SqlParameter("name", name);
            SqlParameter p2 = new SqlParameter("password", password);
            SqlCommand com = new SqlCommand(query, con);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            SqlDataReader dr = com.ExecuteReader();
            int read = 0;
            while (dr.Read())
            {
                if ((string)dr[1] == name && (string)dr[2] == password)
                {
                    read = 1;
                    Console.WriteLine("\nLogin Successful!\n");
                    con.Close();
                    return true;
                }
            }
            if (read == 0)
            {
                Console.WriteLine("\nInvalid Username & password!\n");
                con.Close();
                return false;
            }
            con.Close();
            return false;
        }
        public string DisplayAdminMenu()
        {
            string choice = "";  //  record what user choose to execute
            int loop = 0;   //loop control variable
            //Loop executes until user chooses to exit by pressing 7
            do
            {
                Console.WriteLine("<------------------------Welcome Admin----------------------->");
                Console.Write("1. Add\n2. Update\n3. Delete Donors\n4. DonateBlood\n5. GetAllDonorsInformation\n6. viewDonationReport\n7. GetDonorTableInMemory\n8. StoreRecordsToInMemoryTable\n9. Return To Main Menu\nYour Choice:");
                choice = "";
                //loop executes until user enter choice
                do
                {
                    choice = Console.ReadLine();
                } while (choice == "");
                loop = 0;
                if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7" || choice == "8" || choice == "9")
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Invalid choice!Enter a valid choice.");
                }
            } while (loop == 0);
            return choice;
        }
        public void addDonor()
        {
            donor d = makeObj();
            DonationRepositry.AddNewDonor(d);
        }
        public void deleteDonor()
        {
            DonationRepositry.DeleteDonor(inputId());
        }
        public void updateDonor()
        {
            Console.WriteLine("\tUpdating");
            DonationRepositry.UpdateDonorInformation(inputId(), makeObj());
        }
        public List<donor> GetAllDonorInformation()
        {
            con.Open();
            List<donor> list = new List<donor>();
            string query = $"Select * FROM Donor";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                donor d = new donor((int)dr[0], (string)dr[1], (int)dr[3], (string)dr[2], (bool)dr[4], Convert.ToInt64(dr[5]), (string)dr[6], (string)dr[7]);
                list.Add(d);
            }
            con.Close();
            return list;
        }
        public void DonateBlood()
        {
            Console.Write("Enter Receptor Name:");
            string Name = "";
            do
            {                                     //loop exectutes until user enters a valid name string
                Name = Console.ReadLine();
            } while (Name == "");
            Console.Write("Enter Receptors BloodGroup:");
            string bld_grp = "";
            do
            {                                     //loop exectutes until user enters a valid bld grp string
                bld_grp = Console.ReadLine();
            } while (!isValidBloodGrp(bld_grp));
            DonationRepositry.DonateBlood(Name, bld_grp);
        }
        public void viewDonationReport()
        {
            con.Open();
            string query = $"Select Donor.donorName, DonorInfo.ReceptorName, DonorInfo.Date, Donor.isBloodDonated FROM Donor INNER JOIN DonorInfo on Donor.id = DonorInfo.Donor_ID";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            int read = 0;
            while (dr.Read())
            {
                read = 1;
                string output = string.Format(
                    format: "\nDonorName: {0}\nReceptorName: {1}\nDate: {2}\n",
                    arg0: dr[0],
                    arg1: dr[1],
                    arg2: dr[2]
                    );
                string output1 = string.Format(
                    format: "DonorStatus: {0}\n",
                    arg0: dr[3]
                    );
                
                Console.WriteLine(output + output1);
            }
            if (read == 0)
            {
                Console.WriteLine("No RECORD FOUND");
            }
            con.Close();
        }
        public DataTable GetDonorTableInMemory()
        {
            DataTable dt = new DataTable("Donor");
            DataColumn id = new DataColumn("id");
            DataColumn name = new DataColumn("name");
            DataColumn donorBloodGroup = new DataColumn("bloodgroup");
            DataColumn donorAge = new DataColumn("age");
            DataColumn isBloodDonated = new DataColumn("isblooddonated");
            DataColumn donorPhone = new DataColumn("phone");
            DataColumn registrationDate = new DataColumn("date");
            DataColumn donorEmail = new DataColumn("mail");

            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            dt.Columns.Add(id); 
            dt.Columns.Add(name);
            dt.Columns.Add(donorBloodGroup);
            dt.Columns.Add(donorAge);
            dt.Columns.Add(isBloodDonated);
            dt.Columns.Add(donorPhone);
            dt.Columns.Add(registrationDate);
            dt.Columns.Add(donorEmail);

            DataSet bdms = new DataSet();
            bdms.Tables.Add(dt);
            Console.WriteLine("Table Added!");
            return dt;
        }
        public void StoreRecordsToInMemoryTable(DataTable dr)
        {
            List<donor> list = new List<donor>();
            list = GetAllDonorInformation();
            foreach(donor d in list)
            {
                DataRow drow = dr.NewRow();
                drow["id"] = d.Id;
                drow["name"] = d.DonorName;
                drow["bloodgroup"] = d.DonorBloodGroup;
                drow["age"] = d.DonorAge;
                drow["phone"] = d.DonorPhone;
                drow["mail"] = d.Email;
                drow["isblooddonated"] = d.IsBloodDonated;
                drow["date"] = d.RegistrationDate;
                dr.Rows.Add(drow);
            }
            foreach (DataRow r in dr.Rows)
            {
                Console.WriteLine($"Donor {r[1]} with bloodgroup {r[2]}.");
            }
        }
    }
}
