using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class BegegnungViewModel : BaseViewModel, IViewModel
    {
        public Guid Guid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private SpieltagModel _begegnungDetail { get; set; }
        public SpieltagModel BegegnungDetail
        {
            get { return _begegnungDetail; }
            set { _begegnungDetail = value; OnPropertyChanged("BegegnungDetail"); }
        }

        public BegegnungViewModel()
        {
            BegegnungDetail = new SpieltagModel();
        }
        public void SpieltagViewModel_SelectionChanged(object sender, OnSelectedBegegnungChanged e)
        {
            BegegnungDetail = e.ChangedSpieltag;
        }
    }
}
