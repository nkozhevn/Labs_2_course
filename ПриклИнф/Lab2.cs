using System;
using System.Collections.Generic;
using System.Text;

namespace ПриклИнф
{
    class Lab2
    {
        public static double x, y, h, m;
        public static double[] Y, X;
        public static double Function(double x, double y) => Math.Sqrt(Math.Pow(y, 2) + 2 * x - y);
        public static double Integrate(double x, double y) => 1 / 3 * Math.Pow((2 * x + (y - 1) * y), 3/2);
        public static double Newton(double x, double x0, double y) => Math.Abs(Integrate(x, y) - Integrate(x0, y));
        public static double DF(double x, double y) => (2 * y - 1) / (2 * Math.Sqrt(2 * x + (y - 1) * y));
        public static double Factorial(double n) => n > 0 ? n * Factorial(n - 1) : 1;
        public static void Solver()
        {
            X = new double[10];
            Y = new double[10];
            for (int i = 1; i <= 4; i++)
            {
                double k1 = Function(x, y), k2 = Function(x + h / 2, y + h * k1 / 2), k3 = Function(x + h / 2, y + h * k2 / 2), k4 = Function(x + h, y + h * k3);
                y += (h / 6) * (k1 + 2 * k2 + 2 * k3 + k4);
                Y[i - 1] = y;
                x += i * h;
                X[i - 1] = x;
            }
            Console.WriteLine("\nНачальное значение y: " + y + ", x: " + x + "\n");
        }
        public static void Runge()
        {
            Console.WriteLine("В данном методе н. у. задаются методом Рунге-Кутта");
            Console.WriteLine("Введите следующие данные для получения начальных значений(ур-ие исправляется вручную):");
            Console.Write("xi: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("yi: ");
            y = double.Parse(Console.ReadLine());
            Console.Write("m: ");
            m = double.Parse(Console.ReadLine());
            Console.Write("h0: ");
            h = double.Parse(Console.ReadLine()) / m;
            Solver();
        }
        public static void Adams()
        {
            double x0 = x = X[0];
            y = Y[0];
            for (int i = 0; i < m-2; i++)
            {
                y += Newton(x, x0, y);
                x = X[i];
            }
            Console.WriteLine("Найденное значение функции: " + y);
        }
        public static void Closes()
        {
            Console.WriteLine("Задайте н. у.");
            Console.Write("x: ");
            x = double.Parse(Console.ReadLine());
            double x0 = x;
            Console.Write("y: ");
            y = double.Parse(Console.ReadLine());
            double y0 = y;
            double M = Function(x, y);
            double N = DF(x, y);
            double H = Math.Min(x, y / M);
            int n = 1;
            while (Math.Abs(y) <= Math.Pow(N, n) * M * Math.Pow(H, n + 1) / Factorial(n + 1))
            {
                y = y0 + Newton(x, x0, y);
                Console.WriteLine("Промежуточное значение на " + n + "приближении: " + y);
                n++;
            }
            Console.WriteLine("Найденное значение функции: " + y + "\nКол-во приближений: " + (n - 1) + "\n\n");
        }
        public static void Predict()
        {
            double b = (h - X[0]) / m, y1, dy1, dy2;
            double[] dy = new double[(int)m + 1];
            for (int i = 0; i <= 3; i++)
            {
                dy[i] = Function(X[i], Y[i]);
            }
            for (int i = 3; i < 10; i++)
            {
                X[i + 1] = X[i] + b;
                y1 = Y[i - 3] + 4 / 3 * h * (2 * dy[i] - dy[i - 1] + 2 * dy[i - 2]);
                dy1 = Function(X[i + 1], y1);
                while (true)
                {
                    y1 = Y[i - 1] + h / 3 * (dy1 + 4 * dy[i] + dy[i - 1]);
                    dy2 = Function(X[i + 1], y1);
                    if (Math.Abs(dy2 - dy1) < 1e-3) break;
                    dy1 = dy2;
                }
                dy[i + 1] = dy2;
                Y[i + 1] = Y[i - 1] + h / 3 * (dy[i + 1] + 4 * dy[i] + dy[i - 1]);
            }
            Console.WriteLine("Итоговое значение функции: " + Y[Y.Length - 1]);
        }
    }
}
