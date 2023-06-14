using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReactFunctions
{
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
            Console.WriteLine("I'm going to install your preferred packages now.");
            Console.WriteLine("Starting Multithread mode.");

            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(currentDirectory);

            string[] packagesOne = { "axios", "react-router-dom", "react-redux" };
            Task[] tasksOne = new Task[3];

            //string[] packagesTwo = { "firebase", "sass", "dotenv" };

            // Start a task for each package installation
            for (int i = 0; i < tasksOne.Length; i++)
            {
                string packageName = packagesOne[i];
                tasksOne[i] = Task.Run(() => installPackage(packageName));
            }

            // Wait for all tasks to complete
            Task.WaitAll(tasksOne);

            Console.WriteLine("And we're all done with the installations.");
            Console.WriteLine("I'll open the project in VS Code now. See ya later.");

            // Open in Visual Studio Code
            ProcessStartInfo codeStartInfo = new ProcessStartInfo
            {
                FileName = @"C:\Users\SebCy\AppData\Local\Programs\Microsoft VS Code\Code.exe",
                Arguments = ".",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process codeProcess = new Process
            {
                StartInfo = codeStartInfo
            };

            codeProcess.Start();
            codeProcess.WaitForExit();
            // DetachProcessOnWindows(codeProcess);
            // CloseTerminalOnWindows();
        }
        else
        {
            Console.WriteLine("I ran into an error installing the default packages: 'npm install'.");
            Console.WriteLine("I'm afraid you'll have to take it from here. Happy coding.");
        }
    }

    public static void installPackage(string packageName)
    {

        // Run 'npm install'
        ProcessStartInfo packageInstallation = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\nodejs\npm.cmd",
            Arguments = $"install {packageName}",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process packageInstallProcess = new Process
        {
            StartInfo = packageInstallation
        };

        packageInstallProcess.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        packageInstallProcess.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data);
            }
        };

        packageInstallProcess.Start();
        packageInstallProcess.BeginOutputReadLine();
        packageInstallProcess.BeginErrorReadLine();
        packageInstallProcess.StandardInput.WriteLine("y");
        packageInstallProcess.WaitForExit();

        if (packageInstallProcess.ExitCode == 0)
        {
            Console.WriteLine($"I have finished installing {packageName}.");
        }
        else
        {
            Console.WriteLine($"Oops. I ran into an error installing {packageName}.");
            Console.WriteLine("I'm afraid you'll have to take it from here. Happy coding.");
        }
    }

    private static void DetachProcessOnWindows(Process process)
    {
        try
        {
            // Use Windows-specific code to detach process
            if (process.StartInfo.UseShellExecute)
            {
                Console.WriteLine("Detaching processes.");
                Process.Start("taskkill", $"/PID {process.Id}");
            }
            else
            {
                // Obtain the underlying process handle
                IntPtr processHandle = process.SafeHandle.DangerousGetHandle();

                // Detach the process from the console
                NativeMethods.FreeConsole();

                // Attach the process to a new console
                NativeMethods.AttachConsole(ATTACH_PARENT_PROCESS);

                // Close the original process handle
                NativeMethods.CloseHandle(processHandle);
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine("Failed to detach process on Windows: " + ex.Message);
        }
    }

    private static void CloseTerminalOnWindows()
    {
        try
        {
            // Use Windows-specific code to close the terminal
            Process.Start("taskkill", $"/PID {Process.GetCurrentProcess().Id}");
        }
        catch (Exception ex)
        {
            // Handle any exceptions
            Console.WriteLine("Failed to close terminal on Windows: " + ex.Message);
        }
    }

    private static class NativeMethods
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool AttachConsole(uint dwProcessId);

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool FreeConsole();

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
    }

    private const uint ATTACH_PARENT_PROCESS = 0xFFFFFFFF;

}
