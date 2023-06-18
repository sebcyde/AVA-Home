using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CSharpFunctions
{
    public static void CreateNewApp()
    {

        string TypeofApp = "";

        while(TypeofApp.Equals("")) 
        {
            Console.WriteLine(" ");
            Console.Write("AVA: What kind of C# app do you wanna build?");
            TypeofApp = Console.ReadLine();

            if (TypeofApp.Equals("cancel") || TypeofApp.Equals("c"))
            {
                break;
            }
        }

        switch (TypeofApp)
        {
            case "console":
                Console.WriteLine("AVA: Let's do it.");
                CreateConsoleApp();
                break;
            case "api":
                Console.WriteLine("AVA: Let's do it.");
                break;
            default:
                Console.WriteLine("AVA: Alright no worries. Let me know.");
                break;
        }

    }

    public static void CreateConsoleApp()
    {
        Console.WriteLine("Creating new console app.");
    }
}