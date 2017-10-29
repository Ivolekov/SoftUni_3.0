namespace LearningSystem.Service
{
    using Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = new LearningSystemContext();
        }

        protected LearningSystemContext Context { get; set; }
    }
}
