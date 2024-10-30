namespace TMSApp.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public required string LicensePlate { get; set; }
        public required string Type { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }
    }
}
