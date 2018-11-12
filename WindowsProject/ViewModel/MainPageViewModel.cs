using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsProject.ViewModel
{
    class MainPageViewModel : ViewModelBase
    {
        public RelayCommand AllOndernemingenCommand { get; set; }

        public MainPageViewModel()
        {
            AllOndernemingenCommand = new RelayCommand(_ => ShowOndernemingen());
        }

        private ViewModelBase _currentData;
        public ViewModelBase CurrentData
        {
            get { return _currentData; }
            set { _currentData = value; RaisePropertyChanged(); }
        }

        private void ShowOndernemingen()
        {
            CurrentData = new OndernemingenViewModel();
            Debug.WriteLine("ShowOndernemingen called");
        }

    }
}
