using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Models.DBObjects;

namespace OnlineTaxiBooking.Repository
{
    public class PaymentsRepository
    {
        private ApplicationDbContext dbContext;

        public PaymentsRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public PaymentsRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public List<PaymentsModel> GetAllPayments()
        {
            List<PaymentsModel> paymentsList = new List<PaymentsModel>();
            foreach (Payment dbPayments in dbContext.Payments)
            {
                paymentsList.Add(MapDbObjectToModel(dbPayments));
            }

            return paymentsList;
        }

        public PaymentsModel GetPaymentById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Payments.FirstOrDefault(x => x.PaymentId == ID));
        }

        public void AddPayment(PaymentsModel paymentsModel)
        {
            paymentsModel.PaymentId = Guid.NewGuid();
            dbContext.Payments.Add(MapModelToDbObject(paymentsModel));
            dbContext.SaveChanges();
        }

        public void UpdatePayment(PaymentsModel paymentsModel)
        {
            Payment existingPayment = dbContext.Payments.FirstOrDefault(x => x.PaymentId == paymentsModel.PaymentId);
            if (existingPayment != null)
            {
                existingPayment.PaymentId = paymentsModel.PaymentId;
                existingPayment.UserId = paymentsModel.UserId;
                existingPayment.PaymentValue = paymentsModel.PaymentValue;
                existingPayment.PaymentCurrency = paymentsModel.PaymentCurrency;
                existingPayment.PaymentType = paymentsModel.PaymentType;
                dbContext.SaveChanges();
            }
        }

        public void DeletePayment(Guid id)
        {
            Payment existingPayment = dbContext.Payments.FirstOrDefault(x => x.PaymentId == id);
            if (existingPayment != null)
            {
                dbContext.Payments.Remove(existingPayment);
                dbContext.SaveChanges();
            }
        }


        private PaymentsModel MapDbObjectToModel(Payment dbPayments)
        {
            PaymentsModel paymentsModel = new PaymentsModel();

            if (dbPayments != null)
            {
                paymentsModel.PaymentId = dbPayments.PaymentId;
                paymentsModel.UserId = dbPayments.UserId;
                paymentsModel.PaymentValue = dbPayments.PaymentValue;
                paymentsModel.PaymentCurrency = dbPayments.PaymentCurrency;
                paymentsModel.PaymentType = dbPayments.PaymentType;
            }

            return paymentsModel;
        }
        private Payment MapModelToDbObject(PaymentsModel dbPayments)
        {
            Payment payment= new Payment();

            if (payment != null)
            {
                payment.PaymentId = payment.PaymentId;
                payment.UserId = payment.UserId;
                payment.PaymentValue = payment.PaymentValue;
                payment.PaymentCurrency = payment.PaymentCurrency;
                payment.PaymentType = payment.PaymentType;
            }

            return payment;
        }
    }
}
