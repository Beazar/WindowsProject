using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Data.Xml.Dom;
using Windows.UI.Core;
using Windows.UI.Notifications;
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

        public Visibility IsVisible { get; set; }

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
            if(this.Mp.LoggedInGebruiker == null || this.Mp.LoggedInGebruiker.Abonnementen.StartsWith(this.DetailOnderneming.OndernemingID + ";")
                || this.Mp.LoggedInGebruiker.Abonnementen.Contains(";" + this.DetailOnderneming.OndernemingID + ";")
                 ) { 
          //  if (this.Mp.LoggedInGebruiker.ListAbonnementen.Contains(this.DetailOnderneming)){
                this.IsVisible = Visibility.Collapsed;
            }
            else
            {
                this.IsVisible = Visibility.Visible;
            }
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

            //create XML
            var toastXml = new XmlDocument();
            toastXml.LoadXml("<toast><visual><binding template='ToastGeneric'>" +
                "<text>Abonneren</text><text>U bent geabonneerd op</text> " +
                "<text>" + this.DetailOnderneming.Naam + "</text></binding></visual></toast>");

            //build toast
            var toast = new ToastNotification(toastXml);

            //show toast
            var notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.Show(toast);



            this.Mp.CurrentData = new DetailViewModel(this.DetailOnderneming, this.Mp);
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
