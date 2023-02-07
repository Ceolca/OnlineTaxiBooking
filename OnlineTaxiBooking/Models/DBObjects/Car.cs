using System;
using System.Collections.Generic;

namespace OnlineTaxiBooking.Models.DBObjects
{
    public partial class Car
    {
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public string CarType { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public string? DriverName { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
