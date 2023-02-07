namespace OnlineTaxiBooking.Models
{
    public class CarsModel
    {
        public Guid CarID { get; set; }
        public Guid UserId { get; set; }
        public string CarType { get; set; }
        public string CarModel { get; set; }
        public string DriverName { get; set; }
    }
}
