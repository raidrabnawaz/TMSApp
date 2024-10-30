namespace TMSApp.Models
{
    public class HomeOverviewViewModel
    {
        public int TotalVehicles { get; set; }
        public List<MaintenanceRecord> RecentMaintenanceRecords { get; set; }
        public List<MaintenanceRecord> UpcomingMaintenanceRecords { get; set; }
    }
}
