using System;
using System.Threading;

namespace countdn
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 15;

            if (args.Length == 1)
            {
                int numMinutes = 15;
                var isValidMins = int.TryParse(args[0], out numMinutes);
                if (isValidMins) minutes = numMinutes;
            }
            string timerDoneText = "lift\noff!";
            BeginCountDown(minutes, timerDoneText);
        }

        static private void BeginCountDown(int minutes, string timerDoneText)
        {
            var countdnPath = @"D:\streamtools\countdn.txt";
            Console.Clear();
            Console.WriteLine($"Beginning countdown from {ToTimerFormat(minutes * 60)}");
            Thread.Sleep(3000);
            for (int seconds = minutes * 60; seconds > 0; seconds--)
            {
                Console.Clear();
                System.IO.File.WriteAllText(countdnPath, ToTimerFormat(seconds));
                Console.WriteLine(ToTimerFormat(seconds));
                Thread.Sleep(1000);
            }
            Console.Clear();
            Console.WriteLine(timerDoneText);
            System.IO.File.WriteAllText(countdnPath,timerDoneText);
        }

        static private string ToTimerFormat(int seconds)
        {
            return $"{(seconds/60).ToString("00.")}:{(seconds%60).ToString("00.")}";
        }
    }
}
