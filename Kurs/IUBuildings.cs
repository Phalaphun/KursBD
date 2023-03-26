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
    public partial class IUBuildings : Form
    {
        BindingSource bs;
        string mission;
        NpgsqlConnection conn;
        List<Dictionary<string, int>> dictionaries;

        List<string>[] keys;
        public IUBuildings(BindingSource bs, string mission, NpgsqlConnection conn, List<Dictionary<string, int>> dictionaries, List<string>[] keys)
        {
            InitializeComponent();
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.keys = keys;

        }

        private void Insert_Update_Delete_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                cadastreBox.DataBindings.Add("Text", bs, "cadastre");
                NameBox.DataBindings.Add("Text", bs, "name");
                SquareBox.DataBindings.Add("Text", bs, "square");
                HouseNumBox.DataBindings.Add("Text", bs, "house_number");
                BuildBox.DataBindings.Add("Text", bs, "year_built");
                FloorsBox.DataBindings.Add("Text", bs, "num_of_floors");
                CommBox6.DataBindings.Add("Text", bs, "comment");
                PhotoBox.DataBindings.Add("Text", bs, "photo");
                MaterialBox.DataBindings.Add("Text", bs, "material");
                CityBox.DataBindings.Add("Text", bs, "city");
                AddressBox.DataBindings.Add("Text", bs, "address"); 
                
                
                button5.Enabled = false; button5.Visible = false;
            }else if (mission == "Insert")
            {
                button4.Enabled = false; button4.Visible = false;
                
            }

            pictureBox1.ImageLocation = PhotoBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            PrepairComboboxex();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string command = "UPDATE buildings SET name = @name, square =@square, house_number =@house_number," +
                "year_built =@year_built, num_of_floors=@num_of_floors, comment=@comment, photo=@photo, material=@material, city=@city, " +
                "address =@address where cadastre = @cadastre" ;
            try
            {
                if (String.IsNullOrEmpty(cadastreBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(HouseNumBox.Text)
                    || String.IsNullOrEmpty(BuildBox.Text) || String.IsNullOrEmpty(FloorsBox.Text) || String.IsNullOrEmpty(MaterialBox.Text)
                    || String.IsNullOrEmpty(CityBox.Text) || String.IsNullOrEmpty(AddressBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int square = int.Parse(SquareBox.Text);
                int house_num = int.Parse(HouseNumBox.Text);
                int year = int.Parse(BuildBox.Text);
                int num_of_floors = int.Parse(FloorsBox.Text);
                int material = int.Parse(MaterialBox.Text);
                int city = int.Parse(CityBox.Text);
                int address = int.Parse(AddressBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command,conn);
                cmd.Parameters.AddWithValue("@cadastre", cadastreBox.Text);
                cmd.Parameters.AddWithValue("@name", NameBox.Text);
                cmd.Parameters.AddWithValue("@square", square);
                cmd.Parameters.AddWithValue("@house_number", house_num);
                cmd.Parameters.AddWithValue("@year_built", year);
                cmd.Parameters.AddWithValue("@num_of_floors", num_of_floors);
                //cmd.Parameters.AddWithValue("@p7", CommBox6.Text);
                if (CommBox6.Text == "" || CommBox6.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@comment", NpgsqlDbType.Text));
                    cmd.Parameters[6].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@comment", CommBox6.Text);
                }
                //cmd.Parameters.AddWithValue("@p8", PhotoBox.Text);
                if (PhotoBox.Text == "" || PhotoBox.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@photo", NpgsqlDbType.Varchar));
                    cmd.Parameters[7].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@photo", PhotoBox.Text);
                }
                cmd.Parameters.AddWithValue("@material", material);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@address", address);
                
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string command = "INSERT INTO buildings (cadastre, name, square, house_number, year_built, num_of_floors, " +
                "comment, photo, material, city, address) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)";
            try
            {
                if (String.IsNullOrEmpty(cadastreBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(HouseNumBox.Text)
                    || String.IsNullOrEmpty(BuildBox.Text) || String.IsNullOrEmpty(FloorsBox.Text) || String.IsNullOrEmpty(MaterialBox.Text)
                    || String.IsNullOrEmpty(CityBox.Text) || String.IsNullOrEmpty(AddressBox.Text))
                {
                    MessageBox.Show("Заполните все обязательные поля");
                    return;
                }

                int square = int.Parse(SquareBox.Text);
                int house_num = int.Parse(HouseNumBox.Text);
                int year = int.Parse(BuildBox.Text);
                int num_of_floors = int.Parse(FloorsBox.Text);
                int material = int.Parse(MaterialBox.Text);
                int city = int.Parse(CityBox.Text);
                int address = int.Parse(AddressBox.Text);

                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@p1", cadastreBox.Text);
                cmd.Parameters.AddWithValue("@p2", NameBox.Text);
                cmd.Parameters.AddWithValue("@p3", square);
                cmd.Parameters.AddWithValue("@p4", house_num);
                cmd.Parameters.AddWithValue("@p5", year);
                cmd.Parameters.AddWithValue("@p6", num_of_floors);
                //cmd.Parameters.AddWithValue("@p7", CommBox6.Text);
                if (CommBox6.Text == "" || CommBox6.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p7", NpgsqlDbType.Text));
                    cmd.Parameters[6].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p7", CommBox6.Text);
                }
                //cmd.Parameters.AddWithValue("@p8", PhotoBox.Text);
                if (PhotoBox.Text == "" || PhotoBox.Text == " ")
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@p8", NpgsqlDbType.Varchar));
                    cmd.Parameters[7].Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@p8", PhotoBox.Text);
                }
                cmd.Parameters.AddWithValue("@p9", material);
                cmd.Parameters.AddWithValue("@p10", city);
                cmd.Parameters.AddWithValue("@p11", address);

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

        private void ClearButton_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = String.Empty;
                }
            }
        }

        private void PhotoBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openFileDialog1.ShowDialog();
            PhotoBox.Text = openFileDialog1.FileName;
        }

        private void PhotoBox_Leave(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = PhotoBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void PrepairComboboxex()
        {
            
            comboBox1.Items.AddRange(keys[5].ToArray());

            comboBox2.Items.AddRange(keys[1].ToArray());

            comboBox3.Items.AddRange(keys[0].ToArray());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaterialBox.Text = (dictionaries[5][comboBox1.Text]).ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityBox.Text = (dictionaries[1][comboBox2.Text]).ToString();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddressBox.Text = (dictionaries[0][comboBox3.Text]).ToString();
        }
    }
}
