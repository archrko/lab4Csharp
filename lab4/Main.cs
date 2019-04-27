using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            MagazineCollection m = new MagazineCollection
            {
                CollectionName = "Love It"
            };
            MagazineCollection n = new MagazineCollection
            {
                CollectionName = "Dance"
            };
            Listener lis1 = new Listener();
            Listener lis2 = new Listener();
            m.AddDefaults();
            n.AddDefaults();
            m.MagazineAdded += lis1.Handler;
            m.MagazineReplaced += lis1.Handler;

            m.MagazineAdded += lis2.Handler;
            m.MagazineReplaced += lis2.Handler;
            n.MagazineAdded += lis2.Handler;
            n.MagazineReplaced += lis2.Handler;

            m.AddMagazines(new Magazine());
            m.AddMagazines(new Magazine());
            n[0] = new Magazine();
            n.Replace(0, new Magazine());
            Console.WriteLine(lis1);
            Console.WriteLine(lis2);            
            Console.ReadKey();
        }
       
    }

}
