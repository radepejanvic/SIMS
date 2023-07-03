using Library.Commands;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookLoaning;
using Library.GUI.LibrarianCollection.BookLoaning.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenBookLoaningCommand : CommandBase
    {
        private readonly IMembersService _membersService;
        private readonly ILoaningService _loaningService;
        public OpenBookLoaningCommand(IMembersService membersService, ILoaningService loaningService) 
        {
            _membersService = membersService;
            _loaningService = loaningService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new BookLoaningView();
            popup.DataContext = new BookLoaningViewModel(_membersService, _loaningService);
            popup.ShowDialog();
        }
    }
}
