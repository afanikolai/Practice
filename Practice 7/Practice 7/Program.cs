using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    //  Выписать все булевы функции от 3 аргументов, которые монотонны. Выписать их вектора в лексикографическом порядке.
    //  Ввод/вывод не требуется, передаю в функцию проверки функции на монотонность массив булевых функций от трех переменных.
    //  Одна функция задается вектором в виде cтроки из восьми нулей и единиц, определяющих значение функции при соответствующих
    //  значениях переменных.

    //  Алгоритм: https://ido.tsu.ru/iop_res/bulevfunc/text/g15_5.html

    //  №   xyz

    //  0   000
    //  1   001

    //  2   010       
    //  3   011

    //  4   100
    //  5   101

    //  6   110
    //  7   111

    class Program
    {
        //  Функция для вычисления монотонности функции.
        public static bool CheckMono(int[] mas)
        {
            // Сравниваем первые 4 результата со вторыми четыремя. 
            bool step1 = (mas[0] <= mas[4]) && (mas[1] <= mas[5]) && (mas[2] <= mas[6]) && (mas[3] <= mas[7]);

            if (!step1) // Если условия монотонности нарушены. 
            {
                return false;
            }
            else
            {
                // Сравниваем парами элементы верхней и нижней половин. 
                bool step2 = (mas[0] <= mas[2]) && (mas[1] <= mas[3]) && (mas[4] <= mas[6]) && (mas[5] <= mas[7]);
                if (!step2) // Если условия монотонности нарушены. 
                {
                    return false;
                }
                else
                {
                    // Сравниваем 
                    bool step3 = (mas[0] <= mas[1]) && (mas[2] <= mas[3]) && (mas[4] <= mas[5]) && (mas[6] <= mas[7]);
                    if (!step3) // Если условия монотонности нарушены. 
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        // Функция для вывода массива, хранящего вектор функции, в строку.
        public static void Show (int[] mas)
        {
            Console.Write("f(");
            foreach (int tmp in mas)
            {
                Console.Write(tmp);
            }
            Console.WriteLine(");");
        }

        // Функция для генерации массива с двочиными символами из десятчиного числа.
        public static int[] MakeBinary(int n)
        {
            string str = Convert.ToString(n, 2);    // Перевод в строку с двоичным кодом. 
            string zero = "0";
            while(str.Length < 8)   // Пока в строке меньше 8 символов.
            {
                str = zero.Insert(1, str);
            }

            int[] mas = new int[8];     // Массив для выходных данных.
            int i = 0;                  // Cчетчик.
            foreach (char tmp in str)
            { 
                mas[i] = int.Parse("" + tmp);
                i++;
            }    

            return mas;
        }

        static void Main(string[] args)
        {
            // Приветствие.
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афанасьева Н.В.\nЗадача 7 - перечисление монотонных " +
                "булевых функций от трех переменных.\n\r";
            Console.WriteLine(hello);

            Console.WriteLine("Монотонные функции от трех переменных в лексиграфическом порядке, заданные с помощью векторов: ");

            for (int i = 0; i < 256; i++)
            {
                if (CheckMono(MakeBinary(i)))
                {
                    Show(MakeBinary(i));
                }
            }
            Console.ReadLine();
            
        }
    }
}
