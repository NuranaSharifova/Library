using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Booksinstock
    {
        public int Id { get; set; }
        public int Stockid { get; set; }
        public int Bookid { get; set; }
        public int Stockpercent { get; set; }

        public virtual Book Book { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
