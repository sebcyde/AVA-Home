﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EntertainmentModeClass
{
    public static void EntertainmentMode() 
    {

        string[] urls = { 
            "https://www.youtube.com/watch?v=vPotMYbl8IQ&list=PL8nIz55PGxa9bC5IeYljCB7jZ9iK7Bv_k&index=1",
            "https://firebase.google.com/",
            "https://chat.openai.com/"
        };

        StartGoogleChrome(urls);
    }

    private static void StartGoogleChrome(string[] urls)
    {
        try
        {
            string arguments = string.Join(" ", urls);
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", arguments);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to start Google Chrome: " + ex.Message);
        }
    }
}
