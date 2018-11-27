using Hantaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hantaton.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        //public Drugstore Drugstore { get; set; }
        public IEnumerable<SelectListItem> ProductsDrugstores { get; set; }
        public List<SelectListItem> ItemList { get; set; }

        public List<int> _selectedProductDrugstore;
        public List<int> SelectedProductDrugstore
        {
            get
            {
                if (_selectedProductDrugstore != null)
                {
                    _selectedProductDrugstore = Product.Drugstores.Select(m => m.Id).ToList();
                }
                return _selectedProductDrugstore;
            }
            set { _selectedProductDrugstore = value; }
        }

    }
}
