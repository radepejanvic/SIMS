using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View.Table;
using Library.ViewModel.Table;
using Library.ViewModel;
using Library.ViewModel.Structure;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Commands
{
    public class ShowDynamicalEquipmentRedistributionTableCommand : CommandBase
    {
        private IEquipmentService _equipmentService;

        public ShowDynamicalEquipmentRedistributionTableCommand(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public override void Execute(object? parameter)
        {
            var equipmentTableView = new DynamicalEquipmentRedistributionTableView();
            equipmentTableView.DataContext = new EquipmentRedistributionTableViewModel(_equipmentService);
            equipmentTableView.ShowDialog();
        }
    }
}
