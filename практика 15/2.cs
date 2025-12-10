using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    internal interface IOnOff
    {
        void TurnOn();

        void TurnOff();
    }
    internal interface ILevel
    {
        void SetLevel(int level);
    }
    internal class Lamp : IOnOff, ILevel
    {
        public int Level { get; set; }
        public bool IsOn { get; set; }

        public void TurnOn()
        {
            IsOn = true;
            Level = 100;
            Console.WriteLine($"Лампа включена. Уровень: {Level}");
        }
        public void TurnOff()
        {
            IsOn = false;
            Level = 0;
            Console.WriteLine($"Лампа выключена. Уровень: {Level}");
        }
        public void SetLevel(int level)
        {
            if (level < 0) level = 0;
            if (level > 100) level = 100;
            Level = level;
            Console.WriteLine($"Уровень лампы установлен на {Level}");
        }
    }
    internal class Ventilator : IOnOff
    {
        public void TurnOn()
        {
            Console.WriteLine("Вентилятор включен");
        }
        public void TurnOff()
        {
            Console.WriteLine("Вентилятор выключен");
        }
    }
    internal class Program
    {
        private static void Main()
        {
            Lamp device1 = new Lamp();
            device1.TurnOn();
            device1.SetLevel(30);
            device1.TurnOff();
            Ventilator device2 = new Ventilator();
            device2.TurnOn();
            device2.TurnOff();
        }
    }
}