using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.Farmacy;
using Library.EventArgument;
using Library.Model;
using Library.Model.Refferal;
using Library.Service.FarmaceuticalService;
using Library.Service.FarmaceuticalService.Interface;
using Library.ViewModel.Structure.Farmacy;
using Library.ViewModel.Structure.Refferal;

namespace Library.ViewModel.Table
{
    public class DrugTableViewModel : ViewModelBase
    {

		private ObservableCollection<DrugViewModel> _drugs;
		public ObservableCollection<DrugViewModel> Drugs
		{
			get
			{
				return _drugs;
			}
			set
			{
				_drugs = value;
				OnPropertyChanged(nameof(Drugs));
			}
		}

		private DrugViewModel _selectedDrug;
		public DrugViewModel SelectedDrug
		{
			get
			{
				return _selectedDrug;
			}
			set
			{
				_selectedDrug = value;
				OnPropertyChanged(nameof(SelectedDrug));
			}
		}

		private int _quantity;
		public int Quantity	
		{
			get
			{
				return _quantity;
			}
			set
			{
				_quantity = value;
				OnPropertyChanged(nameof(Quantity));
			}
		}

		private readonly IDrugService _drugService;
		public CommandBase OrderSelected { get; }

        public DrugTableViewModel(IDrugService drugService, IDrugWarehouseService drugWarehouseService)
        {
            _drugService = drugService;
			
			LoadDrugs();
			OrderSelected = new OrderDrugsCommand(this, drugWarehouseService);
			OrderSelected.ExcecutionCompleted += ExecutionCompleted;
		}

        private void LoadDrugs()
		{
            _drugs = new ObservableCollection<DrugViewModel>();
            foreach (Drug drug in _drugService.GetAllUnder(5).Values)
            {
                _drugs.Add(new DrugViewModel(drug));
            }
        }

		public Dictionary<int, int> GetAllDrugOrders()
		{
			return _drugs.Where(drug => drug.OrderQuantity > 0)
				.ToDictionary(drug => drug.Id, drug => drug.OrderQuantity);
        }
    }
}
