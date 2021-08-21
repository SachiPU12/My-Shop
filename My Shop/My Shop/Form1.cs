using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace My_Shop
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void storeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.storeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Database1"].ToString();
            con.Open();

            for (int i = 0; i < storeDataGridView.Rows.Count - 1; i++)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Store (item_No,item_Name,item_Price) VALUES (@item_NoTextBox,@item_NameTextBox,@item_PriceTextBox)", con);

                cmd.Parameters.AddWithValue("@item_NoTextBox", storeDataGridView.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@item_NameTextBox", storeDataGridView.Rows[i].Cells[1].Value);
                cmd.Parameters.AddWithValue("@item_PriceTextBox", storeDataGridView.Rows[i].Cells[2].Value);
                cmd.ExecuteNonQuery();
            }
            storeDataGridView.Rows.Clear();
        }
    }
}
