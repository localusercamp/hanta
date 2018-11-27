using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hantaton.DAL;
using Hantaton.Models;
using Hantaton.ViewModels;

namespace Hantaton.Controllers
{
    public class ProductsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Composition,Price,Mass,AnalogousName_1,AnalogousName_2,AnalogousName_3,AnalogousName_4")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var productViewModel = new ProductViewModel
            {
                Product = db.Products.Include(i => i.Drugstores).First(i => i.Id == id),
            };
            if (productViewModel.Product == null)
                return HttpNotFound();
            var productDrugstores = db.Drugstores.ToList();

            productViewModel.ProductsDrugstores = productDrugstores.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            productViewModel.ItemList = db.Citys.ToList().ConvertAll(
                a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                        Selected = false
                    };
                });
            return View(productViewModel);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            productViewModel.ItemList = db.Citys.ToList().ConvertAll(
                a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                        Selected = false
                    };
                });
            var item = db.Entry(productViewModel.Product);
            item.State = EntityState.Modified;
            item.Collection(i => i.Drugstores).Load();
            productViewModel.Product.Drugstores.Clear();

            foreach (var id in productViewModel._selectedProductDrugstore)
            {
                productViewModel.Product.Drugstores.Add(db.Drugstores.First(i => i.Id == id));
            }

            if (ModelState.IsValid)
            {
                db.Entry(productViewModel.Product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productViewModel);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
