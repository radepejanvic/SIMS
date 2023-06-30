using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.View.Table;
using Library.ViewModel.Table;

namespace Library.Commands.Farmacy
{
    public class OpenDrugOrderManagmentCommand : CommandBase
    {
        private readonly IDrugService _drugService;
        private readonly IDrugWarehouseService _drugWarehouseService;

        public OpenDrugOrderManagmentCommand(IDrugService drugService, IDrugWarehouseService drugWarehouseService)
        {
            _drugService = drugService;
            _drugWarehouseService = drugWarehouseService;
        }

        public override void Execute(object? parameter)
        {
            var popup = new DrugTableView(_drugService, _drugWarehouseService);
            popup.ShowDialog();
        }
    }
}
