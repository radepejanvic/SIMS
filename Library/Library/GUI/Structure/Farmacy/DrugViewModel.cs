using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Enum;

namespace Library.ViewModel.Structure.Farmacy
{
    public class DrugViewModel : ViewModelBase
    {
        private readonly Drug _drug;
        public int Id => _drug.Id;
        public string Name => _drug.Name;
        public ObservableCollection<Alergy> Alergens => new(_drug?.Alergens ?? new List<Alergy>());
        public int NumberOftablets => _drug.NumberOfTablets;
        public int Quantity => _drug.Quantity;

        private int _orderQuantity;
        public int OrderQuantity
        {
            get
            {
                return _orderQuantity;
            }
            set
            {
                _orderQuantity = value;
                OnPropertyChanged(nameof(OrderQuantity));
            }
        }

        public DrugViewModel(Drug drug)
        {
            _drug = drug;
        }
    }
}
