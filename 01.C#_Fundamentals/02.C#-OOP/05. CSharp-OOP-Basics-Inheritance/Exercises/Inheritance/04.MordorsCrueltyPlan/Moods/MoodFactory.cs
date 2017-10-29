using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MordorsCrueltyPlan.Moods
{
    class MoodFactory
    {
        public static Mood MakeMood(int moodPoint)
        {
            if (moodPoint < -5)
            {
                return new Angry();
            }
            else if (moodPoint <= 0)
            {
                return new Sad();
            }
            else if (moodPoint <= 15)
            {
                return new Happy();
            }
            else
            {
                return new JavaScript();
            }
        }
    }
}
