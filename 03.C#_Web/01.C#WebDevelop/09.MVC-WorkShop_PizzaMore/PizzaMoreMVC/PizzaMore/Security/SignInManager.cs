namespace PizzaMore.Security
{
    using System.Linq;
    using PizzaMore.Data;
    using PizzaMore.Models;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Utilities;

    public class SignInManager
    {
        private PizzaMoreMVCContext context;

        public SignInManager(PizzaMoreMVCContext context)
        {
            this.context = context;

        }

        public bool IsAuthenticated(HttpSession session)
        {
            bool isAuthenticated = this.context.Sessions.Any(s => s.SessionId == session.Id && s.IsActive);
            return isAuthenticated;
        }

        public void Logout(HttpResponse response, string sessionId)
        {
            Session sessionEntity = this.context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
            sessionEntity.IsActive = false;
            this.context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);

        }
    }
}
