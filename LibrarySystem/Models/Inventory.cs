using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int BookID{ get; set; }
        public string BookTitle { get; set; }
        public string Price { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}