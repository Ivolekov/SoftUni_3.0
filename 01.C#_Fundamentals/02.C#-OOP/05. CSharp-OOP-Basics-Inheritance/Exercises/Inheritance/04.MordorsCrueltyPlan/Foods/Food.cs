using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MordorsCrueltyPlan.Foods
{
    abstract class Food
    {
        protected int points;

        public Food(int points)
        {
            this.points = points;
        }

        public int GetHappinessPoints()
        {
            return this.points;
        }
    }
}
