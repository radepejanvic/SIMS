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
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.View.Table
{
    /// <summary>
    /// Interaction logic for DoctorExaminationView.xaml
    /// </summary>
    public partial class DoctorInitiateAppointmentView : Window
    {
        public DoctorInitiateAppointmentView(Doctor doctor, ISchedulingService schedulingService, IPatientService patientService, 
            IAppointmentService appointmentService, IDoctorService doctorService, IAnamnesisService anamnesisService, 
            IAppointmentInitiationService appointmentInitiationService, IDoctorRefferalService doctorRefferalService, 
            IDrugService drugService, IDrugPerscribingService drugPerscribingService, IHospitalRefferalService hospitalRefferalService)
        {
            InitializeComponent();
            DataContext = new DoctorExaminationTableViewModel(doctor, schedulingService, patientService, appointmentService, 
                doctorService, anamnesisService, appointmentInitiationService, doctorRefferalService, drugService, drugPerscribingService, 
                hospitalRefferalService);
        }
    }
}
