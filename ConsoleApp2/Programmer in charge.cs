using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class PIC : Employee
    {
        string lastname;
        string firstname;
        string task;
        string dateStart;
        string dateEnd;
        string duration;
        string daysElapsed;
        string salary;

        public PIC(string lastname, string firstname, string task, string dateStart, string dateEnd, string duration, string daysElapsed, string salary)
        {
            this.Lastname = lastname;
            this.Firstname = firstname;
            this.Task = task;
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Duration = duration;
            this.DaysElapsed = daysElapsed;
            this.Salary = salary;
        }

        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Task { get => task; set => task = value; }
        public string DateStart { get => dateStart; set => dateStart = value; }
        public string DateEnd { get => dateEnd; set => dateEnd = value; }
        public string Duration { get => duration; set => duration = value; }
        public string DaysElapsed { get => daysElapsed; set => daysElapsed = value; }
        public string Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return "- " + this.Lastname + " " + this.Firstname + ", in charge of " + this.Task + " from " + this.DateStart + " to " + this.DateEnd + " (duration: " + this.Duration + "), this month: " + this.DaysElapsed + " days (total cost = " + this.Salary + "$).\n";
        }
    }

}
