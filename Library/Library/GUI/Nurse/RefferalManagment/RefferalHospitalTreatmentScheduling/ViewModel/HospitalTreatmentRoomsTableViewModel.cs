using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Commands;
using Library.Commands.HospitalTreatment;
using Library.Model;
using Library.Service.HospitalTreatmentService.Interface;
using Library.ViewModel.Structure.Refferal;

namespace Library.ViewModel.Table
{
    public class HospitalTreatmentRoomsTableViewModel : ViewModelBase
    {
		private readonly IHospitalTreatmentService _hospitalTreatmentService;

        public HospitalRefferalViewModel SelectedHospitalRefferal;

		private ObservableCollection<RoomViewModel> _rooms;

		public ObservableCollection<RoomViewModel> Rooms
		{
			get
			{
				return _rooms;
			}
			set
			{
                _rooms = value;
				OnPropertyChanged(nameof(Rooms));
			}
		}

		private RoomViewModel _selectedRoom;
		public RoomViewModel SelectedRoom
		{
			get
			{
				return _selectedRoom;
			}
			set
			{
				_selectedRoom = value;
				OnPropertyChanged(nameof(SelectedRoom));
			}
		}


		public CommandBase StartHospitalTreatment { get; }

        public HospitalTreatmentRoomsTableViewModel(HospitalRefferalViewModel selectedHospitalRefferal, IHospitalTreatmentService hospitalTreatmentService)
        {
            SelectedHospitalRefferal = selectedHospitalRefferal;
			_hospitalTreatmentService = hospitalTreatmentService;
			StartHospitalTreatment = new StartHospitalTreatmentCommand(this, hospitalTreatmentService);

            StartHospitalTreatment.ExcecutionCompleted += ExecutionCompleted;

            LoadUnderoccupiedRooms();
		}

		public void LoadUnderoccupiedRooms()
		{
            _rooms = new ObservableCollection<RoomViewModel>();
            foreach (Room room in _hospitalTreatmentService.GetAllUnderoccupiedRooms().Values)
            {
                _rooms.Add(new RoomViewModel(room));
            }
        }

    }
}
