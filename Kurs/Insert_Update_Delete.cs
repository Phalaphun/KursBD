﻿using Npgsql;
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
    public partial class Insert_Update_Delete : Form
    {
        BindingSource bs;
        //DataSet dataSet;
        //NpgsqlDataAdapter adapter;
        string mission;
        NpgsqlConnection conn;
        //public Insert_Update_Delete(DataSet dataSet, NpgsqlDataAdapter adapter, BindingSource bs, string mission )
        public Insert_Update_Delete(BindingSource bs, string mission, NpgsqlConnection conn )
        {
            InitializeComponent();
            //this.dataSet = dataSet;
            //this.adapter = adapter;
            this.bs = bs;
            this.mission = mission;
            this.conn = conn;
        }

        private void Insert_Update_Delete_Load(object sender, EventArgs e)
        {
            if (mission == "Update")
            {
                cadastreTextBox.DataBindings.Add("Text", bs, "cadastre");
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
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string command = "UPDATE buildings SET name = @name, square =@square, house_number =@house_number," +
                "year_built =@year_built, num_of_floors=@num_of_floors, comment=@comment, photo=@photo, material=@material, city=@city, " +
                "address =@address where cadastre = @cadastre" ;
            try
            {
                if (String.IsNullOrEmpty(cadastreTextBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(HouseNumBox.Text)
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
                cmd.Parameters.AddWithValue("@cadastre", cadastreTextBox.Text);
                cmd.Parameters.AddWithValue("@name", NameBox.Text);
                cmd.Parameters.AddWithValue("@square", square);
                cmd.Parameters.AddWithValue("@house_number", house_num);
                cmd.Parameters.AddWithValue("@year_built", year);
                cmd.Parameters.AddWithValue("@num_of_floors", num_of_floors);
                cmd.Parameters.AddWithValue("@comment", CommBox6.Text);
                cmd.Parameters.AddWithValue("@photo", PhotoBox.Text);
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
                if (String.IsNullOrEmpty(cadastreTextBox.Text) || String.IsNullOrEmpty(SquareBox.Text) || String.IsNullOrEmpty(HouseNumBox.Text)
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
                cmd.Parameters.AddWithValue("@p1", cadastreTextBox.Text);
                cmd.Parameters.AddWithValue("@p2", NameBox.Text);
                cmd.Parameters.AddWithValue("@p3", square);
                cmd.Parameters.AddWithValue("@p4", house_num);
                cmd.Parameters.AddWithValue("@p5", year);
                cmd.Parameters.AddWithValue("@p6", num_of_floors);
                cmd.Parameters.AddWithValue("@p7", CommBox6.Text);
                cmd.Parameters.AddWithValue("@p8", PhotoBox.Text);
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
    }
}
