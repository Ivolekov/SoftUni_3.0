﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBett.Models
{
    public class BetGame
    {
        public int BetId { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual Bet Bet { get; set; }

        public virtual ResultPrediction ResultPrediction { get; set; }
    }
}
