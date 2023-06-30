using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.ViewModel.Table;

namespace Library.Commands.Farmacy
{
    public class OrderDrugsCommand : CommandBase
    {
        private readonly DrugTableViewModel _drugTableViewModel;
        private readonly IDrugWarehouseService _drugWarehouseService;

        public OrderDrugsCommand(DrugTableViewModel drugTableViewModel, IDrugWarehouseService drugWarehouseService)
        {
            _drugTableViewModel = drugTableViewModel;
            _drugWarehouseService = drugWarehouseService;
            _drugTableViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                foreach (KeyValuePair<int, int> drugOrder in _drugTableViewModel.GetAllDrugOrders())
                {
                    _drugWarehouseService.CreateDrugOrder(drugOrder);
                }
                OnExecutionCompleted(true, "Porudžina za odabrane lekove je izdata.");
            }
            catch (Exception)
            {
                OnExecutionCompleted(false, "Greška prilikom izdavanja porudžbine.");
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }

    }
}
