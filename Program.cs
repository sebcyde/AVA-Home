using OpenAI_API;
using System;
using System.Diagnostics;


namespace AVA
{
    class Program
    {

        static async Task Main(string[] args)
        {

            await avaSettings.startAVA();
       


            //Console.WriteLine("Hello Sebastian.");
            //Console.WriteLine("Are we coding?");

            //string command = Console.ReadLine();

            //if (command == "yes" || command == "y")
            //{
            //    Console.WriteLine("Lovely.");

            //    string selectedLanguage = "";


            //    // Selecting a language
            //    while (string.IsNullOrEmpty(selectedLanguage))
            //    {
            //        Console.WriteLine("What language will you be using?");
            //        Console.WriteLine("1. React");
            //        Console.WriteLine("2. Next");
            //        Console.WriteLine("3. C#");
            //        Console.WriteLine("4. Java");
            //        Console.WriteLine("5. Node");
            //        Console.WriteLine("6. Other");

            //        string userInput = Console.ReadLine();

            //        // To cancel and exit
            //        if (userInput.Equals("c", StringComparison.OrdinalIgnoreCase))
            //        {
            //            return;
            //        }

            //        switch (userInput)
            //        {
            //            case "1":
            //                selectedLanguage = "React";
            //                break;
            //            case "2":
            //                selectedLanguage = "Next";
            //                break;
            //            case "3":
            //                selectedLanguage = "C#";
            //                break;
            //            case "4":
            //                selectedLanguage = "Java";
            //                break;
            //            case "5":
            //                selectedLanguage = "Node";
            //                break;
            //            case "6":
            //                selectedLanguage = "Other";
            //                break;
            //            default:
            //                Console.WriteLine("Thats not in my database.");
            //                Console.WriteLine("If you want something else, choose option 6.");
            //                Console.WriteLine("Or you can cancel by preccing 'c'.");
            //                break;
            //        }
            //    }


            //    // After Selecting a language
            //    switch (selectedLanguage)
            //    {
            //        case "React":
            //            ReactFunctions.CreateReactApp();
            //            break;
            //        case "Next":
            //            selectedLanguage = "Next";
            //            break;
            //        case "C#":
            //            selectedLanguage = "C#";
            //            break;
            //        case "Java":
            //            selectedLanguage = "Java";
            //            break;
            //        case "Node":
            //            selectedLanguage = "Node";
            //            break;
            //        case "Other":
            //            selectedLanguage = "Other";
            //            break;
            //        default:
            //            break;
            //    }


            //}
            //else if (command == "settings")
            //{
            //    avaSettings.OpenAVASettingsInVisualStudio();
            //}
            //else
            //{
            //    Console.WriteLine("Thats a shame.");
            //    Console.WriteLine("Call me again when you need me.");


            //}

        }


    }
}