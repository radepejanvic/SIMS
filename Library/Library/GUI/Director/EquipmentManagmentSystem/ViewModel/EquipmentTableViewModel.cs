using System.Collections.ObjectModel;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.ViewModel.Table
{
    public class EquipmentTableViewModel : ViewModelBase
    {
        private ObservableCollection<StaticEquipmentViewModel> _eqipments;
        public ObservableCollection<StaticEquipmentViewModel> Equipments
        {
            get
            {
                return _eqipments;
            }
            set
            {
                _eqipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }
        public readonly IRoomService RoomService;
        public EquipmentTableViewModel(IRoomService roomService)
        {
            _eqipments = new ObservableCollection<StaticEquipmentViewModel>();
            RoomService = roomService;

            var staticEquipment = RoomService.GetEquipmentWithQuantity(RoomService.GetAll());

            foreach (var o in staticEquipment)
            {
                _eqipments.Add(new StaticEquipmentViewModel(o));
            }


        }


    }
}