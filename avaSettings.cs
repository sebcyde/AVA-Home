using AVA;
using OpenAI_API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


public class avaSettings
{
    [DllImport("kernel32.dll")]
    private static extern bool FreeConsole();

    private static bool isRunning = true;
    private static bool isStopped = false;

    public static async Task startAVA()
    {

        string API_KEY = API_KEYS.OpenAI_API_KEY;

        OpenAIAPI api = new OpenAIAPI(new APIAuthentication(API_KEY));
        var chat = api.Chat.CreateConversation();
        chat.AppendSystemMessage("You are a female AI personal assistant named 'AVA' that helps the user, 'Sebastian' with various tasks on his computer, similar to Jarvis from Iron Man.");
        chat.AppendUserInput("Greet me and ask me what I'd like to do. Also speak like a cool anime girl from now on");

        Console.Write("AVA: ");
        await foreach (var response in chat.StreamResponseEnumerableFromChatbotAsync())
        {
            Console.Write(response);
        }

        while (isRunning)
        {

            introduceUser();

            string userInput = Console.ReadLine();

            if (isCancellingAVA(userInput))
            {
                beginAVAShutdown();
                chat.AppendUserInput("thats all, thanks for your help");
            } 
            else if (isOpeningSettings(userInput))
            {
                beginAVAShutdown();
                chat.AppendUserInput("pretend you're about to open you settings for me to edit");
                openAVASettings();
            } 
            else if (isCreatingReactApp(userInput))
            {
                beginAVAShutdown();
                chat.AppendUserInput("Wish me luck on the new React app I'm about to make.");
                ReactFunctions.CreateReactApp(); ;
            } 
            else if (isCreatingCApp(userInput))
            {
                beginAVAShutdown();
                chat.AppendUserInput("Wish me luck on the new C# app I'm about to make.");
                CSharpFunctions.CreateNewApp();
            } 
            else if (isStartingEntertainmentMode(userInput))
            {
                beginAVAShutdown();
                chat.AppendUserInput("I'm going to listen to music for a bit, I'll talk to you later.");
                EntertainmentModeClass.EntertainmentMode();
            } 
            else
            {
                chat.AppendUserInput(userInput);
            }

            introduceAVA();

            await foreach (var response in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                Console.Write(response);
            }

            if (isStopped)
            {
                break;
            }
        }

        StopAVA();

    }

    private static void StopAVA()
    {
        Console.WriteLine(" ");
        FreeConsole();
    }

    private static void beginAVAShutdown()
    {
        isStopped = true;
        isRunning = false;
    }

    private static void introduceAVA()
    {
        Console.WriteLine(" ");
        Console.Write("AVA: ");
    }

    private static void introduceUser()
    {
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.Write("You: ");
    }

    private static void openAVASettings()
    {

        ProcessStartInfo openSettingsProfileInfo = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe",
            Arguments = @"C:\Users\SebCy\Documents\Code\1-Projects\02-C#\AVA",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process openSettingsProcess = new Process
        {
            StartInfo = openSettingsProfileInfo
        };

        openSettingsProcess.Start();

    }

    private static bool isOpeningSettings(string input)
    {
        switch (input.ToLower())
        {
            case ("open your settings"):
                return true;
                break;
            case ("show me your settings"):
                return true;
                break;
            case ("open your code"):
                return true;
                break;
            case ("show me your code"):
                return true;
                break;
            default:
                return false;
        }
    }

    private static bool isCreatingReactApp(string input)
    {

        switch (input.ToLower())
        {
            case ("create a new react app"):
                return true;
                break;
            case ("create react app"):
                return true;
                break;
            default:
                return false;
        }

    }

    private static bool isCreatingCApp(string input)
    {

        switch (input.ToLower())
        {
            case ("create a new c# app"):
                return true;
                break;
            case ("create c# app"):
                return true;
                break;
            default:
                return false;
        }

    }

    private static bool isStartingEntertainmentMode(string input)
    {

        switch (input.ToLower())
        {
            case ("start entertainment mode"):
                return true;
                break;
            case ("entertainment mode"):
                return true;
                break;
            default:
                return false;
        }

    }

    private static bool isCancellingAVA(string input)
    {
        if (input.ToLower() == "thats all" || input.ToLower() == "c")
        {
            return true;
        } else
        {
            return false;
        }
    }

}
    

