using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ViewModel;
using Library.ViewModel.Form;
using Library.ViewModel.Table;
using Library.View.Table;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.Commands
{
    public class ShowStaticEquipmentQuantityTableCommand : CommandBase
    {
        private readonly IRoomService _roomService;
        public ShowStaticEquipmentQuantityTableCommand(IRoomService roomService)
        {
            _roomService = roomService;

        }

        public override void Execute(object? parameter)
        {
            var equipmentFilterTableView = new StaticEquipmentQuantityTableView();
            equipmentFilterTableView.DataContext = new EquipmentFilterTableViewModel(_roomService);
            equipmentFilterTableView.ShowDialog();
        }
    }
}
