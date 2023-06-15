using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MultiThreadingClass
{
    public static void MultiThreadFunctions(Action[] functions)
    {
        Thread[] threads = new Thread[functions.Length];

        for (int i = 0; i < functions.Length; i++)
        {
            int index = i; 

            threads[i] = new Thread(() => functions[index]());
            threads[i].Start();
        }

        for (int i = 0; i < functions.Length; i++)
        {
            threads[i].Join();
        }
    }
}
