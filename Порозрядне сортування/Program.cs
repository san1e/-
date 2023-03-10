using System;

namespace Порозрядне_сортування
{
    internal class Program
    { 
            static int[] Random1(int n)
            {
                int[] arr = new int[n];
                Random rand = new Random();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(-100, 100);
                }
                return arr;
            }
            public static void RadixSort1(int[] arr)
            {
                // Находим максимальное число, чтобы определить количество цифр в числах
                int maxNum = FindMaxNum(arr);

                // Проходим по каждому разряду
                for (int digit = 1; maxNum / digit > 0; digit *= 10)
                {
                    CountingSort(arr, digit);
                }
            }

            private static void CountingSort(int[] arr, int digit)
            {
                int[] count = new int[10];
                int[] output = new int[arr.Length];

                // Считаем количество вхождений каждой цифры
                for (int i = 0; i < arr.Length; i++)
                {
                    int index = (arr[i] / digit) % 10;
                    count[index]++;
                }

                // Меняем индексы count, чтобы они указывали на позиции в output
                for (int i = 1; i < 10; i++)
                {
                    count[i] += count[i - 1];
                }

                // Заполняем output в правильном порядке
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    int index = (arr[i] / digit) % 10;
                    output[count[index] - 1] = arr[i];
                    count[index]--;
                }

                // Копируем output в arr
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = output[i];
                }
            }

            private static int FindMaxNum(int[] arr)
            {
                int max = int.MinValue;

                foreach (int num in arr)
                {
                    if (num > max)
                    {
                        max = num;
                    }
                }

                return max;
            }

            static void Main(string[] args)
            {
                // Запрашиваем у пользователя массив чисел
                int[] arr = Random1(9);
                Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));

                // Сортируем массив
                RadixSort1(arr);

                // Выводим отсортированный массив
                Console.WriteLine("Отсортированный массив:");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }

