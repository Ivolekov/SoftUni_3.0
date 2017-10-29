using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _03.DependencyInversion;

namespace _03DependencyInversion
{
    class AdditionStrategy : IStrategy
    {
        public int Operation(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
