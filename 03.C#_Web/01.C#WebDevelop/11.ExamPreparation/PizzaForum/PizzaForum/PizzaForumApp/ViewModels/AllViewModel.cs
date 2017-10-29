namespace PizzaForumApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AllViewModel
    {
        //public LoginUserViewModel User { get; set; }

        public IEnumerable<AllCategoryViewModel> Categories { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (AllCategoryViewModel allCategoryViewModel in Categories)
            {
                sb.Append(allCategoryViewModel);
            }
            return sb.ToString();
        }
    }
}
