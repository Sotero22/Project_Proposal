using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project_Proposal.Functions
{
    internal class Updatedetails : User
    {
        string details;
        public Updatedetails(string details)
        {
            this.details = details;
        }
        public void update()
        {

            if (File.Exists(details))
            {
                bool check = true;
                do
                {
                    string[] read = File.ReadAllLines(details);
                    for (int i = 0; i < read.Length; i++)
                    {
                        string prompt = @"
==============================
    UPDATING USERS DETAILS          
==============================";
                        string[] choices = { $"{read[4]}", $"{read[5]}", $"{read[6]}", $"{read[7]}", $"{read[8]}", "[Done]" };
                        Menu m = new Menu(prompt, choices);
                        int index = m.run();
                        switch (index)
                        {
                            case 0:
                               
                                if (File.Exists(details))
                                {
                                    Console.Clear();
                                    bool error = false;
                                    bool wish = false;
                                    int updateline = 4 + index;
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
        UPDATING NAME           
==============================");
                                        Console.WriteLine($"Current {read[updateline]}");
                                        
                                        Console.Write("Enter the new name detail: ");
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
                                            read[updateline] = $"Name: {name}";

                                            File.WriteAllLines(details, read);

                                            Console.WriteLine($"Name detail updated successfully.");
                                            error = false;
                                            Console.ReadKey();
                                        }
                                    } while (error);
                                }
                                break;
                            case 1:
                                if (File.Exists(details))
                                {
                                    Console.Clear();
                                    bool error = false;
                                    bool wish = false;
                                    int updateline = 4 + index;
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
       UPDATING ADDRESS           
==============================");
                                        Console.WriteLine($"Current {read[updateline]}");
                                        Console.Write("Enter the new Address detail: ");
                                        string address = Console.ReadLine();
                                        if (address.Length == 0)
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
                                            read[updateline] = $"Address: {address}";

                                            File.WriteAllLines(details, read);

                                            Console.WriteLine($"Address detail updated successfully.");
                                            error = false;
                                            Console.ReadKey();
                                        }
                                    }while(error);
                                }
                                break;
                            case 2:
                                if (File.Exists(details))
                                {
                                    Console.Clear();
                                    bool error = false;
                                    bool wish = false;
                                    int updateline = 4 + index;
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
       UPDATING NUMBER           
==============================");
                                        Console.WriteLine($"Current {read[updateline]}");
                                        Console.Write("Enter the new Number detail: ");
                                        string num = Console.ReadLine();
                                        if (num.Length == 0)
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
                                            read[updateline] = $"Contact No.: {num}";

                                            File.WriteAllLines(details, read);

                                            Console.WriteLine($"Number detail updated successfully.");
                                            error = false;
                                            Console.ReadKey();
                                        }
                                    }while(error);
                                }
                                break;
                            case 3:
                                if (File.Exists(details))
                                {
                                    Console.Clear();
                                    bool error = false;
                                    bool wish = false;
                                    int updateline = 4 + index;
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
    UPDATING NO. OF PEOPLE           
==============================");
                                        Console.WriteLine($"Current {read[updateline]}");
                                        Console.Write("Enter the new Number of people detail: ");
                                        string people = Console.ReadLine();
                                        if (people.Length == 0)
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
                                            read[updateline] = $"No. of People: {people}";

                                            File.WriteAllLines(details, read);

                                            Console.WriteLine($"Number of people detail updated successfully.");
                                            error = false;
                                            Console.ReadKey();
                                        }
                                    }while (error);
                                }
                                break;
                            case 4:
                                if (File.Exists(details))
                                {
                                    Console.Clear();
                                    bool error = false;
                                    bool wish = false;
                                    int updateline = 4 + index;
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
  UPDATING NO. OF APPLIANCE           
==============================");
                                        Console.WriteLine($"Current {read[updateline]}");
                                        Console.Write("Enter the new Number of appliance detail: ");
                                        string app = Console.ReadLine();
                                        if (app.Length == 0)
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
                                            read[updateline] = $"No.of Appliance: {app}";

                                            File.WriteAllLines(details, read);

                                            Console.WriteLine($"Number of appliance detail updated successfully.");
                                            error = false;
                                            Console.ReadKey();
                                        }
                                    }while (error);
                                }
                                break;
                            case 5:

                                return;
                        }
                    }
                }while (!check);
            }
        }
    }
}
