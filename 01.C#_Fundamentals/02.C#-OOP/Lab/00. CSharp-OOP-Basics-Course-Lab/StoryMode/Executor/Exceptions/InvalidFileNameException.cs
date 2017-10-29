using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Exceptions
{
    class InvalidFileNameException : Exception
    {
        private const string ForbiddenSymbolsContainedInName = 
            "the given name contains symbols that are not alowed to be used in files or folders";

        public InvalidFileNameException()
            :base(ForbiddenSymbolsContainedInName)
        {
        }

        public InvalidFileNameException(string message) 
            : base(message)
        {
        }
    }
}
