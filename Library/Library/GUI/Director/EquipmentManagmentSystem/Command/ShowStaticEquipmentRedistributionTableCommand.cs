using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.View.Table;
using Library.ViewModel.Table;
using Library.ViewModel;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Commands
{
    public class ShowStaticEquipmentRedistributionTableCommand : CommandBase
    {
        private IEquipmentService _equipmentService;


        public ShowStaticEquipmentRedistributionTableCommand(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        public override void Execute(object? parameter)
        {
            var equipmentTableView = new StaticEquipmentRedistributionTableView();
            equipmentTableView.DataContext = new StaticEquipmentRedistributionTableViewModel(_equipmentService);
            equipmentTableView.ShowDialog();
        }
    }
}
