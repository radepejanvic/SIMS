using Library.Commands;
using Library.GUI.LibrarianCollection.BookLoaning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenBookLoaningCommand : CommandBase
    {
        public OpenBookLoaningCommand() 
        {

        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new BookLoaningView();
            popup.DataContext = new BookLoaningViewModel();
            popup.ShowDialog();
        }
    }
}
