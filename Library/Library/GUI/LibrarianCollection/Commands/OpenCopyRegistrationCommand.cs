using Library.Commands;
using Library.Core.Service.Interface;
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
        private readonly IBookCollectionService _bookCollectionService;

        public OpenCopyRegistrationCommand(IBookCollectionService bookCollectionService) 
        {
            _bookCollectionService = bookCollectionService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new CopyRegistrationView
            {
                DataContext = new CopyRegistrationViewModel(_bookCollectionService)
            };
            popup.ShowDialog();
        }
    }
}
