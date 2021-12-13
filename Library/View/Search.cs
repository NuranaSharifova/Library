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
  
    public partial class Search : Form
    {
        public List<Book> Books { get; set; }
        public List <Author> Authors { get; set; }
        public List<Genre> Genres { get; set; }
      
        public Search(List<Book> books, List<Author> authors, List<Genre> genres)
        {

            InitializeComponent();
            Books = books;
            Authors = authors;
            Genres = genres;
            comboBox1.Items.Add("According to Book Name");
            comboBox1.Items.Add("According to Author");
            comboBox1.Items.Add("According to Genre");
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "According to Book Name":
                    comboBox2.Items.Clear();
                    for (int i = 0; i < Books.Count; i++)
                    {
                        comboBox2.Items.Add(Books[i].Name);
                    }
                    break;
                case "According to Author":
                    comboBox2.Items.Clear();
                    for (int i = 0; i < Authors.Count; i++)
                    {
                        comboBox2.Items.Add(Authors[i].Firstname + " " + Authors[i].Lastname);
                    }
                    break;
                case "According to Genre":
                    comboBox2.Items.Clear();
                    for (int i = 0; i < Genres.Count; i++)
                    {
                        comboBox2.Items.Add(Genres[i].Name);
                    }
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "According to Book Name":
                    using (LibraryContext library = new LibraryContext())
                    {
                        var result = library.Books.Select(x => new { x.Name, x.Author.Firstname, x.Author.Lastname }).Where(x => x.Name == comboBox2.SelectedItem.ToString()).ToList();
                        dataGridView1.DataSource = result;
                    }
                    break;
                case "According to Author":
                    using (LibraryContext library = new LibraryContext())
                    {
                        var result = library.Books.Select(x => new { x.Name, x.Author.Firstname, x.Author.Lastname }).Where(x => x.Firstname+" "+x.Lastname  == comboBox2.SelectedItem.ToString()).ToList();
                        dataGridView1.DataSource = result;
                    }
                    break;
                case "According to Genre":
                    using (LibraryContext library = new LibraryContext())
                    {
                        var result = library.Books.Select(x => new { x.Name, x.Author.Firstname, x.Author.Lastname,x.Genre }).Where(x => x.Genre.Name== comboBox2.SelectedItem.ToString()).ToList();
                        dataGridView1.DataSource = result;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
