using HomeWork__Social_Network_.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.BLL.Models
{
    public class FriendInvite
    {
        
        public void Show(UserEntity userEntity)
        {
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"{userEntity.firstname} в друзья усапешно добавлен");
            Console.ResetColor();
        }
    }
}
