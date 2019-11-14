using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class OnSelectedBegegnungChanged : EventArgs
    {
        public SpieltagModel ChangedSpieltag { get; set; }
    }
}
