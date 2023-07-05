using Library.Commands;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.Reports;
using Library.GUI.LibrarianCollection.Reports.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenReportsCommand : CommandBase
    {
        private readonly IPaymentService _paymentService;
        public OpenReportsCommand(IPaymentService paymentService) 
        {
            _paymentService = paymentService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new ReportsView();
            popup.DataContext = new ReportsViewModel(_paymentService);
            popup.ShowDialog();
        }
    }
}
