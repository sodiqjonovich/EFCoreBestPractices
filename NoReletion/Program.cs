using NoReletion.Entities;
using NoReletion.Repasitories;
using NoReletion.RepasitoryInterfaces;
using System;
using System.Collections.Generic;

namespace NoReletion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We impliment Simple CRUD operations

            // You check following examples step by step

            //Create();
            //Read();
            //Update();
            //Delete();
            GetAll();
        }

        static void Create()
        {
            // First we get instance of userRepasitory interface 
            IUserRepasitory userRepasitory = new UserRepasitory();

            User user = new User()
            {
                FirstName = "O'tkirbek",
                LastName = "Sobirjonov",
                MiddleName = "Sodiqjonovich",
                Email = "otkirbeksobirjonov@gmail.com",
                PhoneNumber = "+998976260619",
                RegistrationDate = DateTime.Now
            };
            userRepasitory.CreateAsync(user).Wait();
            
            // Then check your database
        }

        static void Read()
        {
            // First we get instance of userRepasitory interface 
            IUserRepasitory userRepasitory = new UserRepasitory();

            User user = userRepasitory.GetAsync(1).Result;

            Show(user);
        }

        static void Update()
        {
            // First we get instance of userRepasitory interface 
            IUserRepasitory userRepasitory = new UserRepasitory();

            User user = userRepasitory.GetAsync(1).Result;

            user.FirstName = "Alijon";
            user.LastName = "Kamolov";
            user.MiddleName = "Sotiboldiyevich";

            userRepasitory.UpdateAsync(user).Wait();
        }

        static void Delete()
        {
            // First we get instance of userRepasitory interface 
            IUserRepasitory userRepasitory = new UserRepasitory();

            userRepasitory.DeleteAsync(1).Wait();
        }

        static void GetAll()
        {
            // First we get instance of userRepasitory interface 
            IUserRepasitory userRepasitory = new UserRepasitory();

            var users = userRepasitory.GetAsync(1, 5).Result;

            foreach(User user in users)
            {
                Show(user);
            }
        }

        static void Show(User user)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.MiddleName}");
        }
    }
}
