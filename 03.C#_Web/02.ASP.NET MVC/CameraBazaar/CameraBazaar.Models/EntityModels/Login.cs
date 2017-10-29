namespace CameraBazaar.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Login
    {
        [Key]
        public string SessionId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public bool IsActive { get; set; }

        public int MyProperty { get; set; }

        public override string ToString()
        {
            return $"{this.SessionId}/t{this.User.Id}";
        }
    }
}
