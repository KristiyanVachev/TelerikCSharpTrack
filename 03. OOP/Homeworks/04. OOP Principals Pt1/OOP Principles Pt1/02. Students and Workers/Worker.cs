using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Students_and_Workers
{
    class Worker : Human
    {
        //properties
        public int WeekSalary { get; set; }
        public int WorkHoursPerDay { get; set; }

        //constructors
        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        //methods
        public double MoneyPerHour()
        {
            int workDays = 5;
            return this.WeekSalary / (workDays * this.WorkHoursPerDay);
        }

    }
}
