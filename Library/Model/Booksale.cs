using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Booksale
    {
        public int Id { get; set; }
        public int Bookid { get; set; }
        public int Customerid { get; set; }
        public int Salesmanid { get; set; }
        public DateTime SalesDate { get; set; }
        public decimal SalesPrice { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Salesman Salesman { get; set; }
    }
}
