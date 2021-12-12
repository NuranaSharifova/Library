using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Booksales = new HashSet<Booksale>();
            Reservedbooks = new HashSet<Reservedbook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booksale> Booksales { get; set; }
        public virtual ICollection<Reservedbook> Reservedbooks { get; set; }
    }
}
