using CRUDTest.Services;
using CRUDTest.Services.Interfaces;
using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for OrgChartWindow.xaml
    /// </summary>
    public partial class OrgChartWindow : Window
    {
        IUserService userService;
        public SeriesCollection seriesCollection { get; set; }
        public string[] labels { get; set; }

        public OrgChartWindow()
        {
            InitializeComponent();
            userService = UserService.Instance;
            var model = userService.GetOrgChartViewModel();

            labels = model.labels.ToArray();
            seriesCollection = new SeriesCollection();

            for (int i = 0; i < labels.Count(); i++)
            {
                seriesCollection.Add(new PieSeries
                {
                    Values = new ChartValues<decimal> { model.values[i] },
                    Title = labels[i]
                });
            }

            DataContext = this;
        }


    }
}
