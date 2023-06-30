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
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.ViewModel.Table;

namespace Library.View.Table
{

    public partial class DrugTableView : Window
    {
        public DrugTableView(IDrugService drugService, IDrugWarehouseService drugWarehouseService)
        {
            InitializeComponent();
            DataContext = new DrugTableViewModel(drugService, drugWarehouseService);
        }
    }
}
