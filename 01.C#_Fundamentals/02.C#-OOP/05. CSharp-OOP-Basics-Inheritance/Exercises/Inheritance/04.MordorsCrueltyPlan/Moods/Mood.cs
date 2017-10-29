using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MordorsCrueltyPlan.Moods
{
    abstract class Mood
    {
        protected string mood;

        public Mood(string mood)
        {
            this.mood = mood;
        }

        public string GetMood()
        {
            return this.mood;
        }
    }
}
