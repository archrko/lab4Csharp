using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class MagazineListHandlerEventArgs: EventArgs
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public int ElementID { get; set; }
        public MagazineListHandlerEventArgs()
        {
            Name = "";
            Action = "Smth";
            ElementID = 0;
        }
        public MagazineListHandlerEventArgs(string Name,string Action,int ElementID)
        {
            this.Name = Name;
            this.Action = Action;
            this.ElementID = ElementID;
        }
        public override string ToString() => string.Format("Name:{0} Action:{1} ElementID:{2}", Name, Action, ElementID);
    }
}
