using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3
{
    class Program
    {
        // Дано действительное число а. Для функций, представленных ниже, вычислить f(a). 

        // Условия: a - double;         При x <= 0, y = -x;     При x > 0, у = -х^2;



        // Функция для вычисления f(x) по описанной выше формуле.
        static double func(double x)
        {
            if (x <= 0) // Если х <= 0.
            {
                return -x;
            }
            else    // Если x > 0.
            {
                return -(x * x);
            }

        }

        // Функция для вычисления производной функции f(x) в точке x.
        static double der(double x)
        {
            if (x < 0) // Если х < 0.
            {
                return -1;
            }
            else    // Если x >= 0.
            {
                return -(2 * x);
            }

        }

        static void Main(string[] args)
        {
            // Приветствие. 
            Console.WriteLine("Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 3 - вычисление значения " +
                "функции f(a) c точностью в 2 знака после запятой.\n");

            // Объявить переменные.
            double a = 0;
            bool ok = false;    // Маркер проверки правильности ввода переменной а. 
            string tmp = "";    // Строка для ввода данных с клавиатуры.


            while (true)    // Бесконечный цикл. 
            {

                ok = false; // Для последующих итераций. 

                while (!ok) // Пока не введено правильное значение.
                {
                    try     // Ввод а.
                    {
                        Console.WriteLine("Введите действительное число а. \nЧтобы выйти введите \"close\" или \"выход\" ");
                        Console.Write("a = ");
                        tmp = Console.ReadLine();
                        a = double.Parse(tmp);
                        ok = true;
                    }
                    catch (Exception e)
                    {
                        // Массив с командами для выхода из приложения. 
                        string[] closemas = { "Выход", "Выход ", "выход", "выход ", "Close", "close", "Close ", "close " };

                        if (closemas.Contains(tmp)) // Если команда содержится в массиве. 
                        {
                            Environment.Exit(0);
                        }
                        else    // Если введена не команда. 
                        {
                            Console.WriteLine($"Ошибка! + {e.Message}");
                            Console.WriteLine();
                            ok = false;
                        }
                    }

                }   // Пока не введено правильное значение.

                // Вывести результат. 
                Console.WriteLine($"Значение функции f(a) в точке {a} равно {func(a):f}.\nЗначение производной функции f(a) в этой же " +
                    $"точке равно {der(a):f}. ");
                Console.WriteLine();

            }   // Бесконечный цикл.
        }
    }
}
