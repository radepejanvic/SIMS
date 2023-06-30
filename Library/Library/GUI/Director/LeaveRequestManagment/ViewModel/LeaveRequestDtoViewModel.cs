using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel.Structure
{
    public class LeaveRequestDtoViewModel : LeaveRequestViewModel
    {
		private string _doctor;
		public string Doctor
		{
			get
			{
				return _doctor;
			}
			set
			{
				_doctor = value;
				OnPropertyChanged(nameof(Doctor));
			}
		}
        private string _to;
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                OnPropertyChanged(nameof(To));
            }
        }
        private string _from;
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                OnPropertyChanged(nameof(From));
            }
        }
        public LeaveRequestDtoViewModel(LeaveRequest leaveRequest,string doctor,TimeSlot timeSlot) : base(leaveRequest)
        {
			_doctor = doctor;
			_to = DateOnly.FromDateTime(timeSlot.To).ToString();
			_from = DateOnly.FromDateTime(timeSlot.From).ToString();
        }
    }
}
