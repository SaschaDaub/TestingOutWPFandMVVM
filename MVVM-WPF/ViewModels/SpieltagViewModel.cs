using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    public class SpieltagViewModel : BaseViewModel, IViewModel
    {
        public ObservableCollection<SpieltagModel> SpieltagSammlung { get; set; }
        private SpieltagModel _selectedSpiel { get; set; }

        public SpieltagModel SelectedSpiel
        {
            get { return _selectedSpiel; }
            set { _selectedSpiel = value; OnPropertyChanged("SelectedSpiel"); OnSelectionChanged(); }
        }

        public Guid Guid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SpieltagViewModel()
        {
            SpieltagSammlung = new ObservableCollection<SpieltagModel>();

            //Mockdata
            BundesligaDeserializing bundesligaDeserializing = new BundesligaDeserializing();
            var spieltagListe = bundesligaDeserializing.DeserializeXml();

            foreach (var item in spieltagListe)
            {

                SpieltagSammlung.Add(item);
            }

        }

        public event EventHandler<OnSelectedBegegnungChanged> SelectionChanged;

        public void OnSelectionChanged()
        {
            if (SelectionChanged != null)
            {
                SelectionChanged.Invoke(this, new OnSelectedBegegnungChanged() { ChangedSpieltag = SelectedSpiel });
            }
        }
    }
}
