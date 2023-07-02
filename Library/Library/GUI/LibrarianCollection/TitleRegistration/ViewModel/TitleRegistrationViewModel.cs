using Library.Core.Enum;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.TitleRegistration.ViewModel
{
    public class TitleRegistrationViewModel : ViewModelBase
    {
		public ObservableCollection<Language> Languages { get; set; }
		public ObservableCollection<CoverType> CoverTypes { get; set; }

        private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private DateTime _publicationYear;
		public DateTime PublicationYear
		{
			get
			{
				return _publicationYear;
			}
			set
			{
				_publicationYear = value;
				OnPropertyChanged(nameof(PublicationYear));
			}
		}

		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}

		private Language _selectedLanguage;
		public Language SelectedLanguage
        {
			get
			{
				return _selectedLanguage;
			}
			set
			{
                _selectedLanguage = value;
				OnPropertyChanged(nameof(SelectedLanguage));
			}
		}

		private CoverType _selectedCover;
		public CoverType SelectedCover
		{
			get
			{
				return _selectedCover;
			}
			set
			{
				_selectedCover = value;
				OnPropertyChanged(nameof(SelectedCover));
			}
		}

		private string _isbn;
		public string ISBN
		{
			get
			{
				return _isbn;
			}
			set
			{
				_isbn = value;
				OnPropertyChanged(nameof(ISBN));
			}
		}

		private string _udk;
		public string UDK
		{
			get
			{
				return _udk;
			}
			set
			{
				_udk = value;
				OnPropertyChanged(nameof(UDK));
			}
		}


	}
}
