using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoanSystem.Domain.Abstract;
using LoanSystem.Domain.Concrete;
using LoanSystem.Domain.Entities;
using LoanSystem.WebUI.Models;
using Microsoft.Ajax.Utilities;

namespace LoanSystem.WebUI.Controllers
{
    public class PriceController : Controller
    {
        private EFDbContext db = new EFDbContext();
        private IPriceRepository repository;

        public PriceController(IPriceRepository repo)
        {
            this.repository = repo;
        }

        // GET: Price
        public ActionResult Index()
        {
            var viewModel = new PriceListViewModel();
            viewModel.Prices = repository.Prices
                .Include(p => p.Products)
                .OrderBy(p => p.Products.Name);
            
            return View(viewModel);
        }

        // GET: Price/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Price/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(repository.Products, "ProductID", "Name");
            return View();
        }

        // POST: Price/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceID,Date_From,ProductID,Product_Price,Default_Price")] Price price)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Prices.Add(price);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException dex)
            {

                ModelState.AddModelError("", dex.Message);
            }
           

            ViewBag.ProductID = new SelectList(repository.Products, "ProductID", "Name");
            return View(price);
        }

        // GET: Price/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProductID = new SelectList(repository.Products, "ProductID", "Name");
            return View(price);
        }

        // POST: Price/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? PriceID)
        {
            if (PriceID == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Price priceToUpdate = repository.Prices.FirstOrDefault(p => p.PriceID == PriceID);
            if (priceToUpdate == null)
            {
                return HttpNotFound();
            }
            try
            {
                if (TryUpdateModel(priceToUpdate,"", 
                    new string[] {"Date_From","ProductID","Product_Price","Default_Price" }))
                {
                    repository.SavePrice(priceToUpdate);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException dex)
            {
                ModelState.AddModelError("", dex);
                TempData["message"] = "Unable to save changes. Try again, and if the problem persists, see your system administrator";
            }


            ViewBag.ProductID = new SelectList(repository.Products, "ProductID", "Name");
            return View(priceToUpdate);
        }

        // GET: Price/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // POST: Price/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Price price = db.Prices.Find(id);
            db.Prices.Remove(price);
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
