using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.PizzaTime
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodInfo[] methods = typeof(Pizza).GetMethods();
            bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("SortedDictionary`2"));
            if (!containsMethod)
            {
                throw new Exception();
            }

            string[] input = Console.ReadLine().Split();
            Pizza[] pizzas = new Pizza[input.Length];
            Regex reg = new Regex(@"(\d+)(\w+)");
            for (int i = 0; i < input.Length; i++)
            {
                Match match = reg.Match(input[i]);
                int group = int.Parse(match.Groups[1].Value);
                string pizzaName = match.Groups[2].Value;
                Pizza pizza = new Pizza(pizzaName, group);
                pizzas[i] = pizza;
            }
            var resultPizzas = Pizza.GetPizzas(pizzas);
            foreach (var pizza in resultPizzas)
            {
                Console.WriteLine($"{pizza.Key} - {string.Join(", ", pizza.Value)}");
            }
        }
    }
}

public class Pizza
{
    public string name;
    public int group;

    public Pizza(string name, int group)
    {
        this.name = name;
        this.group = group;
    }

    public static SortedDictionary<int, List<string>> GetPizzas(params Pizza[] pizzas)
    {
        SortedDictionary<int, List<string>> pizzaDictionary = new SortedDictionary<int, List<string>>();
        foreach (var pizza in pizzas)
        {
            if (!pizzaDictionary.ContainsKey(pizza.group))
            {
                pizzaDictionary.Add(pizza.group, new List<string>());
            }
            pizzaDictionary[pizza.group].Add(pizza.name);
        }
        return pizzaDictionary;
    }
}