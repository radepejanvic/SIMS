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
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for CreateAppointmentView.xaml
    /// </summary>
    public partial class PatientCreateAppointmentView : Window
    {
        public PatientCreateAppointmentView(Patient patient, ObservableCollection<AppointmentViewModel> appointments, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            InitializeComponent();
            DataContext = new PatientAppointmentCreateFormViewModel(this, patient, appointments, schedulingService, doctorScheduleService, patientService, doctorService);
        }
    }
}
