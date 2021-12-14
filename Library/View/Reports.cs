using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.View
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
           
            comboBox1.Items.Add("New Books");
            comboBox1.Items.Add("Best Seller Books");
            comboBox1.Items.Add("Most Popular Authors");
            comboBox1.Items.Add("Most Popular Genres");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "New Books":
                    using (LibraryContext library=new LibraryContext())
                    {
                        var result = library.Books.Select(x => new { x.Name, x.Author.Firstname, x.Author.Lastname, x.PublishingDate }).OrderBy(x => x.PublishingDate).Take(5).ToList();
                        dataGridView1.DataSource = result;
                    }                 
                    break;
                case "Best Seller Books":
                    using (LibraryContext library = new LibraryContext())
                    {
                     
                        var result2 = library.Books.Include(z=>z.Booksales)
                            .Select(x=>new { Name=x.Name,Count=x.Booksales.Count()}).OrderByDescending(x=>x.Count).Where(x=>x.Count!=0).Take(3).ToList();
                        dataGridView1.DataSource = result2;
                    }
                    break;
                case "Most Popular Authors":
                    using (LibraryContext library = new LibraryContext())
                    {

                        var result2 = library.Booksales.Include(x=>x.Book).ThenInclude(z=>z.Author)
                            .Select(x => new { Author=x.Book.Author.Firstname,Count = x.Book.Booksales.Count() }).Distinct().OrderByDescending(x => x.Count).Where(x => x.Count != 0).Take(3).ToList();
                        dataGridView1.DataSource = result2;
                    }
                    break;
                case "Most Popular Genres":
                    using (LibraryContext library = new LibraryContext())
                    {

                        var result2 = library.Booksales.Include(x => x.Book).ThenInclude(z => z.Genre)
                            .Select(x => new { Genre = x.Book.Genre.Name, Count = x.Book.Booksales.Count() }).Distinct().OrderByDescending(x => x.Count).Where(x => x.Count != 0).Take(3).ToList();
                        dataGridView1.DataSource = result2;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
