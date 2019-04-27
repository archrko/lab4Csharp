using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public enum Frequency
    {
        Yearly,
        Monthly,
        Weekly
    }

    class Magazine : Edition, IRateAndCopy
    {
        private Frequency _frequency { get; set; }
        private List<Article> _articles { get; set; }
        private List<Person> _editors { get; set; }
        public Edition EditionValues
        {
            get => new Edition(_name, _dateTime, _count);
            set
            {
                Magazine magazine = new Magazine(value.DeepCopy() as Edition);
                _name = magazine._name;
                _dateTime = magazine._dateTime;
                _count = magazine._count;
            }
        }

        public  override object DeepCopy()
        {                
            return new Magazine(_name, _dateTime, _count, _frequency, _articles, _editors);
        }

        public double Rating()
        {
            return AvgValueRating;
        }

        public Magazine(Edition edition):base(edition)
        {
          
        }

        public Magazine() : base() 
        {                                    
            _frequency = Frequency.Monthly;                        
        }             

        public Magazine(string name, DateTime date, int edition, Frequency frequency):base(name,date,edition)
        {
            _frequency = frequency;
        }

        public Magazine(string name, DateTime date, int edition,Frequency frequency, List<Article> articles, List<Person> editors) : base(name, date, edition)
        {
            _frequency = frequency;
            _articles = articles;
            _editors = editors;
        }

        public bool this[Frequency frequency]
        {
            get
            {
                return (_frequency == frequency);
            }
        }

        public void AddArticles(params Article[] article)
        {
            if (_articles == null) _articles = new List<Article>();
            for (int i = 0; i < article.Length; i++)
            {
                _articles.Add(article[i]);
            }
            

        }

        public void AddEditors(params Person[] editors)
        {
            if (_editors == null) _editors = new List<Person>();
            for (int i = 0; i < editors.Length; i++)
            {
                _editors.Add(editors[i]);
            }
            
        }   

        public double AvgValueRating
        {
            get
            {
                double result = 0;
                double sum = 0;
                if (_articles == null) return 0;
                else
                {
                    sum = _articles.Sum(a => a.rating);
                    result = sum / _articles.Count;
                    return result;
                }
            }

        }

        public override string ToString()
        {
            Console.WriteLine(_name + " " + _frequency + " " + _dateTime.ToShortDateString() + " count - " + _count);
            if (_articles != null)
            {
                Console.WriteLine("Articles ");
                foreach (Article articles in _articles)
                    Console.WriteLine(articles);                
            }
            else Console.WriteLine("There is no articles yet");
            if (_editors != null)
            {
                Console.WriteLine("Editors");
                foreach (Person person in _editors)
                    Console.WriteLine(person);                
            }
            else Console.WriteLine("There is no editors");
            return "";
        }

        public string ToShortString()
        {
            return _name + " " + _frequency + " " + _dateTime.ToShortDateString() + " " + _count + " " + AvgValueRating;
        }

        public IEnumerable<Article> ByRating(double rating)
        {                
            foreach (Article a in _articles)
            { 
                if(a.rating > rating)
                    yield return a;
            }             
        }

        public IEnumerable<Article> ByNameSubstring(string subString)
        {
            foreach (Article a in _articles)
            {
                if (a.name.IndexOf(subString) > -1) 
                    yield return a;
            }
        }  

        public IEnumerable<Article> AutorIsNotEditor()
        {
            bool check;
            foreach(Article a in _articles)
            {
                check = true;
                foreach(Person p in _editors)
                {
                    if (a.autor == p) check = false;
                }
                if (check)
                {
                    yield return a;
                }
            }
        }

        public IEnumerable<Article> AutorIsEditor()
        {
            bool check;
            foreach (Article a in _articles)
            {
                check = false;
                foreach (Person p in _editors)
                {
                    if (a.autor == p) check = true;
                }
                if (check)
                {
                    yield return a;
                }
            }
        }

        public IEnumerable<Person> EditorButNotAutor()
        {
            bool check;
            foreach(Person p in _editors)
            {
                check = true;
                foreach(Article a in _articles)
                {
                    if (a.autor == p) check = false;
                }
                if (check) yield return p;
            }
        }
    }
}
