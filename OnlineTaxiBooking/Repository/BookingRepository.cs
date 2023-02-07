using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Models.DBObjects;

namespace OnlineTaxiBooking.Repository
{
    public class BookingRepository
    {
        private ApplicationDbContext dbContext;

        public BookingRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public List<BookingsModel> GetAllBookings()
        {
            List<BookingsModel> bookingsList = new List<BookingsModel>();
            foreach (Booking dbBookings in dbContext.Bookings)
            {
                bookingsList.Add(MapDbObjectToModel(dbBookings));
            }

            return bookingsList;
        }

        public BookingsModel GetBookingById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Bookings.FirstOrDefault(x => x.BookingId == ID));
        }

        public void InsertBooking(BookingsModel bookingModel)
        {
            bookingModel.BookingId = Guid.NewGuid();
            dbContext.Bookings.Add(MapModelToDbObject(bookingModel));
            dbContext.SaveChanges();
        }

        public void UpdateBooking(BookingsModel bookingModel)
        {
            Booking existingBooking = dbContext.Bookings.FirstOrDefault(x => x.BookingId == bookingModel.BookingId);
            if (existingBooking != null)
            {
                existingBooking.BookingId = bookingModel.BookingId;
                existingBooking.UserId = bookingModel.UserId;
                existingBooking.PaymentId = bookingModel.PaymentId;
                existingBooking.CarModel = bookingModel.CarModel;
                existingBooking.DriverName = bookingModel.DriverName;
                existingBooking.CustomerUsername = bookingModel.CustomerUsername;
                existingBooking.PaymentType = bookingModel.PaymentType;
                existingBooking.PaymentValue = bookingModel.PaymentValue;
                dbContext.SaveChanges();
            }
        }

        public void DeleteBooking(Guid id)
        {
            Booking existingBooking = dbContext.Bookings.FirstOrDefault(x => x.BookingId == id);
            if (existingBooking != null)
            {
                dbContext.Bookings.Remove(existingBooking);
                dbContext.SaveChanges();
            }
        }


        private BookingsModel MapDbObjectToModel(Booking dbBookings)
        {
            BookingsModel bookingModel = new BookingsModel();

            if (dbBookings != null)
            {
                bookingModel.BookingId= dbBookings.BookingId;
                bookingModel.UserId = dbBookings.UserId;
                bookingModel.PaymentId = dbBookings.PaymentId;
                bookingModel.CarModel = dbBookings.CarModel;
                bookingModel.DriverName = dbBookings.DriverName;
                bookingModel.CustomerUsername = dbBookings.CustomerUsername;
                bookingModel.PaymentType = dbBookings.PaymentType;
                bookingModel.PaymentValue = dbBookings.PaymentValue;
            }

            return bookingModel;
        }
        private Booking MapModelToDbObject(BookingsModel dbBookings)
        {
            Booking booking = new Booking();

            if (dbBookings != null)
            {
                booking.BookingId = dbBookings.BookingId;
                booking.UserId = dbBookings.UserId;
                booking.PaymentId = dbBookings.PaymentId;
                booking.CarModel = dbBookings.CarModel;
                booking.DriverName = dbBookings.DriverName;
                booking.CustomerUsername = dbBookings.CustomerUsername;
                booking.PaymentType = dbBookings.PaymentType;
                booking.PaymentValue = dbBookings.PaymentValue;
            }

            return booking;
        }
    }
}
