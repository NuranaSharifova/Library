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
            dataGridView1.DataSource = Books.Select(x=>new {x.Id,x.Name,x.Authorid,x.Genreid,x.Publisherid,x.Pages,x.PublishingDate,x.CostPrice,x.SalesPrice,x.Continued,x.Quantity}).ToList();
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
            bool check = false; 
            book.Name = textBox1.Text.ToString();

            foreach (var item in Authors)
            {
                if (comboBox1.Text.ToString() == item.Firstname + " " + item.Lastname) {
                    check = true;
                }
            }
            if (check) {
                book.Authorid = Authors.Where(x => (x.Firstname + " " + x.Lastname) == comboBox1.SelectedItem.ToString()).Select(x => x.Id).First();
                check = false;
            }
            else {
                InsertAuthor();
                book.Authorid = Authors.Where(x => (x.Firstname + " " + x.Lastname) == comboBox1.Text.ToString()).Select(x => x.Id).First();
            }
            foreach (var item in Genres)
            {
                if (comboBox2.Text.ToString() == item.Name.ToString()) {
                    check = true;
                }
            }
            if (check)
            {
                book.Genreid = Genres.Where(x => x.Name == comboBox2.SelectedItem.ToString()).Select(x => x.Id).First();
                check = false;
            }
            else {
                InsertGenre();
                book.Genreid = Genres.Where(x => x.Name == comboBox2.Text.ToString()).Select(x => x.Id).First();
            }
            foreach (var item in Publishers)
            {
                if (comboBox3.Text.ToString() == item.Name) { check = true; }
            }
            if (check)
            {
                book.Publisherid = Publishers.Where(x => x.Name == comboBox3.SelectedItem.ToString()).Select(x => x.Id).First();
                check = false;
            }
            else {
                InsertPublisher();
                book.Publisherid = Publishers.Where(x => x.Name == comboBox3.Text.ToString()).Select(x => x.Id).First();
            }
            book.Pages = Convert.ToInt32(textBox3.Text.ToString());
            book.PublishingDate = Convert.ToInt32(textBox2.Text.ToString());
            book.CostPrice = Convert.ToInt32(textBox4.Text.ToString().Split(".")[0]);
            book.SalesPrice = Convert.ToInt32(textBox5.Text.ToString().Split(".")[0]);
            if (comboBox4.Text.ToString() == "Yes") book.Continued = true;
            else book.Continued = false;
            book.Quantity = Convert.ToInt32(textBox6.Text.ToString());
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
                    comboBox1.Text = Authors.Where(x => x.Id == book.Authorid).Select(x=>x.Firstname+" "+x.Lastname).First().ToString();                   
                    comboBox2.Text = Genres.Where(x => x.Id == book.Genreid).Select(x => x.Name).First().ToString();              
                    comboBox3.Text = Publishers.Where(x => x.Id == book.Publisherid).Select(x => x.Name).First().ToString();                
                    textBox3.Text = book.Pages.ToString();
                    textBox2.Text = book.PublishingDate.ToString();
                    textBox4.Text = book.CostPrice.ToString();
                    textBox5.Text = book.SalesPrice.ToString();
                    textBox6.Text = book.Quantity.ToString();

                }
                button3.Enabled = true; 
            }
        }
        private void InsertAuthor() {
            Author author = new Author();
            
          
            string[] name= comboBox1.Text.ToString().Split(" ");
            author.Firstname = name[0];
            author.Lastname = name[1];
          
          
            using (LibraryContext library=new LibraryContext())
            {
                library.Authors.Add(author);
                library.SaveChanges();
                Authors = library.Authors.ToList();
            }
      
        }
        private void InsertGenre()
        {
            Genre genre = new Genre();
            genre.Name = comboBox2.Text.ToString();
            using (LibraryContext library = new LibraryContext())
            {
               
                library.Genres.Add(genre);           
                library.SaveChanges();            
                Genres = library.Genres.ToList();
    
            }

        }
        private void InsertPublisher() {
            Publisher publisher = new Publisher();
            publisher.Name = comboBox3.Text.ToString();
            using (LibraryContext library = new LibraryContext())
            {
              
                library.Publishers.Add(publisher);
                library.SaveChanges();
                Publishers = library.Publishers.ToList();
            }

        }
    }

}     
  
