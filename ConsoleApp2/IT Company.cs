using ConsoleApp2;
using System;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
class ITCompany
{
    int numberOfTeams;
    int numberOfProgrammers;
    int daysElapsed;
    int daysRemaining;
    ProjectTeam[] teams;

    public static ITCompany companyData;

    public ITCompany(int numberOfTeams, int numberOfProgrammers, int daysElapsed, int daysRemaining, ProjectTeam[] teams)
    {
        this.numberOfTeams = numberOfTeams;
        this.numberOfProgrammers = numberOfProgrammers;
        this.daysElapsed = daysElapsed;
        this.daysRemaining = daysRemaining;
        this.teams = teams;
    }



    static void Main(String[] args)
    {

        string fileName = "data.json";
        string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\" + fileName);
        string sFilePath = Path.GetFullPath(sFile);

        if (!File.Exists(sFilePath))
        {
            createFile(sFilePath);
        }
        readFile(sFilePath);
        updateFile(sFilePath);
        printCompanyData(companyData.ToString());

    }


    public static void createFile(string filePath)
    {
        ProjectTeam[] teams = ProjectTeam.CreateBaseTeams();

        var options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(teams, options);

        File.WriteAllText(filePath, jsonString);

    }
    public static void readFile(string filePath)
    {
        string jsonString = File.ReadAllText(filePath);
        ProjectTeam[] teams = JsonSerializer.Deserialize<ProjectTeam[]>(jsonString)!;

        int numberOfTeams = teams.Length;
        int numberOfProgrammers = 0;
        foreach (var team in teams)
        {
            foreach (var programmer in team.Programmers)
            {
                numberOfProgrammers++;
            }
        }

        int daysConsummed = 0;
        foreach (var team in teams)
        {
            foreach (var programmer in team.Programmers)
            {
                try
                {
                    daysConsummed += Int32.Parse(programmer.DaysElapsed);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse");
                }
            }
        }

        int totalDuration = 0;
        foreach (var team in teams)
        {
            foreach (var programmer in team.Programmers)
            {
                try
                {
                    totalDuration += Int32.Parse(programmer.Duration);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse");
                }
            }
        }

        int remainingDays = totalDuration - daysConsummed;

        companyData = new ITCompany(numberOfTeams, numberOfProgrammers, daysConsummed, remainingDays, teams);

    }

    public static void updateFile(string filePath)
    {

        foreach (var team in companyData.teams)
        {
            foreach (var programmer in team.Programmers)
            {
                Employee e = programmer as Employee;
                programmer.DaysElapsed = e.updateWork(e);
            }
        }

        var options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(companyData.teams, options);

        File.WriteAllText(filePath, jsonString);
    }

    public static void printCompanyData(string companyDataText)
    {

        Console.Write(companyDataText);

    }

    public override string ToString()
    {
        string teamsList = "";
        foreach (var team in teams)
        {
            teamsList += team.ToString();
        }
        string report = "IT COMPANY - REPORT \n" +
            "\nIT Company is actually composed of " + companyData.numberOfTeams + " Project Teams and " + companyData.numberOfProgrammers + " Programmers.\n"
            + "\nThis month " + companyData.daysElapsed + " days have been consummed by " + companyData.numberOfProgrammers + " programmers and " + companyData.daysRemaining + " days still in charge."
            + "\nPROJECT TEAMS DETAILS:\n"
            + teamsList;
        return report;
    }

}