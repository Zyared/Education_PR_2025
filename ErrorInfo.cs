using System;
using System.Threading;
using Education_PR_2025;

namespace Education_PR_2025
{
    public class ErrorInfo
    {
        public void Set(string error, int code, UserInterface ui)
        {
            Console.WriteLine($"Ошибка, {error}\nКод ошибки: {code}\n");
            int seconds = 1;
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($"Попробуйте снова через {i} с.");
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.CursorLeft - (i.ToString().Length + 26), Console.CursorTop);
            }
            Console.Clear();
        }
    }
}
