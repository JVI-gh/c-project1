using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ConsoleApp2
{
    internal class ProjectTeam
    {
        bool isHalfSalary;
        string teamName;
        PIC[] programmers;

        public ProjectTeam(bool isHalfSalary, string teamName, PIC[] programmers)
        {
            this.IsHalfSalary = isHalfSalary;
            this.teamName = teamName;
            this.Programmers = programmers;
        }

        public bool IsHalfSalary { get => isHalfSalary; set => isHalfSalary = value; }

        public string TeamName { get => teamName; set => teamName = value; }

        public PIC[] Programmers { get => programmers; set => programmers = value; }

        public static ProjectTeam[] CreateBaseTeams()
        {
            ProjectTeam[] teams = new ProjectTeam[2]
            {
                new ProjectTeam(true, "Deployment",
                new PIC[] {
                    new PIC("Verdera", "Juan", "QA", "10-09-2022", "22-09-2022", "12", "5", "1000,0"),
                    new PIC("Infante", "José", "Deployment", "8-09-2022", "22-09-2022", "14", "7", "900,0") }),
                new ProjectTeam(false, "Analitics",
                new PIC[] {
                    new PIC("Aguilar", "Oswaldo", "Analitics", "1-09-2022", "30-09-2022", "29", "15", "2000,0"),
                    new PIC("Silva", "José", "a", "1-09-2022", "30-09-2022", "29", "15", "3000,0") })
            };

            return teams;
        }

        public override string ToString()
        {
            string programmers = "";
            foreach (var programmer in Programmers)
            {
                Employee e = programmer as Employee;
                programmers += "" + e.ToString(e);
            }
            return "Project team - " + teamName + ":\n" +
                programmers;
        }
    }

}
