using System;
using System.Numerics;

namespace Education_PR_2025
{
    public class RSAAlgorithm
    {
        // Метод для проверки числа на простоту (неоптимизированный для простоты примера)
        private static bool IsPrime(BigInteger number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Метод для нахождения наибольшего общего делителя (НОД)
        private static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Метод для нахождения мультипликативной обратной величины по модулю (расширенный алгоритм Евклида)
        private static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, x0 = 0, x1 = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                // q is quotient
                BigInteger q = a / m;
                BigInteger t = m;

                // m is remainder now, process same as
                // Euclid's algo
                m = a % m;
                a = t;
                t = x0;

                x0 = x1 - q * x0;
                x1 = t;
            }

            // Make x1 positive
            if (x1 < 0)
                x1 += m0;

            return x1;
        }


        // Метод для генерации ключей RSA
        public static (BigInteger publicKey, BigInteger privateKey, BigInteger n) GenerateKeys(BigInteger p, BigInteger q)
        {
            if (!IsPrime(p) || !IsPrime(q))
            {
                throw new ArgumentException("Оба числа p и q должны быть простыми.");
            }

            if (p == q)
            {
                throw new ArgumentException("Числа p и q не должны быть равны.");
            }

            // 1. Вычисляем n
            BigInteger n = p * q;

            // 2. Вычисляем функцию Эйлера (phi)
            BigInteger phi = (p - 1) * (q - 1);

            // 3. Выбираем e (1 < e < phi), взаимно простое с phi
            BigInteger e = 3; // Начинаем с небольшого простого числа
            while (e < phi)
            {
                if (GCD(e, phi) == 1)
                    break;
                e++;
            }

            // 4. Вычисляем d (мультипликативная обратная величина e по модулю phi)
            BigInteger d = ModInverse(e, phi);

            return (e, d, n); // Возвращаем открытый ключ (e, n), закрытый ключ (d, n) и n
        }

        // Метод для шифрования сообщения
        public static BigInteger Encrypt(BigInteger message, BigInteger publicKey, BigInteger n)
        {
            return BigInteger.ModPow(message, publicKey, n);
        }

        // Метод для расшифровки сообщения
        public static BigInteger Decrypt(BigInteger ciphertext, BigInteger privateKey, BigInteger n)
        {
            return BigInteger.ModPow(ciphertext, privateKey, n);
        }

        public static (BigInteger p, BigInteger q, BigInteger message) GetInputFromUser()
        {
            BigInteger p, q, message;

            while (true)
            {
                Console.Write("Введите простое число p: ");
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
                Console.Write("Введите простое число q (не равное p): ");
                if (BigInteger.TryParse(Console.ReadLine(), out q))
                {
                    if (IsPrime(q))
                    {
                        if (p != q)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Число q не должно быть равно p. Попробуйте снова.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введенное число q не является простым. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для q. Попробуйте снова.");
                }
            }

            while (true)
            {
                Console.Write("Введите сообщение для шифрования (число): ");
                if (BigInteger.TryParse(Console.ReadLine(), out message))
                {
                    if (message > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Сообщение должно быть положительным числом. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод для сообщения. Попробуйте снова.");
                }
            }

            return (p, q, message);
        }
    }
}