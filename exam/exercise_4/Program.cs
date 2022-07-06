using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace exercise_4
{
  

    interface IDog : IInfo
    {
        string Name { get; }
        
        string Breed { get; }
        string Type { get; }
    }
    interface IInfo
    {
        void GetInfo();
    }
    public class HuntingDog : IDog, IInfo
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Type { get { return "охотничья"; } }
        public void GetInfo()
        {
            Console.WriteLine($"Тип собаки: {Type}, парода: {Breed}, кличка: {Name}");
        }
    }
    public class DecorativeDog : IDog, IInfo
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Type { get { return "декоративная"; } }
        public void GetInfo()
        {
            Console.WriteLine($"Тип собаки: {Type}, парода: {Breed}, кличка: {Name}");
        }

    }
    public class ServiceDog : IDog, IInfo
    {
        public string Name { get; set; }
        public string Breed { get; set; }        
        public string Type { get { return "служебная"; } }
        public string Profession { get; set; }
        public void GetInfo()
        {
            Console.WriteLine($"Тип собаки: {Type} ({Profession}), парода: {Breed}, кличка: {Name}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {        
            List<IDog> dogs = new List<IDog>()
            {
                new HuntingDog { Name = "Бим", Breed = "Спаниель" },
                new ServiceDog { Name = "Джек", Breed = "Доберман", Profession = "ищейка" },
                new ServiceDog{Name ="Боб", Breed = "Ризеншнауц", Profession = "поводырь"},
                new ServiceDog{ Name="Джерри", Breed = "Дог", Profession= "охранник"},
                new DecorativeDog { Name="Ганс", Breed = "Той-терьер"}
            };         

            foreach (IDog dog in dogs)
            {
                dog.GetInfo();
            }
            Console.ReadLine();
        }
    }
}
