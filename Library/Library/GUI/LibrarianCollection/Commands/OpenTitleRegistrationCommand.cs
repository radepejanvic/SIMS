using Library.Commands;
using Library.GUI.LibrarianCollection.TitleRegistration.ViewModel;
using Library.GUI.LibrarianCollection.TitleRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Service.Interface;

namespace Library.GUI.LibrarianCollection.Commands
{
    public class OpenTitleRegistrationCommand : CommandBase
    {
        private readonly IBookCollectionService _bookCollectionService;

        public OpenTitleRegistrationCommand(IBookCollectionService bookCollectionService) 
        {
            _bookCollectionService = bookCollectionService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var popup = new TitleRegistrationView
            {
                DataContext = new TitleRegistrationViewModel(_bookCollectionService)
            };
            popup.ShowDialog();
        }
    }
}
