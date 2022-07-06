using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_2
{
    internal class Dinosaur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public void Info()
        {
            Console.WriteLine($"ID = {Id}, Название: {Name}, вес: {Weight} тонны, рост: {Height} метра.");
        }
    }
}
