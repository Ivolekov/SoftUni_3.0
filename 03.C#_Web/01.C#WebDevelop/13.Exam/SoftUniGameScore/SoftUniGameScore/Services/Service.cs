namespace SoftUniGameScore.Services
{
    using Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }
        protected SoftUniGameScoreContext Context { get; }
    }
}
