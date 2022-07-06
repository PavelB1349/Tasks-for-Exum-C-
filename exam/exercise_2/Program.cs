using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
 2. Реализовать класс Динозавр. Имеющий следующие свойства:
- Id
- Название
- Вес
- Высота
Создать список динозавров (не менее 8).
Реализовать меню в котором можно выбрать следующие опции (выборки делать при помощи LINQ):
- Вывести список динозавров отсортированный по имени
- Вывести динозавров вес которых задан диапазоном (от.. до..), который задает пользователь, отсортировать результат в обратном порядке
- Вывести всех динозавров название которых содержит строку вводимую пользователем (например «завр», «раптор»),
и которые выше числа введенного пользователем. Отсортировать результат по убыванию он самого высокого к самому маленькому.
 */
namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////  !!!!!!!! ВАЖНО !!!!!!  Дробные значения вводить через запятую, точка вызывает исключение!
            /// Я это исправил с использование IFormatProvider, вот он, ниже. После Console.ReadLine, где double, нужно везде дописать formatProvider
            /// тогда разделителем дроби будет работать точка.
            /// в конце вернул как было, к запятой, так дроби привычней для пользователя (мне кажется)

            //IFormatProvider formatProvider = new NumberFormatInfo { NumberDecimalSeparator = "." };
            List<Dinosaur> dinosaurs = new List<Dinosaur>()
            {
                new Dinosaur(){Id = 1, Name = "Стегозавр", Weight = 3.8, Height = 4.0},
                new Dinosaur(){Id = 2, Name ="Брахиозавр", Weight = 30.0, Height = 12.0},
                new Dinosaur(){Id = 3, Name ="Каудиптерикс", Weight = 0.014, Height = 0.6},
                new Dinosaur(){Id = 4, Name ="Целофиз", Weight = 0.03, Height=1.5},
                new Dinosaur(){Id = 5, Name ="Трицератопс", Weight = 10.0, Height = 3.0},
                new Dinosaur{Id = 6, Name ="Аллозавр", Weight = 3.5, Height = 3.5},
                new Dinosaur{Id=7, Name ="Велоцираптор", Weight= 0.02, Height = 0.055},
                new Dinosaur{Id = 8, Name ="Диплодок", Weight = 20.0, Height = 4.0},
                new Dinosaur{Id = 9, Name = "Кархародонтозавр", Weight = 10.0, Height = 3.8},
                new Dinosaur{Id = 10, Name ="Игуанодон", Weight = 4.0, Height = 3.5}
            };
            
            int userInput;
            Console.WriteLine("Все динозавры по порядку ID:");
            foreach (var dinosaur in dinosaurs)
            {
                dinosaur.Info();
            }
            do
            {                
                Console.WriteLine("\nВведите действие:");
                Console.WriteLine("1 - Вывести список динозавров отсортированный по имени.");
                Console.WriteLine("2 - Вывести динозавров вес которых задан диапазоном (от.. до..) в обратном порядке.");
                Console.WriteLine("3 - Вывести всех динозавров название которых содержит строку вводимую пользователем"+
                    " и которые выше роста введенного пользователем.");
                Console.WriteLine("0 - выход.");
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        //- Вывести список динозавров отсортированный по имени
                        var sortedNames = dinosaurs.OrderBy(x => x.Name);
                        foreach (var dinosaur in sortedNames)
                        {
                            dinosaur.Info();
                        }
                        break;
                    case 2:
                        //- Вывести динозавров вес которых задан диапазоном (от.. до..), который задает пользователь,
                        //отсортировать результат в обратном порядке
                        double min, max;
                        Console.WriteLine("Введите минимальный вес:");
                        min = double.Parse(Console.ReadLine());                        
                        Console.WriteLine("Введите максимальный вес:");
                        max = double.Parse(Console.ReadLine());
                        var result2 = dinosaurs.Where(x => x.Weight >= min && x.Weight <= max).OrderByDescending(x => x.Weight);
                        foreach (var dinosaur in result2)
                        {
                            dinosaur.Info();
                        }
                        break;
                    case 3:
                        //-Вывести всех динозавров название которых содержит строку вводимую пользователем(например «завр», «раптор»),
                        //и которые выше числа введенного пользователем. Отсортировать результат по убыванию он самого высокого к самому маленькому.
                        Console.WriteLine("Введите часть имени:");
                        string temp = Console.ReadLine();
                        Console.WriteLine("Укажите минимальный рост динозавра:");
                        double temp2 = double.Parse(Console.ReadLine());
                        var result3 = dinosaurs.Where(x => x.Name.Contains(temp) && x.Height > temp2).OrderByDescending(x=>x.Height);
                        foreach (var dinosaur in result3)
                        {
                            dinosaur.Info();
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Неверная команда!");
                        break;
                }
            } while (userInput!= 0);
            Console.ReadLine();
        }
    }
}
