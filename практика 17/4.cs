using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    public struct Weather
    {
        public string City;
        public double? Temperature;

        public override string ToString()
        {
            string tempStr = Temperature.HasValue ? $"{Temperature.Value}" : "Нет данных";
            return $"{City}: {tempStr}°С";
        }
    }

    class Program
    {
        static void Main()
        {
            var w1 = new Weather { City = "Москва", Temperature = 22.5 };
            var w2 = new Weather { City = "Сочи", Temperature = null };
            Console.WriteLine(w1);
            Console.WriteLine(w2);
        }
    }
}