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
    public partial class PropertyToRemove : Form
    {
        BindingSource bs = new BindingSource();
        NpgsqlConnection conn;
        List<Dictionary<string, int>> dictionaries;
        List<string>[] keys;
        NpgsqlDataAdapter adapter;
        DataSet dataSet = new DataSet();
        public PropertyToRemove()
        {
            InitializeComponent();
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.keys = keys;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox1.Text == " ")
            {
                comboBox1.Enabled = false; textBox1.Enabled = true;
            }
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                comboBox1.Enabled = true; textBox1.Enabled = false;
            }
            if ((comboBox1.Text == "" || comboBox1.Text == " ") && (textBox1.Text == "" || textBox1.Text == " "))
            {
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox1.Text == " ")
            {
                comboBox1.Enabled = false; textBox1.Enabled = true;
            }
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                comboBox1.Enabled = true; textBox1.Enabled = false;
            }
            if ((comboBox1.Text == "" || comboBox1.Text == " ") && (textBox1.Text == "" || textBox1.Text == " "))
            {
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables.Count != 0)
            {
                dataSet.Tables.Clear();
            }
            string querryMatres = "";
            if (textBox1.Text == "" || textBox1.Text == " ")
            {
                querryMatres = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                "materially_responsible.first_name, materially_responsible.fathers_name  " +
                "from " +
                "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]} and property.depreciation > 75"; //{dictionaries[3][comboBox1.Text]}
            }
            else if(comboBox1.Text == "" || comboBox1.Text == " ")
            {
                querryMatres = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                "materially_responsible.first_name, materially_responsible.fathers_name  " +
                "from " +
                "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id and property.depreciation > 75";
            }
            else if (textBox1.Text=="Все")
            {
                querryMatres = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                "materially_responsible.first_name, materially_responsible.fathers_name  " +
                "from " +
                "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                $"where audiences.materially_responsible = materially_responsible.id and property.depreciation > 75";
            }

            try
            {

                conn.Open();
                adapter = new NpgsqlDataAdapter(new NpgsqlCommand(querryMatres, conn));
                adapter.Fill(dataSet, "querry");
                bs.DataSource = dataSet.Tables["querry"];
                dataGridView1.DataSource = bs;

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

        private void PropertyToRemove_Load(object sender, EventArgs e)
        {

        }
    }
}
