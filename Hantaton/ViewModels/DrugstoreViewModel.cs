using Hantaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hantaton.ViewModels
{
    public class DrugstoreViewModel
    {
        public Product Product { get; set; }
        public Drugstore Drugstore { get; set; }
        public IEnumerable<SelectListItem> DrugstoresProducts { get; set; }
        public List<SelectListItem> ListItems { get; set; }

        public List<int> _selectedDrugstoreProduct;
        public List<int> SelectedDrugstoreProduct
        {
            get
            {
                if (_selectedDrugstoreProduct != null)
                {
                    _selectedDrugstoreProduct = Drugstore.Products.Select(m => m.Id).ToList();
                }
                return _selectedDrugstoreProduct;
            }
            set { _selectedDrugstoreProduct = value; }
        }

    }
}