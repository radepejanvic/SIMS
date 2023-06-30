using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.PersonService;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.View;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class InitiateAppointmentCommand: CommandBase
    {
        private DoctorExaminationTableViewModel _doctorExaminationTableViewModel;

        private IPatientService _patientService;
        private IAnamnesisService _anamnesisService;
        private IDoctorService _doctorService;
        private IDoctorRefferalService _doctorRefferalService;
        private IDrugService _drugService;
        private IDrugPerscribingService _drugPerscribingService;
        private IHospitalRefferalService _hospitalRefferalService;

        public InitiateAppointmentCommand(DoctorExaminationTableViewModel doctorExaminationTableViewModel, 
            IPatientService patientService, IAnamnesisService anamnesisService, IDoctorService doctorService, 
            IDoctorRefferalService doctorRefferalService, IDrugService drugService, IDrugPerscribingService drugPerscribingService,
            IHospitalRefferalService hospitalRefferalService) 
        {
            _doctorExaminationTableViewModel = doctorExaminationTableViewModel;

            _patientService = patientService;
            _anamnesisService = anamnesisService;
            _doctorService = doctorService;
            _doctorRefferalService = doctorRefferalService;
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;
            _hospitalRefferalService = hospitalRefferalService;

            _doctorExaminationTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _doctorExaminationTableViewModel.SelectedAppointment != null;
        }

        public override void Execute(object? parameter)
        {
            var createAppointmentView = new DoctorAppointmentMedicalRecordView(_doctorExaminationTableViewModel.GetPatient(), 
                _doctorExaminationTableViewModel.SelectedAppointment, _patientService, _anamnesisService, _doctorService, 
                _doctorRefferalService, _drugService, _drugPerscribingService, _hospitalRefferalService);
            createAppointmentView.ShowDialog();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_doctorExaminationTableViewModel.SelectedAppointment))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
