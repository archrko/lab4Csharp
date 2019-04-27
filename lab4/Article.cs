using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class Article:IRateAndCopy
    {
        public Person autor;
        public string name;
        public double rating;

        public Article()
        {
            autor = new Person();
            name = "Be iniciative";
            rating = 0;
        }

        public Article(Person autorInfo, string name, double rating)
        {
            autor = autorInfo;
            this.name = name;
            this.rating = rating;
        }        

        public override string ToString()
        {
            return autor.ToShortString() + " - " + name + ";Rating " + rating;
        }

        public object DeepCopy()
        {            
            return new Article(autor.DeepCopy() as Person, name, rating);
        }

        public double Rating()
        {
            return rating;
        }
    }   
}
