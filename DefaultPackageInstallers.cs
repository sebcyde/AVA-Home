using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DefaultPackageInstallers
{
    public static void ReactPackagesInstall()
    {
        Console.WriteLine("I'm installing your preferred packages now.");

        string[] packagesOne = { 
            "axios", 
            "react-router-dom", 
            "react-redux", 
            "firebase", 
            "sass", 
            "dotenv" 
        };

        for (int i = 0; i < packagesOne.Length; i++)
        {
            Console.WriteLine($"Installing {packagesOne[i]}...");
            NPMInstaller(packagesOne[i]);
        }

        Console.WriteLine("And we're all done with the installations.");
    }


    public static void NextPackagesInstall()
    {
        Console.WriteLine("I'm installing your preferred packages now.");

        string[] packagesOne = { "axios", "react-redux", "firebase", "sass", "dotenv" };

        for (int i = 0; i < packagesOne.Length; i++)
        {
            NPMInstaller(packagesOne[i]);
        }

        Console.WriteLine("And we're all done with the installations.");
    }


    public static void NodePackagesInstall()
    {
        Console.WriteLine("I'm installing your preferred packages now.");

        string[] packagesOne = { "axios", "react-redux", "firebase", "sass", "dotenv" };

        for (int i = 0; i < packagesOne.Length; i++)
        {
            NPMInstaller(packagesOne[i]);
        }

        Console.WriteLine("And we're all done with the installations.");
    }


    public static void NPMInstaller(string packageName)
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



}
