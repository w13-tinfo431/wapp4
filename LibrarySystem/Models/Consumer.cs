using System;
using System.Collections.Generic;

namespace LibrarySystem.Models
{
    public class Consumer
    {
        public int ConsumerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Secret { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}