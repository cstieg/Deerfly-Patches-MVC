using System;
using System.Collections.Generic;

namespace Deerfly_Patches.Models
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new List<Address>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public DateTime LastVisited { get; set; }
        public int TimesVisited { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }

}
