using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace Library.View
{
    public partial class SalerView : Form
    {
        public List<Book> Book { get; set; }
       public  List<Customer> Customers { get; set; }
        public List<Salesman> Salers { get; set; }
        public List<Booksale> Booksale { get; set; }
        public List<Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
        Booksale bkSale = new Booksale();
        public SalerView(List<Book> book,List<Customer> customers,List<Salesman> salers,List<Booksale> booksale, List<Author> authors,List<Genre> genres)
        {
            InitializeComponent();
            Book = book;
            Customers = customers;
            Salers = salers;
            Booksale = booksale;
            Authors = authors;
            Genres = genres;
            for (int i = 0; i < Book.Count; i++)
            {
                comboBox1.Items.Add(Book[i].Name);
            }
            for (int i = 0; i < Customers.Count; i++)
            {
                comboBox2.Items.Add(Customers[i].Name);
            }
            for (int i = 0; i < Salers.Count; i++)
            {
                comboBox3.Items.Add(Salers[i].Login);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bkSale.Bookid = Book.Where(x => x.Name == comboBox1.SelectedItem.ToString()).Select(x => x.Id).First();
            bkSale.Customerid = Customers.Where(x => x.Name == comboBox2.SelectedItem.ToString()).Select(x => x.Id).First();
            bkSale.Salesmanid = Salers.Where(x => x.Login == comboBox3.SelectedItem.ToString()).Select(x => x.Id).First();
            bkSale.SalesDate =Convert.ToDateTime(textBox1.Text.ToString());
            bkSale.SalesPrice = Convert.ToInt32(textBox2.Text.ToString());
            using (LibraryContext library=new LibraryContext())
            {
                library.Booksales.Add(bkSale);
                library.SaveChanges();
                
            }
            MessageBox.Show("Succesful Opertion");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Name = textBox3.Text.ToString();
            using (LibraryContext library = new LibraryContext())
            {
                library.Customers.Add(customer);
                library.SaveChanges();
            }
            comboBox2.Items.Add(customer.Name);
            MessageBox.Show("Succesful Opertion");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search search = new Search(Book,Authors,Genres);
            search.ShowDialog();
        }
    }
}
