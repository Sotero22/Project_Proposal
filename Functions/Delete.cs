using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_Proposal
{
    internal class Deleteappliance : User
    {
        private string filepath;
        public Deleteappliance(string filepath)
        {
            this.filepath = filepath;
        }
        public void delete()
        {
            if (File.Exists(filepath))
            {
                Console.Clear();
                bool wish = false;
                bool error = false;
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
                                   ");
                    Console.WriteLine(@"
==============================
       DELETING APPLIANCE           
==============================");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.WriteLine("|           Date          |  Appliance Name  |   Watts  |   Hours  |    kWh   | Monthly Bill |");
                    Console.WriteLine("|--------------------------------------------------------------------------------------------|");
                    string[] read = File.ReadAllLines(filepath);
                    for (int i = 0; i < read.Length; i++)
                    {
                        Console.WriteLine(read[i]);
                    }
                    Console.WriteLine("----------------------------------------------------------------------------------------------");

                    string name = "";
                    
                        Console.Write("Enter the name of the appliance to delete: ");
                        name = Console.ReadLine();
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

                        if (File.Exists(filepath))
                        {
                            string[] locate = File.ReadAllLines(filepath);
                            using (StreamWriter delete = new StreamWriter(filepath))
                            {
                                for (int i = 0; i < locate.Length; i++)
                                {
                                    if (locate[i].Contains(name))
                                    {
                                        error = true;
                                    }
                                    else
                                    {
                                        delete.WriteLine(locate[i]);
                                    }
                                }
                                if (error == true)
                                {
                                    Console.WriteLine("Appliance deleted succesfully.");
                                    return;
                                   
                                }
                                else
                                {
                                    Console.WriteLine("This appliance is not found, Please try again.");
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
                            }
                        }
                        else
                        {
                            Console.WriteLine("File not located, Please try again.");
                        }
                    }

                } while (error); 
            }
            else
            {
                Console.WriteLine("There is no inputed text file to delete.");
            }
        }
    }
}
//Users Delete
namespace Project_Proposal
{
    internal class Deletefile : User
    {
        private string filepath = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Admin";
        private string passuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
        private string details = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Account Details";
        public Deletefile(string filepath, string passuser, string username, string details)
        {
            this.passuser = passuser;
            this.filepath = filepath;
            this.username = username;
            this.details = details;
        }
        //User
        public void usersdelete()
        {
            if (File.Exists(details))
            {
                bool confirmation = false;
                do
                {
                    if (File.Exists(details))
                    {
                        Console.WriteLine("\n*===============================================================================*\n");
                        Console.WriteLine("All the users data in file will be deleted");
                        Console.Write("Are you sure you want to delete this accout? [yes/no]: ");
                        string choice = Console.ReadLine();
                 
                        if (choice == "yes" || choice == "Yes")
                        {
                            Console.WriteLine("\n*------------------------------------*");
                            //Account
                            string[] file = File.ReadAllLines(passuser);
                            if (File.Exists(passuser))
                            {
                                using (StreamWriter delete = new StreamWriter(passuser))
                                {
                                    for (int i = 0; i < file.Length; i++)
                                    {
                                        if (!file[i].Contains(username))
                                        {
                                            delete.WriteLine(file[i]);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Account deleted succesfully.");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }

                            //Account details
                            File.Delete(details);
                            if (!File.Exists(details))
                            {
                                Console.WriteLine("Account details deleted succesfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete account details.");
                            }

                            //File details
                            File.Delete(filepath);
                            if (!File.Exists(filepath))
                            {
                                Console.WriteLine("File deleted sucessfully.");
                                Console.ReadKey();
                                confirmation = true;
                                Ready r = new Ready();
                                r.ready();
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete file.");
                                confirmation = false;
                            }
                        }
                        else if (choice == "no" || choice == "No")
                        {
                            Console.WriteLine("Press any key to return.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                        }
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                        confirmation = true;
                    }
                } while (!confirmation);
            }
            else
            {
                Console.WriteLine("File name not found, Please try again.");
            }
        }

        //Admin
        public void deleteuser()
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
    DELETING USER'S ACCOUNT         
==============================");
                string passuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
                string details = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Account Details";
                string filepath = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Electric Users";
                Console.WriteLine("\nUsers: ");
                Console.WriteLine("*-------------------------*");

                if (File.Exists(passuser))
                {
                    string[] read = File.ReadAllLines(passuser);
                    for (int i = 0; i < read.Length; i++)
                    {
                        Console.WriteLine(read[i]);
                    }
                    Console.WriteLine("*-------------------------*");
                }
                else
                {
                    Console.WriteLine("File is not found, Please try again.");
                }

                if (Directory.Exists(details))
                {
                    Console.Write("\nWho's account you want to delete: ");
                    string name = Console.ReadLine();
                    if (name.Length == 0)
                    {
                        Console.WriteLine("Username and Password cannot be empty. Please try again.");


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
                        string userdetails = Path.Combine(details, name + ".txt");
                        string userinventory = Path.Combine(filepath, name + ".txt");

                        if (File.Exists(userdetails))
                        {
                            do
                            {
                                if (File.Exists(userdetails))
                                {
                                    Console.WriteLine("NOTE: All the data in this user's account will be deleted.");
                                    Console.Write("Are you sure you want to delete this accout? [yes/no]: ");
                                    string choice = Console.ReadLine();
     
                                        if (choice == "yes" || choice == "Yes")
                                        {
                                            Console.WriteLine("\n*------------------------------------*");
                                            //Account
                                            string[] file = File.ReadAllLines(passuser);
                                            if (File.Exists(passuser))
                                            {
                                                using (StreamWriter delete = new StreamWriter(passuser))
                                                {
                                                    for (int i = 0; i < file.Length; i++)
                                                    {
                                                        if (!file[i].Contains(name))
                                                        {
                                                            delete.WriteLine(file[i]);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Account deleted succesfully.");
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Account not found.");
                                                do
                                                {
                                                    Console.Write("Would you wish to continue? [yes/no]: ");
                                                    string get = Console.ReadLine();
                                                    if (get == "yes" || get == "Yes")
                                                    {
                                                        wish = true;
                                                        error = true;
                                                        Console.Clear();
                                                    }
                                                    else if (get == "no" || get == "No")
                                                    {
                                                        Console.WriteLine("Press any key to return.");
                                                        Console.Clear();
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                                        wish = false;
                                                    }
                                                } while (!wish);
                                            }

                                            //Account details
                                            File.Delete(userdetails);
                                            if (!File.Exists(userdetails))
                                            {
                                                Console.WriteLine("Account details deleted succesfully.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Failed to delete account details.");
                                            }

                                            //File details
                                            File.Delete(userinventory);
                                            if (!File.Exists(userinventory))
                                            {
                                                Console.WriteLine("File deleted sucessfully.");
                                                Console.ReadKey();
                                                wish = true;
                                                break;

                                            }
                                            else
                                            {
                                                Console.WriteLine("Failed to delete file.");
                                                wish = true;
                                            }
                                        }
                                        else if (choice == "no" || choice == "No")
                                        {
                                            Console.WriteLine("Press any key to return.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input.");
                                            wish = false;
                                        }
                                }
                                else
                                {
                                    Console.WriteLine("File not found.");
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
                            } while (wish);
                        }
                        else
                        {
                            Console.WriteLine("File not found, Please try again.");
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
            } while (error);
        }
    }
}

