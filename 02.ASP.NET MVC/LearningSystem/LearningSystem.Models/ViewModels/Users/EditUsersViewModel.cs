namespace LearningSystem.Models.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    public class EditUsersViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
