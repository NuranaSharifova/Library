using Library.Model;
using Library.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form1 : Form
    {
        List<Admin> admins;
        List<Salesman> salesman;
        List<Customer> customer;
        List<Book> books;
        List<Author> authors;
        List<Genre> genres;
        List<Publisher> publishers;
        List<Booksale> booksales;
        public Form1()
        {
            InitializeComponent();

            using (LibraryContext library = new LibraryContext())
            {
                admins = library.Admins.ToList();
                salesman = library.Salesmen.ToList();
                customer = library.Customers.ToList();
                books = library.Books.ToList();
                booksales = library.Booksales.ToList();
                authors = library.Authors.ToList();
                genres = library.Genres.ToList();
                publishers = library.Publishers.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                          
           
            SalerView salerView = new SalerView(books,customer,salesman,booksales,authors,genres);
        
            foreach (var item in salesman)
            {
                if (item.Login == textBox1.Text && item.Password == textBox2.Text)
                {

                    salerView.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Incorrect credentials");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminView adminform = new AdminView(books,authors,genres,publishers);
            foreach (var item in admins)
            {
                if (item.Login == textBox1.Text && item.Password == textBox2.Text)
                {

                    adminform.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Incorrect credentials");
                }

            }
        }

     
    }
}
