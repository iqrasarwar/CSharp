using Donor;
using AdminClass;
using System;
using System.Collections.Generic;

namespace DonationManagment
{
    public class DonationClassManagment
    {
        static admin obj = new admin();
        public static void DisplayMenu()
        {
            
            string choice;  //  record what user choose to execute
            int loop = 0;   //loop control variable
            //Loop executes until user chooses to exit by pressing 7
            do
            {
                Console.WriteLine("<------------------------Welcome to BDMS----------------------->");
                Console.Write("1. Admin Login\n2. View Donors Info\n3. Exit BDMS\nYour Choice:"); 
                choice = "";
                string choice1 = "";
                //loop executes until user enter choice
                do
                {
                    choice = Console.ReadLine();
                } while (choice == "");
                loop = 0;
                if (choice == "1")
                {
                    Console.WriteLine("Enter Admin Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string password = Console.ReadLine();
                    if(obj.validateAdmin(name,password))
                    {
                        int loop1 = 0;
                        do
                        {
                            loop1 = 0;
                            choice1 = obj.DisplayAdminMenu();
                            if (choice1 == "1")
                            {
                                obj.addDonor();
                            }
                            else if (choice1 == "2")
                            {
                                obj.updateDonor();
                            }
                            else if (choice1 == "3")
                            {
                                obj.deleteDonor();
                            }
                            else if (choice1 == "4")
                            {
                                obj.DonateBlood();
                            }
                            else if (choice1 == "5")
                            {
                                List<donor> l = obj.GetAllDonorInformation();
                                foreach (donor d in l)
                                {
                                    Console.WriteLine(d.ToString());
                                }
                            }
                            else if (choice1 == "6")
                            {
                                obj.viewDonationReport();
                            }
                            else if (choice1 == "7")
                            {
                                obj.GetDonorTableInMemory();
                            }
                            else if (choice1 == "8")
                            {
                                obj.StoreRecordsToInMemoryTable(obj.GetDonorTableInMemory());
                            }
                            else if (choice1 == "9")
                            {
                                loop1 = 1;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Inavlid Choice");
                            }
                        } while (loop1 != 1);
                    }
                }
                else if (choice == "2")
                {
                    List<donor> l = obj.GetAllDonorInformation();
                    foreach(donor d in l)
                    {
                       Console.WriteLine(d.ToString());
                    }
                }
                else if (choice == "3")
                {
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
