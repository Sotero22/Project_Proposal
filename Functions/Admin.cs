using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_Proposal.Functions
{
    internal class Admin : User
    {
        string file = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Admin";
        string filepath = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Electric Users";
        string fileuser = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Users Account\Account.txt";
        string details = @"C:\Users\HP\Documents\Acad 2ndyr 1st sem\CPE-261\Project_Proposal\Account\Account Details";
        string passuser;
        string username;
        string password;
        public void admin()
        {   
            Directory.CreateDirectory(file);

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
       LOG-IN AS ADMIN           
==============================");
            bool wish = true;
            bool error = true;
            do
            { 
                Console.Write("Enter Username: ");
                username = Console.ReadLine();

                Console.Write("Enter Password: ");
                password = Console.ReadLine();

                if (username != "admin123" || password != "12345678")
                {
                    Console.WriteLine("Wrong Username or Password, Please try again.");
                    do
                    {
                        Console.Write("Do you want to continue? [yes/no]: ");
                        string choice = Console.ReadLine();
                        if (choice == "yes" || choice == "Yes")
                        {
                            error = true;
                            wish = false;   
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
                    Console.WriteLine("Log in as Admin succesful.");
                    error = false;
                }
                Console.WriteLine();
            } while (error);

            string adminfile = Path.Combine(file, username + ".txt");

            if (File.Exists(adminfile))
            {
                View v = new View(filepath, details, passuser);
                Deletefile d = new Deletefile(filepath, passuser,username, details);
                string prompt = @"
==============================
        WELCOME ADMIN           
==============================";
                bool choose = true;
                string[] choice = { "[View users]","[View users details]", "[View users appliance]", "[Delete users account]", "[Exit]" };
                do
                {
                    Menu m = new Menu(prompt, choice);
                    int index = m.run();
                    switch (index)
                    {
                        case 0:
                            Console.Clear();
                            v.viewusers();
                            Console.ReadKey();
                            break;
                        case 1:
                            Console.Clear();
                            v.viewusersdetails();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            v.viewusersappliance();
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            d.deleteuser();
                            Console.ReadKey();
                            break;
                        case 4:
                            choose = false;
                            break;
                    }
                }while(choose);
            }
            else
            {
                using (StreamWriter admin = File.AppendText(adminfile))
                {
                    admin.WriteLine($"Username: {username}\nPassword: {password}");
                    Console.WriteLine("Admin registered succesfully.");
                }
            }

        }
    }
}
