using HomeWork__Social_Network_.BLL.Services;
using HomeWork__Social_Network_.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.BLL.Models
{
    public class Authorizations
    {
        public static string CheckEmail { get;set; }
        public string CheckPassword { get;set; }

        public  static int friends { get;set; }

        public void ShowAuthorizations(UserEntity userEntity)
        {
            CheckEmail = userEntity.email;
         
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($@"Добро пожаловать 
                    Ваше имя: {userEntity.firstname} 
                    Ваша фамилия: {userEntity.lastname} 
                    Ваш email: {userEntity.email}
                    Ваш пароль от учетной записи: {userEntity.password}
                    У Вас друзей: {friends}");
            Console.ResetColor();
        }
    }
}
