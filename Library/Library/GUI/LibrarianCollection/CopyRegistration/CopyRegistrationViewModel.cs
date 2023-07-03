using Library.Commands;
using Library.Core.Model;
using Library.Core.Service.Interface;
using Library.GUI.LibrarianCollection.TitleRegistration.ViewModel;
using Library.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.GUI.LibrarianCollection.CopyRegistration
{
    public class CopyRegistrationViewModel : ViewModelBase
    {
		private int _branchId;
		public int BranchId
		{
			get
			{
				return _branchId;
			}
			set
			{
				_branchId = value;
				OnPropertyChanged(nameof(BranchId));
			}
		}

		private string _inventoryNumber;
		public string InventoryNumber
		{
			get
			{
				return _inventoryNumber;
			}
			set
			{
				_inventoryNumber = value;
				OnPropertyChanged(nameof(InventoryNumber));
			}
		}

		private float _price;
		public float Price
		{
			get
			{
				return _price;
			}
			set
			{
				_price = value;
				OnPropertyChanged(nameof(Price));
			}
		}

		private ObservableCollection<BookTitleViewModel> _titles;
		public ObservableCollection<BookTitleViewModel> Titles
		{
			get
			{
				return _titles;
			}
			set
			{
				_titles = value;
				OnPropertyChanged(nameof(Titles));
			}
		}

		private BookTitleViewModel _selectedTitle;
		public BookTitleViewModel SelectedTitle
		{
			get
			{
				return _selectedTitle;
			}
			set
			{
				_selectedTitle = value;
				OnPropertyChanged(nameof(SelectedTitle));
			}
		}

		private string _searchTitles;
		public string SearchTitles
		{
			get
			{
				return _searchTitles;
			}
			set
			{
				_searchTitles = value;
				OnPropertyChanged(nameof(SearchTitles));
			}
		}

		public CommandBase RegisterCopy { get; }

		private readonly IBookCollectionService _bookCollectionService;

        public CopyRegistrationViewModel(IBookCollectionService bookCollectionService)
        {
			_bookCollectionService = bookCollectionService;
			_titles = new();
			//RegisterCopy = new RegisterCopyCommand(this, bookCollectionService);
			LoadTitles();
            PropertyChanged += OnPropertyChanged;
        }

		private void LoadTitles()
		{
            _titles.Clear();
            foreach (BookTitle title in _bookCollectionService.GetAllTitles().Values)
            {
                _titles.Add(new BookTitleViewModel(title));
            }
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchTitles) && !string.IsNullOrEmpty(SearchTitles))
            {
                var filtered = _titles.Where(title => title.Contains(SearchTitles)).ToList();
                CopyFilteredTitles(filtered);
            }
            else if (e.PropertyName == nameof(SearchTitles))
            {
                LoadTitles();
            }
        }

        private void CopyFilteredTitles(List<BookTitleViewModel> filtered)
        {
            _titles.Clear();
            foreach (BookTitleViewModel title in filtered)
            {
                _titles.Add(title);
            }
        }
    }
}
