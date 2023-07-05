using Library.Commands;
using Library.Core.Model;
using Library.Core.Service;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookRetrieval.Commands;
using Library.GUI.LibrarianCollection.BookRetrieval.ViewModel;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Reports.ViewModel
{
    public class ReportsViewModel : ViewModelBase
    {
        private ObservableCollection<PaymentViewModel> _payments;
        public ObservableCollection<PaymentViewModel> Payments
        {
            get
            {
                return _payments;
            }
            set
            {
                _payments = value;
                OnPropertyChanged(nameof(Payments));
            }
        }

        private int _paymentsCount;
        public int PaymentsCount
        {
            get
            {
                return _paymentsCount;
            }
            set
            {
                _paymentsCount = value;
                OnPropertyChanged(nameof(PaymentsCount));
            }
        }

        private float _paymentsAmount;
        public float PaymentsAmount
        {
            get
            {
                return _paymentsAmount;
            }
            set
            {
                _paymentsAmount = value;
                OnPropertyChanged(nameof(PaymentsAmount));
            }
        }

        private int _damagedPaymentsCount;
        public int DamagedPaymentsCount
        {
            get
            {
                return _damagedPaymentsCount;
            }
            set
            {
                _damagedPaymentsCount = value;
                OnPropertyChanged(nameof(DamagedPaymentsCount));
            }
        }

        private float _damagedPaymentsAmount;
        public float DamagedPaymentsAmount
        {
            get
            {
                return _damagedPaymentsAmount;
            }
            set
            {
                _damagedPaymentsAmount = value;
                OnPropertyChanged(nameof(DamagedPaymentsAmount));
            }
        }

        private int _lossPaymentsCount;
        public int LossPaymentsCount
        {
            get
            {
                return _lossPaymentsCount;
            }
            set
            {
                _lossPaymentsCount = value;
                OnPropertyChanged(nameof(LossPaymentsCount));
            }
        }

        private float _lossPaymentsAmount;
        public float LossPaymentsAmount
        {
            get
            {
                return _lossPaymentsAmount;
            }
            set
            {
                _lossPaymentsAmount = value;
                OnPropertyChanged(nameof(LossPaymentsAmount));
            }
        }

        private int _delayedPaymentsCount;
        public int DelayedPaymentsCount
        {
            get
            {
                return _delayedPaymentsCount;
            }
            set
            {
                _delayedPaymentsCount = value;
                OnPropertyChanged(nameof(DelayedPaymentsCount));
            }
        }

        private float _delayedPaymentsAmount;
        public float DelayedPaymentsAmount
        {
            get
            {
                return _delayedPaymentsAmount;
            }
            set
            {
                _delayedPaymentsAmount = value;
                OnPropertyChanged(nameof(DelayedPaymentsAmount));
            }
        }

        private readonly IPaymentService _paymentService;
        public ReportsViewModel(IPaymentService paymentService)
        {
            _paymentService = paymentService; 

            _payments = new ObservableCollection<PaymentViewModel>();
            LoadAllPayments();

            PaymentsCount = paymentService.GetAllByDateCount();
            PaymentsAmount = paymentService.GetAllByDateAmount();

            DelayedPaymentsCount = paymentService.GetAllDelayedByDateCount();
            DelayedPaymentsAmount = paymentService.GetAllDelayedByDateAmount();   
            
            DamagedPaymentsCount = paymentService.GetAllDamagedByDateCount();  
            DamagedPaymentsAmount = paymentService.GetAllDamagedByDateAmount();

            LossPaymentsCount = paymentService.GetAllLossByDateCount();
            LossPaymentsAmount = paymentService.GetAllLossByDateAmount();

        }

        private void LoadAllPayments()
        {
            _payments.Clear();
            foreach(Payment payment in _paymentService.GetAllByDate())
            {
                _payments.Add(new PaymentViewModel(payment));
            }
        }
    }
}
