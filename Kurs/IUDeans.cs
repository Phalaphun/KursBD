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
    public partial class IUDeans : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn;
        public IUDeans(BindingSource bs, string mission, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            string command = $"UPDATE deans_handbook SET name =@p2 " +
              "where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
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
            string command = $"INSERT INTO deans_handbook (name) VALUES (@p2)";
            try
            {
                if (String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
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

        private void IUDeans_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "id");
                nameBox.DataBindings.Add("Text", bs, "name", true, DataSourceUpdateMode.Never);

                insertBut.Enabled = false; insertBut.Visible = false;
                clearBut.Enabled = false; clearBut.Visible = false;
            }
            else if (mission == "Insert")
            {
                updateBut.Enabled = false; updateBut.Visible = false;
            }
        }
    }
}
