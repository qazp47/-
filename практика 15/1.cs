using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{
    internal interface IWork
    {
        void Work();
    }

    internal interface IBatteryLevel
    {
        void Recharge();
    }

    internal class Robot : IWork, IBatteryLevel
    {
        public string Name { get; }
        public int Energy { get; private set; }

        public Robot(string name, int energy)
        {
            Name = name;
            Energy = energy;
        }

        public void Work()
        {
            Energy -= 20;
            if (Energy < 0) Energy = 0;
            Console.WriteLine($"{Name} работает. Энергия: {Energy}");
        }

        public void Recharge()
        {
            Energy += 50;
            if (Energy > 100) Energy = 100;
            Console.WriteLine($"{Name} заряжается. Энергия: {Energy}");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Robot robot = new Robot("Робот", 50);
            robot.Work();
            robot.Work();
            robot.Recharge();
            robot.Work();
        }
    }
}