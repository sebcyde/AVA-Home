using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class BashCommands
{
    public static void ExecuteBashCommand(string command)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "bash.exe",
            Arguments = $"-c \"{command}\"",
            UseShellExecute = false
        };

        Process process = new Process
        {
            StartInfo = startInfo
        };

        process.Start();
        process.WaitForExit();
    }

    public static string ChangeDirectory()
    {
        string location = "";
        string directoryPath = "";

        while (location.Equals(""))
        {
            Console.WriteLine("");
            Console.Write("AVA: ");
            Console.Write("Where are we going?");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("You: ");
            location = Console.ReadLine();
        }

        switch (location.ToLower())
        {
            case ("react"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\01-React";
                break;
            case ("c#"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\02-C#";
                break;
            case ("node"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\03-Node";
                break;
            case ("next"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\04-Next";
                break;
            case ("fs"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\05-Full-Stack";
                break;
            case ("native"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\06-Native";
                break;
            case ("java"):
                directoryPath = @"C:\Users\SebCy\Documents\Code\1-Projects\07-Java";
                break;
            default:
                break;
        }

        ProcessStartInfo processInfo = new ProcessStartInfo
        {
            FileName = "bash.exe",
            Arguments = $"-c \"cd '{directoryPath}'\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        Process process = new Process
        {
            StartInfo = processInfo
        };

        process.Start();
        process.WaitForExit();

        return directoryPath;
    }

    public static string MakeDirectory(string currentDirectory)
    {
        string NewDirectoryName = "";

        while (NewDirectoryName.Equals(""))
        {
            Console.WriteLine("");
            Console.Write("AVA: ");
            Console.Write("What shall I call the new directory?");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("You: ");
            NewDirectoryName = Console.ReadLine();
        }

        string path = Path.Combine(currentDirectory, NewDirectoryName);

        Directory.CreateDirectory(path);

        return NewDirectoryName;
    }

}
