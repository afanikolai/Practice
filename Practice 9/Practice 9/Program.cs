using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Practice_9
{
    //  Напишите рекурсивный метод создания линейного списка, в информационные поля элементов которого последовательно заносятся 
    //  номера с 1 до N (N водится с клавиатуры). Первый включенный в список элемент, имеющий номер 1, оказывается в голове списка 
    //  (первым). Разработайте рекурсивные методы поиска и удаления элементов списка.



    public class Point
    // Класс члена однонаправленного связного списка. 
    {
        public int data;     // Информационное поле. 
        public Point next;   // Ссылка на следующий элемент коллекции. 



        // Пустой конструктор. 
        public Point()
        {
            data = 0;
            next = null;
        }

        // Полный конструктор c информационным полем. 
        public Point(int n)
        {
            data = n;
            next = null;
        }


        //  Функция для создания списка.
        public static Point Create(int n)
        {
            if (n > 0)  // Если число элементов больше нуля.
            {
                // Cоздание головы списка.
                Point list = MakePoint(1);

                // Запуск рекурсии до N. 
                list.Add(n);

                return list;
            }
            else    // Если число элементов не болше нуля. 
            {
                return null;
            }
        }

        // Cоздание элемента списка с объектом класса int.
        static Point MakePoint(int d)
        {
            Point p = new Point(d);
            return p;
        }



        // Рекурсивная функция последовательного заполнения списка натуральными числами до определенного значения.
        public Point Add(int n)
        {
            if (this.data == n)
            {
                return this;
            }
            else if (this.data < n)
            {
                Point tmp = MakePoint(this.data + 1);
                this.next = tmp;
                tmp.Add(n);
                return this;
            }
            return null;
        }

        // Рекурсивная функция для поиска элемента с указанным значением.
        public Point Find(int n)
        {
            if (this.data == n)
            {
                return this;
            }
            else if (this.next == null)
            {
                return null;
            }
            else
            {
                return this.next.Find(n);
            }
        }


        // Рекурсивная функция для удаления элемента с указанным значением.
        public void Delete(int n)
        {
            if (this.next.data == n)
            {
                this.next = this.next.next;
                
            }
            else if (this.next == null)
            {
                Console.WriteLine("Ошибка! элемент не найден.");
            }
            else
            {
                this.next.Delete(n);
            }
        }


        // Функция для рекурсивного вывода списка. 
        public void Show()
        {
            Point list = this;
            Console.WriteLine(list.data);
            if (list.next != null)
                list.next.Show();
        }

    }


    class Program
    {

        public static int InputNumber(string msg, int left, int right)
        {
            try
            {
                Console.WriteLine(msg);
                string str = Console.ReadLine();
                int res = int.Parse(str);
                if ((res > left) && (res < right))
                {
                    return res;
                }
                else
                {
                    throw new Exception($"Значение должно быть больше {left} и меньше {right}. ");
                }
            }
            catch (Exception exception)
            {
                // Если ошибка, выдаем текст ошибки пользователю и возвращаемся в меню.
                Console.WriteLine("\nОшибка!\n" + exception.Message + "\n");
                Console.ReadLine();
                Environment.Exit(0);
            }
            return 0;
        }


        static void Main(string[] args)
        {

            // Приветствие.
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 9 - рекурсивные методы " +
                "работы со связным списком.\n\n\r";
            Console.WriteLine(hello);

            // Создание списка. Количество членов указывает пользователь.
            int n = InputNumber("Введите число членов коллекции. ", 0, 21);

            Point aga = Point.Create(n);
            aga.Show();
            Console.ReadLine();

            // Замена значения.
            int number = InputNumber("Введите значение, которое надо найти. ", 0, n+1);
            if (aga.Find(number) != null)
            {
                int number2 = InputNumber("Введите значение, которое хотели бы вписать на это место. ", 0, 101);
                aga.Find(number).data = number2;
                aga.Show();
            }
            else
            {
                Console.WriteLine("Ошибка! Элемент не найден. ");
            }

            Console.ReadLine();



            // Удаление члена.
            number = InputNumber("Введите значение члена, первое вхождение которого вы хотели бы удалить. ", 0, n + 1);
            aga.Delete(number);
            aga.Show();
            Console.ReadLine();

        }
    }
}
