using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.MordorsCrueltyPlan.Foods;

namespace _04.MordorsCrueltyPlan.Factories
{
    class FoodFactory
    {
        public static Food MakeFood(string food)
        {
            switch (food.ToLower())
            {
                case "apple":
                    return new Apple();
                case "cram":
                    return new Cram();
                case "honeycake":
                    return new HoneyCake();
                case "lembas":
                    return new Lembas();
                case "melon":
                    return new Melon();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return new Junk();
            }
        }
    }
}
