namespace LearningSystem.Service
{
    using Interfaces;
    using Models.EntityModels;
    public class AccountService : Service, IAccountService
    {
        public void CreateStudent(ApplicationUser user)
        {
            Student student = new Student();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            student.User = currentUser;
            this.Context.Students.Add(student);
            this.Context.SaveChanges();
        }
    }
}
