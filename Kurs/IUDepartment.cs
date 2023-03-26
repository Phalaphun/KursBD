using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class IUDepartment : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn; List<Dictionary<string, int>> dictionaries;
        List<string>[] keys;
        public IUDepartment(BindingSource bs, string mission, NpgsqlConnection conn, List<Dictionary<string, int>> dictionaries, List<string>[] keys)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.keys = keys;
        }

        private void updateBut_Clicking(object sender, EventArgs e) //update
        {
            string command = $"UPDATE department SET name=@p2, second_name =@p3," +
              "first_name =@p4, fathers_name=@p5, deans=@p6, phone=@p7 where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(secondNameBox.Text)
                    || String.IsNullOrEmpty(firstNameBox.Text) || String.IsNullOrEmpty(deanBox.Text) || String.IsNullOrEmpty(telBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int dean = int.Parse(deanBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
                cmd.Parameters.AddWithValue("@p3", secondNameBox.Text);
                cmd.Parameters.AddWithValue("@p4", firstNameBox.Text);
                cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                cmd.Parameters.AddWithValue("@p6", dean);
                cmd.Parameters.AddWithValue("@p7", telBox.Text);
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

        private void IUDepartment_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "id");
                nameBox.DataBindings.Add("Text", bs, "name");
                secondNameBox.DataBindings.Add("Text", bs, "second_name");
                firstNameBox.DataBindings.Add("Text", bs, "first_name");
                fathersNameBox.DataBindings.Add("Text", bs, "fathers_name");
                deanBox.DataBindings.Add("Text", bs, "deans");
                telBox.DataBindings.Add("Text", bs, "phone");

                insertBut.Enabled = false; insertBut.Visible = false;
                clearBut.Enabled = false; clearBut.Visible = false;
            }
            else if (mission == "Insert")
            {
                updateBut.Enabled = false; updateBut.Visible = false;
            }
            PrepairingComboboxes();
        }

        private void insertBut_Click(object sender, EventArgs e)
        {
            string command = $"INSERT INTO department (name,second_name,first_name,fathers_name,deans,phone)" +
              "VALUES (@p2,@p3,@p4,@p5,@p6,@p7)";
            try
            {
                if (String.IsNullOrEmpty(nameBox.Text) || String.IsNullOrEmpty(secondNameBox.Text)
                    || String.IsNullOrEmpty(firstNameBox.Text) || String.IsNullOrEmpty(deanBox.Text) || String.IsNullOrEmpty(telBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int dean = int.Parse(deanBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", nameBox.Text);
                cmd.Parameters.AddWithValue("@p3", secondNameBox.Text);
                cmd.Parameters.AddWithValue("@p4", firstNameBox.Text);
                cmd.Parameters.AddWithValue("@p5", fathersNameBox.Text);
                cmd.Parameters.AddWithValue("@p6", dean);
                cmd.Parameters.AddWithValue("@p7", telBox.Text);
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

        private void exitBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PrepairingComboboxes()
        {
            comboBox1.Items.AddRange(keys[2].ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            deanBox.Text = (dictionaries[2][comboBox1.Text]).ToString();
        }
    }
}
