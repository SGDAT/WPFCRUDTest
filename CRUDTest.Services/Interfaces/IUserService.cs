using CRUDTest.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Services.Interfaces
{
    public interface IUserService
    {
        AllUsersViewModel GetAllUsersViewModel();
        void DeleteUser(Guid Id);
        void UpdateUser(UserModel user);
        void AddUser(UserModel user);
        OrgChartViewModel GetOrgChartViewModel();
        void Save(int dataType);
        void Load(int dataType);
    }
}
