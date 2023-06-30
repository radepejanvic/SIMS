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
using Library.Model;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel;
using Library.ViewModel.Form;

namespace Library.View.Form
{
    /// <summary>
    /// Interaction logic for UrgentAppointmentFormView.xaml
    /// </summary>
    public partial class UrgentAppointmentFormView : Window
    {
        public UrgentAppointmentFormView(PatientViewModel selectedPatient, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
            InitializeComponent();
            DataContext = new UrgentAppointmentFormViewModel(selectedPatient, patientService, doctorService, doctorScheduleService, schedulingService, notificationService);
        }
    }
}
