namespace LearningSystem.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;
    public class EditUsersBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
