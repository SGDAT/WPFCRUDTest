using CRUDTest.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Services.ViewModels
{
    public class OrgChartViewModel
    {
        public IEnumerable<string> labels { get; set; }
        public List<int> values { get; set; }
    }
}
