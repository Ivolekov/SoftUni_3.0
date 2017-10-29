using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Animal f = new Cat("F", 10, "M");
            //Console.WriteLine(f);
            //f.produceSound();

            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                try
                {
                    string animalType = input;
                    string[] animalArgs = Console.ReadLine().Split(' ');
                    string name = animalArgs[0];
                    int age = int.Parse(animalArgs[1]);
                    string gender = animalArgs[2];
                    string nameSpace = "Animals";

                    switch (animalType)
                    {
                        case "Cat":
                            Animal cat = new Cat(name, age, gender);
                            Console.WriteLine(cat);
                            cat.produceSound();
                            break;
                        case "Dog":
                            Animal dog = new Dog(name, age, gender);
                            Console.WriteLine(dog);
                            dog.produceSound();
                            break;
                        case "Frog":
                            Animal frog = new Frog(name, age, gender);
                            Console.WriteLine(frog);
                            frog.produceSound();
                            break;
                        case "Kitten":
                            Animal kitten = new Kitten(name, age, gender);
                            Console.WriteLine(kitten);
                            kitten.produceSound();
                            break;
                        case "Tomcat":
                            Animal tomcat = new Tomcat(name, age, gender);
                            Console.WriteLine(tomcat);
                            tomcat.produceSound();
                            break;
                    }

                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                input = Console.ReadLine();
            }

        }
    }
}
