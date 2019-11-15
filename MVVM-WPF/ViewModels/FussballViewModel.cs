using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static MVVM.BundesligaDeserializing;

namespace MVVM.ViewModels
{
    public class FussballViewModel : BaseViewModel, IViewModel
    {
        //public ObservableCollection<SpieltagModel> SpieltagCollection { get; set; }
        //private SpieltagModel _selectedSpiel { get; set; }

        //public SpieltagModel SelectedSpiel
        //{
        //    get { return _selectedSpiel; }
        //    set { _selectedSpiel = value; OnPropertyChanged("SelectedSpiel"); }
        //}
        //public ObservableCollection<VereinModel> VereinCollection { get; set; }

        //private VereinModel _selectedVerein { get; set; }
        //public VereinModel SelectedVerein
        //{
        //    get { return _selectedVerein; }
        //    set { _selectedVerein = value; OnPropertyChanged("SelectedVerein"); }
        //}

        //private string _liga { get; set; }
        //public string Liga
        //{
        //    get { return _liga; }
        //    set { _liga = value; OnPropertyChanged("Liga"); }
        //}
        //#region ICommand
        //private ICommand _refreshTabelle { get; set; }
        //public ICommand RefreshTabelle
        //{
        //    get
        //    {
        //        if (_refreshTabelle == null)
        //        {
        //            _refreshTabelle = new RelayCommand(
        //                p => this.CanDoSomething(),
        //                p => this.DoSomeImportantMethod());
        //        }
        //        return _refreshTabelle;
        //    }
        //}

        public Guid Guid { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //private bool CanDoSomething()
        //{
        //    if (SelectedVerein != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //private void DoSomeImportantMethod()
        //{
        //    VereinModel verein = new VereinModel();
        //    verein.Name = "Schlechter Verein";
        //    verein.Punkte = 1;
        //    VereinCollection.Add(verein);
        //}
        //#endregion ICommand
    }
}
