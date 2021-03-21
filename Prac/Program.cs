using System;
using System.Collections.Generic;
using System.Linq;

namespace Prac
{
    class Program
    {
        abstract class Animal
        {
            public string kind, foodType;
            public double animalWeight, foodWeight;

            public Animal(string kind, double animalWeight)
            {
                this.kind = kind;
                this.animalWeight = animalWeight;
            }
            public abstract void SetFoodWeight();
        }

        class Predator : Animal
        {
            public Predator(string kind, double animalWeight)
              : base(kind, animalWeight)
            {

            }
            public override void SetFoodWeight()
            {
                foodType = "мясо";
                foodWeight = animalWeight * 0.4;
            }
        }
        class Omnivore : Animal
        {
            public Omnivore(string kind, double animalWeight)
              : base(kind, animalWeight)
            {

            }
            public override void SetFoodWeight()
            {
                foodType = "овощи, фрукты и мясо";
                foodWeight = animalWeight * 0.3;
            }
        }
        class Herbivore : Animal
        {
            public Herbivore(string kind, double animalWeight)
              : base(kind, animalWeight)
            {

            }
            public override void SetFoodWeight()
            {
                foodType = "овощи, фрукты";
                foodWeight = animalWeight * 0.5;
            }
        }
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[5]
            {
                new Predator("Тигр", 110),
                new Herbivore("Корова", 130),
                new Omnivore("Медведь", 100),
                new Herbivore("Жираф", 160),
                new Predator("Акула", 280)
            };

            Console.WriteLine("Изначальный порядок животных:");
            foreach (Animal a in animals)
            {
                a.SetFoodWeight();
                Console.WriteLine($"{a.kind} --- {a.animalWeight} --- {a.foodWeight} --- {a.foodType}");
            }
            
            //1 - Упорядочить по убыванию количества пищи
            Console.WriteLine("\nСортировка по убыванию количества пищи");
            IEnumerable<Animal> sortedAnimals = animals.OrderByDescending(a => a.foodWeight);
            foreach (Animal a in sortedAnimals)
            {
                Console.WriteLine($"{a.kind} --- {a.animalWeight} --- {a.foodWeight} --- {a.foodType}");
            }
            //2 - Вывести первую тройку животных из сортировки убывания пищи
            Console.WriteLine("\nСортировка по убыванию количества пищи, вывод первых трёх животных");
            sortedAnimals = animals.OrderByDescending(a => a.foodWeight).Take(3);
            foreach (Animal a in sortedAnimals)
            {
                Console.WriteLine($"{a.kind} --- {a.animalWeight} --- {a.foodWeight} --- {a.foodType}");
            }
            //3 - Вывести последних трёх животных
            Console.WriteLine("\nВывод последних трёх животных");
            sortedAnimals = animals.OrderBy(a => a.foodWeight).Take(3);
             foreach (Animal a in sortedAnimals)
            {
                Console.WriteLine($"{a.kind} --- {a.animalWeight} --- {a.foodWeight} --- {a.foodType}");
            }
            Console.WriteLine("\nБедные животные...");
            Console.ReadKey();
        }
    }
}
