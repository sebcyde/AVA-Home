using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

public class ReactFunctions
{

    [DllImport("kernel32.dll")]
    private static extern bool FreeConsole();
    public static void CreateReactApp()
    {

        Console.WriteLine("And the project name?");
        string projectName = Console.ReadLine();

        Console.WriteLine("And I assume we're using typescript?");
        string useTS = Console.ReadLine();

        Boolean typescript;

        if (useTS.Equals("y", StringComparison.OrdinalIgnoreCase)) 
        {
            typescript = true;
        } else {
            typescript = false;
        }


        if (typescript)
        {
            // Implementation for creating a TS React app
            Console.WriteLine("Perfect. give me a second.");
            Console.WriteLine("Creating a new TS React instance.");
            Console.WriteLine($"creating {projectName}.");

            executeCommand(projectName, true);

        } else
        {
            // Implementation for creating a non-TS React app
            Console.WriteLine("Got it. Give me a second.");
            Console.WriteLine($"creating {projectName}.");

            executeCommand(projectName, false);

        }

    }

    public static void executeCommand(string projectName, Boolean typescript) {

        string targetDirectory = @"C:\Users\SebCy\Documents\Code\1-Projects\01-React";
        string arg = "";
        if (typescript) {
            arg = $"create vite@latest {projectName} -- --template react-ts";
        } else
        {
            arg = $"create vite@latest {projectName} -- --template react";
        }

        // Set up the process start info
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            WorkingDirectory = targetDirectory,
            FileName = @"C:\Program Files\nodejs\npm.cmd",
            Arguments = arg,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Start the process
        Process process = new Process
        {
            StartInfo = startInfo
        };

        process.OutputDataReceived += (sender, e) =>
        {
            // Display the output in the console
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        process.Start();

        // Begin asynchronous reading of the output stream
        process.BeginOutputReadLine();

        process.StandardInput.WriteLine("y");

        // Wait for the process to exit
        process.WaitForExit();

        // Check the exit code
        int exitCode = process.ExitCode;

        if (exitCode == 0)
        {
            Console.WriteLine("Perfect. Thats all done.");
            initialiseNewApp(targetDirectory, projectName);
        }
        else
        {
            Console.WriteLine($"There was an issue creating {projectName}.");
            Console.WriteLine("Please try again");
        }

    }

    public static void initialiseNewApp(string appLocation, string projectName)
    {
        Console.WriteLine("Changing directories.");

        // Change current directory to the React app directory
        string appDirectory = Path.Combine(appLocation, projectName);
        Directory.SetCurrentDirectory(appDirectory);


        Console.WriteLine("Installing default packages...");
        // Run 'npm install'
        ProcessStartInfo npmInstallStartInfo = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\nodejs\npm.cmd",
            Arguments = "install",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process npmInstallProcess = new Process
        {
            StartInfo = npmInstallStartInfo
        };

        npmInstallProcess.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        npmInstallProcess.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        npmInstallProcess.Start();
        npmInstallProcess.BeginOutputReadLine();
        npmInstallProcess.BeginErrorReadLine();
        npmInstallProcess.StandardInput.WriteLine("y");
        npmInstallProcess.WaitForExit();

        if (npmInstallProcess.ExitCode == 0)
        {
            Console.WriteLine($"I have finished installing the default packages for {projectName}.");
            

            string EMode = "";
            while (string.IsNullOrEmpty(EMode))
            {
            Console.WriteLine("Shall I also start entertainment mode?");
                EMode = Console.ReadLine();
            }


            // Multithread entertainment and packge installs
            if (EMode.Equals("y") || EMode.Equals("yes"))
            {
                Action[] Processes = { 
                    () => EntertainmentModeClass.EntertainmentMode(), 
                    () => DefaultPackageInstallers.ReactPackagesInstall()
                    };

                MultiThreadingClass.MultiThreadFunctions(Processes);
                
            } else
            {
                DefaultPackageInstallers.ReactPackagesInstall();
            }


            Console.WriteLine("All processes complete");

            // Open in Visual Studio Code
            ProcessStartInfo codeStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\SebCy\AppData\Local\Programs\Microsoft VS Code\Code.exe",
                Arguments = ".",
                UseShellExecute = true,
                CreateNoWindow = true
            };

            Process codeProcess = new Process
            {
                StartInfo = codeStartInfo
            };

            codeProcess.Start();
            Console.WriteLine("All done. Feel free to close this console.");
            FreeConsole();

        }
        else
        {
            Console.WriteLine("I ran into an error installing the default packages: 'npm install'.");
            Console.WriteLine("I'm afraid you'll have to take it from here. Happy coding.");
        }
    }

}
