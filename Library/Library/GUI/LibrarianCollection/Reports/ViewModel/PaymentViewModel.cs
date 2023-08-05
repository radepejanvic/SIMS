using Library.Core.Enum;
using Library.Core.Model;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Reports.ViewModel
{
    public class PaymentViewModel : ViewModelBase
    {
        private readonly Payment _payment;
        public int Id => _payment.Id;
        public int MembershipCardId => _payment.MembershipCardId;
        public float Amount => _payment.Amount;
        public DateTime PaymentDate => _payment.PaymentDate;
        public string Reason => SetReason();

        public PaymentViewModel(Payment payment)
        {
            _payment = payment;
        }

        public bool Contains(string keyword)
        {
            return $"{Reason}--{MembershipCardId}".ToLower().Contains(keyword.ToLower());
        }

        private string SetReason()
        {
            if (_payment.Reason == PaymentReason.DELAY)
            {
                return "KASNJENJE";
            }
            if (_payment.Reason == PaymentReason.DAMAGE)
            {
                return "OSTECENJE";
            }
            if (_payment.Reason == PaymentReason.LOSS)
            {
                return "GUBLJENJE";
            }
            return "";
        }
    }
}
