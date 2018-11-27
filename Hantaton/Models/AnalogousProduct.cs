using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hantaton.Models
{
    public class AnalogousProduct
    {
        public int Id { get; set; }
        public string Name1 { get; set; }
        public string Composition1 { get; set; }
        public string Mass1 { get; set; }
        public string Name2 { get; set; }
        public string Composition2 { get; set; }
        public string Mass2 { get; set; }
        public string Name3 { get; set; }
        public string Composition3 { get; set; }
        public string Mass3 { get; set; }
        public string Name4 { get; set; }
        public string Composition4 { get; set; }
        public string Mass4 { get; set; }


        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}