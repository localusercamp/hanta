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
    public class DrugstoreController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Drugstore
        public ActionResult Index()
        {
            var drugstores = db.Drugstores.Include(d => d.City);
            return View(drugstores.ToList());
        }

        // GET: Drugstore/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugstore drugstore = db.Drugstores.Find(id);
            if (drugstore == null)
            {
                return HttpNotFound();
            }
            return View(drugstore);
        }

        // GET: Drugstore/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Citys, "Id", "Name");
            return View();
        }

        // POST: Drugstore/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,OpeningTime,ClosingTime,PhoneNumber,DopInform,CityId")] Drugstore drugstore)
        {
            if (ModelState.IsValid)
            {
                db.Drugstores.Add(drugstore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", drugstore.CityId);
            return View(drugstore);
        }

        // GET: Drugstore/Edit/5
        /*public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugstore drugstore = db.Drugstores.Find(id);
            if (drugstore == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Citys, "Id", "Name", drugstore.CityId);
            return View(drugstore);
        }
        */
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var drugstoreViewModel = new DrugstoreViewModel
            {
                Drugstore = db.Drugstores.Include(i => i.Products).First(i => i.Id == id),
            };
            if (drugstoreViewModel.Drugstore == null)
                return HttpNotFound();
            var drugstoreProduct = db.Products.ToList();

            drugstoreViewModel.DrugstoresProducts = drugstoreProduct.Select(o => new SelectListItem
            {
                Text = o.Name,
                Value = o.Id.ToString()
            });
            Drugstore drugstore = db.Drugstores.Find(id);
            if (drugstore == null)
            {
                return HttpNotFound();
            }
            drugstoreViewModel.ListItems = db.Citys.ToList().ConvertAll(
                a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                        Selected = false
                    };
                });
            return View(drugstoreViewModel);
        }


        // POST: Drugstore/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DrugstoreViewModel drugstoreViewModel)
        {
            drugstoreViewModel.ListItems = db.Citys.ToList().ConvertAll(
                a =>
                {
                    return new SelectListItem()
                    {
                        Text = a.Name,
                        Value = a.Id.ToString(),
                        Selected = false
                    };
                });
            var item = db.Entry<Drugstore>(drugstoreViewModel.Drugstore);
            item.State = EntityState.Modified;
            item.Collection(i => i.Products).Load();
            drugstoreViewModel.Drugstore.Products.Clear();

            foreach (var id in drugstoreViewModel._selectedDrugstoreProduct)
            {
                drugstoreViewModel.Drugstore.Products.Add(db.Products.First(i => i.Id == id));
            }

            if (ModelState.IsValid)
            {
                db.Entry(drugstoreViewModel.Drugstore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(drugstoreViewModel);
        }

        // GET: Drugstore/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drugstore drugstore = db.Drugstores.Find(id);
            if (drugstore == null)
            {
                return HttpNotFound();
            }
            return View(drugstore);
        }

        // POST: Drugstore/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drugstore drugstore = db.Drugstores.Find(id);
            db.Drugstores.Remove(drugstore);
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
