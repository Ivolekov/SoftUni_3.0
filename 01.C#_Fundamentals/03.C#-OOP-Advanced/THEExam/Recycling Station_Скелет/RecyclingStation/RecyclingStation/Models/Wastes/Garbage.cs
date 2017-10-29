namespace RecyclingStation.Models.Wastes
{
    using System;
    using System.Data;
    using RecyclingStation.Enumerations;
    using RecyclingStation.Interfaces;

    public abstract class Garbage : IGarbage
    {
        private StrategyType type;
        private string name;
        private double volumePerKg;
        private double weight;

        protected Garbage(StrategyType type, string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The name of weisht cannot be empty");
                }
                this.name = value;
            }
        }

        public double VolumePerKg
        {
            get { return this.volumePerKg; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidExpressionException("The value of volume per kg cannot be negative!");
                }
                this.volumePerKg = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidExpressionException("The weight cannot be negative value!");
                }
                this.weight = value;
            }
        }

        public StrategyType Type { get; }
    }
}
