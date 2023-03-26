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
    public partial class IUAud : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn;
        List<Dictionary<string, int>> dictionaries;
        DataSet ds = new DataSet();
        Dictionary<string, string> buildDic;
        public IUAud(BindingSource bs, string mission, NpgsqlConnection conn, List<Dictionary<string, int>> dictionaries, DataSet d, Dictionary<string,string> b)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.buildDic = b;
            this.ds = d;
        }

        private void IUAud_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                AudBox.DataBindings.Add("Text", bs, "aud_num");
                SquareBox.DataBindings.Add("Text", bs, "square");
                WinBox.DataBindings.Add("Text", bs, "windows_nums");
                BatteryBox.DataBindings.Add("Text", bs, "battery_nums");
                typeBox.DataBindings.Add("Text", bs, "type");
                buildBox.DataBindings.Add("Text", bs, "name_of_building");
                matResBox.DataBindings.Add("Text", bs, "materially_responsible");
                depBox.DataBindings.Add("Text", bs, "department");



                button1.Enabled = false; button1.Visible = false;
                button3.Enabled = false; button3.Visible = false;
            }
            else if (mission == "Insert")
            {
                button2.Enabled = false; button2.Visible = false;

            }
            PrepairComboboxex();
        }

        private void PrepairComboboxex()
        {
            int count = ds.Tables["buildings"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                comboBox1.Items.Add(ds.Tables["buildings"].Rows[i].ItemArray[1]);
            }

            count = ds.Tables["materially_responsible"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                comboBox2.Items.Add((string)ds.Tables["materially_responsible"].Rows[i].ItemArray[2] + " " + (string)ds.Tables["materially_responsible"].Rows[i].ItemArray[3] + " " + (string)ds.Tables["materially_responsible"].Rows[i].ItemArray[4]);
            }

            count = ds.Tables["department"].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                comboBox3.Items.Add((string)ds.Tables["department"].Rows[i].ItemArray[1]);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            buildBox.Text= (buildDic[comboBox1.Text]).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            matResBox.Text = (dictionaries[3][comboBox2.Text]).ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            depBox.Text = (dictionaries[4][comboBox3.Text]).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string command = $"UPDATE audiences SET square=@p2, windows_nums =@p3," +
               "battery_nums =@p4, type=@p5, name_of_building=@p6, materially_responsible=@p7, department=@p8 where aud_num =@p1";
            try
            {
                if (String.IsNullOrEmpty(AudBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(typeBox.Text)
                    || String.IsNullOrEmpty(matResBox.Text) || String.IsNullOrEmpty(depBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int square = int.Parse(SquareBox.Text);
                int windows_nums = int.Parse(WinBox.Text);
                int battery_nums = int.Parse(BatteryBox.Text);
                int materially_responsible = int.Parse(matResBox.Text);
                int department = int.Parse(depBox.Text);


                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", AudBox.Text);
                cmd.Parameters.AddWithValue("@p2", square);
                cmd.Parameters.AddWithValue("@p3", windows_nums);
                cmd.Parameters.AddWithValue("@p4", battery_nums);
                cmd.Parameters.AddWithValue("@p5", typeBox.Text);
                cmd.Parameters.AddWithValue("@p6", buildBox.Text);
                cmd.Parameters.AddWithValue("@p7", materially_responsible);
                cmd.Parameters.AddWithValue("@p8", department);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string command = $"INSERT INTO audiences (aud_num,square,windows_nums,battery_nums,type,name_of_building,materially_responsible,department) " +
               "VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)";
            try
            {
                if (String.IsNullOrEmpty(AudBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(typeBox.Text)
                    || String.IsNullOrEmpty(matResBox.Text) || String.IsNullOrEmpty(depBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int square = int.Parse(SquareBox.Text);
                int windows_nums = int.Parse(WinBox.Text);
                int battery_nums = int.Parse(BatteryBox.Text);
                int materially_responsible = int.Parse(matResBox.Text);
                int department = int.Parse(depBox.Text);


                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", AudBox.Text);
                cmd.Parameters.AddWithValue("@p2", square);
                cmd.Parameters.AddWithValue("@p3", windows_nums);
                cmd.Parameters.AddWithValue("@p4", battery_nums);
                cmd.Parameters.AddWithValue("@p5", typeBox.Text);
                cmd.Parameters.AddWithValue("@p6", buildBox.Text);
                cmd.Parameters.AddWithValue("@p7", materially_responsible);
                cmd.Parameters.AddWithValue("@p8", department);
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

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = String.Empty;
                }
            }
        }
    }
}
