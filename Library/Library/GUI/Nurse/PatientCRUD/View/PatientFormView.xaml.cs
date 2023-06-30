using System.Windows;
using Library.Model.Enum;
using Library.Service.PersonService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.View
{
    /// <summary>
    /// Interaction logic for PatientFormView.xaml
    /// </summary>
    public partial class PatientFormView : Window
    {
        public PatientFormView(PatientTableViewModel patientTableViewModel, IPatientService patientService)
        {
            InitializeComponent();
            DataContext = new PatientFormViewModel(this, patientTableViewModel, patientService);
        }
    }
}
