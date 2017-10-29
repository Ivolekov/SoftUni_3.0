using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BookShop
{
    class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, double price) :
            base(author, title, price)
        {
        }

        public override double Price
        {
            get { return base.Price*1.3; }
        }
    }
}
