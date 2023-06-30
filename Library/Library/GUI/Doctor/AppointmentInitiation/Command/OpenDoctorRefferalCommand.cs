using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.PersonService.Interface;
using Library.Service.RefferalService;
using Library.Service.RefferalService.Interface;
using Library.Service.ScheduleService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class OpenDoctorRefferalCommand: CommandBase
    {
        private IDoctorService _doctorService;
        private IDoctorRefferalService _doctorRefferalService;
        private Appointment _appointment;
        public OpenDoctorRefferalCommand(IDoctorService doctorService, Appointment appointment, IDoctorRefferalService doctorRefferalService)
        {
            _doctorService = doctorService;
            _doctorRefferalService = doctorRefferalService;
            _appointment = appointment;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            var popup = new DoctorRefferalFormView();
            popup.DataContext = new DoctorRefferalFormViewModel(_doctorService, _appointment, _doctorRefferalService);
            popup.ShowDialog();
        }

    }
}
