using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.Checkup;
using Library.Model.Refferal;

namespace Library.ViewModel.Structure.Checkup
{
    public class PatientAndRoomViewModel : ViewModelBase
    {
        private readonly PatientAndRoom _patientAndRoom;

        public int PatientPlacementId => _patientAndRoom.PatientPlacementId;
        public int PatientId => _patientAndRoom.PatientId;
        public int RoomId => _patientAndRoom.RoomId;
        public string FirstName => _patientAndRoom.FirstName;
        public string LastName => _patientAndRoom.LastName;

        public PatientAndRoomViewModel(PatientAndRoom patientAndRoom)
        {
            _patientAndRoom = patientAndRoom;
        }

        public bool Contains(string keyword)
        {
            return $"{PatientId}--{RoomId}--{FirstName}--{LastName}".ToLower().Contains(keyword.ToLower());
        }
    }
}
