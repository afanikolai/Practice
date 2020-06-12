using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Practice_11
{
    //  Зашифровать текст с помочью табличной посимвольной замены. Для этого на вход подается файл с шифром, файл с исходным текстом и  
    //  программа выдает переработанный текст. Файл с шифром представляет собой текстовый документ, в первой строке которого число с 
    //  количеством букв в шифре, а в следующих n строках файла последовательно расположены n пар вида "буква исходного алфавита - 
    //  ее шифр". Пользователь сам должен убедиться, что система шифрования является однозначно декодируемой, что коды никаких 
    //  двух букв не повторяются, что ни один документ не содержит кириллических символов и что в шифре представлены все символы, 
    //  которые используются в исходном тексте. В файле с шифром каждый исходный символ и каждый код должен состоять из одгого символа. 


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




        static void Main(string[] args)
        {
            // Приветствие.
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 11 - шифрование  " +
                "текста.\n\n\r";
            Console.WriteLine(hello);

            // Описание данных. 
            string strTxt = "";     // Исходный текст.
            string newTxt = "";     // Зашифрованный текст. 
            string newreTxt = "";   // Дешифрованный текст. 
            Dictionary<char, char> keys = new Dictionary<char, char>();     // Словарь для шифра.
            Dictionary<char, char> reKeys = new Dictionary<char, char>();   // Словарь для расшифровки. 


            // Меню выбора действия. 
            while (true)    // Бесконечный цикл. 
            {
                string[] strOptions = { "1. Ввести исходный текст. ", "2. Выбрать файл с шифром. ", "3. Зашифровать текст.", "4. Выход." };
                int option1 = Menu(hello + "Выберите действие: ", strOptions);
                switch (option1)
                {


                    case 0: // Ввести исходный текст. 


                        try
                        {
                            Console.Write("Для ввода текста из файла вам необходимо создать в директории ...\\Practice 11\\bin\\Debug " +
                                "текстовый документ с исходным текстом. Убедитесь, что текст не содержит кириллических символов. Введите " +
                                "имя вашего файла ниже, или оставьте поле пустым, чтобы использовать готовый документ \nИмя файла: ");
                            string fileName = Console.ReadLine();

                            if (fileName == "") // Если имя файла пустое.
                            {
                                fileName = "inputTxt.txt";
                            }

                            StreamReader input = new StreamReader(fileName);
                            strTxt = input.ReadToEnd();


                            // Выводим текст. 
                            Console.WriteLine("Ваш текст: \n\"" + strTxt+"\"");

                            Console.ReadLine();

                        }
                        catch (Exception exception)
                        {
                            // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                            Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

                        break;



                    case 1: // Выбрать файл с шифром.



                        try
                        {
                            Console.WriteLine("Для ввода шифра из файла вам необходимо создать в директории " +
                                "...\\Practice 11\\bin\\Debug текстовый документ с парами вида \"буква её_шифр\" в строках документа " +
                                "начиная с первой. Убедитесь, что коды никаких двух букв не повторяются и что вы используете только  " +
                                "буквы латиницы а также служебные символы и знаки препинания. В файле с шифром  каждый исходный символ и " +
                                "каждый код должен состоять из одгого символа. Введите имя вашего файла ниже, или оставьте поле пустым, " +
                                "чтобы использовать готовый документ \nИмя файла: ");
                            string fileName = Console.ReadLine();

                            if (fileName == "") // Если имя файла пустое.
                            {
                                fileName = "inputKey.txt";
                            }

                            // Открытие файла. 
                            StreamReader input = new StreamReader(fileName);

                            // Читаем шифр. 
                            string tmp = input.ReadLine();
                            char[] separators = {' '};

                            while (tmp != null)   // Пока не последняя строка. 
                            {
                                string[] tmpkey = tmp.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                keys.Add(tmpkey[0][0], tmpkey[1][0]);
                                tmp = input.ReadLine();
                            }

                            // Выводим шифр. 
                            Console.WriteLine("Ваш шифр: ");
                            foreach (KeyValuePair<char, char> keyValue in keys)
                            {
                                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
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

                        break;



                    case 2: // Зашифровать текст.


                        
                            try
                            {

                            // ------------------------------------------------- Шифровка. -------------------------------------------------


                            // Посимвольно перебираем исходный текст. 
                            foreach (char sym in strTxt)
                                {
                                    if (keys.ContainsKey(sym)) // Если текущий символ найден в словаре с кодами.
                                    {
                                        // Шифруем символ.
                                        newTxt += keys[sym];
                                    }
                                    else
                                    {
                                        // Если не найден - переносим его в новый текст. 
                                        newTxt += sym;
                                    }
                                }

                                // Выводим текст. 
                                Console.WriteLine("Ваш текст: \n\"" + strTxt + "\"");
                                Console.WriteLine();

                                // Выводим обработанный текст. 
                                Console.WriteLine("Обработанный текст: \n\"" + newTxt + "\"");
                                Console.WriteLine();


                                // ------------------------------------------- Дешифровка. ------------------------------------------------- 

                                // Создать словарь для дешифровки переворотом старого. 
                                foreach (KeyValuePair<char, char> keyValue in keys)
                                {
                                    reKeys.Add(keyValue.Value, keyValue.Key);
                                }

                                // Посимвольно перебираем исходный текст. 
                                foreach (char sym in newTxt)
                                {
                                    if (reKeys.ContainsKey(sym)) // Если текущий символ найден в словаре с кодами.
                                    {
                                        // Шифруем символ.
                                        newreTxt += reKeys[sym];
                                    }
                                    else
                                    {
                                        // Если не найден - переносим его в новый текст. 
                                        newreTxt += sym;
                                    }
                                }

                                // Выводим текст. 
                                Console.WriteLine("Дешифрованный текст: \n\"" + newreTxt + "\"");
                                Console.ReadLine();


                            }
                            catch (Exception exception)
                            {
                                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                                Console.ReadLine();
                                Environment.Exit(0);
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
