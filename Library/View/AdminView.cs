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
    public partial class AdminView : Form
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Publisher> Publishers { get; set; }
        Book book=new Book();
        public AdminView(List<Book> books,List<Author> authors, List<Genre> genres,List<Publisher> publishers)
        {
            InitializeComponent();        
            Books = books;
            Authors = authors;
            Genres = genres;
            Publishers = publishers;
            dataGridView1.DataSource = Books;
            for (int i = 0; i < Authors.Count; i++)
            {
                comboBox1.Items.Add(Authors[i].Firstname+" "+Authors[i].Lastname);              
            }
            for (int i = 0; i < Genres.Count; i++)
            {
                comboBox2.Items.Add(Genres[i].Name);
            }
            for (int i = 0; i <Publishers.Count; i++)
            {
                comboBox3.Items.Add(Publishers[i].Name);
            }
            comboBox4.Items.Add("Yes");
            comboBox4.Items.Add("No");
            button3.Enabled = false;
        }
         private void button1_Click(object sender, EventArgs e)
        {
            book.Name = textBox1.Text.ToString();
            book.Authorid = Authors[comboBox1.SelectedIndex].Id;
            book.Genreid = Genres[comboBox2.SelectedIndex].Id;
            book.Publisherid = Publishers[comboBox3.SelectedIndex].Id;
            book.Pages = Convert.ToInt32(textBox3.Text.ToString());
            book.PublishingDate= Convert.ToInt32(textBox2.Text.ToString());
            book.CostPrice = Convert.ToInt32(textBox4.Text.ToString());
            book.SalesPrice = Convert.ToInt32(textBox5.Text.ToString());
            book.Quantity = Convert.ToInt32(textBox6.Text.ToString());
            Books.Add(book);
            using (LibraryContext library=new LibraryContext())
            {
                if (book.Id == 0)
                {
                    library.Books.Add(book);
                  
                }
                else
                {
                    library.Entry(book).State = EntityState.Modified;
                }
                library.SaveChanges();
                MessageBox.Show("Succesful operation");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record?", "Warning", MessageBoxButtons.YesNo )== DialogResult.Yes)
            {
                using (LibraryContext library = new LibraryContext())
                {
                    var entry = library.Entry(book);
                    if (entry.State == EntityState.Detached) {
                        library.Books.Attach(book);
                        library.Books.Remove(book);
                        library.SaveChanges();
                        MessageBox.Show("Succesful operation");
                    }
                }
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                book.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);

                using (LibraryContext library = new LibraryContext())
                {
                    book = library.Books.Where(x => x.Id == book.Id).FirstOrDefault();
                    textBox1.Text = book.Name;
                    comboBox1.Text = Authors[book.Authorid-1].Firstname+ " "+Authors[book.Authorid-1].Lastname;
                    comboBox2.Text = Genres[book.Genreid-1].Name;
                    comboBox3.Text = Publishers[book.Publisherid-1].Name;
                    textBox3.Text = book.Pages.ToString();
                    textBox2.Text = book.PublishingDate.ToString();
                    textBox4.Text = book.CostPrice.ToString();
                    textBox5.Text = book.SalesPrice.ToString();
                    textBox6.Text = book.Quantity.ToString();

                }
                button3.Enabled = true;
            }
        }

   
    }

}     
  
