using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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



        public DetailViewModel(Onderneming detailOnderneming)
        {
            this.DetailOnderneming = detailOnderneming;
            //Debug.WriteLine(this.LoggedInGebruiker.Gebruikersnaam);
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
