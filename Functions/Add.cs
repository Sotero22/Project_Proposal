using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.ComponentModel.Design;

namespace Project_Proposal
{
    internal class Add : User
    {
        string name;
        double watts = 0;
        double hour = 0;
        double rate = 12.56;
        double kw = 0;
        double month = 0;
        double mbill = 0;
        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        private string filepath;
        public Add(string filepath)
        {
            this.filepath = filepath;
        }

        public void add()
        {
            Console.Clear();
            ConsoleKey keyPressed;
            bool error = false;
            bool check = false;
            string name = "";
            Console.WriteLine(@" 
--------------------------------------------------------------------------------------
 _____ _           _        _       ______ _ _ _   _____              _             
|  ___| |         | |      (_)      | ___ (_) | | |_   _|            | |            
| |__ | | ___  ___| |_ _ __ _  ___  | |_/ /_| | |   | |_ __ __ _  ___| | _____ _ __ 
|  __|| |/ _ \/ __| __| '__| |/ __| | ___ \ | | |   | | '__/ _` |/ __| |/ / _ \ '__|
| |___| |  __/ (__| |_| |  | | (__  | |_/ / | | |   | | | | (_| | (__|   <  __/ |   
\____/|_|\___|\___|\__|_|  |_|\___| \____/|_|_|_|   \_/_|  \__,_|\___|_|\_\___|_|
--------------------------------------------------------------------------------------
             Press [Arrow keys] to navigate and [Enter] to select. ");
            Console.WriteLine(@"
==============================
        Add Appliance           
==============================");
            do
            {
                do
                {
                    Console.Write("Appliance name: ");
                    name = Console.ReadLine();
                    if (name.Length == 0)
                    {
                        Console.WriteLine("This part should not empty.");
                        break;
                    }
                        try
                        {
                            Console.Write("Estimated Watts: ");
                            watts = double.Parse(Console.ReadLine());

                            Console.Write("Estimated Hours of usage: ");
                            hour = double.Parse(Console.ReadLine());
                            if (watts <= 0 || hour <= 0)
                            {
                                Console.WriteLine("Both values must be greater than zero. Please try again.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter numeric values. Please try again.");
                            error = true;
                        }
                } while (hour <= 0 && watts <= 0 && !error) ;
                    kw = watts * hour / 1000;
                    month = kw * rate * 30;
                 if (name.Length > 0)
                {
                    using (StreamWriter app = File.AppendText(filepath))
                    {
                        app.WriteLine("|   {0,-2}   |        {1,-4}      |   {2,4}   |   {3,4}   |   {4,4:F2}   |    {5,4:F2}    |", time, name, watts, hour, kw, month);
                    }
                }
                    if (File.Exists(filepath) && name.Length > 0)
                    {
                        Console.WriteLine("Appliance details saved to file.");
                    }
                    else
                    {
                        Console.WriteLine("No file path specified.");
                    }
                
                    Console.WriteLine("\nPress [Enter] to Continue and [Spacebar] to Exit.");
                    Console.Write("Do you want to continue?");
                    keyPressed = Console.ReadKey(true).Key;
                    Console.WriteLine();

            } while (keyPressed != ConsoleKey.Spacebar) ;
        }
    }
}
