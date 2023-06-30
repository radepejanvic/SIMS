using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Library.Model;
using Library.Model.Enum;
using Library.Service.PhysicalAssetService.Interface;

namespace Library.ViewModel.Table
{
    public class EquipmentFilterTableViewModel : EquipmentTableViewModel
    {

        private bool _operationRoom;
        public bool OperationRoom
        {
            get { return _operationRoom; }
            set
            {
                if (_operationRoom != value)
                {
                    _operationRoom = value;
                    OnPropertyChanged(nameof(OperationRoom));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _patientRoom;
        public bool PatientRoom
        {
            get
            {
                return _patientRoom;
            }
            set
            {
                _patientRoom = value;
                OnPropertyChanged(nameof(PatientRoom));
            }
        }

        private bool _examinationRoom;
        public bool ExaminationRoom
        {
            get { return _examinationRoom; }
            set
            {
                if (_examinationRoom != value)
                {
                    _examinationRoom = value;
                    OnPropertyChanged(nameof(ExaminationRoom));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _waitingRoom;
        public bool WaitingRoom
        {
            get { return _waitingRoom; }
            set
            {
                if (_waitingRoom != value)
                {
                    _waitingRoom = value;
                    OnPropertyChanged(nameof(WaitingRoom));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _warehouse;
        public bool Warehouse
        {
            get { return _warehouse; }
            set
            {
                if (_warehouse != value)
                {
                    _warehouse = value;
                    OnPropertyChanged(nameof(Warehouse));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _roomFurinture;
        public bool RoomFurinture
        {
            get { return _roomFurinture; }
            set
            {
                if (_roomFurinture != value)
                {
                    _roomFurinture = value;
                    OnPropertyChanged(nameof(RoomFurinture));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _examination;
        public bool Examination
        {
            get { return _examination; }
            set
            {
                if (_examination != value)
                {
                    _examination = value;
                    OnPropertyChanged(nameof(Examination));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _operation;
        public bool Operation
        {
            get { return _operation; }
            set
            {
                if (_operation != value)
                {
                    _operation = value;
                    OnPropertyChanged(nameof(Operation));
                    UpdateSelectedOptions();
                }
            }
        }

        private bool _hallway;
        public bool Hallway
        {
            get { return _hallway; }
            set
            {
                if (_hallway != value)
                {
                    _hallway = value;
                    OnPropertyChanged(nameof(Hallway));
                    UpdateSelectedOptions();
                }
            }
        }

        private string _search;
        private IRoomService roomService;

        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value.ToLower();
                OnPropertyChanged(nameof(Search));
                UpdateSelectedOptions();

            }
        }

        
        public EquipmentFilterTableViewModel(IRoomService roomService):base(roomService) { }

        private void UpdateSelectedOptions()
        {
            var selectedOptionRoomType = new List<RoomType>();
            var selectedOptionEquipmentPurpose = new List<EquipmentPurpose>();

            if (OperationRoom) selectedOptionRoomType.Add(RoomType.OPERATION_ROOM);
            if (PatientRoom) selectedOptionRoomType.Add(RoomType.ROOM_FOR_THE_PATIENT);
            if (ExaminationRoom) selectedOptionRoomType.Add(RoomType.EXAMINATION_ROOM);
            if (WaitingRoom) selectedOptionRoomType.Add(RoomType.WAITING_ROOM);
            if (Warehouse) selectedOptionRoomType.Add(RoomType.WAREHOUSE);
            if (RoomFurinture) selectedOptionEquipmentPurpose.Add(EquipmentPurpose.ROOM_FURNITURE);
            if (Examination) selectedOptionEquipmentPurpose.Add(EquipmentPurpose.EXAMINATION);
            if (Operation) selectedOptionEquipmentPurpose.Add(EquipmentPurpose.OPERATION);
            if (Hallway) selectedOptionEquipmentPurpose.Add(EquipmentPurpose.HALLWAY);
            var researchedEquipment = RoomService.UpdateEquipment(selectedOptionRoomType, selectedOptionEquipmentPurpose,Search);
            Equipments.Clear();
            foreach (var o in researchedEquipment)
            {
                Equipments.Add(new StaticEquipmentViewModel(o));
            }
        }
  


    }



}
