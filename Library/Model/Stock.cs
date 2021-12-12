using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Stock
    {
        public Stock()
        {
            Booksinstocks = new HashSet<Booksinstock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booksinstock> Booksinstocks { get; set; }
    }
}
