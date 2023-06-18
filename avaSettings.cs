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
        chat.AppendSystemMessage("You are a female AI personal assistant named 'AVA' that helps the user, 'Sebastian' with various tasks on his computer, similar to Jarvis from Iron Man. Speak like a cool anime girl.");
        
        
        chat.AppendUserInput("Greet me and ask me what I'd like to do. Also speak like a cool anime girl from now on");

        Console.Write("AVA: ");
        await foreach (var response in chat.StreamResponseEnumerableFromChatbotAsync())
        {
            Console.Write(response);
        }

        while (isRunning)
        {

            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            // Check if the user wants to stop AVA
            if (userInput.ToLower() == "thats all")
            {
                isStopped = true;
                isRunning = false;
                chat.AppendUserInput("thats all, thanks for your help");
            }

            // Open this project in Visual Studio
            if (userInput.ToLower() == "open your settings" || userInput.ToLower() == "show me your settings")
            {
                isStopped = true;
                isRunning = false;
                chat.AppendUserInput("pretend you're about to open you settings for me to edit");
                openAVASettings();
            }

            // Spin up a custom React App with optional Typescript
            if (userInput.ToLower() == "create a new react app" || userInput.ToLower() == "create react app")
            {
                isStopped = true;
                isRunning = false;
                chat.AppendUserInput("Wish me luck on the new React app I'm about to make.");
                ReactFunctions.CreateReactApp(); ;
            }

            // Spin up a custom C# App
            if (userInput.ToLower() == "create a new c# app" || userInput.ToLower() == "create c# app"){
                isStopped = true;
                isRunning = false;
                chat.AppendUserInput("Wish me luck on the new C# app I'm about to make.");
                CSharpFunctions.CreateNewApp();
            }

            // Start entertainment mode without any codeing stuff
            if (userInput.ToLower() == "start entertainment mode")
            {
                isStopped = true;
                isRunning = false;
                chat.AppendUserInput("I'm going to listen to music for a bit, I'll talk to you later.");
                //BashCommands.ExecuteBashCommand("printf \"\\033[3;7;10t\"");
                EntertainmentModeClass.EntertainmentMode();
            }

            Console.WriteLine(" ");
            Console.Write("AVA: ");
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

    public static void StopAVA()
    {
        Console.WriteLine(" ");
        FreeConsole();
        // Add any additional cleanup or termination logic here
    }


    public static void openAVASettings()
    {

        // Run 'npm install'
        ProcessStartInfo openSettingsProfileInfo = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe",
            Arguments = @"C:\Users\SebCy\Documents\Code\1-Projects\02-C#\AVA\Program.cs",
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
        //FreeConsole();


    }
}
    

