using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Data;
using System.Globalization;
using Project_Proposal.Functions;

namespace Project_Proposal
{
    internal class MainMenu : IMenu
    {
        public void menu(string filepath,string passuser,string username, string details)
        {
            string prompt = @"
==============================
        WELCOME USER           
==============================";
            string[] choice = { "[Add Appliance]", "[View Account Data]", "[Update Account Details]", "[Delete]", "[Log Out]" };

            while (true) 
            {
                    Menu m = new Menu(prompt, choice);
                    int index = m.run();
                switch (index)
                {
                    case 0:
                        Add(filepath);
                        Console.ReadKey();
                        break;
                    case 1:
                        View(filepath,details,passuser);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Update(details);
                        break;
                    case 3:
                        Delete(filepath, passuser, username, details);
                        Console.ReadKey();
                        break;
                    case 4:
                        return;
                }
            
            }
        }
        public void Add(string filepath)
        {
            Add a = new Add(filepath);
            a.add();
        }
        public void View(string filepath,string details,string passuser)
        {
            View v = new View(filepath, details, passuser);
            while (true)
            {
                string prompt = @"
==============================
   WHAT DO YOU WANT TO VIEW?          
==============================";
                string[] choice = { "[View Appliance]", "[View Account Details]", "[Back]" };
                Menu m = new Menu(prompt, choice);
                int index = m.run();
                switch (index)
                {
                    case 0:
                        v.viewappliance();
                        Console.ReadKey();
                        break;
                    case 1:
                        v.viewaccountdetails();
                        Console.ReadKey();
                        break;
                    case 2:
                        return;
                }
            }
           
        }
        public void Delete(string filepath,string passuser,string username, string details)
        {
            while (true)
            {
                string prompt = @"
==============================
  WHAT DO YOU WANT TO DELETE?          
==============================";
                string[] choice = { "[Delete appliance]", "[Delete Account]", "[Back]" };
                Menu m = new Menu(prompt, choice);
                int index = m.run();
                switch (index)
                {
                    case 0:
                        Deleteappliance d = new Deleteappliance(filepath);
                        d.delete();
                        Console.ReadKey();
                        break;
                    case 1:
                        Deletefile f = new Deletefile(filepath,passuser,username,details);
                        f.usersdelete();
                        Console.ReadKey();
                        break;
                    case 2:
                        return;
                }
            }
        }
        public void Update(string details)
        {
            Updatedetails u = new Updatedetails(details);
            u.update();
        }

    }   
}
