using System;
using System.ComponentModel;
using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.Helpers.Validation;
using Library.GUI.LibrarianCollection.TitleRegistration.ViewModel;
using Library.GUI.LibrarianMemberships.UserRegistration.ViewModel;
using Microsoft.VisualBasic.CompilerServices;

namespace Library.GUI.LibrarianMemberships.UserRegistration.Command;

public class RegisterUserCommand : CommandBase
{
    private readonly UserRegistrationViewModel _userRegistrationViewModel;
    private readonly IMembersService _membersService;

    public RegisterUserCommand(UserRegistrationViewModel bookLoaningViewModel,
        IMembersService membersService)
    {
        _userRegistrationViewModel = bookLoaningViewModel;
        _membersService = membersService;
        _userRegistrationViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }
    
    bool IsDigitsOnly(string str)
    {
        foreach (char c in str)
        {
            if (c < '0' || c > '9')
                return false;
        }

        return true;
    }

    public override bool CanExecute(object? parameter)
    {
        return (_userRegistrationViewModel.SelectedMembership is not null) &&
               (!string.IsNullOrEmpty(_userRegistrationViewModel.Name)) &&
               (!string.IsNullOrEmpty(_userRegistrationViewModel.Surname)) &&
               (!string.IsNullOrEmpty(_userRegistrationViewModel.Email)) &&
               (!string.IsNullOrEmpty(_userRegistrationViewModel.Phone)) &&
               IsDigitsOnly(_userRegistrationViewModel.JMBG);
    }

    public override void Execute(object? parameter)
    {
        try
        {

            _membersService.AddUser(
                _userRegistrationViewModel.Name,
                _userRegistrationViewModel.Surname,
                _userRegistrationViewModel.Email,
                _userRegistrationViewModel.Phone,
                _userRegistrationViewModel.JMBG,
                _userRegistrationViewModel.SelectedMembership.Membership
            );
            
            OnExecutionCompleted(true, "Uspešno ste registrovali korisnik.");
        }
        catch (Exception)
        {
            OnExecutionCompleted(false, "Greška prilikom registrovanja korisnika!");
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        _userRegistrationViewModel.Error = "";
        if (!IsDigitsOnly(_userRegistrationViewModel.JMBG))
        {
            _userRegistrationViewModel.Error += " JMBG must be number!";
        }
        if (_userRegistrationViewModel.SelectedMembership is not null)
        {
            _userRegistrationViewModel.Error += " You must select membership!";
        }
        if (e.PropertyName == nameof(_userRegistrationViewModel.Name) ||
            e.PropertyName == nameof(_userRegistrationViewModel.Surname) ||
            e.PropertyName == nameof(_userRegistrationViewModel.JMBG) ||
            e.PropertyName == nameof(_userRegistrationViewModel.Email) ||
            e.PropertyName == nameof(_userRegistrationViewModel.Phone) ||
            e.PropertyName == nameof(_userRegistrationViewModel.SelectedMembership))
        {
            OnCanExecutedChanged();
        }
    }
}