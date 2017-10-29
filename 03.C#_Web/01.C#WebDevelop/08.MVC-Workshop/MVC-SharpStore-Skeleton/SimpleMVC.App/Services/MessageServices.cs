namespace SimpleMVC.App.Services
{
    using SimpleMVC.App.BindingModels;
    using SimpleMVC.App.Data;
    using SimpleMVC.App.Models;

    public class MessageServices : Service
    {
        public MessageServices(SharpStoreContext context) : base(context)
        {
        }

        public void MessageFromBind(MessageBinding binding)
        {
            Message message = new Message()
            {
                Email = binding.Email,
                MessageText = binding.Message,
                Subject = binding.Subject
            };
            this.context.Messages.Add(message);
            this.context.SaveChanges();
        }
    }
}
