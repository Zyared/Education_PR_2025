using System;
using System.Threading;
using Education_PR_2025;

namespace Education_PR_2025
{
    public class UserInterface
    {
        ErrorInfo error = new ErrorInfo();
        public void Start()
        {
            Console.WriteLine("Выберете нужное действие: \n1 - алгоритм RSA \n2 - Протокол Диффи-Хелман \nДля закрытия программы нажмите 0");
            char input = Console.ReadKey(true).KeyChar;

            if (input == '1')
                AcceptRsa();
            else if (input == '2')
                return;
            else if (input == '0') 
                Environment.Exit(0);
            else
                error.Set("Пожалуйста выберите нужное действие", 01);
        }

        public void AcceptRsa()
        {
            Console.Clear();
            Console.WriteLine("Вы уверенны что хотите запустить задачу выполнения алгоритма RSA ?\n1 - Да\n2 - Нет");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1')
                return;
            else if (input == '2')
            {
                Console.Clear();
                Start();
            }
            else
                error.Set("Пожалуйста выберите нужное действие", 02);
            return;
        }
        public void AcceptDifHell()
        {
            Console.Clear();
            Console.WriteLine("Вы уверенны что хотите запустить задачу выполнения протокола Диффи-Хелман ?\n1 - Да\n2 - Нет");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1')
                return;
            else if (input == '2')
            {
                Console.Clear();
                Start();
            }
            else
                error.Set("Пожалуйста выберите нужное действие", 03);
            return;
        }

    }
}
