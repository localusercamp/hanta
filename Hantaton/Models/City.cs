using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hantaton.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Drugstore> Drugstores { get; set; }
}
}