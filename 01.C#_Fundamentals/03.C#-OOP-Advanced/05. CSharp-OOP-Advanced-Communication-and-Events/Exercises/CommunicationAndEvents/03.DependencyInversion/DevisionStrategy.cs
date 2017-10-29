using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DependencyInversion
{
    public class DevisionStrategy : IStrategy
    {
        public int Operation(int firstNumber, int secondNumber)
        {
            return firstNumber / secondNumber;
        }
    }
}
