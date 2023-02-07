using System;
using System.Collections.Generic;

namespace OnlineTaxiBooking.Models.DBObjects
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Cars = new HashSet<Car>();
            Payments = new HashSet<Payment>();
        }

        public Guid UserId { get; set; }
        public string UserRole { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
