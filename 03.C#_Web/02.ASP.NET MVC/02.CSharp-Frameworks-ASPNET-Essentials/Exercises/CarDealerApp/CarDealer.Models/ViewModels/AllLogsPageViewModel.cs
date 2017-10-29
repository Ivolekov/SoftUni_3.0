namespace CarDealer.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AllLogsPageViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalNumberOfPages { get; set; }

        public IEnumerable<AllLogViewModel> Logs { get; set; }

        public string WantedUserName { get; set; }
    }
}
