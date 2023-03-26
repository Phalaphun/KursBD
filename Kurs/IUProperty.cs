using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kurs
{
    public partial class IUProperty : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn;

        public IUProperty(BindingSource bs, string mission, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
        }

        private void IUProperty_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "id");
                nameBox.DataBindings.Add("Text", bs, "name");
                deliveryBox.DataBindings.Add("Text", bs, "delivery_date");
                costPerOneBox.DataBindings.Add("Text", bs, "cost_per_one");
                reDateBox.DataBindings.Add("Text", bs, "reprice_date");
                reCostBox.DataBindings.Add("Text", bs, "cost_after_reprice");
                lifetimeBox.DataBindings.Add("Text", bs, "lifetime");
                amountBox.DataBindings.Add("Text", bs, "amount");
                deprecationBox.DataBindings.Add("Text", bs, "depreciation");
                audBox.DataBindings.Add("Text", bs, "aud_num");
                


                insertBut.Enabled = false; insertBut.Visible = false;
                clearBut.Enabled= false; clearBut.Visible = false;
            }
            else if (mission == "Insert")
            {
                updateBut.Enabled = false; updateBut.Visible = false;

            }
        }

        private void exitBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
            }
        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            string command = $"UPDATE property SET name=@p2, delivery_date =@p3," +
              "cost_per_one =@p4, reprice_date=@p5, cost_after_reprice=@p6, lifetime=@p7, amount=@p8, depreciation=@p9, aud_num=@p10 where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(deliveryBox.Text)
                    || String.IsNullOrEmpty(costPerOneBox.Text) || String.IsNullOrEmpty(lifetimeBox.Text)|| String.IsNullOrEmpty(amountBox.Text)|| 
                    String.IsNullOrEmpty(deprecationBox.Text)|| String.IsNullOrEmpty(audBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                DateTime deliveryDate = DateTime.Parse(deliveryBox.Text);
                int cost_per_one = int.Parse(costPerOneBox.Text);
                DateTime reprice_date = DateTime.Parse(reDateBox.Text);
                int cost_after_one = int.Parse(reCostBox.Text);
                int lifetime = int.Parse(lifetimeBox.Text);
                int amount = int.Parse(amountBox.Text);
                int deprecation = int.Parse(deprecationBox.Text);


                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
                cmd.Parameters.AddWithValue("@p3", deliveryDate);
                cmd.Parameters.AddWithValue("@p4", cost_per_one);
                cmd.Parameters.AddWithValue("@p5", reprice_date);
                cmd.Parameters.AddWithValue("@p6", cost_after_one);
                cmd.Parameters.AddWithValue("@p7", lifetime);
                cmd.Parameters.AddWithValue("@p8", amount);
                cmd.Parameters.AddWithValue("@p9", deprecation);
                cmd.Parameters.AddWithValue("@p10", audBox.Text);
                conn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void insertBut_Click(object sender, EventArgs e)
        {
            string command = $"INSERT INTO property (name,delivery_date,cost_per_one,reprice_date,cost_after_reprice,lifetime,amount,depreciation, aud_num)" +
              "VALUES (@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)";
            try
            {
                if (String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(deliveryBox.Text)
                    || String.IsNullOrEmpty(costPerOneBox.Text) || String.IsNullOrEmpty(lifetimeBox.Text) || String.IsNullOrEmpty(amountBox.Text) ||
                    String.IsNullOrEmpty(deprecationBox.Text) || String.IsNullOrEmpty(audBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                DateTime deliveryDate = DateTime.Parse(deliveryBox.Text);
                int cost_per_one = int.Parse(costPerOneBox.Text);
                DateTime reprice_date = DateTime.Parse(reDateBox.Text);
                int cost_after_one = int.Parse(reCostBox.Text);
                int lifetime = int.Parse(lifetimeBox.Text);
                int amount = int.Parse(amountBox.Text);
                int deprecation = int.Parse(deprecationBox.Text);


                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", audBox.Text);
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
                cmd.Parameters.AddWithValue("@p3", deliveryDate);
                cmd.Parameters.AddWithValue("@p4", cost_per_one);
                cmd.Parameters.AddWithValue("@p5", reprice_date);
                cmd.Parameters.AddWithValue("@p6", cost_after_one);
                cmd.Parameters.AddWithValue("@p7", lifetime);
                cmd.Parameters.AddWithValue("@p8", amount);
                cmd.Parameters.AddWithValue("@p9", deprecation);
                cmd.Parameters.AddWithValue("@p10", audBox.Text);
                conn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
