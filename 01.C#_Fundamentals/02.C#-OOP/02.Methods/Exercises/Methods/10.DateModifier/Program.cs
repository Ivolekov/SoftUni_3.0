using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firsDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
           
            DateModifier dates = new DateModifier(firsDate, secondDate);
            Console.WriteLine(dates.DaysBeetweenTwoDate());
        }
    }

    public class DateModifier
    {
        public string firstDate;
        public string secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        public int DaysBeetweenTwoDate()
        {
            DateTime parseFirstDate = Convert.ToDateTime(this.firstDate);
            DateTime parseSecondDate = Convert.ToDateTime(this.secondDate);
            var result = (int)((parseFirstDate - parseSecondDate).TotalDays);
            var resultABS = Math.Abs(result);
            return resultABS;
        }
    }
}
