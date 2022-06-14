using MyBooks.Core;
using MyBooks.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand BooksViewCommand { get; set; }
        public RelayCommand AuthorsViewCommand { get; set; }
        public RelayCommand CategoriesViewCommand { get; set; }
        public RelayCommand EditViewCommand { get; set; }
        public RelayCommand SettingsViewCommand { get; set; }
        public RelayCommand HelpViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public BooksViewModel BooksVm { get; set; }
        public AuthorsViewModel AuthorsVm { get; set; }
        public CategoriesViewModel CategoriesVm { get; set; }
        public EditViewModel EditVm { get; set; }
        public SettingsViewModel SettingsVm { get; set; }
        public HelpViewModel HelpVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            BooksVm = new BooksViewModel();
            AuthorsVm = new AuthorsViewModel();
            CategoriesVm = new CategoriesViewModel();
            EditVm = new EditViewModel();
            SettingsVm = new SettingsViewModel();
            HelpVm = new HelpViewModel();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            BooksViewCommand = new RelayCommand(o =>
            {
                CurrentView = BooksVm;
            });

            AuthorsViewCommand = new RelayCommand(o =>
            {
                CurrentView = AuthorsVm;
            });

            CategoriesViewCommand = new RelayCommand(o =>
            {
                CurrentView = CategoriesVm;
            });

            EditViewCommand = new RelayCommand(o =>
            {
                CurrentView = EditVm;
            });

            SettingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SettingsVm;
            });

            HelpViewCommand = new RelayCommand(o =>
            {
                CurrentView = HelpVm;
            });
        }
    }
}
