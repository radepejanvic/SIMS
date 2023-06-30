using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Library.Commands;
using Library.Model;

using Library.Service;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Table;

namespace Library.ViewModel
{
    public class PatientAppointmentUpdateFormViewModel : ViewModelBase
    {
        private ObservableCollection<AppointmentViewModel> _appointments;
        public AppointmentViewModel SelectedAppointment;
        public string DateAndTime { get; set; }
        private ISchedulingService _schedulingService;
        private IDoctorScheduleService _doctorScheduleService;
        public ICommand UpdateAppointmentCommand { get; }
        public ICommand CloseCommand { get; set; }

        public PatientAppointmentUpdateFormViewModel(Window window, ObservableCollection<AppointmentViewModel> appointments, AppointmentViewModel selectedAppointment, ISchedulingService schedulingService, IDoctorScheduleService doctorScheduleService) 
        {
            SelectedAppointment = selectedAppointment;
            _doctorScheduleService = doctorScheduleService;
            _schedulingService = schedulingService;
            _appointments = appointments;
            DateAndTime = selectedAppointment.FromDate;
            CloseCommand = new CloseCommand(window);
            UpdateAppointmentCommand = new RelayCommand(UpdateTime, CanUpdateTime);
        }

        public bool CanUpdateTime()
        {
            return !(String.IsNullOrEmpty(DateAndTime))
                    && (PatientAppointmentCreateFormViewModel.ConvertStringToDateTime(this.DateAndTime).CompareTo(DateTime.Now) > 0)
                    && !(PatientAppointmentTableViewModel.IsPastOrWithin24Hours(PatientAppointmentCreateFormViewModel.ConvertStringToDateTime(this.DateAndTime)));
        }

        public void UpdateTime()
        {
            if (CanUpdateTime())
            {
                SelectedAppointment.FromDate = PatientAppointmentCreateFormViewModel.ConvertStringToDateTime(this.DateAndTime).ToString("dd/MM/yyyy HH:mm");

                var newTimeSlot = PatientAppointmentCreateFormViewModel.MakeTimeSlot(PatientAppointmentCreateFormViewModel.ConvertStringToDateTime(this.DateAndTime), 15);
                if (_schedulingService.IsAvailableForUpdate(SelectedAppointment.Doctor, newTimeSlot, SelectedAppointment.Appointment)
                    && _schedulingService.IsAvailableForUpdate(SelectedAppointment.Patient, newTimeSlot, SelectedAppointment.Appointment)
                    && (_schedulingService.IsAvaliableRoom(SelectedAppointment.Appointment.RoomId, newTimeSlot)))
                {
                    SelectedAppointment.Appointment.TimeSlot = newTimeSlot;
                    _schedulingService.Reschedule(SelectedAppointment.Appointment);
                    CollectionViewSource.GetDefaultView(_appointments).Refresh();
                    CloseCommand.Execute(null);
                }
                else
                {
                    MessageBox.Show("Ne mozete izmeniti ovo vreme");
                }

            }
            
        }

    }
}
