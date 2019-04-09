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
    /// Interaction logic for ViewUserWindow.xaml
    /// </summary>
    public partial class ViewUserWindow : Window
    {
        IUserService userService;
        ViewUserViewModel model
        {
            get
            {
                return this.DataContext as ViewUserViewModel;
            }
        }

        public ViewUserWindow()
        {
            InitializeComponent();
            userService = UserService.Instance;

        }

        public void SetDataContext(ViewUserViewModel viewModel)
        {
            this.DataContext = viewModel;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            userService.DeleteUser(model.user.id);
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            userService.UpdateUser(model.user);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
