using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsProject.Model;
using WindowsProject.View;

namespace WindowsProject.ViewModel
{
    public class DetailViewModel: ViewModelBase
    {
        public RelayCommand AbonneerCommand { get; set; }

        private MainPageViewModel _mp;

        public MainPageViewModel Mp
        {
            get { return _mp; }
            set { _mp = value; }
        }

        private Onderneming _detailonderneming;

        public Onderneming DetailOnderneming
        {
            get { return _detailonderneming; }
            set { _detailonderneming = value; RaisePropertyChanged(); }
        }

        private Promotie _selectedPromotie;

        public Promotie SelectedPromotie
        {
            get { return _selectedPromotie; }
            set { _selectedPromotie = value; RaisePropertyChanged(); HandleSelectedPromotie(); }
        }



        public DetailViewModel(Onderneming detailOnderneming, MainPageViewModel mp)
        {
            this.DetailOnderneming = detailOnderneming;
            this.Mp = mp;
            AbonneerCommand = new RelayCommand((a) => Abonneer());
            //Debug.WriteLine(this.LoggedInGebruiker.Gebruikersnaam);
        }

        public async void Abonneer()
        {
            this.Mp.LoggedInGebruiker.Abonnementen +=  (this.DetailOnderneming.OndernemingID) + ";" ;
            this.Mp.LoggedInGebruiker.ListAbonnementen.Add(this.DetailOnderneming);
            HttpClient client = new HttpClient();
            Debug.WriteLine(this.Mp.LoggedInGebruiker.Gebruikerid);
            var json = await client.PutAsJsonAsync(new Uri("http://localhost:52974/api/gebruikers/"+this.Mp.LoggedInGebruiker.Gebruikerid),
                this.Mp.LoggedInGebruiker);
        }

        public async Task HandleSelectedPromotie()
        {
            CoreApplicationView newView = CoreApplication.CreateNewView();
            int newViewId = 1;
            await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Frame frame = new Frame();
                frame.Navigate(typeof(PromotieImageView), null);
                frame.DataContext = new PromotieImageViewModel(this.SelectedPromotie);
                //Page page = new Page();

                Window.Current.Content = frame;
                // You have to activate the window in order to show it later.
                Window.Current.Activate();
                newViewId = ApplicationView.GetForCurrentView().Id;
            });
            bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
        }


    }
}
