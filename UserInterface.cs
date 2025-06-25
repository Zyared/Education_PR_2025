using System;
using System.Threading;

namespace Education_PR_2025
{
    public class UserInterface
    {
        private readonly ErrorInfo _error; 
        public string _nextMethodToRun = "Start"; 

        public UserInterface()
        {
            _error = new ErrorInfo();
        }

        public void Run() // Главный метод, который запускает приложение
        {
            while (true)
            {
                switch (_nextMethodToRun)
                {
                    case "Start":
                        Start();
                        break;
                    case "AcceptRsa":
                        AcceptRsa();
                        break;
                    case "AcceptDifHell":
                        AcceptDifHell();
                        break;
                    case "Exit":
                        return; // Завершаем приложение
                    default:
                        Console.WriteLine("Ошибка: Неизвестный метод для запуска.");
                        return;
                }
            }
        }

        public void Start()
        {
            Console.WriteLine("Выберете нужное действие: \n1 - алгоритм RSA \n2 - Протокол Диффи-Хелман \nДля закрытия программы нажмите 0");
            char input = Console.ReadKey(true).KeyChar;

            if (input == '1')
            {
                _nextMethodToRun = "AcceptRsa"; 
            }
            else if (input == '2')
            {
                _nextMethodToRun = "AcceptDifHell";
            }
            else if (input == '0')
            {
                _nextMethodToRun = "Exit"; 
            }
            else
            {
                _error.Set("Пожалуйста выберите нужное действие", 01, this);
            }
        }

        public void AcceptRsa()
        {
            Console.Clear();
            Console.WriteLine("Вы уверенны что хотите запустить задачу выполнения алгоритма RSA ?\n1 - Да\n2 - Нет");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1')
                _nextMethodToRun = "Exit";
            else if (input == '2')
            {
                Console.Clear();
                _nextMethodToRun = "Start";
            }
            else
            {
                _error.Set("Пожалуйста выберите нужное действие", 02, this);
            }
        }

        public void AcceptDifHell()
        {
            Console.Clear();
            Console.WriteLine("Вы уверенны что хотите запустить задачу выполнения протокола Диффи-Хелман ?\n1 - Да\n2 - Нет");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1')
                _nextMethodToRun = "Exit";
            else if (input == '2')
            {
                Console.Clear();
                _nextMethodToRun = "Start";
            }
            else
            {
                _error.Set("Пожалуйста выберите нужное действие", 03, this);
            }
        }

    }
}