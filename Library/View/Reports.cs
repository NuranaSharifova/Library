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

                        //var result = library.Booksales.GroupBy<>
                        //dataGridView1.DataSource = result;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
