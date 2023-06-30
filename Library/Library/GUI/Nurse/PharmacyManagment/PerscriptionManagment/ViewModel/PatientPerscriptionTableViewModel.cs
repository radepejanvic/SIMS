using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Farmacy;
using Library.EventArgument;
using Library.Model;
using Library.Service.AppointmentService.Interface;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.ViewModel.Structure.Farmacy;

namespace Library.ViewModel.Table
{
    public class PatientPerscriptionTableViewModel : ViewModelBase
    {
        private ObservableCollection<PerscriptionViewModel> _perscriptions;
        public ObservableCollection<PerscriptionViewModel> Perscriptions
        {
            get
            {
                return _perscriptions;
            }
            set
            {
                _perscriptions = value;
                OnPropertyChanged(nameof(Perscriptions));
            }
        }

        private PerscriptionViewModel _selectedPerscription;
        public PerscriptionViewModel SelectedPerscription
        {
            get
            {
                return _selectedPerscription;
            }
            set
            {
                _selectedPerscription = value;
                OnPropertyChanged(nameof(SelectedPerscription));
            }
        }

        private string _from;
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public PatientViewModel SelectedPatient;

        private IPerscriptionService _perscriptionService;
        private IDrugService _drugService;
        private IAppointmentService _appointmentService;

        public ICommand OpenInstruction { get; }
        public CommandBase ExtendTherapy { get; }
        public CommandBase CreateAppointment { get; }

        public PatientPerscriptionTableViewModel(PatientViewModel selectedPatient, IPerscriptionService perscriptionService, IDrugPerscribingService drugPerscribingService, IDrugService drugService, IPerscriptionSchedulingService perscriptionSchedulingService, ISchedulingService schedulingService, IAppointmentService appointmentService)
        {
            SelectedPatient = selectedPatient;
            _perscriptionService = perscriptionService;
            _drugService = drugService;
            _appointmentService = appointmentService;

            LoadPerscriptions();

            ExtendTherapy = new ExtendTherapyCommand(this, drugPerscribingService, drugService);
            CreateAppointment = new CreatePerscriptionAppointmentCommand(this, schedulingService, perscriptionSchedulingService);
            
            ExtendTherapy.ExcecutionCompleted += ExecutionCompleted;
            CreateAppointment.ExcecutionCompleted += ExecutionCompleted;
            //ShowInstruction = new ExtendTherapyCommand(this, perscriptionService);
        }

        private void LoadPerscriptions()
        {
            _perscriptions = new ObservableCollection<PerscriptionViewModel>();
            foreach (Perscription persctiption in _perscriptionService.GetAll(SelectedPatient.Id).Values)
            {
                _perscriptions.Add(new PerscriptionViewModel(persctiption, _drugService));
            }
        }

        public TimeSlot GetTimeSlot()
        {
            return new TimeSlot(DateTime.ParseExact(_from, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture), 15);
        }

        public int GetDoctorId()
        {
            return _appointmentService.Get(SelectedPerscription.AppointmentId).DoctorId;
        }
    }
}
