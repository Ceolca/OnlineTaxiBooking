namespace OnlineTaxiBooking.Models
{
    public class PaymentsModel
    {
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public decimal PaymentValue { get; set; }
        public string PaymentCurrency { get; set; }
        public string PaymentType { get; set; }
    }
}
