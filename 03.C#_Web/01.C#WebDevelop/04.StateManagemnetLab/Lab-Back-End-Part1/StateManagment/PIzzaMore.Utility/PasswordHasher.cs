namespace PIzzaMore.Utility
{
    public class PasswordHasher
    {
        public static string Hash(string password)
        {
            return $"SECRET{password}";
        }
    }
}
