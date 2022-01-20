using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneraslStore.MVC.Models
{   
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required, Display(Name = "First Name")]
        public string  FirstName { get; set; }
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get { return $"{FirstName } {LastName}"; } }      
        public virtual ICollection<Transaction> ListOfTransactions { get; set; }
        public Customer()
        {
            ListOfTransactions = new List<Transaction>();
        }
    }
}