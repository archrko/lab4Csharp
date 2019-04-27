using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace lab4
{
    //variant 2
   
    public class Person :IEquatable <Person>
    {
        private string _name { get; set; }
        private string _surname { get; set; }
        private System.DateTime _birthDate { get; set; }
        public Person(string name, string surname, DateTime birthdate)
        {
            _name = name;
            _surname = surname;
            _birthDate = birthdate;
        }

        public Person()
        {
            _name = "Armen";
            _surname = "Mazmanyan";
            _birthDate = new DateTime(1998, 1, 23);
        }

        int ChangeBirthDate {
            get
            {
                return _birthDate.Year;
            }
            set {
                _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day);
            }
        }

        public override string ToString()
        {
            return _name + " " + _surname + " " + _birthDate.ToShortDateString();
        }

        public string ToShortString()
        {
            return _name + " " + _surname;
        }

        public static bool operator ==(Person obj1, Person obj2)
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

            return (obj1._birthDate == obj2._birthDate
                    && obj1._name == obj2._name
                    && obj1._surname == obj2._surname);
        }
        
        public static bool operator !=(Person obj1, Person obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _surname.Equals(other._surname)
                   && _name.Equals(other._name)
                   && _birthDate.Equals(other._birthDate);
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

            return obj.GetType() == GetType() && Equals((Person)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = _name.GetHashCode();
                hashCode = (hashCode * 397) ^ _surname.GetHashCode();
                hashCode = (hashCode * 397) ^ _birthDate.GetHashCode();
                return hashCode;
            }
        }
   
        public virtual object DeepCopy()
            {                
                return new Person(_name, _surname, _birthDate);
            }
    }


}
