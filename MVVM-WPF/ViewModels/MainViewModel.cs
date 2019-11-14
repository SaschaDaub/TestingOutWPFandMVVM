using MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private IViewModel _spieltagVm { get; set; }
        private IViewModel _begegnungVm { get; set; }
        private object _spieltagUi { get; set; }
        public object SpieltagUi
        {
            get { return _spieltagUi; }
            set { _spieltagUi = value; OnPropertyChanged("SpieltagUi"); }
        }

        private object _begegnungUi { get; set; }
        public object BegegnungUi
        {
            get { return _begegnungUi; }
            set { _begegnungUi = value; OnPropertyChanged("BegegnungUi"); }
        }

        public MainViewModel()
        {
            InitializeSpieltagUi();
            InitializeBegegnungUi();
            SetUpSubscribers();
        }

        private void InitializeSpieltagUi()
        {
            _spieltagVm = new SpieltagViewModel();
            SpieltagUi = new SpieltagView(_spieltagVm);
        }

        private void InitializeBegegnungUi()
        {
            _begegnungVm = new BegegnungViewModel();
            BegegnungUi = new BegegnungView(_begegnungVm);

        }

        private void SetUpSubscribers()
        {
            //if (_spieltagVm.GetType().Equals(typeof(SpieltagViewModel)))
            //{
            SpieltagViewModel spieltagVm = _spieltagVm as SpieltagViewModel;
            BegegnungViewModel begegnungVm = _begegnungVm as BegegnungViewModel;


            spieltagVm.SelectionChanged += begegnungVm.SpieltagViewModel_SelectionChanged;
        }


    }
}
