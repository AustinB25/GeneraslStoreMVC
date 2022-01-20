using GeneraslStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneraslStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> tList = _ctx.Transactions.ToList();
            List<Transaction> orderedTList = tList.OrderBy(t => t.TransactionId).ToList();
            return View(orderedTList);
        }
        //Get Transaction/Create
        public ActionResult Create()
        {
           // var products = _ctx.Products.ToList();
            ViewBag.ProductId = new SelectList(_ctx.Products, "ProductId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Post: Customer/Create
        public ActionResult Create(TransactionViewModel transactionmodel)
        {            
            if (ModelState.IsValid)
            {
                var transaction = new Transaction();
                var customer = _ctx.Customers.Find(transactionmodel.CustomerId);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                transaction.Customer = customer;
                foreach (var p in transactionmodel.Products)
                {
                    transaction.ListOfProducts.Add(p);
                }
                _ctx.Transactions.Add(transaction);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionmodel);
        }
        //Get: Transaction/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var transaction = _ctx.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }
        //Post; Transaction/Delete/{id}
        public ActionResult Delete(int id)
        {
            var transaction = _ctx.Transactions.Find(id);
            _ctx.Transactions.Remove(transaction);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        private IEnumerable<SelectListItem> GetProductListItems(IEnumerable<Product> elements)        {
            var roleList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                roleList.Add(new SelectListItem
                {
                    Value = element.Name ,
                    Text = element.Name
                });
            }
            return roleList;
        }    
    private List<Product> GetAllProducts()
        {
            var productList =  _ctx.Products.ToList();
            if(productList != null)
            {
                return productList;
            }
            return null;
        }        
    }
}