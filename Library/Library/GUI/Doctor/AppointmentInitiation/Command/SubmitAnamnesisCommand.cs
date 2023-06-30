using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModel.Form;
using Library.ViewModel;
using Library.ViewModel.Structure;
using Library.Service.AppointmentService.Interface;
using Library.ViewModel.Table;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using System.Windows;
using Library.Model;

namespace Library.Commands
{
    public class SubmitAnamnesisCommand: CommandBase
    {
        private ShowAnamnesisViewModel _showAnamnesisViewModel;
        private IAnamnesisService _anamnesisService;
        private Appointment _appointment;
        public SubmitAnamnesisCommand(ShowAnamnesisViewModel showAnamnesisViewModel, IAnamnesisService anamnesisService, Appointment appointment) 
        {
            _showAnamnesisViewModel = showAnamnesisViewModel;
            _anamnesisService = anamnesisService;
            _appointment = appointment;

            _showAnamnesisViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _showAnamnesisViewModel.Sympthoms != "" &&
                   _showAnamnesisViewModel.Observation != "" &&
                   _showAnamnesisViewModel.Conclusion != "";
        }

        public override void Execute(object? parameter)
        {
            // Need to add patient and appointment.

            var anamnesis = new Anamnesis(_showAnamnesisViewModel.Sympthoms, _showAnamnesisViewModel.Observation, _showAnamnesisViewModel.Conclusion, _appointment.PatientId, _appointment.Id);
            _anamnesisService.Add(anamnesis);
            MessageBox.Show("Uspešno ste dodali anamnezu", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_showAnamnesisViewModel.Sympthoms)) || 
                (e.PropertyName == nameof(_showAnamnesisViewModel.Observation)) ||
                (e.PropertyName == nameof(_showAnamnesisViewModel.Conclusion)))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
