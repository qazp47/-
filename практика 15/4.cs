using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    interface IAttack
    {
        void Attack();
    }
    interface IHeal
    {
        void Heal();
    }
    class Warrior : IAttack
    {
        public void Attack()
        {
            Console.WriteLine("Воин атакует!");
        }
    }

    class Mage : IAttack, IHeal
    {
        public void Attack()
        {
            Console.WriteLine("Маг атакует!");
        }

        public void Heal()
        {
            Console.WriteLine("Маг лечит!");
        }
    }
    class Program
    {
        static void Main()
        {
            List<object> characters = new List<object>
            {
                new Warrior(),
                new Mage()
            };

            Console.WriteLine("Все умеющие атаковать:");
            foreach (var character in characters)
            {
                if (character is IAttack attacker)
                {
                    attacker.Attack();
                }
            }

            Console.WriteLine("\nТолько умеющие лечить:");
            foreach (var character in characters)
            {
                if (character is IHeal healer)
                {
                    healer.Heal();
                }
            }
        }
    }
}