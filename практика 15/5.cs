using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    namespace BankTransfer
    {
        interface IDeposit
        {
            void Deposit(decimal amount);
            void Withdraw(decimal amount);
        }
        interface ITransfer
        {
            void Transfer(decimal amount, BankAccount targetAccount);
        }

        class BankAccount : IDeposit, ITransfer
        {
            public decimal Balance { get; private set; }
            public string AccountName { get; private set; }

            public BankAccount(string accountName, decimal initialBalance = 0)
            {
                AccountName = accountName;
                Balance = initialBalance;
            }
            public void Deposit(decimal amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"{AccountName}: внесено {amount}. Текущий баланс: {Balance}");
                }
                else
                {
                    Console.WriteLine($"{AccountName}: сумма должна быть больше 0 для внесения.");
                }
            }
            public void Withdraw(decimal amount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    Balance -= amount;
                    Console.WriteLine($"{AccountName}: снято {amount}. Текущий баланс: {Balance}");
                }
                else
                {
                    Console.WriteLine($"{AccountName}: недостаточно средств или некорректная сумма для снятия.");
                }
            }
            public void Transfer(decimal amount, BankAccount targetAccount)
            {
                if (amount > 0 && amount <= Balance)
                {
                    this.Withdraw(amount);
                    targetAccount.Deposit(amount);
                    Console.WriteLine($"Перевод {amount} со счета {AccountName} на счет {targetAccount.AccountName} завершен.");
                }
                else
                {
                    Console.WriteLine($"{AccountName}: перевод невозможен. Проверьте сумму и баланс.");
                }
            }
        }
        class Program
        {
            static void Main()
            {
                BankAccount account1 = new BankAccount("Счет 1", 6000);
                BankAccount account2 = new BankAccount("Счет 2", 900);
                decimal transferAmount = 100;
                Console.WriteLine($"\nПеревод {transferAmount} с {account1.AccountName} на {account2.AccountName}...\n");
                account1.Transfer(transferAmount, account2);
                Console.WriteLine($"{account1.AccountName} баланс: {account1.Balance}");
                Console.WriteLine($"{account2.AccountName} баланс: {account2.Balance}");
            }
        }
    }
}