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
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService.Interface;
using Library.ViewModel;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for ExaminationMedicalRecordView.xaml
    /// </summary>
    public partial class DoctorAppointmentMedicalRecordView : Window
    {
        public DoctorAppointmentMedicalRecordView(PatientViewModel patient, AppointmentViewModel appointment, 
            IPatientService patientService, IAnamnesisService anamnesisService, IDoctorService doctorService, 
            IDoctorRefferalService doctorRefferalService, IDrugService drugService, IDrugPerscribingService drugPerscribingService, 
            IHospitalRefferalService hospitalRefferalService)
        {
            InitializeComponent();
            DataContext = new ExaminationMedicalRecordViewModel(patient, appointment, patientService, anamnesisService, 
                doctorService, doctorRefferalService, drugService, drugPerscribingService, hospitalRefferalService);
        }
    }
}
