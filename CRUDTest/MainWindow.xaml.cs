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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserService userService;
        public MainWindow()
        {
            InitializeComponent();

            userService = UserService.Instance;
            this.DataContext = userService.GetAllUsersViewModel();
        }

        private void lstBxUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserModel selected = lstBxUsers.SelectedItem as UserModel;
            ViewUserWindow viewUserWindow = new ViewUserWindow();
            viewUserWindow.SetDataContext(new ViewUserViewModel
            {
                user = selected
            });
            viewUserWindow.ShowDialog();

            this.DataContext = userService.GetAllUsersViewModel();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddNewUserWindow addNewUserWindow = new AddNewUserWindow();
            addNewUserWindow.ShowDialog();

            this.DataContext = userService.GetAllUsersViewModel();
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            OrgChartWindow orgChartWindow = new OrgChartWindow();
            orgChartWindow.ShowDialog();
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            userService.Save(cmbBxDataType.SelectedIndex);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            userService.Load(cmbBxDataType.SelectedIndex);

            this.DataContext = userService.GetAllUsersViewModel();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
