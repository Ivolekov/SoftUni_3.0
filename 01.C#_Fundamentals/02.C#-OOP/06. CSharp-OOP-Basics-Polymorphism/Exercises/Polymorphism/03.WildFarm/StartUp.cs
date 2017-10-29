using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WildFarm
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputAnimal = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            string[] inputFood = Console.ReadLine().Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);
            List<Animal> animals = new List<Animal>();

            while (inputAnimal[0] != "End")
            {


                string getTypeAnimal = inputAnimal[0].ToLower();
                string name = inputAnimal[1];
                double weight = double.Parse(inputAnimal[2]);
                string livingRegion = inputAnimal[3];


                string getTypeFood = inputFood[0].ToLower();
                int foodQuantity = int.Parse(inputFood[1]);

               

                switch (getTypeAnimal)
                {
                    case "cat":
                        string breed = inputAnimal[4];
                        Cat cat = new Cat(name, weight, livingRegion, breed);
                        cat.MakeSound();
                        animals.Add(cat);
                        switch (getTypeFood)
                        {
                            case "vegetable":
                                Vegetable veg = new Vegetable(foodQuantity);
                                cat.Eat(veg);
                                Console.WriteLine(cat);
                                break;
                            case "meat":
                                Meat meat = new Meat(foodQuantity);
                                cat.Eat(meat);
                                Console.WriteLine(cat);
                                break;
                        }
                        break;
                    case "tiger":
                        Tiger tiger = new Tiger(name, weight, livingRegion);
                        tiger.MakeSound();
                        animals.Add(tiger);
                        switch (getTypeFood)
                        {
                            case "vegetable":
                                Vegetable veg = new Vegetable(foodQuantity);
                                tiger.Eat(veg);
                                Console.WriteLine(tiger);
                                break;
                            case "meat":
                                Meat meat = new Meat(foodQuantity);
                                tiger.Eat(meat);
                                Console.WriteLine(tiger);
                                break;
                        }
                        break;
                    case "mouse":
                        Mouse mouse = new Mouse(name, weight, livingRegion);
                        mouse.MakeSound();
                        switch (getTypeFood)
                        {
                            case "vegetable":
                                Vegetable veg = new Vegetable(foodQuantity);
                                mouse.Eat(veg);
                                Console.WriteLine(mouse);
                                break;
                            case "meat":
                                Meat meat = new Meat(foodQuantity);
                                mouse.Eat(meat);
                                Console.WriteLine(mouse);
                                break;
                        }
                        break;
                    case "zebra":
                        Zebra zebra = new Zebra(name, weight, livingRegion);
                        zebra.MakeSound();
                        switch (getTypeFood)
                        {
                            case "vegetable":
                                Vegetable veg = new Vegetable(foodQuantity);
                                zebra.Eat(veg);
                                Console.WriteLine(zebra);
                                break;
                            case "meat":
                                Meat meat = new Meat(foodQuantity);
                                zebra.Eat(meat);
                                Console.WriteLine(zebra);
                                break;
                        }
                        break;
                }
                inputAnimal = Console.ReadLine().Split(new[] { ' ' },
           StringSplitOptions.RemoveEmptyEntries);
                if (inputAnimal[0]=="End")
                {
                    break;
                }
                inputFood = Console.ReadLine().Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);


            }

            foreach (var animal in animals)
            {
                //animal.MakeSound();
            }
        }
    }
}
