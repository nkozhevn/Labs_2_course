using System;

namespace ПриклИнф
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(new string('-', 30) + "\nМеню:\n1. Анализ сложноти алгоритмов\n2. Алгоритмы решения ОДУ\n3. Алгоритмы решения СЛАУ\n4. Алгоритмы на графах\n" + new string('-', 30));
                bool cond = true;
                while (cond)
                {
                    switch(int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine(new string('-', 30) + "\n1. Сортировка выборкой\n2. Сортировка пузырьком\n3. Бинарный поиск\n" + new string('-', 30));
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    Lab1.Selection();
                                    cond = false;
                                    break;
                                case 2:
                                    Lab1.Bubble();
                                    cond = false;
                                    break;
                                case 3:
                                    Lab1.Binary();
                                    cond = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение, попробуйте еще раз:\n");
                                    continue;
                            }
                            break;
                        case 2:
                            Console.WriteLine(new string('-', 30) + "\n" + "1. Последовательные приближения\n2. Прогноз и коррекция\n3. Адамс\nДля 2-3 пунктов ввод н. у. производится посредством метода Рунге-Кутта.\n" + new string('-', 30));
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    Lab2.Closes();
                                    cond = false;
                                    break;
                                case 2:
                                    Lab2.Runge();
                                    Lab2.Predict();
                                    cond = false;
                                    break;
                                case 3:
                                    Lab2.Runge();
                                    Lab2.Adams();
                                    cond = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение, попробуйте еще раз:\n");
                                    continue;
                            }
                            break;
                        case 3:
                            Console.WriteLine(new string('-', 30) + "\n" + "1. Метод Гаусса\n2. Метод прогонки\n" + new string('-', 30));
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    Lab3.Gauss();
                                    cond = false;
                                    break;
                                case 2:
                                    Lab3.Prog();
                                    cond = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение, попробуйте еще раз:\n");
                                    continue;
                            }
                            break;
                        case 4:
                            Console.WriteLine(new string('-', 30) + "\n" + "1. Поиск в глубину и ширину\n2. Алгоритм Дейкстры\n3. Алгоритм Крускала\n" + new string('-', 30));
                            switch (int.Parse(Console.ReadLine()))
                            {
                                case 1:
                                    Lab4.Search();
                                    cond = false;
                                    break;
                                case 2:
                                    Lab4.Dijkstra();
                                    cond = false;
                                    break;
                                case 3:
                                    Lab4.Cruscal();
                                    cond = false;
                                    break;
                                default:
                                    Console.WriteLine("Некорректное значение, попробуйте еще раз:\n");
                                    continue;
                            }
                            break;
                        default:
                            Console.WriteLine("Некорректное значение, попробуйте еще раз:\n");
                            continue;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            
        }
    }
}
