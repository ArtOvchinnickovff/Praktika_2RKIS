using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Entities;

namespace Todo.Repository
{
    internal class UserRepository
    {
        // Приватный статический список зарегистрированных пользователей
        private static List<UserModel> registeredUsers = new List<UserModel>();
        private static int userIdCounter = 1; // Счетчик для ID пользователей

        // Метод для регистрации пользователей
        public bool RegisterUser(string username, string password, string email)
        {
            // Проверка на уникальность пользователя
            if (registeredUsers.Any(u => u.Username == username))
            {
                return false; // Пользователь уже существует
            }

            // Создание нового пользователя и добавление в список
            var newUser = new UserModel(userIdCounter++, username, password, email);
            registeredUsers.Add(newUser);
            return true; // Регистрация успешна
        }

        // Метод для авторизации пользователей
        public bool AuthenticateUser(string username, string password)
        {
            // Поиск пользователя по имени и проверка пароля
            var user = registeredUsers.SingleOrDefault(u => u.Username == username);
            return user != null && user.Password == password; // Возвращаем результат проверки
        }
    }
}


