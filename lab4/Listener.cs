using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Listener
    {
        public Listener()
        {
            ListEntries = new List<ListEntry>();
        }
        public List<ListEntry> ListEntries { get; }
        public void Handler(object source, MagazineListHandlerEventArgs args)
        {
            ListEntries.Add(new ListEntry(args.Name, args.Action, args.ElementID));
        }
        public override string ToString()
        {
            var sb = new StringBuilder(ListEntries.Count + " Elements was changed\n");
            for (int i = 0; i < ListEntries.Count; i++)
            {
                sb.Append(ListEntries[i] + "\n");
            }
            return sb.ToString();
        }

    }
}
