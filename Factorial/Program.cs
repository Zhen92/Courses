using System;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ulong n;
                ulong count = 0;
                double proizv = 1;

                Console.Write("введите число, факториал которого вам нужен: ");
                while (!ulong.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("АЛО, введите корректное число");
                }

                //количество символов в факториалe
                for (ulong i = 1; i <= n; i++)
                {
                    proizv *= i;
                    while (proizv >= 1)
                    {
                        count++;
                        proizv /= 10;
                    }
                }

                ulong[] array = new ulong[count];

                array[count - 1] = 1;
                for (ulong i = 1; i <= n; i++)
                {
                    for (ulong j = 0; j < count; j++)
                    {
                        array[j] *= i;
                    }
                    for (ulong j = 0; j < count; j++)
                    {
                        //отсеиватель c посл числа
                        while (array[count - 1 - j] >= 10)
                        {
                            array[count - 2 - j] += array[count - 1 - j] / 10;
                            array[count - 1 - j] %= 10;
                        }
                    }
                }

                Console.Write("факториал == ");
                for (ulong j = 0; j < count; j++)
                {
                    Console.Write($"{array[j]}");
                }

                Console.WriteLine("\nДля продолжения нажмите Enter");
                Console.ReadKey();
            }
        }
    }
}
