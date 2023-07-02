using Library.Commands;
using Library.GUI.LibrarianCollection.BookRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenBookRetrievalCommand : CommandBase
    {
        public OpenBookRetrievalCommand() 
        {

        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new BookRetrievalView();
            popup.DataContext = new BookRetrievalViewModel();
            popup.ShowDialog();
        }
    }
}
