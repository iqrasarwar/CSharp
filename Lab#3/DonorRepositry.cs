
using Donor;
using Microsoft.Data.SqlClient;
using DonorInfo;
using System;
namespace DonationRepo
{
    public class DonationRepositry
    {
        SqlConnection con,con1;
        /* Two connections were reuired bz we need con for data reder and executenonreader in donaton function
         * According to MSDN
         * Note that while a DataReader is open, the Connection is in use exclusively by that DataReader.
         * You cannot execute any commands for the Connection, including creating another DataReader, until the original DataReader is closed*/
        public DonationRepositry()
        {
            //initiallizing connections
            string ConStr = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=BDMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(ConStr);
            con1 = new SqlConnection(ConStr);
        }
        public void AddNewDonor(donor d)
        {
            con.Open();
            string query = $"INSERT INTO Donor(donorName, donorBloodGroup, donorAge, isBloodDonated, donorPhone, registrationDate, donorEmail) " +
                $"VALUES('{d.DonorName}', '{d.DonorBloodGroup}', '{d.DonorAge}', '{d.IsBloodDonated}', '{d.DonorPhone}', '{d.RegistrationDate}', '{d.Email}')";
            SqlCommand com = new SqlCommand(query, con);
            int val = com.ExecuteNonQuery();
            if (val >= 1)
                Console.WriteLine("row inserted\n");
            else
                Console.WriteLine("insertion failed\n");
            con.Close();

        }
        public void UpdateDonorInformation(int idd, donor d)
        {
            con.Open();
            string query = $"UPDATE Donor SET donorName = '{d.DonorName}', donorBloodGroup = '{d.DonorBloodGroup}', donorAge = '{d.DonorAge}', isBloodDonated = '{d.IsBloodDonated}'," +
                $" donorPhone = '{d.DonorPhone}', registrationDate = '{d.RegistrationDate}', donorEmail = '{d.Email}' WHERE id = '{idd}' ";
            SqlCommand com = new SqlCommand(query, con);
            int val = com.ExecuteNonQuery();
            if (val >= 1)
                Console.WriteLine("row updated\n");
            else
                Console.WriteLine("update failed\n");
            con.Close();

        }
        public void DeleteDonor(int id)
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
        public void DisplayAllDonorsInformation()
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
        public void SearchDonor(int id, string name, string bld_grp, int age)
        {
            con.Open();
            string query = $"SELECT * FROM Donor WHERE id = '{id}' OR donorName = '{name}' OR donorBloodGroup = '{bld_grp}' OR donorAge = '{age}' ";
            SqlCommand com = new SqlCommand(query, con);
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
        private bool canDonate(object dr, string bldgrp)
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
        public void DonateBlood(string name, string bldgrp)
        {
            con.Open();
            bool status = false;
            //get all donors who can donate blood and have nott donated before
            string query = $"Select id, donorBloodGroup FROM Donor WHERE isBloodDonated = '{status}'";
            SqlCommand com = new SqlCommand(query, con);
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
                query = $"UPDATE Donor SET isBloodDonated = '{status}' WHERE id = '{dr[0]}' ";
                com = new SqlCommand(query, con1);
                int val = com.ExecuteNonQuery();
                if (val >= 1)
                    Console.WriteLine("Donor updated\n");
                DonorInformation d = new DonorInformation(dr.GetInt32(0), name);
                //record donation in donorinfo  table having record of donations
                query = $"INSERT INTO DonorInfo(Donor_Id, ReceptorName,Date) VALUES('{d.DonorId}', '{d.ReceptorName}', '{d.Date}')";
                com = new SqlCommand(query, con1);
                val = com.ExecuteNonQuery();
                if (val >= 1)
                    Console.WriteLine("DonorInfo updated\n");
            }
            con1.Close();
            con.Close();
        }
    }
}

