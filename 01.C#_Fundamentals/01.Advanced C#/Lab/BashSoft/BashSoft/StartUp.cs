using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //IOManager.TraverseDirectory(@"E:\");
            //Data.InitializeData();
            //Data.GetAllStudentsFromCourse("Unity");
            //Data.GetStudentScoresFromCourse("Ivan", "Unity");
            //IOManager.CreateDirectoryInCurrentFolder("pesho");
           //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);
            //IOManager.CreateDirectoryInCurrentFolder("*2");
            InputReader.StartReadingCommands();
        }
    }
}
