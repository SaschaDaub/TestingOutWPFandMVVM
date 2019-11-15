using MVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MVVM
{
    //XML-Struktur des RSS-Feeds
    [XmlRoot("rss")]
    public class BundesligaDeserializing
    {
        [XmlElement("channel")]
        public ChannelNode Channel { get; set; }
        public class ChannelNode
        {
            //Die Liste wird benötigt, da sich unter diesem Knoten mehrere Einträge befinden, die wir später benutzen wollen
            [XmlElement("item")]
            public List<BundesligaItems> Items { get; set; }
        }
        public class BundesligaItems
        {
            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("description")]
            public string Description { get; set; }
        }

        //Die Methode DeserializeXml() erstellt eine Liste (deserializedSpieltage) vom Typen "SpieltagModel" aus einem RSSFeed
        //Returned die Liste "deserializedSpieltage" mit einer Auflistung aller Partien und deren Description
        public List<SpieltagModel> DeserializeXml()
        {
            //Schritt 1: Xml Pfad + Liste initialisieren
            string path = "http://rss.kicker.de/live/bundesliga";
            List<SpieltagModel> deserializedSpieltage = new List<SpieltagModel>();

            //Der Webrequest holt sich die XML (falls diese gezippt ist wird diese dekomprimiert)
            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(path);
            webReq.AutomaticDecompression = DecompressionMethods.GZip;
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            string KickerXML = string.Empty;

            //Der StreamReader liest die Textfile/XML aus, die in der "response" steht
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                //Datei wird ausgelesen, Sonderzeichen gelöscht, ein XMLDocument erstellt und in dieses die XML gespeichert
                KickerXML = sr.ReadToEnd();
                string KickerXML_ohneHexa = KickerXML.Replace(Convert.ToString((byte)0x1F), string.Empty);
                XmlDocument loadedXml = new XmlDocument();
                loadedXml.LoadXml(KickerXML_ohneHexa);

                //XmlDocument in MemoryStream laden. Dieser legt das XML im Arbeitsspeicher ab
                MemoryStream memStream = new MemoryStream();
                loadedXml.Save(memStream);
                memStream.Seek(0, 0);

                //Deserializer initialisieren
                XmlSerializer deserializer = new XmlSerializer(typeof(BundesligaDeserializing));

                //Deserializer "starten"
                BundesligaDeserializing bundesligaCollection = new BundesligaDeserializing();
                bundesligaCollection = (BundesligaDeserializing)deserializer.Deserialize(memStream);
                //Die Methode CreateSpieltagDTO aufrufen und dort eine Liste mit Objekten füllen
                deserializedSpieltage = CreateSpieltagDTO(bundesligaCollection);
            }
            return deserializedSpieltage;
        }

        //Die Methode CreateSpieltagDTO() erstellt ein neues Objekt in unserer Liste "SpieltagModel" und returned die Liste "spieltags"
        public List<SpieltagModel> CreateSpieltagDTO(BundesligaDeserializing bundesligaCollection)
        {
            List<SpieltagModel> spieltags = new List<SpieltagModel>();
            foreach (var item in bundesligaCollection.Channel.Items)
            {
                SpieltagModel neuesSpiel = new SpieltagModel();
                neuesSpiel.Begegnung = item.Title;
                neuesSpiel.Information = item.Description;

                spieltags.Add(neuesSpiel);
            }
            return spieltags;
        }
    }
}


