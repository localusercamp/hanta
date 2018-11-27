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

namespace Hantaton.Controllers
{
    public class AnalogousProductsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: AnalogousProducts
        public ActionResult Index()
        {
            var analogousProducts = db.AnalogousProducts.Include(a => a.Product);
            return View(analogousProducts.ToList());
        }

        // GET: AnalogousProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalogousProduct analogousProduct = db.AnalogousProducts.Find(id);
            if (analogousProduct == null)
            {
                return HttpNotFound();
            }
            return View(analogousProduct);
        }

        // GET: AnalogousProducts/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: AnalogousProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name1,Composition1,Mass1,Name2,Composition2,Mass2,Name3,Composition3,Mass3,Name4,Composition4,Mass4,ProductId")] AnalogousProduct analogousProduct)
        {
            if (ModelState.IsValid)
            {
                db.AnalogousProducts.Add(analogousProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", analogousProduct.ProductId);
            return View(analogousProduct);
        }

        // GET: AnalogousProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalogousProduct analogousProduct = db.AnalogousProducts.Find(id);
            if (analogousProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", analogousProduct.ProductId);
            return View(analogousProduct);
        }

        // POST: AnalogousProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name1,Composition1,Mass1,Name2,Composition2,Mass2,Name3,Composition3,Mass3,Name4,Composition4,Mass4,ProductId")] AnalogousProduct analogousProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(analogousProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", analogousProduct.ProductId);
            return View(analogousProduct);
        }

        // GET: AnalogousProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnalogousProduct analogousProduct = db.AnalogousProducts.Find(id);
            if (analogousProduct == null)
            {
                return HttpNotFound();
            }
            return View(analogousProduct);
        }

        // POST: AnalogousProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnalogousProduct analogousProduct = db.AnalogousProducts.Find(id);
            db.AnalogousProducts.Remove(analogousProduct);
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
