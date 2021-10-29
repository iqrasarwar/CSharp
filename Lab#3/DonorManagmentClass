
using DonationRepo;
using Donor;
using System;
namespace DonationManagment
{
    public class DonationClassManagment
    {
        //a static repo obj --> now all the data of BDMS will be stored in this class level obj --> no need to make its func static if we make its obj static.
        private static DonationRepositry repo = new DonationRepositry();
        
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
            Console.WriteLine("Enter email");
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

        public static void DisplayMenu()
        {
            
            string choice;  //  record what user choose to execute
            int loop = 0;   //loop control variable
            //Loop executes until user chooses to exit by pressing 7
            do
            {
                Console.WriteLine("<------------------------Welcome to BDMS----------------------->");
                Console.Write("1. Add Donor\n2. Update Donor\n3. Delete Donor\n4. Display Donor Info\n5. Search Donor\n6. Donate Blood\n7. Exit BDMS\nYour Choice:");
                choice = "";
                //loop executes until user enter choice
                do
                {
                    choice = Console.ReadLine();
                } while (choice == "");
                loop = 0;
                //Adding Donor
                if (choice == "1")
                {
                    donor d = makeObj();
                    repo.AddNewDonor(d);
                }
                //update donor
                else if (choice == "2")
                {
                    Console.WriteLine("\tUpdating");
                    repo.UpdateDonorInformation(inputId(),makeObj());
                }
                //Delete donor
                else if (choice == "3")
                {
                    repo.DeleteDonor(inputId());
                }
                //display all donors
                else if (choice == "4")
                {
                    repo.DisplayAllDonorsInformation();
                }
                //search donor
                else if (choice == "5")
                {
                    int error = 0;
                    Console.Write("Enter Donor Name:");
                    string Name = "";
                    do
                    {                                     //loop exectutes until user enters a valid name string
                        Name = Console.ReadLine();
                    } while (Name == "");
                    Console.Write("Enter Age:");
                    int ageofDonor = 0;
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
                    Console.Write("Enter BloodGroup:");
                    string bld_grp = "";
                    do
                    {                                     //loop exectutes until user enters a valid bld grp string
                        bld_grp = Console.ReadLine();
                    } while (bld_grp == "");
                    repo.SearchDonor(inputId(), Name, bld_grp, ageofDonor);
                }
                //donate if possible
                else if (choice == "6")
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
                    repo.DonateBlood(Name,bld_grp);
                }
                //exit
                else if (choice == "7")
                {
                    loop = 1;
                    Console.WriteLine("\t\t\tGoodBye, BDMS!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice!Enter a valid choice.");
                }
            } while (loop == 0);
        }
        
    }
}
