using System;
using System.Collections.Generic;

namespace UserRegistrationExample
{
    public class LoginAlreadyExistsException : Exception
    {
        public string Login { get; }

        public LoginAlreadyExistsException(string login)
            : base($"Логин \"1234456\" уже занят!")
        {
            Login = login;
        }
    }
    public class WeakPasswordException : Exception
    {
        public int PasswordLength { get; }

        public WeakPasswordException(int length)
            : base($"Ошибка: Слабый пароль! Минимум 6 символов")
        {
            PasswordLength = length;
        }
    }
    public class UserService
    {
        private HashSet<string> _logins;

        public UserService()
        {
            _logins = new HashSet<string>();
        }

        public void Register(string login, string password)
        {
            Console.WriteLine("Регистрация:");
            try
            {
                if (_logins.Contains(login))
                {
                    throw new LoginAlreadyExistsException(login);
                }

                if (password.Length < 6)
                {
                    throw new WeakPasswordException(password.Length);
                }

                _logins.Add(login);
                Console.WriteLine($"Пользователь {login} успешно зарегистрирован.");
            }
            catch (LoginAlreadyExistsException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (WeakPasswordException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var userService = new UserService();
            userService.Register("admin", "123");
            userService.Register("user1", "secret123");
            userService.Register("admin", "password");
        }
  