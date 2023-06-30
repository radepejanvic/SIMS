using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Library.Service.ScheduleService.Interface;
using Library.ViewModel;
using Library.ViewModel.Form;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for UpdateAppointmentDoctor.xaml
    /// </summary>
    public partial class DoctorUpdateAppointmentView : Window
    {
        public DoctorUpdateAppointmentView(ObservableCollection<AppointmentViewModel> _appointments, AppointmentViewModel SelectedAppointment, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService)
        {
            InitializeComponent();
            DataContext = new DoctorAppointmentUpdateFormViewModel(this, _appointments, SelectedAppointment, schedulingService, doctorScheduleService);
        }
    }
}
