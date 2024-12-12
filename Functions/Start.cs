using Project_Proposal;
using Project_Proposal.Functions;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

namespace Project_Proposal
{
    class Menu : Start
    {

        private int index;
        private string[] Choice;
        private string Prompt;
        public Menu(string prompt,string[] choice)
        {
            Prompt = prompt;
            Choice = choice;
            index = 0;
        }
        private void Display()
        {
            Console.WriteLine(@" 
-------------------------------------Welcome to---------------------------------------
 _____ _           _        _       ______ _ _ _   _____              _             
|  ___| |         | |      (_)      | ___ (_) | | |_   _|            | |            
| |__ | | ___  ___| |_ _ __ _  ___  | |_/ /_| | |   | |_ __ __ _  ___| | _____ _ __ 
|  __|| |/ _ \/ __| __| '__| |/ __| | ___ \ | | |   | | '__/ _` |/ __| |/ / _ \ '__|
| |___| |  __/ (__| |_| |  | | (__  | |_/ / | | |   | | | | (_| | (__|   <  __/ |   
\____/|_|\___|\___|\__|_|  |_|\___| \____/|_|_|_|   \_/_|  \__,_|\___|_|\_\___|_|
--------------------------------------------------------------------------------------
             Press [Arrow keys] to navigate and [Enter] to select.                                                                                                                                              
");

            Console.WriteLine(Prompt);
            for (int i = 0; i < Choice.Length; i++)
            {
                string thechoice = Choice[i];
                string point;


                if (i == index)
                {
                    point = "-->";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    point = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{point} {thechoice}");
            }
            Console.ResetColor();
        }
        public int run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Display();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index == -1)
                    {
                        index = Choice.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == Choice.Length)
                    {
                        index = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return index;
        }
    }
}
namespace Project_Proposal
{
    internal class Ready
    {
        public void ready()
        {
            string prompt = @"
==============================
           MAINMENU           
==============================";
            Start s = new Start();
            bool choose = true;
            string[] choice = { "[Admin]", "[User]", "[About]", "[Exit]" };
            do
            {
                Menu m = new Menu(prompt,choice);
                int index = m.run();
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Admin a = new Admin();
                        a.admin();
                        break;
                    case 1:
                        s.start();
                        break;
                    case 2:
                        s.About();
                        Console.ReadKey();
                        break;
                    case 3:
                        s.Exit();
                        choose = false;
                        Environment.Exit(0);
                        break;
                }
            }while(choose);
        }
    }

}
    namespace Project_Proposal
    {

        internal class Start : IStart
        {
            public void start()
            {
            string prompt = @"
==============================
         USER SYSTEM           
==============================";

            bool choose = false;
            string[] choice = { "[Log In]", "[Create Account]", "[Exit]" };

            do
            {
                Menu m = new Menu(prompt, choice);
                int index = m.run();
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Login();
                        Console.ReadKey();
                        break;
                    case 1:
                        Console.Clear();
                        Register();
                        Console.ReadKey();
                        break;
                    case 2:
                        Exit();
                        return;
                }
            } while (!choose);
            }

            public void Login()
            {
                User a = new User();
                a.login();
            }
            public void Register()
            {
                User a = new User();
                a.register();
            }
            public void About()
            {
            Console.WriteLine( @"
==============================
         USER SYSTEM           
==============================");
            Console.WriteLine("This program is created by Emmanuel Sotero Cueva");
                Console.WriteLine("BSCPE-H2 2nd Year");
            }
            public void Exit()
            {
                Console.WriteLine("Thanks for Pacticipating!!");
            }
        }
    }

