namespace PizzaForumApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DetailsViewModel
    {
        public DetailsTopicViewModel Topic { get; set; }

        public IEnumerable<DetailsReplyViewModel> Replies { get; set; }
    }
}
