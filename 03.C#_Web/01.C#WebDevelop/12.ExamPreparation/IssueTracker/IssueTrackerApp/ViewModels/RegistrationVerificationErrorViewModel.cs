namespace IssueTrackerApp.ViewModels
{
    public class RegistrationVerificationErrorViewModel
    {
        public RegistrationVerificationErrorViewModel(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

        public override string ToString()
        {
            string template = $"<div class=\"alert alert-danger alert-dismissable\">\r\n  <a href=\"/users/register\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n  <strong>Error!</strong>{this.Message}\r\n</div>";
            return template;
        }
    }
}
