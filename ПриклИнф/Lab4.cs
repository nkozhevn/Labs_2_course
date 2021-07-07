using System;
using System.Collections.Generic;
using System.Text;

namespace ПриклИнф
{
    class Lab4
    {
        int N, x;
        public double[,] M;
        public rebro[] Reb;
        public int[] Color;
        public int[] A;
        public double[] B;
        public int[] C;
        public struct rebro //Структура, запоминающая инцидентные вершины для каждого ребра
        {
            public int i, j;
        }
        public Lab4(int N) //Конструктор класса
        {
            this.N = N;
            M = new double[N, N];
            Reb = new rebro[N - 1];
            Color = new int[N];
            A = new int[N];
            B = new double[N];
            C = new int[N];
        }
        public void InputM() //Заполнение матрицы
        {
            Console.WriteLine("Заполните весовую матрицу: ");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    M[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                if (i < N - 1)
                {
                    Console.WriteLine("Следующая строка: ");
                }
            }
        }
        public void PrintM() //Вывод матрицы
        {
            Console.WriteLine("\n");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(M[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }
        static bool Symmetric(double[,] M) //Проверка матрицы на симметричность
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = i; j < M.GetLength(0); j++)
                {
                    if (M[i, j] != M[j, i])
                        return false;
                    if (i == j && M[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
        public void Search() //Алгоритм Крускала
        {
            if (!Symmetric(M))
                Console.WriteLine("Матрица введена неверно, введите симметричную матрицу!");
            else
            {
                for (int i = 0; i < N; i++)
                {
                    Color[i] = i;
                }
                Console.WriteLine("Ребра в решении: ");
                for (int k = 0; k < N - 1; k++)
                {
                    int col_i = 0, col_j = 0;
                    double min = 10000;
                    for (int i = 0; i < N - 1; i++)
                    {
                        for (int j = i + 1; j < N; j++)
                        {
                            if (Color[i] != Color[j] && M[i, j] < min && M[i, j] != 0)
                            {
                                min = M[i, j];
                                Reb[k].i = i + 1;
                                Reb[k].j = j + 1;
                                col_i = Color[i];
                                col_j = Color[j];
                            }
                        }
                    }
                    for (int i = 0; i < N; i++)
                    {
                        if (Color[i] == col_j)
                        {
                            Color[i] = col_i;
                        }
                    }
                }
                for (int k = 0; k < N - 1; k++)
                {
                    Console.WriteLine(Reb[k].i + "-" + Reb[k].j);
                }
            }
        }
        public static void Cruscal()
        {
            Console.Write("Введите количество вершин в графе: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Lab4 c = new Lab4(N);
            c.InputM();
            c.PrintM();
            c.Search();
        }
        public void Ways(int x) //Алгоритм Дейкстры
        {
            if (!Symmetric(M))
            {
                Console.WriteLine("Матрица введена неверно, введите симметричную матрицу c нулевой главной диагональю!");
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    A[i] = 0;
                    if (i == x)
                    {
                        B[i] = 0;
                    }
                    else
                    {
                        if (M[x, i] == 0)
                        {
                            B[i] = 10001;
                        }
                        else
                        {
                            B[i] = M[x, i];
                        }
                    }
                    C[i] = x;
                }
                A[x] = 1;
                for (int i = 0; i < N - 1; i++)
                {
                    int min = 10001;
                    for (int j = 0; j < N; j++)
                    {
                        if (A[j] == 0 && B[j] < min)
                        {
                            min = j;
                        }

                    }
                    A[min] = 1;
                    for (int j = 0; j < N; j++)
                    {
                        if (M[min, j] != 0 && M[min, j] + B[min] < B[j])
                        {
                            B[j] = M[min, j] + B[min];
                            C[j] = min;
                        }
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    if (i != x)
                    {
                        Console.Write(i + ": ");
                        int z = i;
                        Console.Write(z);
                        while (z != x)
                        {
                            z = C[z];
                            Console.Write(" <- " + z);
                        }
                        Console.Write("\n");
                    }
                }
            }
        }
        public static void Dijkstra()
        {
            Console.Write("Введите количество вершин в графе: ");
            int N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер необходимой вершины (нумерация с 0): ");
            int x = Convert.ToInt32(Console.ReadLine());
            Lab4 c = new Lab4(N);
            Console.WriteLine("Значения весовой матрицы не должны превышать 10000!");
            c.InputM();
            c.PrintM();
            c.Ways(x);
        }
    }
}