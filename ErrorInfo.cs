using System;
using System.Threading;
using Education_PR_2025;

namespace Education_PR_2025
{
    public class ErrorInfo
    {
        UserInterface userInterface = new UserInterface();
        public void Set(string error, int code)
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

            if (code == 01)
            {
                userInterface.Start();
            }
            else if (code == 02)
            {
                userInterface.AcceptRsa();
            }
            else if (code == 03)
            {
                userInterface.AcceptDifHell();
            };
        }
    }
}
