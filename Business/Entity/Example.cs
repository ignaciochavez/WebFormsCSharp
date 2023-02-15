using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Example
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

        public Example()
        {

        }

        public Example(int id, string rut, string name, string lastName, DateTimeOffset birthDate, bool active, string password)
        {
            Id = id;
            Rut = rut;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Active = active;
            Password = password;
        }
    }
}
