using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hantaton.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string Price { get; set; }
        public string Mass { get; set; }

        public string AnalogousName_1 { get; set; }
        public string AnalogousName_2 { get; set; }
        public string AnalogousName_3 { get; set; }
        public string AnalogousName_4 { get; set; }

        public virtual ICollection<Drugstore> Drugstores { get; set; }
    }
}