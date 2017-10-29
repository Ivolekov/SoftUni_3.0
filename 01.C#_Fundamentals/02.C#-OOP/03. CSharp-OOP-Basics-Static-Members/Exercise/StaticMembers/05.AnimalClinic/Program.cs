using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AnimalClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> healAnimal = new List<Animal>();
            List<Animal> rehabAnimal = new List<Animal>();
            while (input != "End")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string breed = tokens[1];
                string healOrRehab = tokens[2];
                AnimalClinic animals = new AnimalClinic(new Animal(name, breed));
                switch (healOrRehab)
                {
                    case "heal":
                        Console.WriteLine("Patient " + AnimalClinic.PatientCounter +
                            $": [{name} ({breed})] has been healed!");
                        AnimalClinic.Heal();
                        healAnimal.Add(new Animal(name, breed));
                        //healAnimal.Add(new Animal(name, breed));
                        break;
                    case "rehabilitate":
                        Console.WriteLine("Patient " + AnimalClinic.PatientCounter +
                            $": [{name} ({breed})] has been rehabilitated!");
                        AnimalClinic.Rehabilite();
                        //rehabAnimal.Add(new Animal(name, breed));
                        rehabAnimal.Add(new Animal(name, breed));
                        break;

                }

                input = Console.ReadLine();
            }
            string command = Console.ReadLine();
            Console.WriteLine("Total healed animals: " + AnimalClinic.HealedAnimalsCount);
            Console.WriteLine("Total rehabilitated animals: " + AnimalClinic.RehabilitedAnimalsCount);
            switch (command)
            {
                case "heal":
                    foreach (var animal in healAnimal)
                    {
                        Console.WriteLine(animal);
                    }
                    break;
                case "rehabilitate":
                    foreach (var animal in rehabAnimal)
                    {
                        Console.WriteLine(animal);
                    }
                    break;
            }
        }
    }

    public class Animal
    {
        public string name;
        public string breed;

        public Animal(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
        }

        public override string ToString()
        {
            return string.Format($"{name} {breed}");
        }
    }

    public class AnimalClinic
    {
        public static int patientId;
        public static int healedAnimalsCount;
        public static int rehabilitedAnimalsCount;
        public static List<Animal> healAnimals;
        public static List<Animal> rehabAnimals;

        public static int PatientCounter
        {
            get { return AnimalClinic.patientId; }
        }

        public static int HealedAnimalsCount
        {
            get { return AnimalClinic.healedAnimalsCount; }
        }
        public static int RehabilitedAnimalsCount
        {
            get { return AnimalClinic.rehabilitedAnimalsCount; }
        }

        public AnimalClinic(Animal animal)
        {
            patientId++;
            List<Animal> healAnimals = new List<Animal>();
            List<Animal> rehabAnimals = new List<Animal>();
        }

        public static void Heal()
        {
            healedAnimalsCount++;
        }

        public static void Rehabilite()
        {
            rehabilitedAnimalsCount++;
        }

        public string Animal { get; set; }
    }
}
