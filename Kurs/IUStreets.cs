﻿using Npgsql;
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
    public partial class IUStreets : Form
    {
        readonly BindingSource bs;
        readonly string mission;
        readonly NpgsqlConnection conn;

        public IUStreets(BindingSource bs, string mission, NpgsqlConnection conn)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
        }

        private void IUStreets_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                idBox.DataBindings.Add("Text", bs, "ID");
                addressAttributeBox.DataBindings.Add("Text", bs, "Тип", true, DataSourceUpdateMode.Never);
                checkBox1.DataBindings.Add("Checked", bs, "Порядок", true, DataSourceUpdateMode.Never);
                nameBox.DataBindings.Add("Text", bs, "Название", true, DataSourceUpdateMode.Never);

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
            string command = $"UPDATE streets_handbook SET address_attribute=@p2, address_order =@p3," +
              "name =@p4 where id =@p1";
            try
            {
                if (String.IsNullOrEmpty(idBox.Text) || String.IsNullOrEmpty(addressAttributeBox.Text) ||  String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", addressAttributeBox.Text);
                cmd.Parameters.AddWithValue("@p3", checkBox1.Checked);
                cmd.Parameters.AddWithValue("@p4", nameBox.Text);
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
            string command = $"INSERT INTO streets_handbook (address_attribute,address_order,name)" +
                $" VALUES (@p2,@p3,@p4)";

            try
            {
                if (String.IsNullOrEmpty(addressAttributeBox.Text) || String.IsNullOrEmpty(nameBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                //cmd.Parameters.AddWithValue("@p1", int.Parse(idBox.Text));
                cmd.Parameters.AddWithValue("@p2", addressAttributeBox.Text);
                cmd.Parameters.AddWithValue("@p3", checkBox1.Checked);
                cmd.Parameters.AddWithValue("@p4", nameBox.Text);
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

        private void AddressAttributeBox_TextChanged(object sender, EventArgs e)
        {
            exampleBox.Text = !checkBox1.Checked ? addressAttributeBox.Text+" "+nameBox.Text : nameBox.Text +" "+ addressAttributeBox.Text;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            exampleBox.Text = !checkBox1.Checked ? addressAttributeBox.Text + " " + nameBox.Text : nameBox.Text + " " + addressAttributeBox.Text;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            exampleBox.Text = !checkBox1.Checked ? addressAttributeBox.Text + " " + nameBox.Text : nameBox.Text + " " + addressAttributeBox.Text;
        }
    }
}
