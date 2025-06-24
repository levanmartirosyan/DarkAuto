using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class LoaderService
    {
        public static void Spinner(int duration)
        {
            var symbols = new[] { "/", "-", "\\", "|" };
            int counter = 0;
            int time = 0;
            while (time < duration)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(symbols[counter % symbols.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
                counter++;
                time += 100;

                Console.ResetColor();
            }
        }
    }
}
