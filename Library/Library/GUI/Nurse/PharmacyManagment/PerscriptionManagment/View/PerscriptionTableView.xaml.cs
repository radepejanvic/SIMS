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
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel;
using Library.ViewModel.Table;

namespace Library.View.Table
{
    public partial class PerscriptionTableView : Window
    {
        public PerscriptionTableView(PatientViewModel selectedViewModel, IPerscriptionService perscriptionService, IDrugPerscribingService drugPerscribingService, IDrugService drugService, IPerscriptionSchedulingService perscriptionSchedulingService, ISchedulingService schedulingService, IAppointmentService appointmentService)
        {
            InitializeComponent();
            DataContext = new PatientPerscriptionTableViewModel(selectedViewModel, perscriptionService, drugPerscribingService, drugService, perscriptionSchedulingService, schedulingService, appointmentService);
        }
    }
}
