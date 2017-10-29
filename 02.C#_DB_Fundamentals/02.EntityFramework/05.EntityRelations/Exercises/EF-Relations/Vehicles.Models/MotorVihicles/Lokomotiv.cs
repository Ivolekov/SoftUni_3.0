namespace Vehicles.Models.MotorVihicles
{
    public class Lokomotiv
    {
        public string Model { get; set; }

        public double Power { get; set; }

        public virtual Train Train { get; set; }
    }
}