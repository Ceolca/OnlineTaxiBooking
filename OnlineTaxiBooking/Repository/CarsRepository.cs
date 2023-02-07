using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Models.DBObjects;

namespace OnlineTaxiBooking.Repository
{
    public class CarsRepository
    {
        private ApplicationDbContext dbContext;

        public CarsRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public CarsRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public List<CarsModel> GetAllCars()
        {
            List<CarsModel> CarsList = new List<CarsModel>();
            foreach (Car dbCars in dbContext.Cars)
            {
                CarsList.Add(MapDbObjectToModel(dbCars));
            }

            return CarsList;
        }

        public CarsModel GetCarById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Cars.FirstOrDefault(x => x.CarId == ID));
        }

        public void InsertCars(CarsModel carModel)
        {
            carModel.CarID = Guid.NewGuid();
            dbContext.Cars.Add(MapModelToDbObject(carModel));
            dbContext.SaveChanges();
        }

        public void UpdateCar(CarsModel carModel)
        {
            Car existingCar = dbContext.Cars.FirstOrDefault(x => x.CarId == carModel.CarID);
            if (existingCar != null)
            {
                existingCar.CarId = carModel.CarID;
                existingCar.UserId = carModel.UserId;
                existingCar.CarModel = carModel.CarModel;
                existingCar.CarType = carModel.CarType;
                existingCar.DriverName = carModel.DriverName;
                dbContext.SaveChanges();
            }
        }

        public void DeleteCar(Guid id)
        {
            Car existingCar= dbContext.Cars.FirstOrDefault(x => x.CarId == id);
            if (existingCar!= null)
            {
                dbContext.Cars.Remove(existingCar);
                dbContext.SaveChanges();
            }
        }


        private CarsModel MapDbObjectToModel(Car dbCars)
        {
            CarsModel carModel = new CarsModel();

            if (dbCars != null)
            {
                carModel.CarID = dbCars.CarId;
                carModel.UserId = dbCars.UserId;
                carModel.CarType = dbCars.CarModel;
                carModel.CarModel = dbCars.CarModel;
                carModel.DriverName = dbCars.DriverName;
            }

            return carModel;
        }
        private Car MapModelToDbObject(CarsModel carModel)
        {
            Car dbCars = new Car();

            if (dbCars != null)
            {
                dbCars.CarId = carModel.CarID;
                dbCars.UserId = carModel.UserId;
                dbCars.CarType = carModel.CarModel;
                dbCars.CarModel = carModel.CarModel;
                dbCars.DriverName = carModel.DriverName;
            }

            return dbCars;
        }
    }
}
