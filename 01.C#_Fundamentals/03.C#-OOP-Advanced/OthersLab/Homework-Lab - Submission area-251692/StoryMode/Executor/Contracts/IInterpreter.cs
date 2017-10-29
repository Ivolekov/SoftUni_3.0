using System;

namespace Executor.Contracts
{
    public interface IInterpreter
    {
        void InterpretCommand(String command);
    }
}
