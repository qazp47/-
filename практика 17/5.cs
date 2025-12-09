using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    public enum EmploymentStatus
    {
        Active,
        OnLeave,
        Terminated
    }
    public class Employee
    {
        public string Name { get; set; }
        public DateTime? HireDate { get; set; }
        public EmploymentStatus Status { get; set; }

        public int GetYearsWorked()
        {
            if (!HireDate.HasValue)
                return -1;

            var today = DateTime.Today;
            int years = today.Year - HireDate.Value.Year;
            if (HireDate.Value.Date > today.AddYears(-years))
                years--;

            return years;
        }
        public override string ToString()
        {
            string statusStr = Status.ToString();
            string hireDateStr = HireDate.HasValue ? HireDate.Value.ToShortDateString() : "не указана";
            return $"{Name}, статус: {statusStr}, стаж: {hireDateStr}";
        }
    }
    class Program
    {
        static void Main()
        {
            var emp = new Employee
            {
                Name = "Пётр",
                HireDate = new DateTime(2020, 3, 15),
                Status = EmploymentStatus.Active
            };
            Console.WriteLine(emp.GetYearsWorked());
            emp.HireDate = null;
            Console.WriteLine(emp.GetYearsWorked());
            Console.WriteLine(emp);
        }
    }
}