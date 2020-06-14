using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    // Даны натуральное число n и целые числа a[1] ... a[n], принимающие значения "0" либо "1", при том, что а[n] != 0.
    // Последовательность a[n]*2^n + ... + a[0] задает двочиное представление целого числа p.
    // Вернуть последовательность, задающую представление числа p - 1.


    class Program
    {

        // Функция для отрисовки меню. 
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

        //// Функция для перевода последоваетльности нулей и единиц в десятичную систему. 
        //static int Transfer(params int[] mas)
        //{
        //    int tmp = 0;
        //    int sum = 0;
        //    for (int i= mas.Length-1; i > -1; i--)
        //    {
        //        sum += (int)Math.Pow(2, tmp) * mas[i];
        //        tmp++;
        //    }
        //    return sum;
        //}





        static void Main(string[] args)
        {
            // Приветствие.
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 4 - преобразование " +
                "последовательности, задающейся в виде двоичного кода.\n\n\r";
            Console.WriteLine(hello);

            // Описание данных. 
            string str = "";
            int[] posl = new int[0];

            // Меню выбора действия. 
            while (true)    // Бесконечный цикл. 
            {
                string[] strOptions = { "1. Ввести последовательность. ","2. Вывести обработанную последовательность. ",
                "3. Вывести закодированное в последовательности число.", "3. Выход." };
                int option1 = Menu(hello + "Выберите действие: ", strOptions);
                switch (option1)
                {
                    case 0: // Ввести последовательность.
                        {
                            string[] inputoptions = { "1. Из файла.", "2. С клавиатуры." };
                            int inputoption = Menu("Выберите, как ввести последовательность. ", inputoptions);
                            switch (inputoption)
                            {
                                case 0: // Из файла.
                                    {
                                        try
                                        {
                                            Console.Write("Для ввода последовательности из файла вам необходимо создать в директории " +
                                                "...\\Practice 4\\bin\\Debug текстовый документ и заполнить его первую строку последовательностью " +
                                                "нулей и единиц без пробелов и знаков препинания. Введите имя вашего файла ниже, или " +
                                                "оставьте поле пустым, чтобы воспользоваться готовой последовательностью \nИмя файла: ");
                                            string fileName = Console.ReadLine();

                                            if (fileName == "") // Если имя файла пустое.
                                            {
                                                fileName = "input.txt";
                                            }
                                            else
                                            {
                                                // Nothing.
                                            }
                                            StreamReader input = new StreamReader(fileName);
                                            str = input.ReadLine();
                                            input.Close();

                                            // Проверка на систему счисления.
                                            Convert.ToInt32(str, 2);
                                        }
                                        catch (Exception exception)
                                        {
                                            // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                            Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                            Console.ReadLine();
                                        }
                                    }
                                    break;

                                case 1: // С клавиатуры. 
                                    {
                                        try
                                        {
                                            Console.Write("Для ввода последовательности c клавиатуры не используйте пробел и " +
                                                "знаки препинания. \nВаша последовательность: ");
                                            str = Console.ReadLine();

                                            // Проверка на систему счисления.
                                            Convert.ToInt32(str, 2);
                                        }
                                        catch (Exception exception)
                                        {
                                            // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                            Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                            Console.ReadLine();
                                        }
                                    }
                                    break;
                            }


                        }
                        break;

                    case 1: // Вывести обработанную последовательность.
                        {
                            Console.Clear();
                            try
                            {
                                // Преобразование строки двоичного кода в целое число.
                                int ch = Convert.ToInt32(str, 2) - 1;


                                if (ch >= 0)    // Если результат положителен.
                                {
                                    // Вывод преобразованного в строку двоичного кода результата.
                                    Console.WriteLine(Convert.ToString(ch, 2));
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка! Число должно быть больше нуля. ");
                                }
                                Console.ReadLine();
                            }
                            catch (Exception exception)
                            {
                                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                Console.ReadLine();
                            }
                        }
                        break;

                    case 2: // Вывести закодированное в последовательности число.
                        {
                            Console.Clear();
                            try
                            {
                                // Преобразование строки двоичного кода в целое число.
                                int ch = Convert.ToInt32(str, 2);

                                
                                
                                    // Вывод целого числа.
                                    Console.WriteLine(ch);
                                
                                
                                Console.ReadLine();
                            }
                            catch (Exception exception)
                            {
                                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                Console.ReadLine();
                            }
                        }
                        break;

                    case 3: // Выход.
                        {
                            Environment.Exit(0);
                        }
                        break;
                }

            }   // Бесконечный цикл. 

        }
    }
}
