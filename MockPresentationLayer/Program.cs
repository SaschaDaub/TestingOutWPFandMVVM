using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace MockPresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            MVVM.BundesligaDeserializing wpf = new BundesligaDeserializing();
            wpf.DeserializeXml();
        }
    }
}
