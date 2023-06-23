using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class BashCommands
{
    public static async Task<string> ExecuteBashCommandAsync(string command)
    {

        Console.WriteLine(" ");
        Console.WriteLine($"Initialised Command: {command}.");
        Console.WriteLine(" ");
        Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");
        Console.WriteLine(" ");

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "bash.exe",
            Arguments = $"-c \"{command}\"",
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        Process process = new Process
        {
            StartInfo = startInfo
        };

        // Set up event handlers for capturing output
        StringBuilder outputBuilder = new StringBuilder();

        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
                outputBuilder.AppendLine(e.Data);
                // Output the log to the console in real-time
            }
        };

        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();


        return outputBuilder.ToString();
    }

    public static async Task<string> ChangeDirectory(string location = "")
    {

        string directoryPath = "";

        if (location.Equals("")) {
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
                directoryPath = location;
                break;
        }

        Directory.SetCurrentDirectory(directoryPath);
        await Task.Delay(1000);

        Console.WriteLine(" ");


        return directoryPath;
    }

    public static async Task<string> MakeDirectory(string currentDirectory)
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
