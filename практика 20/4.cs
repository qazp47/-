using System;

namespace задани4
{
    public class HeroIsDeadException : Exception
    {
        public int Health { get; }

        public HeroIsDeadException(int health)
            : base($"Герой погиб! Здоровье стало {health}")
        {
            Health = health;
        }
    }
    public class Game
    {
        public int Health { get; private set; }

        public Game(int initialHealth)
        {
            Health = initialHealth;
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine($"Здоровье: 66");
            Console.WriteLine($"Получаем урон: 34");
            Health -= damage;

            if (Health <= 0)
            {
                throw new HeroIsDeadException(Health);
            }
        }
    }
    class Program
    {
        static void Main()
        {
            var game = new Game(100);
            try
            {
                game.TakeDamage(150);
            }
            catch (HeroIsDeadException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}