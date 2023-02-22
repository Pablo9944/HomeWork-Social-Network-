using HomeWork__Social_Network_.BLL.Models;
using HomeWork__Social_Network_.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.PLL
{
    public class WelcomeMenu
    {
        Authorizations authorizations;
        MyProfile myProfile = new MyProfile();
        public WelcomeMenu()
        {
            authorizations = new Authorizations();
        }
      
        public void Welcome(UserService userService)
        {
            Console.ForegroundColor= ConsoleColor.Cyan;
            Console.WriteLine("Добро пожаловать в нашу социальную сеть");
            
            while (true)
            {
                Console.WriteLine("Для регистрации нажмите - 1");
                Console.WriteLine("Для входа в профиль - 2");
                Console.ResetColor();

                string answer = Console.ReadLine();
                bool flag = true;
                switch (answer)
                {
                    case "1":
                        {
                            User user = new User();
                            UserRegistration userRegistration = new UserRegistration(user);
                            userService.Register(userRegistration);
                            userRegistration.ShowUser();
                            break;
                        }
                        case "2": 
                        {
                            Console.Write("Введите email адрес: ");
                            Authorizations.CheckEmail = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            authorizations.CheckPassword = Console.ReadLine();
                            userService.Authenticate(authorizations);

                            while(flag)
                            {
                                Console.WriteLine("Добавить друзей нажмите - 1");
                                Console.WriteLine("Информация о профиле - 2 ");
                                Console.WriteLine("Выйти - 3");
                                answer = Console.ReadLine();
                                switch (answer)
                                {
                                    case "1":
                                        {
                                            Console.Write("Введите email друга: ");
                                            string email = Console.ReadLine();
                                            userService.AddFriend(email);
                                            break;
                                        }
                                        case "2":
                                        {
                                            myProfile.ShowAbout(userService,authorizations);
                                            break;
                                        }
                                        case "3":
                                        {
                                            flag = false;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                }
            }
           
        }
    }
}
