using System;
using System.Collections.Generic;

#nullable disable

namespace Library.Model
{
    public partial class Salesman
    {
        public Salesman()
        {
            Booksales = new HashSet<Booksale>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booksale> Booksales { get; set; }
    }
}
