using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private DataTemplate _template;

        public DataTemplate Template
        {
            get { return _template; }
            set { _template = value; RaisePropertyChanged("Template"); }
        }

        private bool _loggedIn;

        public bool LoggedIn
        {
            get { return _loggedIn; }
            set { _loggedIn = value; RaisePropertyChanged("LoggedIn"); }
        }

        private Gebruiker _loggedInGebruiker;

        public Gebruiker LoggedInGebruiker
        {
            get { return _loggedInGebruiker; }
            set { _loggedInGebruiker = value; RaisePropertyChanged("gebruiker"); }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModelBase()
        {
            Template = GetTemplate();
        }

        private DataTemplate GetTemplate()
        {
            string s = GetType().Name;
            return (DataTemplate)App.Current.Resources[s];
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}