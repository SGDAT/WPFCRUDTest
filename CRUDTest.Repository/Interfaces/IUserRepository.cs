using CRUDTest.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(Guid Id);

        void CreateUser(User User);
        void UpdateUser(User User);
        void DeleteUser(Guid Id);
        void Save(int dataType);
        void Load(int dataType);
    }
}
