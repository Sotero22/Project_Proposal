using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_Proposal
{
    //Users
    internal class View : User
    {
        private string passuser;
        private string filepath;
        private string details;

        public View(string filepath, string details,string passuser)
        {
            this.password = passuser;
            this.filepath = filepath;
            this.details = details;
            
        }
        public void viewappliance()
        {
            if (File.Exists(filepath))
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("|           Date          |  Appliance Name  |   Watts  |   Hours  |    kWh   | Monthly Bill |");
                Console.WriteLine("|--------------------------------------------------------------------------------------------|");
                string[] read = File.ReadAllLines(filepath);
                for (int i = 0; i < read.Length; i++)
                {
                    Console.WriteLine(read[i]);
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Press any key to return.");
            }
            else
            {
                Console.WriteLine("There is no inputed text file to view.");
            } 
        }
        public void viewaccountdetails()
        {
            Console.WriteLine("\n*=====================================*");
            if(File.Exists(details))
            {
                string[] read = File.ReadAllLines(details);
                for(int i =0;  i < read.Length; i++)
                {
                    Console.WriteLine(read[i]);
                }
            }
        }

        //Admin:

        //view users
        public void viewusers()
        {
            Console.WriteLine(@" 
--------------------------------------------------------------------------------------
 _____ _           _        _       ______ _ _ _   _____              _             
|  ___| |         | |      (_)      | ___ (_) | | |_   _|            | |            
| |__ | | ___  ___| |_ _ __ _  ___  | |_/ /_| | |   | |_ __ __ _  ___| | _____ _ __ 
|  __|| |/ _ \/ __| __| '__| |/ __| | ___ \ | | |   | | '__/ _` |/ __| |/ / _ \ '__|
| |___| |  __/ (__| |_| |  | | (__  | |_/ / | | |   | | | | (_| | (__|   <  __/ |   
\____/|_|\___|\___|\__|_|  |_|\___| \____/|_|_|_|   \_/_|  \__,_|\___|_|\_\___|_|
--------------------------------------------------------------------------------------
                                   [ADMIN SYSTEM]");
            Console.WriteLine(@"
==============================
      VIEWING ALL USERS           
==============================");

            string passuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
            if (File.Exists(passuser))
            {
                string[] read = File.ReadAllLines(passuser);
                for(int i = 0;i < read.Length; i++)
                {
                    Console.WriteLine(read[i]);
                }
            }
            else
            {
                Console.WriteLine("File is not found, Please try again.");
            }
        }

        //view user's details
        public void viewusersdetails()
        {
            bool error = false;
            bool wish = false;
            do
            {
                Console.WriteLine(@" 
--------------------------------------------------------------------------------------
 _____ _           _        _       ______ _ _ _   _____              _             
|  ___| |         | |      (_)      | ___ (_) | | |_   _|            | |            
| |__ | | ___  ___| |_ _ __ _  ___  | |_/ /_| | |   | |_ __ __ _  ___| | _____ _ __ 
|  __|| |/ _ \/ __| __| '__| |/ __| | ___ \ | | |   | | '__/ _` |/ __| |/ / _ \ '__|
| |___| |  __/ (__| |_| |  | | (__  | |_/ / | | |   | | | | (_| | (__|   <  __/ |   
\____/|_|\___|\___|\__|_|  |_|\___| \____/|_|_|_|   \_/_|  \__,_|\___|_|\_\___|_|
--------------------------------------------------------------------------------------
                                   [ADMIN SYSTEM]");
                Console.WriteLine(@"
==============================
     VIEWING USER'S DETAILS           
==============================");
                string passuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
                Console.WriteLine("\nUsers: ");
                Console.WriteLine("*-------------------------*");
                if (File.Exists(passuser))
                {
                    string[] read = File.ReadAllLines(passuser);
                    for (int i = 0; i < read.Length; i++)
                    {
                        Console.WriteLine(read[i]);
                    }
                }
                else
                {
                    Console.WriteLine("File is not found, Please try again.");
                }
                Console.WriteLine("*-------------------------*\n");

                string userdetails = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Account Details";

                if (Directory.Exists(userdetails))
                {
                    Console.Write("Who's details do you want to view: ");
                    string name = Console.ReadLine();
                    if (name.Length == 0)
                    {
                        Console.WriteLine("This part should not empty.");
                        do
                        {
                            Console.Write("Do you want to continue? [yes/no]: ");
                            string choice = Console.ReadLine();
                            if (choice == "yes" || choice == "Yes")
                            {
                                error = true;
                                wish = false;
                                Console.Clear();
                            }
                            else if (choice == "no" || choice == "No")
                            {
                                Console.WriteLine("Press any key to return.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                wish = true;
                            }
                        } while (wish);
                    }
                    else
                    {
                        string filapath = Path.Combine(userdetails, name + ".txt");
                        if (File.Exists(filapath))
                        {
                            Console.WriteLine($"\nReading details : {name}");
                            Console.WriteLine("*----------------------*");
                            string[] read = File.ReadAllLines(filapath);
                            for (int i = 0; i < read.Length; i++)
                            {
                                Console.WriteLine(read[i]);
                            }
                            Console.WriteLine("*-------------------------*");
                            do
                            {
                                Console.Write("Would you wish to continue? [yes/no]: ");
                                string choice = Console.ReadLine();
                                if (choice == "yes" || choice == "Yes")
                                {
                                    wish = true;
                                    error = true;
                                    Console.Clear();
                                }
                                else if (choice == "no" || choice == "No")
                                {
                                    Console.WriteLine("Press any key to return.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                    wish = false;
                                }
                            } while (!wish) ;

                        }
                        else
                        {
                            Console.WriteLine("File name not found, Please try again.");
                            do
                            {
                                Console.Write("Would you wish to continue? [yes/no]: ");
                                string choice = Console.ReadLine();
                                if (choice == "yes" || choice == "Yes")
                                {
                                    wish = true;
                                    error = true;
                                    Console.Clear();
                                }
                                else if (choice == "no" || choice == "No")
                                {
                                    Console.WriteLine("Press any key to return.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                    wish = false;
                                }
                            } while (!wish);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found, Please try again.");
                }
            }while (error);
        }

        //view user's Inventory
        public void viewusersappliance()
        {
            bool error = false;
            bool wish = false;
            do
            {
                Console.WriteLine(@" 
--------------------------------------------------------------------------------------
 _____ _           _        _       ______ _ _ _   _____              _             
|  ___| |         | |      (_)      | ___ (_) | | |_   _|            | |            
| |__ | | ___  ___| |_ _ __ _  ___  | |_/ /_| | |   | |_ __ __ _  ___| | _____ _ __ 
|  __|| |/ _ \/ __| __| '__| |/ __| | ___ \ | | |   | | '__/ _` |/ __| |/ / _ \ '__|
| |___| |  __/ (__| |_| |  | | (__  | |_/ / | | |   | | | | (_| | (__|   <  __/ |   
\____/|_|\___|\___|\__|_|  |_|\___| \____/|_|_|_|   \_/_|  \__,_|\___|_|\_\___|_|
--------------------------------------------------------------------------------------
                                   [ADMIN SYSTEM]");
                Console.WriteLine(@"
==============================
   VIEWING USER'S APPLIANCE           
==============================");
                string file = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Electric Users";
                string passuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";

                Console.WriteLine("\nUsers: ");
                Console.WriteLine("*-------------------------*");
                if (File.Exists(passuser))
                {
                    string[] read = File.ReadAllLines(passuser);
                    for (int i = 0; i < read.Length; i++)
                    {
                        Console.WriteLine(read[i]);
                    }
                }
                else
                {
                    Console.WriteLine("File is not found, Please try again.");
                }
                Console.WriteLine("*-------------------------*\n");

                if (Directory.Exists(file))
                {
                    Console.Write("Who's inventory do you want to view: ");
                    string name = Console.ReadLine();
                    if (name.Length == 0)
                    {
                        Console.WriteLine("This part should not empty.");

                        do
                        {
                            Console.Write("Would you wish to continue? [yes/no]: ");
                            string choice = Console.ReadLine();
                            if (choice == "yes" || choice == "Yes")
                            {
                                wish = false;
                                error = true;
                                Console.Clear();
                            }
                            else if (choice == "no" || choice == "No")
                            {
                                Console.WriteLine("Press any key to return.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                wish = true;
                            }
                        } while (wish);
                    }
                    else
                    {
                        string filapath = Path.Combine(file, name + ".txt");
                        if (File.Exists(filapath))
                        {
                            Console.WriteLine($"Viewing Inventory of {name}");
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            Console.WriteLine("|           Date          |  Appliance Name  |   Watts  |   Hours  |    kWh   | Monthly Bill |");
                            Console.WriteLine("|--------------------------------------------------------------------------------------------|");
                            string[] read = File.ReadAllLines(filapath);
                            for (int i = 0; i < read.Length; i++)
                            {
                                Console.WriteLine(read[i]);
                            }
                            Console.WriteLine("----------------------------------------------------------------------------------------------");
                            do
                            {
                                Console.Write("Would you wish to continue? [yes/no]: ");
                                string choice = Console.ReadLine();
                                if (choice == "yes" || choice == "Yes")
                                {
                                    wish = true;
                                    error = true;
                                    Console.Clear();
                                }
                                else if (choice == "no" || choice == "No")
                                {
                                    Console.WriteLine("Press any key to return.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                    wish = false;
                                }
                            } while (!wish);
                        }
                        else
                        {
                            Console.WriteLine("File name not found, Please try again.");
                            do
                            {
                                Console.Write("Would you wish to continue? [yes/no]: ");
                                string choice = Console.ReadLine();
                                if (choice == "yes" || choice == "Yes")
                                {
                                    wish = true;
                                    error = true;
                                    Console.Clear();
                                }
                                else if (choice == "no" || choice == "No")
                                {
                                    Console.WriteLine("Press any key to return.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                    wish = false;
                                }
                            } while (!wish) ;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found, Please try again.");
                }
            }while (error);
        }
    }
}
