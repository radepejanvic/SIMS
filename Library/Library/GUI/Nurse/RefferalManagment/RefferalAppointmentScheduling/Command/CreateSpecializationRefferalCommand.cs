using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class CreateSpecializationRefferalCommand : CommandBase
    {
        private NurseRefferalTableViewModel _refferalTableViewModel;
        private ISchedulingService _schedulingService;
        private IRefferalSchedulingService _refferalSchedulingService;
        public CreateSpecializationRefferalCommand(NurseRefferalTableViewModel refferalTableViewModel, ISchedulingService schedulingService, IRefferalSchedulingService refferalSchedulingService)
        {
            _refferalTableViewModel = refferalTableViewModel;
            _schedulingService = schedulingService;
            _refferalSchedulingService = refferalSchedulingService;
            _refferalTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_refferalTableViewModel.From is not null) &&
                (_refferalTableViewModel.SelectedDoctorRefferal is not null) &&
                (_refferalTableViewModel.SelectedDoctorRefferal.Specialization is not null) &&
                (_schedulingService.GetFirstAvaliableDoctor((Specialization)_refferalTableViewModel.
                SelectedDoctorRefferal.Specialization, _refferalTableViewModel.GetTimeSlot()) != 0) &&
                _schedulingService.IsAvaliable(_refferalTableViewModel.SelectedPatient.Id, _refferalTableViewModel.GetTimeSlot()) &&
                (_schedulingService.GetFirstAvaliableRoom(_refferalTableViewModel.GetTimeSlot()) != 0);
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _refferalSchedulingService.ScheduleWithSpecializationRefferal(_refferalTableViewModel.SelectedDoctorRefferal.Id, _schedulingService.GetFirstAvaliableRoom(_refferalTableViewModel.GetTimeSlot()), _refferalTableViewModel.GetTimeSlot());
                OnExecutionCompleted(true, "Uspešno je zakazan pregled pomoću uputa.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom zakazivanja pregleda pomoću uputa.");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(_refferalTableViewModel.SelectedDoctorRefferal)) ||
                (e.PropertyName == nameof(_refferalTableViewModel.From)))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
