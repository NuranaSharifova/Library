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
    public partial class Registration : Form
    {
        public List<Salesman> Salers { get; set; }
        Salesman salesman = new Salesman();
        public Registration(List<Salesman> salers)
        {
            InitializeComponent();
            Salers = salers;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (LibraryContext library=new LibraryContext())
            {
                salesman.Login = textBox1.Text.ToString();
                salesman.Password = textBox2.Text.ToString();
                library.Salesmen.Add(salesman);
                library.SaveChanges();
            }
            this.Close();
        }
    }
}
