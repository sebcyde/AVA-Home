using System;

public class DataOrganisation
{
	public static async Task<bool> RefreshJikanData()
	{
        Console.WriteLine(" ");
        Console.WriteLine("AVA: Perfect. Give me two seconds, I'll pull the data and update the database");
        await BashCommands.ChangeDirectory("C://Users/SebCy/Documents/Code/1-Projects/02-C#/DataCollectors/JikanAnimeDataCollector");
        string res = await BashCommands.ExecuteBashCommandAsync("dotnet build");

        if (!res.ToLower().Contains("build succeeded"))
        {
            avaSettings.ErrorLog = res;
            return false;

        } else
        {
            Console.WriteLine(" ");
            Console.Write($"AVA: Okay, I've built the program. Initialising it now, this will take a little while so check back in a bit...");
            Console.WriteLine(" ");
            await Task.Delay(1000);

            await BashCommands.ExecuteBashCommandAsync("dotnet run");
            return true;
        }
    }
}
