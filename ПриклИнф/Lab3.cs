using System;
using System.Collections.Generic;
using System.Text;

namespace ПриклИнф
{
    class Lab3
    {
        int size;
        public double[,] matr;
        public double[] x_vector { get; set; }
        public double[] X { get; set; }
        public double[] A { get; set; }
        public double[] B { get; set; }
        public double[] C { get; set; }
        public Lab3(int size)
        {
            this.size = size;
            matr = new double[size, size + 1];
            x_vector = new double[size];
            X = new double[size];
            A = new double[size];
            B = new double[size];
            C = new double[size];
        }
        public void InputM()
        {
            Console.WriteLine("Заполните матрицу коефициентов A:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size + 1; j++)
                {
                    if (j == size)
                    {
                        Console.Write("Коефициент B: ");
                    }
                    matr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                if (i < size - 1)
                {
                    Console.WriteLine("Коефициенты следующего уравнения");
                }
            }
        }
        public void PrintM()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size + 1; j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        static void SubtractRow(double[,] M, int k)
        {
            double m = M[k, k];
            for (int i = k + 1; i < M.GetLength(0); i++)
            {
                double t = M[i, k] / m;
                for (int j = k; j < M.GetLength(1); j++)
                {
                    M[i, j] = M[i, j] - M[k, j] * t;
                }
            }
        }
        static void SelectLeading(double[,] M, int n)
        {
            int iMax = n;
            for (int i = n + 1; i < M.GetLength(0); i++)
                if (Math.Abs(M[iMax, n]) < Math.Abs(M[i, n]))
                    iMax = 1;
            if (iMax != n)
                for (int i = n; i < M.GetLength(1); i++)
                {
                    double t = M[n, i];
                    M[n, i] = M[iMax, i];
                    M[iMax, i] = t;
                }
        }
        static bool TriangleMatrix(double[,] M)
        {
            for (int i = 1; i < M.GetLength(0); i++)
            {
                SelectLeading(M, i - 1);
                if (Math.Abs(M[i - 1, i - 1]) > 0.0001)
                    SubtractRow(M, i - 1);
                else
                    return false;
            }
            return true;
        }
        public void Solve()
        {
            if (!TriangleMatrix(matr))
            {
                Console.WriteLine("Не правильно");
            }
            else
            {
                int Nb = matr.GetLength(1) - 1;
                for (int n = x_vector.Length - 1; n >= 0; n--)
                {
                    double sum = 0;
                    for (int i = n + 1; i < Nb; i++)
                        sum += x_vector[i] * matr[n, i];
                    x_vector[n] = (matr[n, Nb] - sum) / matr[n, n];
                }
            }
        }
        public static void Gauss()
        {
            Console.Write("Введите количество уравнений: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Lab3 g = new Lab3(size);
            g.InputM();
            g.PrintM();
            g.Solve();
            Console.WriteLine("Решением будет:");
            for (int i = 0; i < g.x_vector.Length; i++)
            {
                Console.Write($"x{i + 1}= {g.x_vector[i]} ");
            }
            Console.WriteLine("\n");
        }
        public void InputProg()
        {
            Console.WriteLine("Заполните значения диагонали под главной: ");
            for (int i = 0; i < size - 1; i++)
            {
                matr[i + 1, i] = Convert.ToInt32(Console.ReadLine());
                A[i] = matr[i + 1, i];
            }
            Console.WriteLine("Заполните значения главной диагонали: ");
            for (int i = 0; i < size; i++)
            {
                C[i] = Convert.ToInt32(Console.ReadLine());
                matr[i, i] = C[i];
            }
            Console.WriteLine("Заполните значения диагонали над главной: ");
            for (int i = 0; i < size - 1; i++)
            {
                B[i] = Convert.ToInt32(Console.ReadLine());
                matr[i, i + 1] = B[i];
            }
            Console.WriteLine("Заполните значения правой части: ");
            for (int i = 0; i < size; i++)
            {
                X[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public void PrintProg()
        {
            Console.WriteLine("\n");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matr[i, j] + "\t");
                }
                Console.Write(X[i] + "\t");
                Console.WriteLine("\n");
            }
        }
        public void SolveProg()
        {
            double m;
            for (int i = 1; i < size; i++)
            {
                m = A[i] / C[i - 1];
                C[i] = C[i] - m * B[i - 1];
                X[i] = X[i] - m * X[i - 1];
            }
            x_vector[size - 1] = X[size - 1] / C[size - 1];
            for (int i = size - 2; i >= 0; i--)
            {
                x_vector[i] = (X[i] - B[i] * x_vector[i + 1]) / C[i];
            }
        }
        public static void Prog()
        {
            Console.Write("Введите количество уравнений: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Lab3 g = new Lab3(size);
            g.InputProg();
            g.PrintProg();
            g.SolveProg();
            Console.WriteLine("Решением будет:");
            for (int i = 0; i < g.x_vector.Length; i++)
            {
                Console.Write($"x{i + 1}= {g.x_vector[i]} ");
            }
            Console.WriteLine("\n");
        }
    }
}
