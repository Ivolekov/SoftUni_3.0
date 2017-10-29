using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (input != "Tournament")
            {
                string[] trainerArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = trainerArgs[0];
                string pokemonName = trainerArgs[1];
                string pokemonElement = trainerArgs[2];
                int pokemonHealth = int.Parse(trainerArgs[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                bool isTrainerExists = false;
                if (trainers.Any(x => x.name == trainerName))
                {
                    trainers.FirstOrDefault(x => x.name == trainerName).pokemons.Add(pokemon);
                    isTrainerExists = true;
                }

                if (isTrainerExists == false)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string element = input;
                foreach (var trainer in trainers)
                {
                    bool fountPokemon = false;
                    if (trainer.pokemons.Any(x => x.element == element))
                    {
                        fountPokemon = true;
                        trainer.bages++;
                    }
                    if (fountPokemon == false)
                    {
                        foreach (var pokemon in trainer.pokemons)
                        {
                            pokemon.health -= 10;
                        }
                    }
                    for (int i = 0; i < trainer.pokemons.Count; i++)
                    {
                        if (trainer.pokemons[i].health <= 0)
                        {
                            trainer.pokemons.Remove(trainer.pokemons[i]);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            var trainerResult = trainers.OrderByDescending(x => x.bages);
            foreach (var trainer in trainerResult)
            {
                Console.WriteLine($"{trainer.name} {trainer.bages} {trainer.pokemons.Count}");
            }
        }
    }

    public class Trainer
    {
        public string name;
        public int bages;
        public List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.name = name;
            this.bages = 0;
            this.pokemons = new List<Pokemon>();
        }
    }

    public class Pokemon
    {
        public string name;
        public string element;
        public int health;

        public Pokemon(string name, string element, int health)
        {
            this.name = name;
            this.element = element;
            this.health = health;
        }
    }
}
