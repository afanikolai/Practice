using System;
using System.IO;

namespace Practice_5
{
    class Program
    {
        static int Menu(string title, params string[] choiceOptions)    // На вход подается строка с заголовком и строковый массив с пунктами. 
        {
            Console.Clear();
            Console.WriteLine(title);
            int option = 0, x = 0, y = 2, oldOption = 0;
            Console.CursorVisible = false;
            for (int i = 0; i < choiceOptions.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + i);
                Console.Write(choiceOptions[i]);
            }
            bool choice = false;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(x, y + oldOption);
                Console.Write(choiceOptions[oldOption] + " ");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.SetCursorPosition(x, y + option);
                Console.Write(choiceOptions[option]);

                oldOption = option;

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option++;
                        break;
                    case ConsoleKey.UpArrow:
                        option--;
                        break;
                    case ConsoleKey.Enter:
                        choice = true;
                        break;
                }

                if (option >= choiceOptions.Length)
                    option = 0;
                else if (option < 0)
                    option = choiceOptions.Length - 1;

                if (choice)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.CursorVisible = true;
                    Console.Clear();
                    break;
                }
            }

            Console.Clear();
            Console.CursorVisible = true;
            return option;
        }

        public static void DeleteColumn(ref float[,] matr, int k)
        {
            float[,] matr1 = new float[matr.GetLength(0), matr.GetLength(1) - 1];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1) - 1; j++)
                {
                    if (k > j)
                    {
                        matr1[i, j] = matr[i, j];
                    }
                    else
                    {
                        matr1[i, j] = matr[i, j + 1];
                    }
                    
                }
               
            }
            matr = matr1;
        }
    
    static void DeleteString(ref float[,] matr, int i)
        {
            float[,] matr1 = new float[matr.GetLength(0) - 1, matr.GetLength(1)];
            for (int j = 0; j < i; j++)
            {
                for (int k = 0; k < matr.GetLength(1); k++)
                {
                    matr1[j, k] = matr[j, k];
                }
            }
            for (int j = i; j < matr.GetLength(0) - 1; j++)
            {
                for (int k = 0; k < matr.GetLength(1); k++)
                {
                    matr1[j, k] = matr[j + 1, k];
                }
            }
            matr = matr1;
            return;
        }

        static void PrintMas(ref float[,] matr, string message)
        {
            Console.WriteLine(message);
            if (matr.GetLength(0) != 0 & matr.GetLength(1) != 0)
            {
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                    {
                        Console.Write($"{matr[i, j]:00} ");
                    }
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("массив пустой.");

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // Приветствие.
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 5 - удаление  " +
                "строки и столбца квадратной матрицы.\n\n\r";
            Console.WriteLine(hello);

            // Описание данных. 
            float[,] matr = new float[0,0];
            int n = 0;
            int idelete = 0, jdelete = 0;

            // Меню выбора действия. 
            while (true)    // Бесконечный цикл. 
            {
                string[] strOptions = { "1. Ввести матрицу. ", "2. Вывести обработанную матрицу. ", "2. Выход." };
                int option1 = Menu(hello + "Выберите действие: ", strOptions);
                switch (option1)
                {
                    case 0: // Ввести матрицу.

                        try
                        {
                            Console.Write("Для ввода матрицы из файла вам необходимо создать в директории " +
                                "...\\Practice 5\\bin\\Debug текстовый документ и указать размерность матрицы n в его первой строке, " +
                                "номера i и j строки и столбца, которые надо удалить, а начиная с третьей строки расположить матрицу n*n, " +
                                "используя пробел как разделитель в строках. Введите имя вашего файла ниже, или оставьте поле пустым, " +
                                "чтобы воспользоваться готовой матрицей \nИмя файла: ");
                            string fileName = Console.ReadLine();

                            if (fileName == "") // Если имя файла пустое.
                            {
                                fileName = "input.txt";
                            }
                            
                            StreamReader input = new StreamReader(fileName);
                            n = int.Parse(input.ReadLine());
                            matr = new float[n, n];
                            try
                            {
                                string[] tmp = input.ReadLine().Split(' ');
                                idelete = int.Parse(tmp[0]);
                                jdelete = int.Parse(tmp[1]);
                            }
                            catch (Exception exception)
                            {
                                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                Console.ReadLine();
                                Environment.Exit(0);
                            }

                            // Прочитать матрицу.
                            for (int i = 0; i < matr.GetLength(0); i++)
                            {
                                string str = input.ReadLine();
                                char[] separators = {' '};
                                string[] strmas = str.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                for (int j = 0; j < matr.GetLength(1); j++)
                                {
                                    matr[i, j] = Convert.ToInt32(strmas[j]);
                                }
                            }

                            Console.WriteLine("Исходная матрица: ");
                            PrintMas(ref matr, "");

                        }
                        catch (Exception exception)
                        {
                            // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                            Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

                        break;

                    case 1: // Вывести обработанную матрицу.
                        {
                            Console.Clear();
                            try
                            {
                                DeleteString(ref matr, idelete);
                                DeleteColumn(ref matr, jdelete);

                                
                                PrintMas(ref matr, "Обработанная матрица: ");

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
                        break;

                    case 2: // Выход.
                        {
                            Environment.Exit(0);
                        }
                        break;
                }

            }   // Бесконечный цикл. 
        }
    }
}
