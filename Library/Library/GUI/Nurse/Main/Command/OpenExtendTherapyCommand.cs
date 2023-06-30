using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.Commands.Farmacy
{
    public class OpenExtendTherapyCommand : CommandBase
    {
        private readonly PatientTableViewModel _patientTableViewModel;
        private readonly IPerscriptionService _perscriptionService;
        private readonly IDrugService _drugService;
        private readonly IDrugPerscribingService _drugPerscribingService;
        private readonly IPerscriptionSchedulingService _perscriptionSchedulingService;
        private readonly ISchedulingService _schedulingService;
        private readonly IAppointmentService _appointmentService;

        public OpenExtendTherapyCommand(PatientTableViewModel patientTableViewModel, IPerscriptionService perscriptionService, IDrugService drugService, IDrugPerscribingService drugPerscribingService, IPerscriptionSchedulingService perscriptionSchedulingService, ISchedulingService schedulingService, IAppointmentService appointmentService)
        {
            _patientTableViewModel = patientTableViewModel;
            _perscriptionService = perscriptionService;
            _drugService = drugService;
            _drugPerscribingService = drugPerscribingService;
            _perscriptionSchedulingService = perscriptionSchedulingService;
            _schedulingService = schedulingService;
            _appointmentService = appointmentService;
            _patientTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _patientTableViewModel.SelectedPatient is not null;
        }

        public override void Execute(object? parameter)
        {
            var popup = new PerscriptionTableView(_patientTableViewModel.SelectedPatient, _perscriptionService, _drugPerscribingService, _drugService, _perscriptionSchedulingService, _schedulingService, _appointmentService);
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
