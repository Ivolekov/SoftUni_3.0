namespace SoftUniGameScore.Data
{
    public class Data
    {
        private static SoftUniGameScoreContext context;

        public static SoftUniGameScoreContext Context => context ?? (context = new SoftUniGameScoreContext());
    }
}
