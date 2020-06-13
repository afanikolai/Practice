using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practice_6
{
    //  Ввести а1, а2, а3, N, E. Построить N элементов последовательности ак = 1/3*ак–1 + 1/2*ак-2 + 2/3*ак–3. Выяснить, сколько 
    //  пар удовлетворяют условию | ак – ак–1 | < E. Напечатать их номера. 
    //
    class Program
    {
        // Рекурсивный алгоритм создания последовательности до полного заполнения массива. 
        public static void Create(ref float[] mas, int i)
        {
            //  Вычисляем текущий элемент. 
            mas[i] = (mas[i - 1] / 3) + (mas[i - 2] / 2) + (2 * mas[i - 3] / 3);

            // Выводим текущий элемент.
            Console.WriteLine($"{i + 1}-ый элемент: {mas[i]}");

            // Проверка на заполнение массива. 
            if (i+1 < mas.Length)
                Create(ref mas, i + 1);

        }



        static void Main(string[] args)
        {
            try
            {
                // Приветствие.
                string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 6 - построение и анализ числовой " +
                    "последовательности.\n\n\r";
                Console.WriteLine(hello);

                // Описание данных. 
                float max;
                float[] mas = new float[0];
                string res = "";
                int count = 0;

                // Ввод данных.
                Console.WriteLine("Для ввода данных создайте в директории...\\Practice 11\\bin\\Debug текстовый документ и " +
                    "расположите в первой строчке количество членов N вашей последовательности, а также число Е, с которым будет " +
                    "проводиться сравнение. Во второй строчке укажите три первых члена вашей последовательности. Значения разделяйте " +
                    "одинарным пробелом. Имя вашего файла укажите ниже, или оставьте поле пустым для использования стандартных данных \nИмя файла: ");
                string fileName = Console.ReadLine();

                if (fileName == "") // Если имя файла пустое.
                {
                    fileName = "input.txt";
                }

                // Открытие файла. 
                StreamReader input = new StreamReader(fileName);

                // Чтение файла.
                string[] strmas = input.ReadLine().Split(' ');
                mas = new float[int.Parse(strmas[0])];
                max = int.Parse(strmas[1]);

                strmas = input.ReadLine().Split(' ');
                mas[0] = int.Parse(strmas[0]);
                Console.WriteLine($"1-ый элемент: {mas[0]}");
                mas[1] = int.Parse(strmas[1]);
                Console.WriteLine($"2-ый элемент: {mas[1]}");
                mas[2] = int.Parse(strmas[2]);
                Console.WriteLine($"3-ый элемент: {mas[2]}");

                
                // Cоздание последовательности. 
                Create(ref mas, 3);




                for (int i = 1; i < mas.Length; i++)
                {

                    // Проверка на условие. 
                    if (Math.Abs(mas[i] - mas[i - 1]) < max)
                    {
                        res += $"Элемент №{i + 1};\n";
                        count++;
                    }

                }


                // Вывод. 
                Console.WriteLine();
                if (res != "")  // Если есть что выводить.
                {
                    Console.WriteLine($"Условию задачи удовлетворяют следующие {count} членов последовательности: \n" + res);
                }
                else
                {
                    Console.WriteLine("Условию задачи не удовлетворяет ни один из членов последовательности.");
                }    
                Console.ReadLine();

            }
            catch (Exception exception)
            {
                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                Console.ReadLine();
                Environment.Exit(0);
            }

        }
    }
}
