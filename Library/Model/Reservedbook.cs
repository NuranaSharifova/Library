using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Reservedbook
    {
        public int Id { get; set; }
        public int Bookid { get; set; }
        public int Customerid { get; set; }
        public int Amount { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
