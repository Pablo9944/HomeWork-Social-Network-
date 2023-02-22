using HomeWork__Social_Network_.BLL.Exceptions;
using HomeWork__Social_Network_.BLL.Models;
using HomeWork__Social_Network_.DAL.Entities;
using HomeWork__Social_Network_.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork__Social_Network_.BLL.Services
{
    public class UserService
    {
       
        IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public void Register(UserRegistration userRegistration)
        {
            
            if (String.IsNullOrEmpty(UserRegistration.user.FirstName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(UserRegistration.user.LastName))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(UserRegistration.user.Password))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(UserRegistration.user.Email))
                throw new ArgumentNullException();

            if (UserRegistration.user.Password.Length < 5)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(UserRegistration.user.Email))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(UserRegistration.user.Email) != null)
                throw new ArgumentNullException();


            var userEntity = new UserEntity()
            {
                
                firstname = UserRegistration.user.FirstName,
                lastname = UserRegistration.user.LastName,
                password = UserRegistration.user.Password,
                email = UserRegistration.user.Email,
               
            };

           
            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();

        }

        public void Authenticate(Authorizations authorizations)
        {

            var authorizationsUser = userRepository.FindUserToEnter(Authorizations.CheckEmail);
            if (authorizationsUser is null) throw new UserNotFoundException();

            if (authorizationsUser.password != authorizations.CheckPassword)
                throw new WrongPasswordException();
       
            else
              authorizations.ShowAuthorizations(MyProfile(authorizationsUser));

            
        }

        UserEntity MyProfile(UserEntity authorizationsUser )
        {
            return new UserEntity()
            {
                id = authorizationsUser.id,
                firstname = authorizationsUser.firstname,
                lastname = authorizationsUser.lastname,
                email = authorizationsUser.email,
                password = authorizationsUser.password,
                
                
            };
        }

        public void InfoAboutProfile(Authorizations authorizations)
        {
            var profileInfo = userRepository.FindUserToEnter(Authorizations.CheckEmail);
            
            if (profileInfo is null)
                throw new Exception();

            MyProfile myProfile= new MyProfile();
            myProfile.Show(profileInfo);


        }

        public void AddFriend(string email)
        {
            var findfriend = userRepository.FindByEmail(email);

            if (findfriend is null)
            {
                Console.WriteLine("Таких пользователей нет");
                return;
            }
            if (Authorizations.CheckEmail == email)
            {
                Console.WriteLine("Хочешь сам с собой дружить? Дружок.... =)");
                return;
            }
            else
            {
                MyProfile(findfriend);
                FriendInvite friendInvite = new FriendInvite();
                Authorizations.friends++;
                friendInvite.Show(findfriend);

            }
        }

    }
}
