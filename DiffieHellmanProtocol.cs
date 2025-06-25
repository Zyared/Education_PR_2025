using System;
using System.Numerics;

namespace Education_PR_2025
{
    public class DiffieHellmanProtocol
    {
        // Метод для проверки числа на простоту
        private static bool IsPrime(BigInteger number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (BigInteger i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Метод для ввода данных от пользователя (p, g, a, b)
        public static (BigInteger p, BigInteger g, BigInteger a, BigInteger b) GetInputFromUser()
        {
            BigInteger p, g, a, b;

            while (true)
            {
                Console.Write("Введите простое число p (большое простое число): ");
                if (BigInteger.TryParse(Console.ReadLine(), out p))
                {
                    if (IsPrime(p))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введенное число p не является простым. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для p. Попробуйте снова.");
                }
            }

            while (true)
            {
                Console.Write("Введите первообразный корень g по модулю p (1 < g < p): ");
                if (BigInteger.TryParse(Console.ReadLine(), out g))
                {
                    if (g >= 1 && g < p)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введенное число g должно быть больше 1 и меньше p. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для g. Попробуйте снова.");
                }
            }

            while (true)
            {
                Console.Write("Введите секретное число a для пользователя A (1 < a < p): ");
                if (BigInteger.TryParse(Console.ReadLine(), out a))
                {
                    if (a >= 1 && a < p)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введенное число a должно быть больше 1 и меньше p. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для a. Попробуйте снова.");
                }
            }

            while (true)
            {
                Console.Write("Введите секретное число b для пользователя B (1 < b < p): ");
                if (BigInteger.TryParse(Console.ReadLine(), out b))
                {
                    if (b >= 1 && b < p)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введенное число b должно быть больше 1 и меньше p. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для b. Попробуйте снова.");
                }
            }

            return (p, g, a, b);
        }

        // Метод для вычисления открытого ключа
        public static BigInteger CalculatePublicKey(BigInteger g, BigInteger secretKey, BigInteger p)
        {
            return BigInteger.ModPow(g, secretKey, p);
        }

        // Метод для вычисления общего секретного ключа
        public static BigInteger CalculateSharedSecret(BigInteger otherPublicKey, BigInteger secretKey, BigInteger p)
        {
            return BigInteger.ModPow(otherPublicKey, secretKey, p);
        }

        // Метод для запуска протокола Диффи-Хеллмана
        public static (BigInteger sharedKeyA, BigInteger sharedKeyB) RunDiffieHellman(BigInteger p, BigInteger g, BigInteger a, BigInteger b)
        {
            // 1. Вычисление открытых ключей
            BigInteger publicKeyA = CalculatePublicKey(g, a, p);
            BigInteger publicKeyB = CalculatePublicKey(g, b, p);

            Console.WriteLine($"Открытый ключ пользователя A: {publicKeyA}");
            Console.WriteLine($"Открытый ключ пользователя B: {publicKeyB}");

            // 2. Обмен открытыми ключами (имитация)

            // 3. Вычисление общего секретного ключа
            BigInteger sharedKeyA = CalculateSharedSecret(publicKeyB, a, p);
            BigInteger sharedKeyB = CalculateSharedSecret(publicKeyA, b, p);

            Console.WriteLine($"Общий секретный ключ пользователя A: {sharedKeyA}");
            Console.WriteLine($"Общий секретный ключ пользователя B: {sharedKeyB}");

            if (sharedKeyA != sharedKeyB)
            {
                Console.WriteLine("Внимание: Общие секретные ключи не совпадают! Проверьте входные данные и алгоритм.");
            }

            return (sharedKeyA, sharedKeyB);
        }
    }
}