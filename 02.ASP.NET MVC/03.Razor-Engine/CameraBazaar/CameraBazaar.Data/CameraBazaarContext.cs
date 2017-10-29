namespace CameraBazaar.Data
{
    using Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CameraBazaarContext : DbContext
    {
        public CameraBazaarContext()
            : base("CameraBazaarContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Camera> Cameras { get; set; }
    }
}