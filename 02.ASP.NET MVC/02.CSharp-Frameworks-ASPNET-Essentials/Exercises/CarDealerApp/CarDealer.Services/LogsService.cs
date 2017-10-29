namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarDealer.Data;
    using Models.ViewModels;
    using Models;

    public class LogsService : Service
    {
        public LogsService(CarDealerContext context) : base(context)
        {
        }

        public AllLogsPageViewModel GetAllLogsPageVm(string username, int? page)
        {
            var currentPage = 1;
            if (page != null)
            {
                currentPage = page.Value;
            }

            IEnumerable<Log> logs;
            if (username != null)
            {
                logs = this.Context.Logs.Where(log => log.User.Username == username);
            }
            else
            {
                logs = this.Context.Logs;
            }

            int allLogPagesCount = logs.Count() / 20 + (logs.Count() % 20 == 0 ? 0 : 1);
            int logsTotake = 20;
            if (allLogPagesCount == currentPage)
            {
                logsTotake = logs.Count() % 20 == 0 ? 20 : logs.Count() % 20;
            }

            logs = logs.Skip((currentPage - 1) * 20).Take(logsTotake);

            List<AllLogViewModel> logVms = new List<AllLogViewModel>();
            foreach (Log log in logs)
            {
                logVms.Add(new AllLogViewModel()
                {
                    Operation = log.Operation,
                    ModfiedTable = log.ModifiedTableName,
                    UserName = log.User.Username,
                    ModifiedAt = log.ModifiedAt
                });
            }


            AllLogsPageViewModel pageVm = new AllLogsPageViewModel()
            {
                WantedUserName = username,
                CurrentPage = currentPage,
                TotalNumberOfPages = allLogPagesCount,
                Logs = logVms
            };

            return pageVm;
        }

        public void DeleteAllLogs()
        {
            this.Context.Logs.RemoveRange(this.Context.Logs);
            this.Context.SaveChanges();
        }
    }
}
