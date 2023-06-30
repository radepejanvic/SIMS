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
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for DoctorAppointmentView.xaml
    /// </summary>
    public partial class DoctorAppointmentView : Window
    {
        public DoctorAppointmentView(Doctor doctor, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IAppointmentService appointmentService, IDoctorService doctorService)
        {
            InitializeComponent();
            DataContext = new DoctorAppointmentTableViewModel(doctor, schedulingService, doctorScheduleService, patientService, appointmentService, doctorService);
        }
    }
}
