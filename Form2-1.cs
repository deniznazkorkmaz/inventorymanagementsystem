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


namespace Form2
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into Inventory(ProductId,TotalEntry, TotalExit, Type,EntryDate, ExitDate,  UserId, StorageId) values ( @ProductId,@TotalEntry,@TotalExit,@Type,@EntryDate,@ExitDate,@UserId,@StorageId)", baglanti);
            komut.Parameters.AddWithValue("@ProductId", txtId.Text);
            komut.Parameters.AddWithValue("@Type", txtType.Text);
            komut.Parameters.AddWithValue("@TotalEntry", txtTotalEntry.Text);
            komut.Parameters.AddWithValue("@TotalExit", txtTotalExit.Text);
            komut.Parameters.AddWithValue("@EntryDate", datetimeEntryDate.Value);
            komut.Parameters.AddWithValue("@ExitDate", datetimeExitDate.Value);
            komut.Parameters.AddWithValue("@UserId", txtUserId.Text);
            komut.Parameters.AddWithValue("@StorageId", txtStorageId.Text);

            komut.ExecuteNonQuery();
            VerileriGoster("Select*from Inventory");
            baglanti.Close();

            txtId.Clear();
            txtType.Clear();
            txtTotalEntry.Clear();
            txtTotalExit.Clear();

            txtId.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Inventory where ProductId=@ProductId", baglanti);
            komut.Parameters.AddWithValue("@ProductId", txtId2.Text);
            komut.ExecuteNonQuery();
            VerileriGoster("select * from Inventory");
            baglanti.Close();
        }
    }
}







