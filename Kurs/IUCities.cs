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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kurs
{
    public partial class IUCities : Form
    {
        readonly BindingSource bs;
        readonly string mission;
        readonly NpgsqlConnection conn;
        public IUCities(BindingSource bs, string mission, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
        }

        private void IUCities_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "id");
                typeBox.DataBindings.Add("Text", bs, "type", true, DataSourceUpdateMode.Never);
                nameBox.DataBindings.Add("Text", bs, "name", true, DataSourceUpdateMode.Never);

                insertBut.Enabled = false; insertBut.Visible = false;
                clearBut.Enabled = false; clearBut.Visible = false;
            }
            else if (mission == "Insert")
            {
                updateBut.Enabled = false; updateBut.Visible = false;
            }
        }

        private void ClearBut_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
            }
        }

        private void ExitBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateBut_Click(object sender, EventArgs e)
        {
            string command = $"UPDATE cities_handbook SET type=@p2, name =@p3 " +
              "where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(typeBox.Text) || String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", typeBox.Text);
                cmd.Parameters.AddWithValue("@p3", nameBox.Text);
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

        private void InsertBut_Click(object sender, EventArgs e)
        {
            string command = $"INSERT INTO cities_handbook (type,name) VALUES (@p2,@p3)";
            try
            {
                if (String.IsNullOrEmpty(typeBox.Text) || String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", typeBox.Text);
                cmd.Parameters.AddWithValue("@p3", nameBox.Text);
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
