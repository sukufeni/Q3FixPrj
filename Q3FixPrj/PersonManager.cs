using System;
using System.Collections.Generic;
using System.Linq;

namespace Q3FixPrj
{
    public class PersonManager
    {
        public List<Person> Db { get; set; }
        public PersonManager()
        {
            this.Db = new List<Person>();
        }
        public void AddPerson(Person person)
        {
            this.Db.Add(person);
        }
        public bool DeletePerson(Person person) => this.Db.Contains(person) ? this.Db.Remove(person) : false;

        public Person FindPerson(string name, DateTime birthDate)
        {
            return Db.Where(r => r.Name.Equals(name) && r.BirthDate.Date.Equals(birthDate)).Select(r => r).FirstOrDefault();
        }
        public bool DeletePerson(int index)
        {
            if (index < this.Db.Count) this.Db.RemoveAt(index);
            return true;
        }
    }
}
