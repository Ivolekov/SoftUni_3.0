using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.MordorsCrueltyPlan.Factories;
using _04.MordorsCrueltyPlan.Foods;
using _04.MordorsCrueltyPlan.Moods;

namespace _04.MordorsCrueltyPlan
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] {},
                StringSplitOptions.RemoveEmptyEntries);
            List<Food> foods = new List<Food>();
            int moodFactor = 0;
            foreach (var food in input)
            {
                moodFactor += FoodFactory.MakeFood(food).GetHappinessPoints();
                foods.Add(FoodFactory.MakeFood(food));
            }

            Console.WriteLine(moodFactor);
            Console.WriteLine(MoodFactory.MakeMood(moodFactor).GetMood());
        }
    }
}
