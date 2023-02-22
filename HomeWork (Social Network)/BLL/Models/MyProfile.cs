using HomeWork__Social_Network_.BLL.Services;
using HomeWork__Social_Network_.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.BLL.Models
{
    public class MyProfile
    {
        public void ShowAbout(UserService userservice, Authorizations authorizations)
        {
           
            userservice.InfoAboutProfile(authorizations);

        }

        public void Show(UserEntity userEntity)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($@"О профиле:
                    Ваше имя: {userEntity.firstname} 
                    Ваша фамилия: {userEntity.lastname} 
                    Ваш email: {userEntity.email}
                    Ваш пароль от учетной записи: {userEntity.password}
                    У Вас друзей: {Authorizations.friends}");
            Console.ResetColor();
        }
    }
}
