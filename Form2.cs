using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace inv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-GH01B6HU\\SQLEXPRESS;Initial Catalog=InventoryManagement;Integrated Security=True;");

        public void VerileriGoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Insert into Inventory(ProductId,TotalEntry, TotalExit, Type,EntryDate, ExitDate) values ( @ProductId,@TotalEntry,@TotalExit,@Type,@EntryDate,@ExitDate)",baglanti);
            komut.Parameters.AddWithValue("@ProductId", txtId.Text);
            komut.Parameters.AddWithValue("@Type", txtType.Text);
            komut.Parameters.AddWithValue("@TotalEntry", txtTotalEntry.Text);
            komut.Parameters.AddWithValue("@TotalExit", txtTotalExit.Text);
            komut.Parameters.AddWithValue("@EntryDate.", datetimeEntryDate.Value);
            komut.Parameters.AddWithValue("@ExitDate", datetimeExitDate.Value);
            komut.ExecuteNonQuery();
            VerileriGoster("Select*from Inventory");
            baglanti.Close();

            txtId.Clear();
            txtType.Clear();
            txtTotalEntry.Clear();
            txtTotalExit.Clear();

            txtId.Focus();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
