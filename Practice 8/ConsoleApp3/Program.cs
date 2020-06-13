using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_8
{



    class Program
    {
        public static int ReadInt(int left = -10000, int right = 10000)
        {
            bool ok = false;
            int number = 0;
            do
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number >= left && number <= right) ok = true;
                    else
                    {
                        Console.WriteLine($"Ошибка. Число выход за границы. Введите число большее {left} и меньшее {right}");
                        ok = false;
                    }
                }
                catch (Exception exception)
                {
                    // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                    Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            } while (!ok);
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива ");
            int n = ReadInt(0);
            var pointList = new List<List<int>>(n); // Для кажжой вершины записаны вершины с которыми она соединена.
            for (int i = 0; i < n; ++i)
            {
                pointList.Add(new List<int>());
                pointList[i] = new List<int>();
            }
            for (int i = 0; i < n; ++i) // Тут записывается через матрицу смежности.
            {
                for (int j = 0; j < n; ++j)
                {
                    Console.WriteLine($"Введите {i}{j} элемент");
                    int tmp = ReadInt(0, 1);
                    if (tmp == 1 && i != j)
                        pointList[i].Add(j);
                }
            }
            bool ok = true;
            int[] part = new int[n];    //  К какой доле относится вершина.
            int[] road = new int[n];    //  Отсда можно восстановить путь, если надо (path).
            for (int i = 0; i < n; ++i)
                part[i] = -1;
            for (int st = 0; st < n && ok; ++st)    // st - стартовая вершина.
            {
                if (part[st] == -1)     // Если мы еще не определили долю у вершины.
                {
                    int h = 0, t = 1;   // t - количество определенных вершин на текущем шаге.
                    road[t] = st;
                    part[st] = 0;
                    while (h < t)
                    {
                        int v = road[h];
                        h++;
                        for (int i = 0; i < pointList[v].Count && ok; ++i)
                        {
                            int to = pointList[v][i];
                            if (part[to] == -1)
                            {
                                part[to] = part[v] == 0 ? 1 : 0;    // Раскраска другим цветом от текущей вершины.
                                road[t] = to;
                                t++;
                            }
                            else if (part[to] == part[v] && ok == true) // Если доли одинаковые.
                            {
                                ok = false;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(ok ? "Двудольный" : "Не двудольный");
            Console.ReadLine();
        }
    }
}
