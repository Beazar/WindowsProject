using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

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