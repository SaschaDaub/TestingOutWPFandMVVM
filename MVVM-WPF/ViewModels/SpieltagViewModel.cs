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
        //
        public ObservableCollection<SpieltagModel> SpieltagSammlung { get; set; }

        //Hier wird eine Liste/ObservableCollection erstellt und befüllt, die später auf der Seite "SpieltagView" angezeigt wird
        public SpieltagViewModel()
        {
            SpieltagSammlung = new ObservableCollection<SpieltagModel>();

            //Die Methode DeserializeXml() ausführen und in einer foreach-Schleife alle zurückgegebenen Einträge in die ObservableCollection "SpieltagSammlung" hinzufügen
            BundesligaDeserializing bundesligaDeserializing = new BundesligaDeserializing();
            List<SpieltagModel> spieltagListe = bundesligaDeserializing.DeserializeXml();

            foreach (var item in spieltagListe)
            {
                SpieltagSammlung.Add(item);
            }
        }


        //Wenn ein Spiel ausgewählt wird, wird hier das PropertyChanged aufgerufen
        private SpieltagModel _selectedSpiel { get; set; }

        public SpieltagModel SelectedSpiel
        {
            get { return _selectedSpiel; }
            set { _selectedSpiel = value; OnPropertyChanged("SelectedSpiel"); OnSelectionChanged(); }
        }

        public Guid Guid { get; set; }

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
