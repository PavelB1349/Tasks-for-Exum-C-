using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 3. Заполнить матрицу А 3х3 числами 0 и 1 в случайном порядке.
Заполнить матрицу B 3х3 числами 0 и 1 в случайном порядке.
Получить матрицу С 3х3 в которой будут сохранены булевы значения равен ли элемент A[x,y] элементу B[x,y],
подсчитать количество элементов со значением true, и со значением false.
 */
namespace exercise_3
{
    internal class Program
    {        
        public static void FillMatrix(int[,] array, Random rand)
        {            
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(2);
                }
            }
        }
        /// <summary>
        /// Метод для заполнения булевого массива результатами проверок на совпадения двух матриц
        /// </summary>
        /// <param name="array"></param>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        public static void FillMatrix(bool[,] array, int[,]array1, int[,]array2)
        {            
            Random random = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array1[i,j] == array2[i,j])
                    {
                        array[i, j] = true;
                    }
                    else
                    {
                        array[i, j] = false;
                    }
                }
            }
        }
        public static void PrintMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(bool[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для подсчета значений true и false в Матрице С
        /// </summary>
        /// <param name="array"></param>
        public static void CountCoincidence(bool[,]array)
        {
            int countTrue = 0, countFalse = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] == true)
                    {
                        countTrue++;
                    }
                    else
                    {
                        countFalse++;
                    }
                }
            }
            Console.WriteLine($"Количество элементов true в матрице С: {countTrue}");
            Console.WriteLine($"Количество элементов false в матрице С: {countFalse}");
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] matrixA = new int[3, 3];
            int[,] matrixB = new int[3, 3];
            bool[,] matrixC = new bool[3, 3];

            FillMatrix(matrixA, random);
            FillMatrix(matrixB, random);
            Console.WriteLine("Матрица А:");
            PrintMatrix(matrixA);
            Console.WriteLine("\nМатрица B:");
            PrintMatrix(matrixB);
            Console.WriteLine("\nМатрица С:");
            FillMatrix(matrixC, matrixA, matrixB);
            PrintMatrix(matrixC);
            Console.WriteLine();
            CountCoincidence(matrixC);
            Console.ReadLine();
        }
    }
}
