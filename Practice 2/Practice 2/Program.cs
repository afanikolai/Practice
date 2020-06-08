using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    class Program
    {
        
        // Дано натуральное число N. Над ним можно произвести следующий набор операций:

        // - Вычитать единицу;
        // - Делить на три, если число кратно трем;
        // - Делить на два, если число четное.
        
        // После выполнения одной из операций к полученному результату также можно применить указанные операции, 
        // и делается это до тех пор, пока результат не окажется равным 1.

        // N <= 1 000 000

        static void Main(string[] args)
        {
            int n = 0; // Исходное число. 
            int t1, t2, t3; // Переменные для каждого действия (-1 / :3 / :2)
            int[] arr = new int[1000000];   // Массив, в котором для каждого числа хранится количество действий, 
            // необходимых для достижения этого числа в соответствии с условием задачи. 

            
            // Открытие файла, заполнение переменной. 
            try
            {
                StreamReader input = new StreamReader("INPUT.TXT");

                n = int.Parse(input.ReadLine());

            }
            catch (Exception exception)
            {
                // Если ошибка, выдаем текст ошибки пользователю и закрываем программу. 
                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                Console.ReadLine();
                Environment.Exit(0);
            }

            // Первые 3 члена массива. 
            arr[1] = 0;
            arr[2] = 1;
            arr[3] = 1;

            // С четвертого члена до n-ного.
            for (int i = 4; i <= n; i++)
            {
                // Первый способ, вычитаем единицу т.к. в ответе +1. 
                t1 = arr[i - 1];

                if (i % 3 == 0) // Если число кратно трем.
                {
                    t2 = arr[i / 3];
                }
                else    // Иначе t2 = огромное значение. 
                {
                    t2 = int.MaxValue;
                }

                if (i % 2 == 0) // Если число кратно двум. 
                {
                    t3 = arr[i / 2];
                }
                else    // Иначе t3 = огромное значение. 
                {
                    t3 = int.MaxValue;
                }

                // Находим минимальное количество действий для нахождения этого числа.
                int[] tmp = { t1, t2, t3 };
                arr[i] = 1 + tmp.Min();

            }



            // Открываем файл для записи и записываем результат.
            StreamWriter output = new StreamWriter("OUTPUT.TXT");
            output.WriteLine(arr[n]);
            output.Close();

        }
    }
}
