using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModel.Form;
using Library.ViewModel;
using Library.Model;
using Library.View.Table;
using Library.ViewModel.Table;
using Library.Service.AppointmentService.Interface;
using Library.ViewModel.Structure;
using System.ComponentModel;

namespace Library.Commands
{
    public class OpenAnamnesisCommand: CommandBase
    {
        private IAnamnesisService _anamnesisService;
        private Appointment _appointment;
        private ExaminationMedicalRecordViewModel _examinationMedicalRecordViewModel;
        public OpenAnamnesisCommand(ExaminationMedicalRecordViewModel examinationMedicalRecordViewModel, 
            IAnamnesisService anamnesisService, Appointment appointment) 
        {
            _examinationMedicalRecordViewModel = examinationMedicalRecordViewModel;
            _anamnesisService = anamnesisService;
            _appointment = appointment;

            _examinationMedicalRecordViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            var anamnesis = new Anamnesis();
            var anamnesisViewModel = new AnamnesisViewModel(anamnesis);
            var anamnesisView = new ShowAnamnesisView();
            anamnesisView.DataContext = new ShowAnamnesisViewModel(anamnesisViewModel, _anamnesisService, _appointment, true);
            anamnesisView.ShowDialog();
            _examinationMedicalRecordViewModel.IsAnamnesisEntered = true;
        }

        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_examinationMedicalRecordViewModel.IsAnamnesisEntered))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
