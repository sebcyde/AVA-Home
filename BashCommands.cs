using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
