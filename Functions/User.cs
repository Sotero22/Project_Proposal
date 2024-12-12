using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_Proposal
{
    internal class User 
    {
        string file = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Electric Users";
        string fileusers = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
        string userdetails = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Account Details";
        public string username;
        public string password;
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        MainMenu m = new MainMenu();
        public void register()
        {
            Directory.CreateDirectory(file);
            Directory.CreateDirectory(userdetails);
            
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
                          Please fill out the required area.");
                Console.WriteLine(@"
==============================
      CREATE NEW ACCOUNT           
==============================");
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if (username.Length == 0 || password.Length == 0)
                {
                    Console.WriteLine("Username and Password cannot be empty. Please try again.");
                 
                        bool wish = false;
                        while (!wish)
                        {
                            Console.Write("Would you wish to continue? [yes/no]: ");
                            string choice = Console.ReadLine();
                            if (choice == "yes" || choice == "Yes")
                            {
                                wish = true;
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
                            }
                        }
                }
                else
                {
                    
                    string filepath = Path.Combine(file, username + ".txt");
                    string details = Path.Combine(userdetails, username + ".txt");
                   
                    if (File.Exists(filepath))
                    {
                        Console.WriteLine("The account you've entered already exist, Please try logging it in.");
                        bool wish = false;
                        while (!wish)
                        {
                            Console.Write("Would you wish to continue? [yes/no]: ");
                            string choice = Console.ReadLine();
                            if (choice == "yes" || choice == "Yes")
                            {
                                wish = true;
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
                    }
                    else
                    {
                        using (StreamWriter user = File.AppendText(fileusers))
                        {
                            user.WriteLine($"{username},{password}");
                        }

                        Console.WriteLine("----------Please Fill Account Details----------");
                        Console.Write("Full name: ");
                        string name = Console.ReadLine();
                        Console.Write("Address: ");
                        string address = Console.ReadLine();
                        Console.Write("Contact No: ");
                        string num = Console.ReadLine();
                        Console.Write("No. of People in the household: ");
                        string people = Console.ReadLine();
                        Console.Write("No. of Appliance in the household: ");
                        string appliance = Console.ReadLine();

                        using (StreamWriter userdetail = File.AppendText(details))
                        {
                            userdetail.WriteLine($"Created: {time}");
                            userdetail.WriteLine($"Username:{username}");
                            userdetail.WriteLine($"Password: {password}");
                            userdetail.WriteLine("*-----------------------------*");
                            userdetail.WriteLine($"Name: {name}");
                            userdetail.WriteLine($"Address: {address}");
                            userdetail.WriteLine($"Contact No.: {num}");
                            userdetail.WriteLine($"No. of People: {people}");
                            userdetail.WriteLine($"No.of Appliance: {appliance}");

                        }
                            Console.WriteLine("Registration succesful!");
                        error = true;
                    }
                }
                Console.WriteLine();
         
            } while(!error);
        }
        public void login()
        {
           
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
                          Please fill out the required area.");
                Console.WriteLine(@"
==============================
  LOG-IN AN EXISTING ACCOUNT           
==============================");
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if (username.Length == 0 || password.Length == 0)
                {
                    Console.WriteLine("Username and Password cannot be empty. Please try again.");

                    bool wish = false;
                    while (!wish)
                    {
                        Console.Write("Would you wish to continue? [yes/no]: ");
                        string choice = Console.ReadLine();
                        if (choice == "yes" || choice == "Yes")
                        {
                            wish = true;
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
                        }
                    }
                }
                else
                {

                    if (File.Exists(fileusers))
                    {
                        bool userinfo = false;
                        foreach (string line in File.ReadLines(fileusers))
                        {
                            var user = line.Split(',');
                            if (user.Length == 2 && user[0] == username && user[1] == password)
                            {
                                userinfo = true;
                                break;
                            }
                        }
                        if (userinfo == true)
                        {
                            Console.WriteLine("Login successful! Welcome.");
                            error = true;

                            Console.Clear();
                            string filepath = Path.Combine(file, username + ".txt");
                            string passuser = fileusers;
                            string details = Path.Combine(userdetails, username + ".txt");
                            m.menu(filepath,passuser,username,details);
                        }
                        else
                        {
                            Console.WriteLine("The account you've entered does not exist, Please try registering your account.");
                            bool wish = false;
                            while (!wish)
                            {
                                Console.Write("Would you wish to continue? [yes/no]: ");
                                string choice = Console.ReadLine();
                                if (choice == "yes" || choice == "Yes")
                                {
                                    wish = true;
                                    Console.Clear();
                                }
                                else if(choice == "no" || choice == "No")
                                {
                                    Console.WriteLine("Press any key to return.");
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("The account you've entered does not exist, Please try registering your account.");
                        bool wish = false;
                        while (!wish)
                        {
                            Console.Write("Would you wish to continue? [yes/no]: ");
                            string choice = Console.ReadLine();
                            if (choice == "yes" || choice == "Yes")
                            {
                                wish = true;
                            }
                            else if (choice == "no" || choice == "No")
                            {
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter [yes] or [no].");
                            }
                        }
                    }
                } 
            } while (!error);
        }
    }
}