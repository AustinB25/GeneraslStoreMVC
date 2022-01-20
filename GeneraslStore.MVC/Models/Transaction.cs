using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneraslStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [ForeignKey(nameof(Customer))]
        [Display(Name = "Customer ID ")]
        public int CustomerId { get; set; }
        public  virtual Customer Customer { get; set; }
        [Display(Name = "Products")]    
        public virtual ICollection<Product> ListOfProducts { get; set; } = new List<Product>();
        [Display(Name = "Grand Total")]
        public decimal TotalPrice { get { return GetTotalPrice(ListOfProducts.ToList()); } }
        [Display(Name = "Date of Transaction")]
        public DateTime TransactionDate { get { return DateTime.Now; } }
        private decimal GetTotalPrice(List<Product> products)
        {
            decimal total = 0;
            foreach (var p in products)
            {
                p.Price += total;
            }
            return total;
        }
    }
}