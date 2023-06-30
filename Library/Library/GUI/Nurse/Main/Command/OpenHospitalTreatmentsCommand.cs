using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.HospitalTreatmentService.Interface;
using Library.View.Table.Checkup;
using Library.ViewModel.Table.Checkup;

namespace Library.Commands.HospitalTreatment
{
    public class OpenHospitalTreatmentsCommand : CommandBase
    {
        private readonly IHospitalTreatmentService _hospitalTreatmentService;
        private readonly IPatientCheckupService _patientCheckupService;

        public OpenHospitalTreatmentsCommand(IHospitalTreatmentService hospitalTreatmentService, IPatientCheckupService patientCheckupService)
        {
            _hospitalTreatmentService = hospitalTreatmentService;
            _patientCheckupService = patientCheckupService;
        }

        public override void Execute(object? parameter)
        {
            var popup = new HospitalTreatmentPatientTableView
            {
                DataContext = new HospitalTreatmentPatientTableViewModel(_hospitalTreatmentService, _patientCheckupService)
            };
            popup.Show();
        }
    }
}
