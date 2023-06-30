using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.AppointmentService;
using Library.Service.AppointmentService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.Commands.Farmacy
{
    public class CreatePerscriptionAppointmentCommand : CommandBase
    {
        private PatientPerscriptionTableViewModel _patientPerscriptionTableViewModel;
        private readonly ISchedulingService _schedulingService;
        private readonly IPerscriptionSchedulingService _perscriptionSchedulingService;

        public CreatePerscriptionAppointmentCommand(PatientPerscriptionTableViewModel patientPerscriptionTableViewModel, ISchedulingService schedulingService, IPerscriptionSchedulingService perscriptionSchedulingService)
        {
            _patientPerscriptionTableViewModel = patientPerscriptionTableViewModel;
            _schedulingService = schedulingService;
            _perscriptionSchedulingService = perscriptionSchedulingService;
            _patientPerscriptionTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_patientPerscriptionTableViewModel.From is not null) &&
                (_patientPerscriptionTableViewModel.SelectedPerscription is not null) &&
                _schedulingService.IsAvaliable(_patientPerscriptionTableViewModel.GetDoctorId(), _patientPerscriptionTableViewModel.GetTimeSlot()) &&
                _schedulingService.IsAvaliable(_patientPerscriptionTableViewModel.SelectedPatient.Id, _patientPerscriptionTableViewModel.GetTimeSlot()) &&
                (_schedulingService.GetFirstAvaliableRoom(_patientPerscriptionTableViewModel.GetTimeSlot()) != 0);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _perscriptionSchedulingService.ScheduleWithPerscription(_patientPerscriptionTableViewModel.SelectedPerscription.Id, _schedulingService.GetFirstAvaliableRoom(_patientPerscriptionTableViewModel.GetTimeSlot()), _patientPerscriptionTableViewModel.GetTimeSlot());
                OnExecutionCompleted(true, "Uspešno je zakazan pregled pomoću recepta.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom zakazivanja pregleda pomoću recepta.");
            }
            
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_patientPerscriptionTableViewModel.SelectedPerscription)) ||
                (e.PropertyName == nameof(_patientPerscriptionTableViewModel.From)))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
