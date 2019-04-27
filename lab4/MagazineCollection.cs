using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    delegate void MagazineListHandler(object source, MagazineListHandlerEventArgs args);
    class MagazineCollection
    {        
        public event MagazineListHandler MagazineAdded;
        public event MagazineListHandler MagazineReplaced;
        private List<Magazine> _magazines;
        public string CollectionName { get; set; }
        public bool Replace(int index, Magazine magazine)
        {
            var res = MagazineReplaced;            
            if (index < 0 || index >= _magazines.Count)
            {
                return false;
            }
            _magazines[index] = magazine;
            res?.Invoke(this, new MagazineListHandlerEventArgs(CollectionName, "Replaced", index));
            return true;
        }
        public Magazine this[int index]
        {
            get
            {
                if (index < 0 || index >= _magazines.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return _magazines[index];
            }
            set
            {
                if (index < 0 || index >= _magazines.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                var res = MagazineReplaced;
                _magazines[index] = value;
                res?.Invoke(this, new MagazineListHandlerEventArgs(CollectionName, "Replaced", index));
            }
        }

        public void AddDefaults()
        {
            var res = MagazineAdded;
            if (_magazines == null) _magazines = new List<Magazine>();            
            var articles = new List<Article>
            {
                new Article()
            };
            var editors = new List<Person>
            {
                new Person()
            };
            _magazines.Add(new Magazine("First",new DateTime(2012,12,1),1000,Frequency.Monthly,articles,editors));
            res?.Invoke(this, new MagazineListHandlerEventArgs(CollectionName, "Added", _magazines.Count - 1));            
        }

        public void AddMagazines(params Magazine[] magazines)
        {
            var res = MagazineAdded;
            if (_magazines==null) _magazines = new List<Magazine>();
            for (int i = 0; i < magazines.Length; i++)
            {
                _magazines.Add(magazines[i]);
                res.Invoke(this, new MagazineListHandlerEventArgs(CollectionName,"Added",_magazines.Count - 1));
            }
        }

        public override string ToString()
        {
            foreach (Magazine s in _magazines)
            {
                Console.WriteLine(s);
            }
            return "";
        }
        public string ToShortString()
        {
            foreach(Magazine s in _magazines)
            {
                Console.WriteLine(s.ToShortString());
            }
            return "";
        }
        public void SortByName() => _magazines.Sort((x, y) => x.CompareTo(y));

        public void SortByDate() => _magazines.Sort((x, y) => new Edition().Compare(x, y));

        public void SortByCount() => _magazines.Sort((x, y) => new HelpMagazine().Compare(x, y));

        public double GetMaxAvgRating => _magazines.DefaultIfEmpty(new Magazine()).Max(m => m.AvgValueRating);
  
        public IEnumerable<Magazine> MonthlyMagazines
        {
            get
            {
                return from magazine in _magazines
                       where magazine[Frequency.Monthly]
                       select magazine; ;
            }
        }
        
        public List<Magazine> RatingGroup(double value)
        {            
            return _magazines.GroupBy(rat => rat.AvgValueRating >= value).Where(p => p.Key).First().ToList();
        }
    }
}
