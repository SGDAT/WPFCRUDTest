using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Services.ViewModels
{
    public class AllUsersViewModel
    {
        public IEnumerable<UserModel> users { get; set; }
    }
}
