using CRUDTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDTest.Services.ViewModels;
using CRUDTest.Repository.Interfaces;
using CRUDTest.Repository;
using CRUDTest.Repository.Models;

namespace CRUDTest.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        static IUserService _userService { get; set; }
        public static IUserService Instance {
            get {
                if (_userService == null)
                    _userService = new UserService();
                return _userService;
            }
        }

        public UserService()
        {
            userRepository = new UserRepository();
        }


        public AllUsersViewModel GetAllUsersViewModel()
        {
            IEnumerable<User> users = userRepository.GetUsers();

            AllUsersViewModel model = new AllUsersViewModel()
            {
                users = users.Select(u=> new UserModel
                {
                    id = u.id,
                    firstName = u.firstName,
                    lastName = u.lastName,
                    department = u.department,
                    address1 = u.address1,
                    address2 = u.address2,
                    address3 = u.address3,
                    town = u.town,
                    postCode = u.postCode
                })
            };

            return model;
        }

        public void DeleteUser(Guid Id)
        {
            userRepository.DeleteUser(Id);
        }

        public void UpdateUser(UserModel user)
        {
            User existingUser = new User
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                department = user.department,
                address1 = user.address1,
                address2 = user.address2,
                address3 = user.address3,
                town = user.town,
                postCode = user.postCode
            };

            userRepository.UpdateUser(existingUser);
        }

        public void AddUser(UserModel user)
        {
            User newUser = new User
            {
                id = user.id,
                firstName = user.firstName,
                lastName = user.lastName,
                department = user.department,
                address1 = user.address1,
                address2 = user.address2,
                address3 = user.address3,
                town = user.town,
                postCode = user.postCode
            };

            userRepository.CreateUser(newUser);
        } 

        public OrgChartViewModel GetOrgChartViewModel()
        {
            IEnumerable<User> users = userRepository.GetUsers();
            IEnumerable<IGrouping<string, User>> userByGroup = users.GroupBy(u => u.department).OrderBy(g=>g.Key);
            IEnumerable<string> departments = users.Select(u => u.department).Distinct();

            OrgChartViewModel model = new OrgChartViewModel();
            model.labels = userByGroup.Select(g => g.Key);
            model.values = new List<int>();

            foreach (var group in userByGroup)
            {
                model.values.Add(group.Count());
            }


            return model;
        }

        public void Save(int dataType)
        {
            userRepository.Save(dataType);
        }

        public void Load(int dataType)
        {
            userRepository.Load(dataType);
        }
    }
}
