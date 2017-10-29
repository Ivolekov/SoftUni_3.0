using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.DependencyInversion;

namespace _03DependencyInversion
{
    class PrimitiveCalculator
    {
        private IStrategy strategy;

        public PrimitiveCalculator()
            : this(new AdditionStrategy())
        {
            
        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Operation(firstOperand, secondOperand);
        }
    }
}
