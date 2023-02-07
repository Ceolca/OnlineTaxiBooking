namespace OnlineTaxiBooking.Models
{
    public class BookingsModel
    {
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public string CarModel { get; set; }
        public string DriverName { get; set; }
        public string CustomerUsername { get; set; }
        public string PaymentType { get; set; }
        public decimal PaymentValue { get; set; }
    }
}
