using System;
using System.Text;

namespace Q3FixPrj
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }

        private void CalcAge()
        {
            this.Age = DateTime.Now.Year - this.BirthDate.Year;
        }
        public Person(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate.Date;
            CalcAge();
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("\n Name: {0} ", this.Name);
            builder.AppendFormat("\n Age: {0} ", this.Age);
            builder.AppendFormat("\n BirthDate: {0} ", this.BirthDate.ToShortDateString());
            return builder.ToString();
        }
    }
}