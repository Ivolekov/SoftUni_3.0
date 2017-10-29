namespace PizzaForumApp.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            string content = "<form method=\"POST\">\r\n\t\t<label>Name</label>\r\n\t\t"+
                "<div class=\"form-group\">\r\n\t\t\t<input type=\"hidden\" "+
                $" class=\"form-control\" value=\"{this.Id}\" name=\"CategoryId\"/>\r\n\t\t\t"+
                $"<input type=\"text\" class=\"form-control\" value=\"{this.CategoryName}\" "+
                "name=\"CategoryName\"/>\r\n\t\t</div>\r\n\t\t<input type=\"submit\" class=\"btn btn-primary\"" +
                " value=\"Edit Category\"/>\r\n\t</form>";
            return content;
        }
    }
}
