using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Service.HospitalTreatmentService.Interface;
using Library.View.Form;
using Library.View.Table;
using Library.ViewModel.Form;
using Library.ViewModel.Table;

namespace Library.Commands.HospitalTreatment
{
    public class OpenUnderoccupiedRoomsTableCommand : CommandBase
    {
        private NurseRefferalTableViewModel _nurseRefferalTableViewModel;
        private readonly IHospitalTreatmentService _hospitalTreatmentService;

        public OpenUnderoccupiedRoomsTableCommand(NurseRefferalTableViewModel nurseRefferalTableViewModel, IHospitalTreatmentService hospitalTreatmentService)
        {
            _nurseRefferalTableViewModel = nurseRefferalTableViewModel;
            _hospitalTreatmentService = hospitalTreatmentService;
            _nurseRefferalTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _nurseRefferalTableViewModel.SelectedHospitalRefferal is not null;
        }

        public override void Execute(object? parameter)
        {
            var popup = new HospitalTreatmentRoomsView();
            popup.DataContext = new HospitalTreatmentRoomsTableViewModel(_nurseRefferalTableViewModel.SelectedHospitalRefferal, _hospitalTreatmentService);
            popup.ShowDialog();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_nurseRefferalTableViewModel.SelectedHospitalRefferal))
            {
                OnCanExecutedChanged();
            }
        }


    }
}
