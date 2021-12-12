using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Book
    {
        public Book()
        {
            Booksales = new HashSet<Booksale>();
            Booksinstocks = new HashSet<Booksinstock>();
            Reservedbooks = new HashSet<Reservedbook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Authorid { get; set; }
        public int Genreid { get; set; }
        public int Publisherid { get; set; }
        public int Pages { get; set; }
        public int PublishingDate { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public bool? Continued { get; set; }
        public int? Quantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Booksale> Booksales { get; set; }
        public virtual ICollection<Booksinstock> Booksinstocks { get; set; }
        public virtual ICollection<Reservedbook> Reservedbooks { get; set; }
    }
}
