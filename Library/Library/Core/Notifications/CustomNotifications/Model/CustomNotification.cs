using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class CustomNotification : Notification
    {
        private DateTime _date;
        private string _message;
        private bool _isDisabled;
        public DateTime Date
        {
            get => _date; set => _date = value;
        }
        public string Message
        {
            get => _message; set => _message = value;
        }
        public bool IsDisabled
        {
            get => _isDisabled; set => _isDisabled = value;
        }
        public CustomNotification() { }
        public CustomNotification(int patientId, DateTime date, string message) : base(patientId)
        {
            _date = date;
            _message = message;
            _isDisabled = false;
        }
    }
}
