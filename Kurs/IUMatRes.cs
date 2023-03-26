using Npgsql;
using NpgsqlTypes;
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
    public partial class IUMatRes : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn; List<Dictionary<string, int>> dictionaries;
        List<string>[] keys;
        public IUMatRes(BindingSource bs, string mission, NpgsqlConnection conn, List<Dictionary<string, int>> dictionaries, List<string>[] keys)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.keys = keys;
        }

        private void IUMatRes_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "id");
                yearBox.DataBindings.Add("Text", bs, "start_year");
                secondNameBox.DataBindings.Add("Text", bs, "second_name");
                firstNameBox.DataBindings.Add("Text", bs, "first_name");
                fathersNameBox.DataBindings.Add("Text", bs, "fathers_name");
                houseNumBox.DataBindings.Add("Text", bs, "num_of_house");
                flatNumBox.DataBindings.Add("Text", bs, "num_of_flat");
                addressBox.DataBindings.Add("Text", bs, "address");
                cityBox.DataBindings.Add("Text", bs, "city");

                insertBut.Enabled = false; insertBut.Visible = false;
                clearBut.Enabled = false; clearBut.Visible = false;
            }
            else if (mission == "Insert")
            {
                updateBut.Enabled = false; updateBut.Visible = false;
            }
            PrepairingComboboxes();
        }

        private void PrepairingComboboxes()
        {
            comboBox1.Items.AddRange(keys[0].ToArray());
            comboBox2.Items.AddRange(keys[1].ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressBox.Text= (dictionaries[0][comboBox1.Text]).ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cityBox.Text = dictionaries[1][comboBox2.Text].ToString();
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
            string command = $"UPDATE materially_responsible SET start_year=@p2, second_name =@p3," +
              "first_name =@p4, fathers_name=@p5, num_of_house=@p6, num_of_flat=@p7, address=@p8, city=@p9 where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(firstNameBox.Text) || String.IsNullOrEmpty(secondNameBox.Text)|| String.IsNullOrEmpty(yearBox.Text)
                    || String.IsNullOrEmpty(houseNumBox.Text) || String.IsNullOrEmpty(addressBox.Text) || String.IsNullOrEmpty(cityBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int year = int.Parse(yearBox.Text);
                int house = int.Parse(houseNumBox.Text);

                int? flat;
                if (flatNumBox.Text == "" || flatNumBox.Text == " ")
                {
                    flat = null;
                }
                else
                {
                    flat = int.Parse(flatNumBox.Text);
                }
                int address = int.Parse(addressBox.Text);
                int city = int.Parse(cityBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", year);
                cmd.Parameters.AddWithValue("@p3", secondNameBox.Text);
                
                cmd.Parameters.AddWithValue("@p4", firstNameBox.Text);
                if (fathersNameBox.Text == "" || fathersNameBox.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p5", NpgsqlDbType.Varchar));
                    cmd.Parameters[4].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                }
                //cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                cmd.Parameters.AddWithValue("@p6", house);

                //cmd.Parameters.AddWithValue("@p7", flatNumBox.Text == "" ? null : flat); // null
                if (flat==null)
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p7", NpgsqlDbType.Integer));
                    cmd.Parameters[6].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p7", fathersNameBox.Text);
                }
                cmd.Parameters.AddWithValue("@p8", address);
                cmd.Parameters.AddWithValue("@p9", city);
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
            string command = $"INSERT INTO materially_responsible (start_year,second_name,first_name,fathers_name,num_of_house,num_of_flat,address,city)" +
              "VALUES (@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            try
            {
                if (String.IsNullOrEmpty(firstNameBox.Text) || String.IsNullOrEmpty(secondNameBox.Text) || String.IsNullOrEmpty(yearBox.Text)
                    || String.IsNullOrEmpty(houseNumBox.Text) || String.IsNullOrEmpty(addressBox.Text) || String.IsNullOrEmpty(cityBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int year = int.Parse(yearBox.Text);
                int house = int.Parse(houseNumBox.Text);
                int? flat;
                if (flatNumBox.Text == "" || flatNumBox.Text == " ")
                {
                    flat = null;
                }
                else
                {
                    flat = int.Parse(flatNumBox.Text);
                }
                int address = int.Parse(addressBox.Text);
                int city = int.Parse(cityBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", year);
                cmd.Parameters.AddWithValue("@p3", secondNameBox.Text);
                cmd.Parameters.AddWithValue("@p4", firstNameBox.Text);
                //cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                if (fathersNameBox.Text == "" || fathersNameBox.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p5", NpgsqlDbType.Varchar));
                    cmd.Parameters[3].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                }
                cmd.Parameters.AddWithValue("@p6", house);
                //cmd.Parameters.AddWithValue("@p7", flatNumBox.Text == "" ? null : flat); // null
                if (flat == null)
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p7", NpgsqlDbType.Integer));
                    cmd.Parameters[5].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p7", fathersNameBox.Text);
                }
                cmd.Parameters.AddWithValue("@p8", address);
                cmd.Parameters.AddWithValue("@p9", city);
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
