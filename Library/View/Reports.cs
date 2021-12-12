using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        }
    }
}
