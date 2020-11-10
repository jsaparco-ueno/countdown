using System;
using System.Threading;

namespace countdn
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = 15;
            string timerDoneText = "lift\noff!";
            BeginCountDown(minutes, timerDoneText);
        }

        static private void BeginCountDown(int minutes, string timerDoneText)
        {
            Console.WriteLine("Beginning countdown");
            for (int seconds = minutes * 60; seconds > 0; seconds--)
            {
                System.IO.File.WriteAllText(@"D:\projects\countdn\countdn.txt", ToTimerFormat(seconds));
                Console.WriteLine(ToTimerFormat(seconds));
                Thread.Sleep(1000);
            }
            Console.WriteLine(timerDoneText);
            System.IO.File.WriteAllText(@"D:\projects\countdn\countdn.txt",timerDoneText);
        }

        static private string ToTimerFormat(int seconds)
        {
            return $"{(seconds/60).ToString("00.")}:{(seconds%60).ToString("00.")}";
        }
    }
}
