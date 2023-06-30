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
using Library.ViewModel;
using Library.Model.Enum;
using System.Collections.ObjectModel;
using Library.ViewModel.Form;
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class DoctorCreateAppointmentView : Window
    {
        public DoctorCreateAppointmentView(Doctor doctor, ObservableCollection<AppointmentViewModel> _appointments, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService, IPatientService patientService, IDoctorService doctorService)
        {
            InitializeComponent();
            DataContext = new DoctorAppointmentCreateFormViewModel(this, doctor, _appointments, schedulingService, doctorScheduleService, patientService, doctorService);
        }
    }
}
