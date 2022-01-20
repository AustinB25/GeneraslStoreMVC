using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneraslStore.MVC.Models
{
    public class TransactionViewModel
    {     
        [Key]
        public int TransactionViewID { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<Product> Products { get; set; }       
        
    }
}