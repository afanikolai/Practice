using System;
using System.Collections.Generic;
using System.Text;

namespace Practice10
{
    public class Tree
    {
        public double data;

        // Адрес левого поддерева.
        public Tree left;

        // Адрес правого поддерева.
        public Tree right;

        static private Random rand = new Random();

        public Tree(double num)
        {
            data = num;
            left = null;
            right = null;
        }

        public override string ToString()
        {
            return data + " ";
        }

        public static void Print(Tree point, int l = 0)
        {
            if (point != null)
            {
                // Переход к левому поддереву.
                Print(point.left, l + 3);

                for (int i = 0; i < l; i++)
                {
                    // Создание отступа.
                    Console.Write(" ");
                }

                // Печать узла.
                Console.WriteLine(point.data);

                // Переход к правому поддереву.
                Print(point.right, l + 3);
            }
        }

        static public int CountElements(Tree point)
        {
            if (point == null || point.left == null && point.right == null)
            {
                return 1;
            }

            int left = point.left != null ? CountElements(point.left) : 0;
            int right = point.right != null ? CountElements(point.right) : 0;

            return left + right + 1;
        }

        // Высота дерева.
        public static int Height(Tree point)
        {
            if (point == null)
            {
                return 0;
            }

            // Находим высоту правой и левой ветки, и из них берем максимальную.
            return 1 + Math.Max(Height(point.left), Height(point.right));
        }

        public static Tree Add(Tree root, double num)
        {
            if (root == null)
            {
                return new Tree(num);
            }

            bool isExist = num == root.data;

            // Элемент уже существует.
            if (isExist)
            {
                Console.WriteLine("Объект с таким числом уже есть в дереве: добавление невозможно");

                // Найдено, не добавляем.
                return root;
            }

            if (Height(root.left) < Height(root.right))
            {
                root.left = Add(root.left, num);
            }
            else if (Height(root.left) > Height(root.right))
            {
                root.right = Add(root.right, num);
            }
            else
            {
                if (CountElements(root.left) < CountElements(root.right))
                {
                    root.left = Add(root.left, num);
                }
                else
                {
                    root.right = Add(root.right, num);
                }
            }

            return root;
        }

        // Построение идеально сбалансированного дерева.
        public static Tree IdealTree(int size)
        {
            Tree p;
            int nl, nr;

            if (size == 0)
            {
                return null;
            }

            nl = size / 2;
            nr = size - nl - 1;

            p = new Tree(rand.Next(-2000, 2000));
            p.left = IdealTree(nl);
            p.right = IdealTree(nr);
            return p;
        }
    }
}



namespace Practice10
{
    class Program
    {
        static int Menu(string title, params string[] choiceOptions)
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
            string hello = "Учебная практика студента 1 курса НИУ ВШЭ - Пермь, Афаеасьева Н.В.\nЗадача 10 - балансировка бинарного " +
                "дерева при добавлении элемента.\n\n\r";
            Console.WriteLine(hello);


            Tree tree = null;


            while (true)
            {
                

                string[] strOptions = { "1. Создание сбалансированного дерева. ","2. Печать дерева. ",
                "3. Добавить элемент в сбалансированное дерево.", "4. Выход." };
                int option = Menu(hello + "Выберите действие: ", strOptions);

                switch (option)
                {
                    // Создание дерева.
                    case 0:
                        Console.WriteLine("Введите число элементов дерева от 0 до 50:");
                        tree = Tree.IdealTree(InputInt(0, 50));
                        Console.WriteLine("Дерево создано");
                        Console.ReadLine();
                        break;
                    // Печать списка.
                    case 1:
                        if (tree == null)
                        {
                            Console.WriteLine("Дерево пустое");
                            Console.ReadLine();
                            break;
                        }

                        Tree.Print(tree);
                        Console.ReadLine();
                        break;
                    // Добавление вершины.
                    case 2:
                        Console.WriteLine("Введите элемент для добавления от -2000 до 2000:");
                        tree = Tree.Add(tree, InputInt(-2000, 2000));
                        Console.WriteLine("Элемент добавлен");
                        Console.ReadLine();

                        break;
                    // Выход из программы.
                    case 3:
                       Environment.Exit(0);
                        break;
                }
            }
        }

        

        private static int InputInt(int left, int right)
        {
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || !(number >= left && number <= right))
            {
                Console.WriteLine($"Введите целое число от {left} до {right}");
            }

            return number;
        }
    }
}
