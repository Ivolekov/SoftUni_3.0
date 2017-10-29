namespace SoftUniGameScore.ViewModels
{
    using System.Collections.Generic;
    using System.Text;

    public class AllViewModel
    {
        public IEnumerable<GamesViewModel> Games { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int counter = 0;
            foreach (GamesViewModel allGamesViewModel in Games)
            {
                if (counter != 0 && counter % 3 == 0)
                {
                    sb.Append("</div>");
                }
                if (counter % 3 == 0)
                {
                    sb.Append("<div class=\"card-group\">");
                }
                sb.Append(allGamesViewModel);
                counter++;
            }
            
            return sb.ToString();
        }
    }
}
