using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.HospitalTreatmentService;
using Library.Service.HospitalTreatmentService.Interface;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService;
using Library.Service.ScheduleService.Interface;
using Library.Service.TehnicalService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenRefferalTableCommand : CommandBase
    {
        private readonly PatientTableViewModel _patientTableViewModel;
        private ISchedulingService _schedulingService;
        private IDoctorRefferalService _doctorRefferalService;
        private IHospitalRefferalService _hospitalRefferalService;
        private IRefferalSchedulingService _refferalSchedulingService;
        private IHospitalTreatmentService _hospitalTreatmentService;

        public OpenRefferalTableCommand(PatientTableViewModel patientTableViewModel, ISchedulingService schedulingService, IDoctorRefferalService doctorRefferalService, IHospitalRefferalService hospitalRefferalService, IRefferalSchedulingService refferalSchedulingService, IHospitalTreatmentService hospitalTreatmentService)
        {
            _patientTableViewModel = patientTableViewModel;
            _schedulingService = schedulingService;
            _doctorRefferalService = doctorRefferalService;
            _hospitalRefferalService = hospitalRefferalService;
            _refferalSchedulingService = refferalSchedulingService;
            _hospitalTreatmentService = hospitalTreatmentService;
            _patientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _patientTableViewModel.SelectedPatient is not null;
        }
        public override void Execute(object? parameter)
        {
            var popup = new RefferalTableView();
            popup.DataContext = new NurseRefferalTableViewModel(_patientTableViewModel.SelectedPatient, _schedulingService, _doctorRefferalService, _hospitalRefferalService, _refferalSchedulingService, _hospitalTreatmentService);
            popup.ShowDialog();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_patientTableViewModel.SelectedPatient))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
