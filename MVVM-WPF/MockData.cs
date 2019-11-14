using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class MockData
    {
        public List<VereinModel> GetMockData()
        {
            List<VereinModel> vereinListe = new List<VereinModel>();

            VereinModel neuerVerein = new VereinModel();
            neuerVerein.Name = "VfB";
            neuerVerein.Punkte = 30;
            neuerVerein.Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/VfB_Stuttgart_1893_Logo.svg/2000px-VfB_Stuttgart_1893_Logo.svg.png";

            vereinListe.Add(neuerVerein);

            VereinModel Kickers = new VereinModel();
            Kickers.Name = "Kickers";
            Kickers.Punkte = 10;
            Kickers.Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d6/Stuttgarter_Kickers_Logo.svg/2000px-Stuttgarter_Kickers_Logo.svg.png";

            vereinListe.Add(Kickers);
           
            return vereinListe;
        }

        public string GetMoreMock()
        {
            return "Superbundesliga";
        }

        public List<SpieltagModel> GetSpieltagMock()
        {
            List<SpieltagModel> spieltagListe = new List<SpieltagModel>();

            SpieltagModel elfterSpieltag = new SpieltagModel();

            elfterSpieltag.Begegnung = "Freiburg - Eintracht Frankfurt 1:0 (0:0)";
            elfterSpieltag.Information = "Der SC Freiburg geht als Tabellenvierter in die Länderspielpause: Die Breisgauer fuhren am Sonntagabend einen knappen 1:0-Erfolg gegen Eintracht Frankfurt ein. Dabei profitierten die Hausherren auch von einer 45-minütigen Überzahlsituation. Denkwürdig sollte letztlich aber besonders die Nachspielzeit werden.";

            spieltagListe.Add(elfterSpieltag);
            return spieltagListe;
        }
    }
}
