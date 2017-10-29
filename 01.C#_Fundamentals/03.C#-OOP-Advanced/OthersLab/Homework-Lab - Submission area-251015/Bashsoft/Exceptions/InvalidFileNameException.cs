﻿namespace Lab.AdvancedCSharp.Bashsoft.Exceptions
{
    using System;

    public class InvalidFileNameException : Exception
    {
        private const string ForbiddenSymbolsInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public InvalidFileNameException() : base(ForbiddenSymbolsInName)
        {
        }

        public InvalidFileNameException(string message) : base(message)
        {
        }
    }
}
