using Library.Commands;
using Library.GUI.LibrarianCollection.TitleRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenTitleRegistrationCommand : CommandBase
    {
        public OpenTitleRegistrationCommand() 
        {

        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new TitleRegistrationView();
            popup.DataContext = new TitleRegistrationViewModel();
            popup.ShowDialog();
        }
    }
}
