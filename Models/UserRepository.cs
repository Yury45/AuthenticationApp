using AuthenticationApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationApp.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public UserRepository()
        {
            _users.Add(new User()
            {
                Id = Guid.NewGuid(),
                Firstname = $"Админ",
                Lastname = $"Рутович",
                Email = $"Admin@yandex.ru",
                Password = $"admin",
                Login = $"admin",
                Role = new Role()
                {
                    Id = 1,
                    Status = "Администратор"
                }

            });

            for (int i = 0; i < 4; i++)
            { 
                _users.Add(new User()
                {
                    Id = Guid.NewGuid(),
                    Firstname = $"Имя_Пользователь{i+1}",
                    Lastname = $"Фамилия_Пользователь{i+1}",
                    Email = $"User{i+1}Mail@gmail.com",
                    Password = $"password{i+1}",
                    Login = $"user{i+1}",
                    Role = new Role()
                    {
                        Id = 2,
                        Status = "Пользователь"
                    }
                });
            }
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetByLogin(string login)
        {
            return _users.FirstOrDefault(x => x.Login == login);
        }
    }
}
