using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 1. Создать зубчатый массив со следующим наполнением:
"C", "A", "E",
"Z", "Q",
"L", "J", "K", "S"
Отсортировать массив по алфавиту, результат:
"A", "C", "E",
"J", "K",
"L", "Q", "S", "Z"
Вывести отсортированный массив в консоль.
 */
namespace exercise_1
{
    
    internal class Program
    {
        /// <summary>
        /// метод для заполнения массива символами из списка
        /// </summary>
        /// <param name="array"></param>
        /// <param name="charList"></param>
        public static void fillCharArray(char[][] array, List<char> charList)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = charList[index];
                    index++;
                }
            }
        }
        /// <summary>
        /// метод вывода для массива
        /// </summary>
        /// <param name="array"></param>
        public static void printCharArray(char[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Метод для сортировки символьного массива с помошью LINQ
        /// </summary>
        /// <param name="array"></param>
        public static void SortCharArray(char[][] array)
        {
            int index = 0;
            List<char> tempCharList = new List<char>();
            // в цикле пробегаю по массиву и собираю символы в список
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    tempCharList.Add(array[i][j]);
                }
            }
            // сортирую собранный список
            var sortCharList = tempCharList.OrderBy(x => x).ToList();
            // перезаполняю массив из отсортированного списка
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = sortCharList[index];
                    index++;
                }
            }
        }
        static void Main(string[] args)
        {
            // определим массив массивов и создам саисок символов для заполнения
            char[][] charArray = new char[3][];
            charArray[0] = new char[3];
            charArray[1] = new char[2];
            charArray[2] = new char[4];
            List<char> charList = new List<char>() { 'C', 'A', 'E', 'Z', 'Q', 'L', 'J', 'K', 'S' };
           
            Console.WriteLine("Изначальный массив:");
            fillCharArray(charArray, charList);
            printCharArray(charArray);
            
            Console.WriteLine("Отсортированный массив:");
            SortCharArray(charArray);
            printCharArray(charArray);
            Console.ReadLine();
        }
    }
}
