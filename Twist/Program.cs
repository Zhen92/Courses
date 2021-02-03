using System;

namespace Twist
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите матрицу n на m: ");

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            int[,] array = new int[n, m];

            Console.WriteLine("---------------------------------");

            int y_start = 0, y_end = 0, x_start = 0, x_end = 0, k = 1, y = 0, x = 0;

            while (k <= n * m)
            {
                array[y, x] = k;
                if (y == y_start && x < m - x_end - 1)
                {
                    ++x;
                }
                else if (x == m - x_end - 1 && y < n - y_end - 1)
                {
                    ++y;
                }
                else if (y == n - y_end - 1 && x_start < x)
                {
                    --x;
                }
                else
                {
                    --y;
                }

                if ((y == y_start + 1) && (x == x_start) && (x_start != m - x_end - 1))
                {
                    ++y_start;
                    ++x_start;
                    ++y_end;
                    ++x_end;
                }
                ++k;
            }
            for (y = 0; y < n; y++)
            {
                for (x = 0; x < m; x++)
                {

                    Console.Write(array[y, x] + " ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }
    }
}
