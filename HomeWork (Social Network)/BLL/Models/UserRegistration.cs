using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.BLL.Models
{
    public class UserRegistration
    {
        public static int ID { get; set; }
        public static User user { get; private set; }
        public UserRegistration(User _user)
        {
            user = _user;
            InfoOrUser();
        }
        void InfoOrUser()
        {
            Console.Write("Введите имя: ");
            user.FirstName= Console.ReadLine();
            Console.Write("Введите фамилию: ");
            user.LastName= Console.ReadLine();
            Console.Write("Введите пароль: ");
            user.Password= Console.ReadLine();
            Console.Write("Введите email адрес: ");
            user.Email= Console.ReadLine();

        }

        public void ShowUser()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Регистрация прошла успешно");
            Console.ResetColor();
        }

    }
}
