using CRUDTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDTest.Repository.Models;

namespace CRUDTest.Repository
{
    public class UserRepository : IUserRepository
    {
        public DataContext dataContext;

        public UserRepository()
        {
            dataContext = new DataContext();
        }

        public void CreateUser(User User)
        {
            User.id = Guid.NewGuid();
            dataContext.Users.Add(User);
        }

        public void DeleteUser(Guid Id)
        {
            User user = dataContext.Users.FirstOrDefault(u => u.id == Id);
            dataContext.Users.Remove(user);
        }

        public User GetUser(Guid Id)
        {
            return dataContext.Users.FirstOrDefault(u => u.id == Id);
        }

        public List<User> GetUsers()
        {
            return dataContext.Users;
        }

        public void Load(int dataType)
        {
            dataContext.Load((Enums.DataFormat)dataType);
        }

        public void Save(int dataType)
        {
            dataContext.Save((Enums.DataFormat)dataType);
        }

        public void UpdateUser(User User)
        {
            User existingUser = dataContext.Users.FirstOrDefault(u => u.id == User.id);

            existingUser.firstName = User.firstName;
            existingUser.lastName = User.lastName;
            existingUser.department = User.department;
            existingUser.address1 = User.address1;
            existingUser.address2 = User.address2;
            existingUser.address3 = User.address3;
            existingUser.town = User.town;
            existingUser.postCode = User.postCode;
        }
    }
}
