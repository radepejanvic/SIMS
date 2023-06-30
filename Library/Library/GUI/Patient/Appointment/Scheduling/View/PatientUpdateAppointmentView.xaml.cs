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
using Library.Model;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for UpdateAppointmentTimeView.xaml
    /// </summary>
    public partial class PatientUpdateAppointmentView : Window
    {
        public PatientUpdateAppointmentView(ObservableCollection<AppointmentViewModel> appointments, AppointmentViewModel selectedAppointment, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService)
        {
            InitializeComponent();
            DataContext = new PatientAppointmentUpdateFormViewModel(this, appointments, selectedAppointment, schedulingService, doctorScheduleService);
        }
    }
}
