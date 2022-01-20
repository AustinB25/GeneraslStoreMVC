using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneraslStore.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "# in stock")]
        public int InventoryOnHand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "It is food")]
        public bool IsFood { get; set; }        
        public virtual Transaction Transaction { get; set; }
    }
}