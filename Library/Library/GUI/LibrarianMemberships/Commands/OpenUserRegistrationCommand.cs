using System;
using System.Diagnostics;
using Library.Commands;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.TitleRegistration;
using Library.GUI.LibrarianCollection.TitleRegistration.ViewModel;

namespace Library.GUI.LibrarianMemberships.Commands
{
    public class OpenUserRegistrationCommand : CommandBase
    {
        private readonly IMembersService _membersService;
        public OpenUserRegistrationCommand(IMembersService membersService) 
        {
            _membersService = membersService;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Debug.WriteLine("MY WINDOW (c) Alex M.");
        }
    }
}