namespace PizzaForumApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProfileViewModel
    {
        public string ClickedUsername { get; set; }

        public int ClickeUserId { get; set; }

        public int CurrentUserId { get; set; }

        public IEnumerable<ProfileTopicViewModel> Topics { get; set; }
    }
}
