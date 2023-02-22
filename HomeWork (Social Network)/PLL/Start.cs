using HomeWork__Social_Network_.BLL.Models;
using HomeWork__Social_Network_.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.PLL
{
    
    public static class Start  
    {
        
        static WelcomeMenu welcomeMenu= new WelcomeMenu();
        static UserService UserService = new UserService();

        public static void Enter()
        {
            welcomeMenu.Welcome(UserService);
        }
    }
}
