using FootballBett.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class ResultPrediction
    {
        public int Id { get; set; }

        public Prediction Prediction { get; set; }
    }
}
