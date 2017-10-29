namespace Lab.AdvancedCSharp.Bashsoft.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Contracts;
    using Exceptions;
    using StaticData;

    public class IOManager : IDirectoryManager
    {
        #region Public Methods

        public void CreateDirectory(string name)
        {
            string path = Path.Combine(this.GetCurrentDirectoryPath(), name);

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeDirectoryRelative(string relativePath)
        {
            string currentPath = this.GetCurrentDirectoryPath();

            if (relativePath == "..")
            {
                try
                {
                    int lastSlashIndex = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, lastSlashIndex);
                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.RootDirectoryReached, "lastSlashIndex");
                }
            }
            else
            {
                currentPath += $"\\{relativePath}";
                this.ChangeDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = absolutePath;
        }

        public void TraverseDirectory(int traversalDepth)
        {
            var path = this.GetCurrentDirectoryPath();
            var initialIndentation = path.Split('\\').Length;
            var subfolders = new Queue<string>();
            subfolders.Enqueue(path);

            while (subfolders.Count != 0)
            {
                var currentPath = subfolders.Dequeue();
                var currentIndentation = currentPath.Split('\\').Length;
                var indentation = currentIndentation - initialIndentation;
                if (traversalDepth - indentation < 0)
                {
                    break;
                }

                try
                {
                    var message = $"{new string('=', indentation)}{currentPath}";
                    OutputWriter.WriteMessageLine(message, Console.ForegroundColor);

                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int lastSlashIndex = file.LastIndexOf('\\');
                        string fileName = file.Substring(lastSlashIndex);
                        message = $"{new string('=', lastSlashIndex)}{fileName}";
                        OutputWriter.WriteMessageLine(message, Console.ForegroundColor);
                    }

                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subfolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccess);
                }
            }
        }

        #endregion
        
        #region Private Methods

        private string GetCurrentDirectoryPath()
        {
            return SessionData.CurrentPath;
        }
         
        #endregion
    }
}
