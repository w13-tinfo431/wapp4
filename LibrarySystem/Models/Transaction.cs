using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Transaction
    {
        [Key]
        public int ReferrenceID { get; set; }
        public DateTime Date { get; set; }
        public int ConsumerID { get; set; }
        public int BookID { get; set; }

        public virtual Consumer Consumer { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}