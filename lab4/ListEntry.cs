using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class ListEntry
    {
        public string CollectionName { get; set; }
        public string Action { get; set; }
        public int ElementID;
        public ListEntry()
        {
            CollectionName = "";
            Action = "";
            ElementID = 0;
        }
        public ListEntry(string colectionName,string action,int elementID)
        {
            CollectionName = colectionName;
            Action = action;
            ElementID = elementID;
        }
        public override string ToString()
        {                      
            return string.Format("Collection Name: {0}\nAction: {1}\nElementID: {2} ",CollectionName,Action,ElementID);
        }
    }
}
