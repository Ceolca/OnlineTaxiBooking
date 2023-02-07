using System;
using System.Collections.Generic;

namespace OnlineTaxiBooking.Models.DBObjects
{
    public partial class Booking
    {
        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }
        public Guid PaymentId { get; set; }
        public string CarModel { get; set; } = null!;
        public string DriverName { get; set; } = null!;
        public string CustomerUsername { get; set; } = null!;
        public string PaymentType { get; set; } = null!;
        public decimal PaymentValue { get; set; }

        public virtual Payment Payment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
