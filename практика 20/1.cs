using System;

namespace ATMExample
{
    public class NotEnoughMoneyException : Exception
    {
        public decimal Balance { get; }
        public decimal Amount { get; }

        public NotEnoughMoneyException(decimal balance, decimal amount)
            : base($"Недостаточно средств! Баланс: {balance}, Запрошено: {amount}")
        {
            Balance = balance;
            Amount = amount;
        }
    }
    public class WrongPinException : Exception
    {
        public int AttemptsLeft { get; }

        public WrongPinException(int attemptsLeft)
            : base($"Неверный PIN! Осталось попыток: {attemptsLeft}")
        {
            AttemptsLeft = attemptsLeft;
        }
    }
    public class ATM
    {
        private decimal _balance;
        private readonly int _correctPin = 1234;
        private int _pinAttemptsLeft = 3;
        private bool _isCardBlocked = false;

        public ATM(decimal initialBalance)
        {
            _balance = initialBalance;
        }
        public void EnterPin(int pin)
        {
            if (_isCardBlocked)
            {
                Console.WriteLine("Карта заблокирована!");
                return;
            }

            if (pin == _correctPin)
            {
                Console.WriteLine("PIN правильно. Доступ разрешён.");
                _pinAttemptsLeft = 3;
            }
            else
            {
                _pinAttemptsLeft--;
                if (_pinAttemptsLeft == 0)
                {
                    _isCardBlocked = true;
                    Console.WriteLine("Карта заблокирована!");
                }
                else
                {
                    Console.WriteLine($"Ошибка: Неверный PIN! Осталось попыток: {_pinAttemptsLeft}");
                }
            }
        }
        public void Withdraw(decimal amount)
        {
            if (_isCardBlocked)
            {
                Console.WriteLine("Карта заблокирована!");
                return;
            }

            if (_pinAttemptsLeft == 0)
            {
                Console.WriteLine("Карта заблокирована!");
                return;
            }

            try
            {
                if (amount > _balance)
                {
                    throw new NotEnoughMoneyException(_balance, amount);
                }
                _balance -= amount;
                Console.WriteLine($"Выведено: {amount}");
            }
            catch (NotEnoughMoneyException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Баланс: {_balance}");
        }
    }
    class Program
    {
        static void Main()
        {
            var atm = new ATM(500);

            atm.ShowBalance();
            Console.WriteLine("Ввод PIN: 0000");
            atm.EnterPin(0000);

            Console.WriteLine("Ввод PIN: 1111");
            atm.EnterPin(1111);

            Console.WriteLine("Ввод PIN: 9999");
            atm.EnterPin(9999);
            atm.Withdraw(1000);
        }
    }
}