using System;
using System.Collections.Generic;
using System.Text;

namespace ПриклИнф
{
    class Lab1
    {
        public static int l, a;
        public static double[] A;
        public static void Selection()
        {
            Console.Write("\n   Введите длину последовательности: ");
            l = int.Parse(Console.ReadLine());
            A = new double[l];
            Console.WriteLine("   Введите элементы последовательности:");
            for (int i = 0; i < l; i++)
            {
                Console.Write("   a" + i + ": ");
                A[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("   Исходная последовательность:");
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + A[i]);
            }
            for (int i = 0; i < l - 1; i++)
            {
                int idx = i;
                for (int j = i + 1; j < l; j++)
                {
                    if (A[j] < A[idx])
                        idx = j;
                }
                double temp = A[idx];
                A[idx] = A[i];
                A[i] = temp;
            }
            Console.Write("\n   Отсортированная последовательность:");
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + A[i]);
            }
            Console.WriteLine("\n");
        }
        public static void Bubble()
        {
            Console.Write("\n   Введите длину последовательности: ");
            l = int.Parse(Console.ReadLine());
            A = new double[l];
            Console.WriteLine("   Введите элементы последовательности:");
            for (int i = 0; i < l; i++)
            {
                Console.Write("   a" + i + ": ");
                A[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("   Исходная последовательность:");
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + A[i]);
            }
            for (int i = 0; i < l - 1; i++)
            {
                for (int j = 0; j < l - i - 1; j++)
                    if (A[j] > A[j + 1])
                    {
                        double temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
            }
            Console.Write("\n   Отсортированная последовательность:");
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + A[i]);
            }
            Console.WriteLine("\n");
        }
        public static void Binary()
        {
            Console.Write("\n   Введите длину последовательности: ");
            l = int.Parse(Console.ReadLine());
            A = new double[l];
            Console.Write("   Введите первое число последовательности: ");
            a = int.Parse(Console.ReadLine());
            for (int i = 0; i < l; i++)
            {
                A[i] = a + i;
            }
            Console.Write("   Последовательность:");
            for (int i = 0; i < l; i++)
            {
                Console.Write(" " + A[i]);
            }
            Console.Write("\n   Введите запрашиваемое число: ");
            int x = int.Parse(Console.ReadLine());
            int p = 0;
            int r = l - 1;
            while (p <= r)
            {
                int m = (r + p) / 2;
                if (A[m] == x)
                    x = m + 1;
                else if (A[m] < x)
                    p = m + 1;
                else
                    r = m - 1;
            }
            Console.Write("   Номер запрашимоего числа: " + x + "\n");
        }
    }
}
