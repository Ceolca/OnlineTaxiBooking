using OnlineTaxiBooking.Data;
using OnlineTaxiBooking.Models;
using OnlineTaxiBooking.Models.DBObjects;

namespace OnlineTaxiBooking.Repository
{
    public class UsersRepository
    {
        private ApplicationDbContext dbContext;

        public UsersRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public UsersRepository(ApplicationDbContext applicationDbContext)
        {
            this.dbContext = applicationDbContext;
        }

        public List<UsersModel> GetAllUsers()
        {
            List<UsersModel> UsersList = new List<UsersModel>();
            foreach (User dbUsers in dbContext.Users)
            {
                UsersList.Add(MapDbObjectToModel(dbUsers));
            }

            return UsersList;
        }

        public UsersModel GetUserById(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Users.FirstOrDefault(x => x.UserId == ID));
        }

        public void InsertUser(UsersModel userModel)
        {
            userModel.UserId = Guid.NewGuid();
            dbContext.Users.Add(MapModelToDbObject(userModel));
            dbContext.SaveChanges();
        }

        public void UpdateUser(UsersModel userModel)
        {
            User existingUser = dbContext.Users.FirstOrDefault(x => x.UserId == userModel.UserId);
            if (existingUser != null)
            {
                existingUser.UserId = userModel.UserId;
                existingUser.UserRole = userModel.UserRole;
                existingUser.Name = userModel.Name;
                existingUser.Surname = userModel.Surname;
                existingUser.Username = userModel.Username;
                existingUser.Password = userModel.Password;
                existingUser.Email = userModel.Email;
                existingUser.Country = userModel.Country;
                existingUser.PhoneNumber = userModel.PhoneNumber;
                dbContext.SaveChanges();
            }
        }

        public void DeleteUser(Guid id)
        {
            User existingUser = dbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (existingUser != null)
            {
                dbContext.Users.Remove(existingUser);
                dbContext.SaveChanges();
            }
        }


        private UsersModel MapDbObjectToModel(User dbUsers)
        {
            UsersModel usersModel = new UsersModel();

            if (dbUsers != null)
            {
                usersModel.UserId = dbUsers.UserId;
                usersModel.UserRole = dbUsers.UserRole;
                usersModel.Name = dbUsers.Name;
                usersModel.Surname = dbUsers.Surname;
                usersModel.Username = dbUsers.Username;
                usersModel.Password = dbUsers.Password;
                usersModel.Email = dbUsers.Email;
                usersModel.Country = dbUsers.Country;
                usersModel.PhoneNumber = dbUsers.PhoneNumber;
            }

            return usersModel;
        }
        private User MapModelToDbObject(UsersModel dbUsers)
        {
            User users = new User();

            if (dbUsers != null)
            {
                users.UserId = dbUsers.UserId;
                users.UserRole = dbUsers.UserRole;
                users.Name = dbUsers.Name;
                users.Surname = dbUsers.Surname;
                users.Username = dbUsers.Username;
                users.Password = dbUsers.Password;
                users.Email = dbUsers.Email;
                users.Country = dbUsers.Country;
                users.PhoneNumber = dbUsers.PhoneNumber;
            }

            return users;
        }
    }
}
