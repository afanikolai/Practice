using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    // Входные данные: INPUT.TXT В первых двух строках содержатся координаты (x1,y1) и (x2,y2) - центры кругов. 
    // В третьей строке задан радиус r описанных выше кругов.
    // Четвертая строка содержит площадь освещения s фонариком из одной лампочки.

    //      1 <= ЗНАЧ <= 100    где ЗНАЧ = {x1, y1, x2, y2, r. }               1 <= s <= 10^5

    // Выходные данные: OUTPUT.TXT выведите «YES», если Мишин фонарик освещает большую площадь 
    //                                                  и «NO» в противном случае (плозадь меньше или равна).


    class Program
    {

        // Функция получает на вход исходную площадь и найденную площадь, и выдает ответ 
        // для записи в текстовый файл согласно условию задачи.
        static string SqrCompare(double s, double sFounded) 
        {
            if (sFounded > s)   // Если найденная площадь больше исходной.
            {
                return "YES";
            }
            else        // Если найденная площадь меньше или равна исходной. 
            {
                return "NO";
            }
        }



        static void Main(string[] args)
        {
            // ------------------------------------- Ввод данных. --------------------------------------------------------------------------

            int x1=0, y1=0, x2=0, y2=0, r=0, s=0;   // Переменные координат центров кругов, радиуса и площади исходного круга. 
            double sFounded = 0;    // Найденная площадь для сравнения с исходной.


            // Открытие файла, заполнение переменных. 
            try
            {
                StreamReader input = new StreamReader("INPUT.TXT");

                string[] strmas = input.ReadLine().Split(' ');  // Чтение первой строки, деление на массив по пробелам.
                x1 = int.Parse(strmas[0]);                      // Присваивание переменных х1 и у1.
                y1 = int.Parse(strmas[1]);

                strmas = input.ReadLine().Split(' ');
                x2 = int.Parse(strmas[0]);                      // Присваивание переменных х2 и у2.
                y2 = int.Parse(strmas[1]);

                strmas = input.ReadLine().Split(' ');
                r = int.Parse(strmas[0]);                      // Присваивание переменной R. 

                strmas = input.ReadLine().Split(' ');
                s = int.Parse(strmas[0]);                      // Присваивание переменной S. 
            }
            catch (Exception exception)
            {
                // Если ошибка, выдаем текст ошибки пользователю и закрываем программу. 
                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                Console.ReadLine();
                Environment.Exit(0);
            }


            // ------------------------------------------------ Рассчеты. ------------------------------------------------------------------

            // Расстояние между центрами окружностей, 
            // вычисляется по формуле "Корень из суммы квадртаов разностей соответствующих координат".
            double lgt = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

            // Суммарная площадь обоих кругов. (без вычета площади их пересечения).
            sFounded = 2 * Math.PI * r * r;

            if (lgt > 2 * r)    // Если расстояние между центрами больше двух радиусов. (круги не пересекаются).
            {
                
                // Открываем файл для записи и записываем результат.
                StreamWriter output = new StreamWriter("OUTPUT.TXT");
                output.WriteLine(SqrCompare(s, sFounded));
                output.Close();
            }
            else if (lgt != 0)   // Если центры окружностей не совпадают.
            {
            
            
                double tmp = 2 * Math.Acos(lgt / 2 / r);

                // Находим общую площадь двух кругов без их пересечения. 
                sFounded = sFounded - r*r * (tmp - Math.Sin(tmp));


                // Открываем файл для записи и записываем результат.
                StreamWriter output = new StreamWriter("OUTPUT.TXT");
                output.WriteLine(SqrCompare(s, sFounded));
                output.Close();


            }
            else    // Если центры окружностей совпадают. 
            {
                sFounded = Math.PI * r*r;   // Находим площадь окружности.

                // Открываем файл для записи и записываем результат.
                StreamWriter output = new StreamWriter("OUTPUT.TXT");
                output.WriteLine(SqrCompare(s, sFounded));
                output.Close();
            }



        }
    }
}
