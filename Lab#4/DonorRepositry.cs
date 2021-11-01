using Donor;
using Microsoft.Data.SqlClient;
using DonorInfo;
using System;

namespace DonationRepo
{
    public class DonationRepositry
    {
        private static SqlConnection con = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private static SqlConnection con1 = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        /* Two connections were reuired bz we need con for data reder and executenonreader in donaton function
         * According to MSDN
         * Note that while a DataReader is open, the Connection is in use exclusively by that DataReader.
         * You cannot execute any commands for the Connection, including creating another DataReader, until the original DataReader is closed*/
        public static void AddNewDonor(donor d)
        {
            con.Open();
            string query = $"INSERT INTO Donor(donorName, donorBloodGroup, donorAge, isBloodDonated, donorPhone, registrationDate, donorEmail) " +
                $"VALUES(@name, @bldGrp, @age, @status, @phone, @date, @email)";
            SqlParameter p1 = new SqlParameter("name", d.DonorName);
            SqlParameter p2 = new SqlParameter("bldGrp", d.DonorBloodGroup);
            SqlParameter p3 = new SqlParameter("age", d.DonorAge);
            SqlParameter p4 = new SqlParameter("status", d.IsBloodDonated);
            SqlParameter p5 = new SqlParameter("phone", d.DonorPhone);
            SqlParameter p6 = new SqlParameter("date", d.RegistrationDate);
            SqlParameter p7 = new SqlParameter("email", d.Email);

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            com.Parameters.Add(p7);
            int val = com.ExecuteNonQuery();
            if (val >= 1)
                Console.WriteLine("row inserted\n");
            else
                Console.WriteLine("insertion failed\n");
            con.Close();

        }
        public static void UpdateDonorInformation(int idd, donor d)
        {
            con.Open();
            string query = $"UPDATE Donor SET donorName = @name, donorBloodGroup = @bldGrp, donorAge = @age, isBloodDonated = @status," +
                $" donorPhone = @phone, registrationDate = @date, donorEmail = @email WHERE id = @idd ";
            SqlParameter p1 = new SqlParameter("name", d.DonorName);
            SqlParameter p2 = new SqlParameter("bldGrp", d.DonorBloodGroup);
            SqlParameter p3 = new SqlParameter("age", d.DonorAge);
            SqlParameter p4 = new SqlParameter("status", d.IsBloodDonated);
            SqlParameter p5 = new SqlParameter("phone", d.DonorPhone);
            SqlParameter p6 = new SqlParameter("date", d.RegistrationDate);
            SqlParameter p7 = new SqlParameter("email", d.Email);
            SqlParameter p8 = new SqlParameter("idd", idd);

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            com.Parameters.Add(p5);
            com.Parameters.Add(p6);
            com.Parameters.Add(p7);
            com.Parameters.Add(p8);
            int val = com.ExecuteNonQuery();
            if (val >= 1)
                Console.WriteLine("row updated\n");
            else
                Console.WriteLine("update failed\n");
            con.Close();

        }
        public static void DeleteDonor(int id)
        {
            con.Open();
            string query = $"DELETE FROM Donor WHERE id = '{id}' ";
            SqlCommand com = new SqlCommand(query, con);
            int val = com.ExecuteNonQuery();
            if (val >= 1)
                Console.WriteLine("row deleted\n");
            else
                Console.WriteLine("deletion failed\n");
            con.Close();
        }
        public static void DisplayAllDonorsInformation()
        {
            con.Open();
            string query = $"Select * FROM Donor";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            int read = 0;
            while (dr.Read())
            {
                read = 1;
                string output = string.Format(
                    format: "\nDonorId: {0}\nDonorName: {1}\nDonorBloodGroup: {2}\n",
                    arg0: dr[0],
                    arg1: dr[1],
                    arg2: dr[2]
                    );
                string output1 = string.Format(
                    format: "DonorAge: {0}\nDonorStatus: {1}\nDonorPhone: {2}\n",
                    arg0: dr[3],
                    arg1: dr[4],
                    arg2: dr[5]
                    );
                string output2 = string.Format(
                    format: "RegistrationDate: {0}\nDonorEmail: {1}\n",
                    arg0: dr[6],
                    arg1: dr[7]
                    );
                Console.WriteLine(output + output1 + output2);
            }
            if (read == 0)
            {
                Console.WriteLine("No RECORD FOUND");
            }
            con.Close();
        }
        public static void SearchDonor(int id, string name, string bld_grp, int age)
        {
            con.Open();
            string query = $"SELECT * FROM Donor WHERE id = @idd OR donorName = @name OR donorBloodGroup = @bldGrp OR donorAge = @age ";
            SqlParameter p1 = new SqlParameter("idd", id);
            SqlParameter p2 = new SqlParameter("name", name);
            SqlParameter p3 = new SqlParameter("bldGrp", bld_grp);
            SqlParameter p4 = new SqlParameter("age", age);

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            com.Parameters.Add(p3);
            com.Parameters.Add(p4);
            SqlDataReader dr = com.ExecuteReader();
            int found = 0;
            while (dr.Read())
            {
                found = 1;
                string output = string.Format(
                    format: "DonorId: {0}\nDonorName: {1}\nDonorBloodGroup: {2}\n",
                    arg0: dr[0],
                    arg1: dr[1],
                    arg2: dr[2]
                    );
                string output1 = string.Format(
                    format: "DonorAge: {0}\nDonorStatus: {1}\nDonorPhone: {2}\n",
                    arg0: dr[3],
                    arg1: dr[4],
                    arg2: dr[5]
                    );
                string output2 = string.Format(
                    format: "RegistrationDate: {0}\nDonorEmail: {1}\n",
                    arg0: dr[6],
                    arg1: dr[7]
                    );
                Console.WriteLine(output + output1 + output2);
            }
            if (found == 0)
                Console.WriteLine("No donor found!\n");
            con.Close();
        }
        //this  is a helper function i created to avoid overcomplexing donation function
        //this function compare all possibilties of receptor bld grp and available donor bld grps and returns as soon as founds one.
        private static bool canDonate(object dr, string bldgrp)
        {
            if (dr is "A+" or "a+")
            {
                if (bldgrp is "A+" or "AB+" or "a+" or "ab+" or "Ab+" or "aB+")
                {
                    return true;
                }
            }
            else if (dr is "O+" or "o+")
            {
                if (bldgrp is "A+" or "AB+" or "a+" or "ab+" or "Ab+" or "aB+" or "o+" or "O+" or "b+" or "B+")
                {
                    return true;
                }
            }
            else if (dr is "b+" or "B+")
            {
                if (bldgrp is "AB+" or "ab+" or "Ab+" or "aB+" or "b+" or "B+")
                {
                    return true;
                }
            }
            else if (dr is "AB+" or "ab+" or "Ab+" or "aB+")
            {
                if (bldgrp is "AB+" or "ab+" or "Ab+" or "aB+")
                {
                    return true;
                }
            }
            else if (dr is "a-" or "A-")
            {
                if (bldgrp is "A+" or "AB+" or "a+" or "ab+" or "Ab+" or "aB+" or "A-" or "AB-" or "a-" or "ab-" or "Ab-" or "aB-")
                {
                    return true;
                }
            }
            else if (dr is "b-" or "B-")
            {
                if (bldgrp is "B+" or "AB+" or "b+" or "ab+" or "Ab+" or "aB+" or "B-" or "AB-" or "b-" or "ab-" or "Ab-" or "aB-")
                {
                    return true;
                }
            }
            else if (dr is "AB-" or "ab-" or "Ab-" or "aB-")
            {
                if (bldgrp is "AB+" or "ab+" or "Ab+" or "aB+" or "AB-" or "ab-" or "Ab-" or "aB-")
                {
                    return true;
                }
            }
            else if (dr is "o-" or "O-")
            {
                return true;
            }
            return false;
        }
        public static void DonateBlood(string name, string bldgrp)
        {
            con.Open();
            bool status = false;
            //get all donors who can donate blood and have nott donated before
            string query = $"Select id, donorBloodGroup FROM Donor WHERE isBloodDonated = @status";
            SqlParameter p4 = new SqlParameter("status", status);

            SqlCommand com = new SqlCommand(query, con);

            com.Parameters.Add(p4);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                //check if any of available donor can donate to receptor if any break 
                if (canDonate(dr[1], bldgrp))
                {
                    status = true;
                    break;
                }
            }
            if (status == false)
                Console.WriteLine("No DONOR FOUND!\n");
            else
            {
                con1.Open();
                //update donor status to donated
                query = $"UPDATE Donor SET isBloodDonated = @stat WHERE id = @idi ";
                SqlParameter p3 = new SqlParameter("stat", status);
                SqlParameter p2 = new SqlParameter("idi", dr[0]);
                com = new SqlCommand(query, con1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                
                int val = com.ExecuteNonQuery();
                if (val >= 1)
                    Console.WriteLine("Donor updated\n");
                DonorInformation d = new DonorInformation(dr.GetInt32(0), name);
                //record donation in donorinfo  table having record of donations
                query = $"INSERT INTO DonorInfo(Donor_Id, ReceptorName, Date) VALUES(@ids, @nme, @datee)";
                SqlParameter p0 = new SqlParameter("ids", d.DonorId);
                SqlParameter p1 = new SqlParameter("nme", d.ReceptorName);
                SqlParameter p = new SqlParameter("datee", d.Date);
                com = new SqlCommand(query, con1);
                com.Parameters.Add(p);
                com.Parameters.Add(p0);
                com.Parameters.Add(p1);
                val = com.ExecuteNonQuery();
                if (val >= 1)
                    Console.WriteLine("DonorInfo updated\n");
            }
            con1.Close();
            con.Close();
        }
        
    }
}

