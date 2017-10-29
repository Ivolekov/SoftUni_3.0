﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.IO.Contracts
{
    public interface IDirectoryChanger
    {
        void ChangeCurrentDirectoryRelative(string relaticePath);
        void ChangeCurrentDirectoryAbsolute(string absolutePath);
    }
}
