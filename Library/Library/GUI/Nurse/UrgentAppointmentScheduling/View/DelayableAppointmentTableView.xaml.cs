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
using Library.Service.PersonService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.View.Table
{
    /// <summary>
    /// Interaction logic for DelayableAppointmentsTableView.xaml
    /// </summary>
    public partial class DelayableAppointmentTableView : Window
    {
        public DelayableAppointmentTableView(UrgentAppointmentFormViewModel urgentAppointmentFormViewModel, IPatientService patientService, IDoctorService doctorService, IDoctorScheduleService doctorScheduleService, ISchedulingService schedulingService, IAppointmentNotificationService notificationService)
        {
            InitializeComponent();
            DataContext = new DelayableAppointmentTableViewModel(urgentAppointmentFormViewModel, patientService, doctorService, doctorScheduleService, schedulingService, notificationService);
        }
    }
}
