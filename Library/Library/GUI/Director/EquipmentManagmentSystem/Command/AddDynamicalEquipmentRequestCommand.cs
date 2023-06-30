using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.Model;
using Library.Service;
using Library.Service.PhysicalAssetService.Interface;
using Library.ViewModel.Form;
using Library.ViewModel.Structure;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class AddDynamicalEquipmentRequestCommand : CommandBase
    {
        private readonly DynamicalEquipmentTableViewModel _dynamicalEquipmentTableFormViewModel;
        private IEquipmentService _equipmentService;
        public AddDynamicalEquipmentRequestCommand(DynamicalEquipmentTableViewModel dynamicalEquipmentTableFormViewModel, IEquipmentService equipmentService)
        {
            _dynamicalEquipmentTableFormViewModel = dynamicalEquipmentTableFormViewModel;
            _dynamicalEquipmentTableFormViewModel.PropertyChanged+=OnViewModelPropertyChanged;
            _equipmentService = equipmentService;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_dynamicalEquipmentTableFormViewModel.SelectedEquipment is not null)&&(_dynamicalEquipmentTableFormViewModel.RequestedQuantity != 0) ;
        }

        public override void Execute(object? parameter)
        {
            _equipmentService.MakeDynamicalEquipmentRequest(_dynamicalEquipmentTableFormViewModel.SelectedEquipment.Type,_dynamicalEquipmentTableFormViewModel.RequestedQuantity);
            MessageBox.Show("Uspesno ste napravili zahtez za dobavljanje "+ _dynamicalEquipmentTableFormViewModel.RequestedQuantity.ToString()+" "+_dynamicalEquipmentTableFormViewModel.SelectedEquipment.Type.ToString());
            _dynamicalEquipmentTableFormViewModel.RequestedQuantity = 0;
            _dynamicalEquipmentTableFormViewModel.SelectedEquipment = null;
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == nameof(_dynamicalEquipmentTableFormViewModel.SelectedEquipment)||
                e.PropertyName == nameof(_dynamicalEquipmentTableFormViewModel.RequestedQuantity))
            {
                OnCanExecutedChanged();
            }
        }
  
    }
}
