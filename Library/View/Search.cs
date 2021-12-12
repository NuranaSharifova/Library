using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            for (int i = 0; i < Books.Count; i++)
            {
                comboBox1.Items.Add(Books[i].Name);
            }
            for (int i = 0; i < Authors.Count; i++)
            {
                comboBox2.Items.Add(Authors[i].Firstname+" "+Authors[i].Lastname);
            }
            for (int i = 0; i < Genres.Count; i++)
            {
                comboBox3.Items.Add(Genres[i].Name);
            }
        }
    }
}
