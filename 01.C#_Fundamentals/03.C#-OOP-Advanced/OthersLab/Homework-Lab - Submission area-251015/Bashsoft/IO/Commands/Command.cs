namespace Lab.AdvancedCSharp.Bashsoft.IO.Commands
{
    using System;
    using Contracts;
    using Exceptions;

    public abstract class Command : IExecutable
    {
        #region Private Fields

        private string input;

        private string[] data;
        
        #endregion
        
        #region Constructors

        protected Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
        }

        #endregion

        #region Properties

        protected string Input
        {
            get
            {
                return this.input;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get
            {
                return this.data;
            }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        #endregion

        #region Abstract Methods

        public abstract void Execute(); 

        #endregion
    }
}
