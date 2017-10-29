namespace LearningSystem.Models.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AddArticleBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
