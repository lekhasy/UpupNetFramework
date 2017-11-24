using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.ViewModels
{
    public class PoItemModel
    {
        public string Code { get; internal set; }
        public long Id { get; internal set; }
        public string Name { get; internal set; }
        public int State { get; internal set; }
        public int Sequence { get; internal set; }
        public string ShipingProgress { get; internal set; }
        public string CompleteProgress { get; internal set; }
        public bool Ordered { get; internal set; }
        public bool Paid { get; internal set; }
        public bool Removable => Paid ? false : true;
    }
}