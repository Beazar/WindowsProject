using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    public class DetailViewModel: ViewModelBase
    {
        private Onderneming _detailonderneming;

        public Onderneming DetailOnderneming
        {
            get { return _detailonderneming; }
            set { _detailonderneming = value; }
        }
        

        public DetailViewModel(Onderneming detailOnderneming)
        {
            this.DetailOnderneming = detailOnderneming;
            //Debug.WriteLine(this.LoggedInGebruiker.Gebruikersnaam);
        }


    }
}
