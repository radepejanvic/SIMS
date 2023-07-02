using Library.Commands;
using Library.Core.Enum;
using Library.Core.Model;
using Library.Core.Service;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.BookLoaning.ViewModel;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.TitleRegistration.ViewModel
{
    public class TitleRegistrationViewModel : ViewModelBase
    {
		public ObservableCollection<Language> Languages => new(Enum.GetValues(typeof(Language)).Cast<Language>().ToList());
        public ObservableCollection<CoverType> CoverTypes => new(Enum.GetValues(typeof(CoverType)).Cast<CoverType>().ToList());

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

		private string _publicationYear;
		public string PublicationYear
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

		private ObservableCollection<AuthorViewModel> _authors;
		public ObservableCollection<AuthorViewModel> Authors
		{
			get
			{
				return _authors;
			}
			set
			{
                _authors = value;
				OnPropertyChanged(nameof(Authors));
			}
		}

		private ObservableCollection<PublisherViewModel> _publishers;
		public ObservableCollection<PublisherViewModel> Publishers
		{
			get
			{
				return _publishers;
			}
			set
			{
				_publishers = value;
				OnPropertyChanged(nameof(Publishers));
			}
		}

		private PublisherViewModel _selectedPublisher;
		public PublisherViewModel SelectedPublisher
		{
			get
			{
				return _selectedPublisher;
			}
			set
			{
				_selectedPublisher = value;
				OnPropertyChanged(nameof(SelectedPublisher));
			}
		}

		private string _searchAuthors;
		public string SearchAuthors
		{
			get
			{
				return _searchAuthors;
			}
			set
			{
				_searchAuthors = value;
				OnPropertyChanged(nameof(SearchAuthors));
			}
		}

		private string _searchPublishers;
		public string SearchPublishers
		{
			get
			{
				return _searchPublishers;
			}
			set
			{
				_searchPublishers = value;
				OnPropertyChanged(nameof(SearchPublishers));
			}
		}

		public CommandBase RegisterTitle { get; }
		public CommandBase RegisterAuthor { get; }
		public CommandBase RegisterPublisher { get; }

		private readonly IBookCollectionService _bookCollectionService;

        public TitleRegistrationViewModel(IBookCollectionService bookCollectionService)
        {
			_bookCollectionService = bookCollectionService;
			_authors = new();
			_publishers = new();
			//RegisterTitle = new RegisterTitleCommand(this, bookCollectionService);

            LoadAuthors();
			LoadPublishers();
            PropertyChanged += OnPropertyChanged;
        }

		public void LoadAuthors()
		{
            _authors.Clear();
            foreach (Author author in _bookCollectionService.GetAllAuthors().Values)
            {
                _authors.Add(new AuthorViewModel(author));
            }
        }

		public void LoadPublishers()
		{
            _publishers.Clear();
            foreach (Publisher publisher in _bookCollectionService.GetAllPublishers().Values)
            {
                _publishers.Add(new PublisherViewModel(publisher));
            }
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchAuthors) && !string.IsNullOrEmpty(SearchAuthors))
            {
                var filtered = _authors.Where(author => author.Contains(SearchAuthors)).ToList();
                CopyFilteredAuthors(filtered);
            }
            else if (e.PropertyName == nameof(SearchAuthors))
            {
                LoadAuthors();
            }
            else if (e.PropertyName == nameof(SearchPublishers) && !string.IsNullOrEmpty(SearchPublishers))
            {
                var filtered = _publishers.Where(publisher => publisher.Contains(SearchPublishers)).ToList();
                CopyFilteredPublishers(filtered);
            }
            else if (e.PropertyName == nameof(SearchPublishers))
            {
                LoadPublishers();
            }
        }

        private void CopyFilteredAuthors(List<AuthorViewModel> filtered)
        {
            _authors.Clear();
            foreach (AuthorViewModel author in filtered)
            {
                _authors.Add(author);
            }
        }

        private void CopyFilteredPublishers(List<PublisherViewModel> filtered)
        {
            _publishers.Clear();
            foreach (PublisherViewModel publisher in filtered)
            {
                _publishers.Add(publisher);
            }
        }

		public List<int> GetAllSelectedAuthors()
		{
			return _authors.Where(author => author.IsSelected is true).Select(author => author.Id).ToList();
		}

    }
}
