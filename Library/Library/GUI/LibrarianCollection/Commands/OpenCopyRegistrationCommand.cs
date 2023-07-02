using Library.Commands;
using Library.GUI.LibrarianCollection.CopyRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenCopyRegistrationCommand : CommandBase
    {
        public OpenCopyRegistrationCommand() 
        {

        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new CopyRegistrationView();
            popup.DataContext = new CopyRegistrationViewModel();
            popup.ShowDialog();
        }
    }
}
