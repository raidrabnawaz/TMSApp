namespace TMSApp.Models
{
    public class MaintenanceRecord
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public Vehicle? Vehicle { get; set; }
        public required string ActivityType { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public string? Notes { get; set; }
    }
}
