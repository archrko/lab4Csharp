using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Edition:IComparable,IComparer<Edition>
    {
        protected string _name { get; set; }
        protected DateTime _dateTime { get; set; }
        protected int _count { get; set; }
        public Edition()
        {
            _name = "Be stronger";
            _dateTime = new DateTime();
            _count = 0;
        }

        public Edition(string name, DateTime date, int edition)
        {
            _name = name;
            _dateTime = date;
            _count = edition;
        }

        public Edition(Edition edition)
        {
            _name = edition._name;
            _dateTime = edition._dateTime;
            _count = edition._count;
        }

        public virtual object DeepCopy()
        {            
            return new Edition(_name, _dateTime, _count);
        }

        public static bool operator ==(Edition obj1, Edition obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }

            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return (obj1._count == obj2._count
                    && obj1._name == obj2._name
                    && obj1._dateTime == obj2._dateTime);
        }

        public static bool operator !=(Edition obj1, Edition obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() 
                && _name.Equals((obj as Edition)._name) 
                && _count.Equals((obj as Edition)._count)
                && _dateTime.Equals((obj as Edition)._dateTime);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _name.GetHashCode();
                hashCode = (hashCode * 397) ^ _count.GetHashCode();
                hashCode = (hashCode * 397) ^ _dateTime.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return _name + " " + _count + " " + _dateTime.ToShortDateString();
        }

        public int countInfoEdit
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 0) _count = value;
                else
                    throw new ArgumentOutOfRangeException("oops", "Product Number value must be positive");
            }
        }

        public int CompareTo(object obj)
        {
            return _name.CompareTo((obj as Magazine)._name);
        }

        public virtual int Compare(Edition x, Edition y)
        {            
            return x._dateTime.CompareTo(y._dateTime);
        }
    }
}
