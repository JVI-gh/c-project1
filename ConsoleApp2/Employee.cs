using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface Employee
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Task { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public string Duration { get; set; }
        public string DaysElapsed { get; set; }
        public string Salary { get; set; }

        public string updateWork(Employee employee)
        {
            if (Int32.Parse(employee.Duration) > Int32.Parse(employee.DaysElapsed))
            {
                employee.DaysElapsed = (Int32.Parse(employee.DaysElapsed) + 1).ToString();
            }
            return employee.DaysElapsed;
        }
        public string ToString(Employee employee)
        {
            return "- " + employee.Lastname + " " + employee.Firstname + ", in charge of " + employee.Task + " from " + employee.DateStart + " to " + employee.DateEnd + " (duration: " + employee.Duration + "), this month: " + employee.DaysElapsed + " days (total cost = " + employee.Salary + "$).\n";

        }
    }

}
