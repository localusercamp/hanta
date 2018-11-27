using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hantaton.Models
{
    public class Drugstore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int OpeningTime { get; set; }    // Время открытия
        public int ClosingTime { get; set; }    // Время закрытия
        public string PhoneNumber { get; set; }
        public string DopInform { get; set; }   // Инфа о доступнисти маломобильных групп



        public int CityId { get; set; } // Вторичный ключ
        public virtual City City { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}