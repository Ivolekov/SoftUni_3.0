namespace IssueTrackerApp
{
    public class Constants
    {
        //Html path constants
        public const string ConstantPath = "../../content/";
        public const string Header = "header.html";
        public const string Footer = "footer.html";
        public const string Login = "login.html";
        public const string Register = "register.html";
        public const string Menu = "menu.html";
        public const string MenuLogged = "menu-logged.html";
        public const string Home = "home.html";

        //Validation constants
        public const string UserNameLengthErrorMessage = "Username should be between 5 and 30 symbols";
        public const string PasswordIncorrectFormatMessage = "The password is not in the correct format";
        public const string FullNameTooShortMessage = "The full name should be at least 5 symbols";
        public const string PasswordsDoNotMatchMessage = "Passwords do not match";
        public const string UsernameError = "This username do not exist in database";
        public const string WrongPassword = "Wrong Password";

    }
}
