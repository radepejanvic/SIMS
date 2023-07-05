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
        public PaymentReason Reason => _payment.Reason;

        public PaymentViewModel(Payment payment)
        {
            _payment = payment;
        }

    }
}
