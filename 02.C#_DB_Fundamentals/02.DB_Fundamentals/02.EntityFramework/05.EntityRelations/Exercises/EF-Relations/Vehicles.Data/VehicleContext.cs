namespace Vehicles.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class VehicleContext : DbContext
    {
        public VehicleContext()
            : base("VehicleContext")
        {
        }

        public IDbSet<Vihicle> Vihicels { get; set; }
    }
}