using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entity
{
    public class Heroe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
        public DateTimeOffset Appearance { get; set; }
        public string Description { get; set; }
        public string ImgBase64String { get; set; }

        public Heroe()
        {

        }

        public Heroe(int id, string name, string home, DateTimeOffset appearance, string description, string imgBase64String)
        {
            Id = id;
            Name = name;
            Home = home;
            Appearance = appearance;
            Description = description;
            ImgBase64String = imgBase64String;
        }
    }
}
