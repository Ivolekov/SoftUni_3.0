﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Repository.Contacts
{
    interface IDataSorter
    {
        void PrintSortedStudents(Dictionary<string, double> studentsMarks,
          string comparison, int studentsToTake);
    }
}
