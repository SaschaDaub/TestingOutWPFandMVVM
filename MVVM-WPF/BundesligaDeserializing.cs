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
    [XmlRoot("rss")]
    public class BundesligaDeserializing
    {
        [XmlElement("channel")]
        public ChannelNode Channel { get; set; }
        public class ChannelNode
        {
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


        //public class XMLCollection
        //{
        //    [XmlArrayItem(typeof(Item))]
        //    public Item[] Item { get; set; }
        //}

        //public List<SpieltagModel> XML_auslesen()
        //{
        //    XMLCollection input = null;
        //    string path = "http://rss.kicker.de/live/bundesliga";
        //    XmlSerializer serializer = new XmlSerializer(typeof(XMLCollection));

        //    MemoryStream reader = new MemoryStream(path);
        //    input = (XMLCollection)serializer.Deserialize(reader);
        //    reader.Close();

        //    List<SpieltagModel> spieltagListe = new List<SpieltagModel>();
        //    foreach (var item in input.Item)
        //    {
        //        SpieltagModel neuesSpiel = new SpieltagModel();
        //        neuesSpiel.Begegnung = "begegnung";
        //        neuesSpiel.Information = "info";

        //        spieltagListe.Add(neuesSpiel);
        //    }

        //    return spieltagListe;

        //}

        //public List<SpieltagModel> DeserializeXml()
        //{

        //    ////Schritt 0: Xml Pfad
        //    string path = "http://rss.kicker.de/live/bundesliga";


        //    //string path = "http://joeroganexp.joerogan.libsynpro.com/rss";




        //    //Schritt 1: Uri in XmlDocument laden

        //    XmlDocument loadedXml = new XmlDocument();
        //    loadedXml.Load(path);

        //    //Schritt 2: XmlDocument in MemoryStream laden
        //    MemoryStream memStream = new MemoryStream();
        //    loadedXml.Save(memStream);
        //    memStream.Seek(0, 0);
        //    //Schritt 3: Deserializer initialisieren
        //    XmlSerializer deserializer = new XmlSerializer(typeof(BundesligaDeserializing));
        //    //Schritt 4: Deserializer "starten"
        //    BundesligaDeserializing bundesligaCollection = new BundesligaDeserializing();
        //    bundesligaCollection = (BundesligaDeserializing)deserializer.Deserialize(memStream);

        //    List<SpieltagModel> deserializedSpieltage = CreateSpieltagDTO(bundesligaCollection);

        //    return deserializedSpieltage;
        //}


        public List<SpieltagModel> DeserializeXml()
        {

            ////Schritt 0: Xml Pfad

            string path = "http://rss.kicker.de/live/bundesliga";

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(path);
            HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
            string xml = string.Empty;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
      




                xml = sr.ReadToEnd();



                string a = xml.Replace(Convert.ToString((byte)0x1F), string.Empty);
            

                XmlDocument loadedXml = new XmlDocument();
                loadedXml.LoadXml(a);




                //XmlDocument loadedXml = new XmlDocument();
                //loadedXml.Load(path);

                //Schritt 2: XmlDocument in MemoryStream laden
                MemoryStream memStream = new MemoryStream();
                loadedXml.Save(memStream);
                memStream.Seek(0, 0);






                //Schritt 3: Deserializer initialisieren
                XmlSerializer deserializer = new XmlSerializer(typeof(BundesligaDeserializing));
                //Schritt 4: Deserializer "starten"
                BundesligaDeserializing bundesligaCollection = new BundesligaDeserializing();
                bundesligaCollection = (BundesligaDeserializing)deserializer.Deserialize(memStream);
                List<SpieltagModel> deserializedSpieltage = CreateSpieltagDTO(bundesligaCollection);

                return deserializedSpieltage;
            }






        }


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


