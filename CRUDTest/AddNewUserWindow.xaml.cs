using CRUDTest.Services;
using CRUDTest.Services.Interfaces;
using CRUDTest.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUDTest
{
    /// <summary>
    /// Interaction logic for AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewUserWindow : Window
    {
        IUserService userService;
        AddUserViewModel model
        {
            get
            {
                return this.DataContext as AddUserViewModel;
            }
        }

        public AddNewUserWindow()
        {
            InitializeComponent();

            userService = UserService.Instance;
            this.DataContext = new AddUserViewModel
            {
                user = new UserModel()
            };
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            userService.AddUser(model.user);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
