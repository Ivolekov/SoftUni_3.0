namespace SoftUniGameScore.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AllAdminGameViewModel
    {
        public IEnumerable<AdminGameViewModel> Games { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (AdminGameViewModel allGamesViewModel in Games)
            {
                sb.Append(allGamesViewModel);
            }
            return sb.ToString();
        }
    }
}
