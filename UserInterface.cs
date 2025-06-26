using System;
using System.Threading;
using System.Numerics;

namespace Education_PR_2025
{
    public class UserInterface
    {
        private readonly ErrorInfo _error; 
        public string _nextMethodToRun = "Start"; 

        public UserInterface()
        {
            _error = new ErrorInfo();
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
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
                    case "RunRSA":
                        RunRSA();
                        break;
                    case "RunDH":
                        RunDH();
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
            Console.Clear();
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
                _nextMethodToRun = "RunRSA";
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
        public void RunRSA()
        {
            Console.Clear();
            try
            {
                // Получаем входные данные от пользователя
                (BigInteger p, BigInteger q, BigInteger message) = RSAAlgorithm.GetInputFromUser();

                // Генерируем ключи
                (BigInteger publicKey, BigInteger privateKey, BigInteger n) = RSAAlgorithm.GenerateKeys(p, q);

                Console.WriteLine($"Открытый ключ (e, n): ({publicKey}, {n})");
                Console.WriteLine($"Закрытый ключ (d, n): ({privateKey}, {n})");

                // Шифруем сообщение
                BigInteger ciphertext = RSAAlgorithm.Encrypt(message, publicKey, n);
                Console.WriteLine($"Зашифрованное сообщение: {ciphertext}");

                // Расшифровываем сообщение
                BigInteger decryptedMessage = RSAAlgorithm.Decrypt(ciphertext, privateKey, n);
                Console.WriteLine($"Расшифрованное сообщение: {decryptedMessage}");

                Console.WriteLine("\n------------------------------------------------------------------------------------------\n\nВернутся в начальное меню ?\n1 - Да\n2 - Начать заново RSA");
                char input = Console.ReadKey(true).KeyChar;
                if (input == '1')
                    _nextMethodToRun = "Start";
                else if (input == '2')
                {
                    Console.Clear();
                    _nextMethodToRun = "RunRSA";
                }
                else
                {
                    Console.WriteLine("пожалуйста выберите верное действие");
                }
            }
            catch (ArgumentException ex)
            {
                _error.Set($"Ошибка, {ex.Message}", 03, this);
            }
        }

        public void AcceptDifHell()
        {
            Console.Clear();
            Console.WriteLine("Вы уверенны что хотите запустить задачу выполнения протокола Диффи-Хелман ?\n1 - Да\n2 - Нет");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1')
                _nextMethodToRun = "RunDH";
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
        public void RunDH() 
        {
            Console.Clear();
            try
            {
                // Получаем входные данные от пользователя
                (BigInteger p, BigInteger g, BigInteger a, BigInteger b) = DiffieHellmanProtocol.GetInputFromUser();

                // Запускаем протокол Диффи-Хеллмана
                (BigInteger sharedKeyA, BigInteger sharedKeyB) = DiffieHellmanProtocol.RunDiffieHellman(p, g, a, b);

                Console.WriteLine("\n------------------------------------------------------------------------------------------\n\nВернутся в начальное меню ?\n1 - Да\n2 - Начать протокол Деффи-Хелман ?");
                char input = Console.ReadKey(true).KeyChar;
                if (input == '1')
                    _nextMethodToRun = "Start";
                else if (input == '2')
                {
                    Console.Clear();
                    _nextMethodToRun = "RunDH";
                }
                else
                {
                    Console.WriteLine("пожалуйста выберите верное действие");
                }
            }
            catch (ArgumentException ex)
            {
                _error.Set($"Ошибка, {ex.Message}", 03, this);
            }

        }
    }
}