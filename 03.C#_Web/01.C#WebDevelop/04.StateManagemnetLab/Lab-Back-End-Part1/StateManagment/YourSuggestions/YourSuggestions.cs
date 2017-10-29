﻿using PizzaMore.Data;
using PIzzaMore.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YourSuggestions
{
    public class YourSuggestions
    {
        private static IDictionary<string, string> RequestParameters;
        private static Header Header = new Header();
        private static Session Session = new Session();

        public static void Main()
        {
            Session = WebUtil.GetSession();
            if (Session != null)
            {
                if (WebUtil.IsGet())
                {
                    ShowPage();
                }
                else if (WebUtil.IsPost())
                {
                    DeletePizza();
                    ShowPage();
                }
            }
            else
            {
                Header.Print();
                WebUtil.PageNotAllowed();
            }
        }

        private static void DeletePizza()
        {
            RequestParameters = WebUtil.RetrivePostParameters();
            int pizzaToDeleteId = int.Parse(RequestParameters["pizzaid"]);
            using (var context = new PizzaMoreContext())
            {
                Pizza pizzaToRemove = context.PizzaSuggestions.Find(pizzaToDeleteId);
                context.PizzaSuggestions.Remove(pizzaToRemove);
                context.SaveChanges();
            }
        }

        private static void ShowPage()
        {
            Header.Print();
            WebUtil.PrintFileContent(Constants.SuggestionsTop);
            PrintListOfSuggestedItems();
            WebUtil.PrintFileContent(Constants.SuggestionsBottom);
        }

        private static void PrintListOfSuggestedItems()
        {
            var context = new PizzaMoreContext();
            var suggestions = context.PizzaSuggestions.Where(p => p.Owner.Id == Session.User.Id);
            Console.WriteLine("<ul>");
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"DetailsPizza.exe?pizzaid={suggestion.Id}\">{suggestion.Title}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }
            Console.WriteLine("</ul>");
        }
    }
}
