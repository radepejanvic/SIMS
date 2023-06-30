using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.PhysicalAssetService.Interface;
using Library.View.Table;
using Library.ViewModel;
using Library.ViewModel.Table;

namespace Library.Commands
{
    public class ShowDynamicalEquipmentTableCommand : CommandBase
    {
        private IEquipmentService _equipmentService;

        public ShowDynamicalEquipmentTableCommand(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public override void Execute(object? parameter)
        {
            var equipmentFilterTableView = new DynamicalEquipmentTableView();
            equipmentFilterTableView.DataContext = new DynamicalEquipmentTableViewModel(_equipmentService);
            equipmentFilterTableView.ShowDialog();
        }
    }
}
