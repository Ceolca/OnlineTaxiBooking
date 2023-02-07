using System;
using System.Collections.Generic;

namespace OnlineTaxiBooking.Models.DBObjects
{
    public partial class Payment
    {
        public Payment()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
        public decimal PaymentValue { get; set; }
        public string PaymentCurrency { get; set; } = null!;
        public string PaymentType { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
