using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class ItemRepository
    {
        SotreContext context = new SotreContext();
        private SotreContext db = new SotreContext();

        public IEnumerable<StockItem> GetAll_Items()
        {
            //Skall kontakta SortreContext
            return context.Items.ToList();
        }

        public StockItem GetItemById(int id) //Klar
        {
            return context.Items.SingleOrDefault(item => item.ArticleNumber == id);
        }

        public void AddItem(StockItem item)
        {
            //int next = context.Max(b => b.ID) + 1;
            //book.ID = next;
            context.Items.Add(item);
            context.SaveChanges();
        }


        public void Delete(int id)
        {
            StockItem item = context.Items.Find(id);
            context.Items.Remove(item);
            context.SaveChanges(); 
        }


        public void Edit(StockItem item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }


        //Kanske fungerar
        public StockItem Search(string searchString)
        {
            var tempvar = from name in db.Items
                          select name;

            if (!String.IsNullOrEmpty(searchString))
            {
                tempvar = tempvar.Where(s => s.Name.Contains(searchString));
            }
            return context.Items.SingleOrDefault(item => item.Name == searchString);
        }

    }
}