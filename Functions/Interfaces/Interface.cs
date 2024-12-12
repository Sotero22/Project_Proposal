using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Proposal
{
    interface IStart
    {
        void start();   
        void Login();
        void Register();
        void About();
        void Exit();
    }
    interface IMenu
    {
        void Add(string filepath);
        void View(string filepath,string details,string passuser);
        void Delete(string filepath,string passuser,string username,string details);
    }
}
