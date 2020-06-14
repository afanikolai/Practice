using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_12
{
    class Program
    {

        public static int[] HeapSort(int[] arr, ref int countSwap, ref int countComp)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                MakeHeap(arr, n, i, ref countSwap, ref countComp);
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i], ref countSwap);
                MakeHeap(arr, i, 0, ref countSwap, ref countComp);
            }
            return arr;
        }
        static void MakeHeap(int[] arr, int n, int i, ref int countSwap, ref int countComp)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && arr[l] > arr[largest])
                largest = l;
            countComp++;
            if (r < n && arr[r] > arr[largest])
                largest = r;
            countComp++;
            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest], ref countSwap);
                MakeHeap(arr, n, largest, ref countSwap, ref countComp);
            }
            countComp++;
        }

        static void Swap(ref int l, ref int r, ref int count)
        {
            int tmp = l;
            l = r;
            r = tmp;
            count++;
        }
        public static int[] CoctailSort(int[] arr, ref int countComp, ref int countSwap)
        {
            int l = 0, r = arr.Length;
            while (l < r)
            {
                for (int i = l; i < r - 1; ++i)
                {
                    if (arr[i] > arr[i + 1])
                        Swap(ref arr[i], ref arr[i + 1], ref countSwap);
                    countComp++;
                }
                r--;
                for (int i = r; i > l; --i)
                {
                    if (arr[i] < arr[i - 1])
                        Swap(ref arr[i], ref arr[i - 1], ref countSwap);
                    countComp++;
                }
                l++;
            }
            return arr;
        }

        

        //----------------------------------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            int CountComp = 0,
                CountSwap = 0;


            Console.WriteLine("Массив упорядочен по убыванию. ");

            int[] myint = { 99, 88, 77, 66, 55, 44, 33, 22, 11, 8, 5, 3, 1 };
            HeapSort(myint, ref CountSwap, ref CountComp);
            Console.WriteLine("Пирамидальная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);

            CountComp = 0;
            CountSwap = 0;
            myint = new int[] { 99, 88, 77, 66, 55, 44, 33, 22, 11, 8, 5, 3, 1 };
            CoctailSort(myint, ref CountComp, ref CountSwap);
            Console.WriteLine("Шейкерная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);



            Console.WriteLine("Массив упорядочен по возрастанию. ");

            CountComp = 0;
            CountSwap = 0;
            myint = new int[] { 1, 3, 5, 8, 11, 22, 33, 44, 55, 66, 77, 88, 99 };
            HeapSort(myint, ref CountSwap, ref CountComp);
            Console.WriteLine("Пирамидальная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);

            CountComp = 0;
            CountSwap = 0;
            myint = new int[] { 1, 3, 5, 8, 11, 22, 33, 44, 55, 66, 77, 88, 99 };
            CoctailSort(myint, ref CountComp, ref CountSwap);
            Console.WriteLine("Шейкерная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);



            Console.WriteLine("Массив упорядочен хаотично. ");

            CountComp = 0;
            CountSwap = 0;
            myint = new int[] { 88, 99, 5, 8, 66, 22, 1, 11, 55, 3, 77, 33, 44 };
            HeapSort(myint, ref CountSwap, ref CountComp);
            Console.WriteLine("Пирамидальная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);

            CountComp = 0;
            CountSwap = 0;
            myint = new int[] { 88, 99, 5, 8, 66, 22, 1, 11, 55, 3, 77, 33, 44 };
            CoctailSort(myint, ref CountComp, ref CountSwap);
            Console.WriteLine("Шейкерная сортировка заняла {0} сравнений и {1} пересылок.", CountComp, CountSwap);


            Console.ReadLine();


        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    
}
