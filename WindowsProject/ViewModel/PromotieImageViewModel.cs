using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsProject.Model;

namespace WindowsProject.ViewModel
{
    class PromotieImageViewModel: ViewModelBase
    {
//        private MainPageViewModel mp;

        private Promotie _promotie;

        public Promotie Promotie
        {
            get { return _promotie; }
            set { _promotie = value; RaisePropertyChanged(); }
        }
        


        public PromotieImageViewModel( Promotie promotie)
        {
//            this.mp = mp;
            this.Promotie = promotie;
            
        }


    }
}
