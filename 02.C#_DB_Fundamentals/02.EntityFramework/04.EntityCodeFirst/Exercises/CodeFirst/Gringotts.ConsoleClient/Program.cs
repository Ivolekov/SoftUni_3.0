using Gringotts.Data;
using Gringotts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WizartContext context = new WizartContext();
            //context.WizartDeposits.Count();

            WizardDeposit dumbledore = new WizardDeposit()
            {
                Firstname = "Mavrus",
                Lastname = "Desketar",
                Age = 250,
                MagicWandCreator = "Ev Quartys",
                MagicWandSize = 30,
                DepositStartDate = new DateTime(2016, 11, 20),
                DepositExpirationDate = new DateTime(2022, 11, 20),
                DepositAmount = 50000.24m,
                DepositCharge = 0.3,
                IsDepositExpired = false
            };

            context.WizartDeposits.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
