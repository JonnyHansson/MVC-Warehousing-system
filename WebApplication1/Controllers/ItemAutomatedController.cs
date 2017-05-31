using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Repository;


namespace WebApplication1.Controllers
{
    public class ItemAutomatedController : Controller
    {
        private SotreContext db = new SotreContext(); //Original
        ItemRepository repo = new ItemRepository();

        #region Klara
        [HttpGet]
        public ActionResult Index()
        {
            return View(repo.GetAll_Items());
        }

        public ActionResult Details(int id) //DETAILS
        {
            return View(repo.GetItemById(id));
        }

        [HttpGet] //CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StockItem b)
        {
            repo.AddItem(b);
            return RedirectToAction("Index");
        }


        [HttpGet] //Delete
        public ActionResult Delete(int id)
        {
            return View(repo.GetItemById(id));
        }

        //[HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet] //Edit
        public ActionResult Edit(int id)
        {
            return View(repo.GetItemById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticleNumber,Name,Price,ShelfPosition,Quantity,Description")] StockItem item)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(item);
                //db.Entry(item).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }
        #endregion



        //SEARCH

        ////[HttpGet]
        //public ActionResult SearchName(string SearchString)
        //{
        //    StockItem item =  repo.Search(SearchString);
        //    return View(item);
        //}


        //[HttpGet] Fungerar
        public ActionResult SearchName(string SearchString)
        {
            var tempvar = from name in db.Items
                          select name;

            if (!String.IsNullOrEmpty(SearchString))
            {
                tempvar = tempvar.Where(s => s.Name.Contains(SearchString));
            }
            return View(tempvar);
        }


       //Multiple Search
        public ActionResult SearchMultiple(string namePrice, string SearchString)
        {
            var namePriceLst = new List<string>();

            var namePriceQry = from d in db.Items
                           orderby d.Name
                           select d.Name;

            namePriceLst.AddRange(namePriceQry.Distinct());
            ViewBag.namePrice = new SelectList(namePriceLst);

            var itemsvar = from m in db.Items
                         select m;

            if (!String.IsNullOrEmpty(SearchString))
            {
                itemsvar = itemsvar.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(namePrice))
            {
                itemsvar = itemsvar.Where(x => x.Name == namePrice);
            }

            return View(itemsvar);
        }

    }
}

