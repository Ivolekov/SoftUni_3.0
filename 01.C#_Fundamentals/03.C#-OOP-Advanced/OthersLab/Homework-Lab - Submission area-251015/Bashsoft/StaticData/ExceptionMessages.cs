namespace Lab.AdvancedCSharp.Bashsoft.StaticData
{
    public static class ExceptionMessages
    {
        public const string DataAlreadyInitialized = "Data is already initialized!";
        public const string DataNotInitialized = "The data structure must be initialised first in order to make any operations with it.";
        public const string InexistingCourseInDatabase = "The course you are trying to get does not exist in the data base!";
        public const string InexistingStudentInDatabase = "The user name for the student you are trying to get does not exist!";
        public const string UnauthorizedAccess = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";
        public const string DifferentSizeFileComparison = "Files not of equal size, certain mismatch.";
        public const string RootDirectoryReached = "Root directory reached. Unable to go higher than the root directory!";
        public const string UnableToParseNumber = "The sequence you've written is not a valid number.";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";
        public const string InvalidTakeCommand = "The take command expected does not match the format wanted!";
        public const string InvalidTakeQuantityParameter = "The take quantity parameter is not valid!";
        public const string InvalidNumberOfScores = "The number of scores for the given course is greater than the possible.";
        public const string InvalidScore = "Invalid score! The score must be between 0 and 100!";
    }
}
