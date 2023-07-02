using Library.Commands;
using Library.GUI.LibrarianCollection.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenReportsCommand : CommandBase
    {
        public OpenReportsCommand() 
        {

        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new ReportsView();
            popup.DataContext = new ReportsViewModel();
            popup.ShowDialog();
        }
    }
}
