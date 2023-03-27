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
    public partial class QuerryPropAud : Form
    {
        readonly BindingSource bs = new BindingSource();
        readonly NpgsqlConnection conn;
        readonly List<Dictionary<string, int>> dictionaries;
        readonly List<string>[] keys;
        NpgsqlDataAdapter adapter;
        readonly DataSet dataSet = new DataSet();
        readonly string mission;
        public QuerryPropAud(NpgsqlConnection conn, List<Dictionary<string, int>> dictionaries, List<string>[] keys, string mission)
        {
            InitializeComponent();
            this.conn = conn;
            this.dictionaries = dictionaries;
            this.keys = keys;
            this.mission = mission;
        }

        private void QuerryPropCost_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(keys[3].ToArray());
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text==""||comboBox1.Text==" ")
            {
                comboBox1.Enabled = false; textBox1.Enabled = true;
            }
            if(textBox1.Text==""||textBox1.Text==" ")
            {
                comboBox1.Enabled = true; textBox1.Enabled = false;
            }
            if ((comboBox1.Text == "" || comboBox1.Text == " ") && (textBox1.Text == "" || textBox1.Text == " "))
            {
                comboBox1.Enabled = true;
                textBox1.Enabled = true;
            }
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e)
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
            if(dataSet.Tables.Count != 0){
                dataSet.Tables.Clear();
            }
            string querryMatres = ChooseStringQuerry(mission);
            //if (textBox1.Text==""||textBox1.Text==" ")
            //{
            //    querryMatres = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
            //    "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
            //    "materially_responsible.first_name, materially_responsible.fathers_name  " +
            //    "from " +
            //    "((property inner join audiences on property.aud_num = audiences.aud_num) " +
            //    "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
            //    $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]}"; //{dictionaries[3][comboBox1.Text]}
            //}
            //else
            //{
            //    querryMatres = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
            //    "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
            //    "materially_responsible.first_name, materially_responsible.fathers_name  " +
            //    "from " +
            //    "((property inner join audiences on property.aud_num = audiences.aud_num) " +
            //    "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
            //    $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id";
            //}

            try
            {

                conn.Open();
                adapter = new NpgsqlDataAdapter(new NpgsqlCommand(querryMatres, conn));
                adapter.Fill(dataSet,"querry");
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

        private string ChooseStringQuerry(string mission)
        {
            string s1 = "";
            switch (mission)
            {
                case "Aud":
                    if (textBox1.Text == "" || textBox1.Text == " ")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]}"; //{dictionaries[3][comboBox1.Text]}
                    }
                    else if((comboBox1.Text == "" || comboBox1.Text == " ") && textBox1.Text != "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id";
                    }
                    else if(textBox1.Text == "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where and audiences.materially_responsible = materially_responsible.id";
                    }
                    return s1;
                case "Rem":
                    if (textBox1.Text == "" || textBox1.Text == " ")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]} and property.depreciation > 75"; //{dictionaries[3][comboBox1.Text]}
                    }
                    else if ((comboBox1.Text == "" || comboBox1.Text == " ") && textBox1.Text !="Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id and property.depreciation > 75";
                    }
                    else if (textBox1.Text == "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and property.depreciation > 75";
                    }
                    return s1;
                case "ReCost":
                    if (textBox1.Text == "" || textBox1.Text == " ")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]} and  property.reprice_date < now()"; //{dictionaries[3][comboBox1.Text]}
                    }
                    else if ((comboBox1.Text == "" || comboBox1.Text == " ") && textBox1.Text != "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id and  property.reprice_date < now()";
                    }
                    else if (textBox1.Text == "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and property.reprice_date < now() ";
                    }
                    return s1;
                case ("FullCost"):
                    if (textBox1.Text == "" || textBox1.Text == " ")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name, case when reprice_date<now() and cost_after_reprice>0 then property.amount*cost_after_reprice else  property.amount*cost_per_one end as FullCost  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id and audiences.materially_responsible = {dictionaries[3][comboBox1.Text]}"; //{dictionaries[3][comboBox1.Text]}
                    }
                    else if ((comboBox1.Text == "" || comboBox1.Text == " ") && textBox1.Text != "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name, case when reprice_date<now() and cost_after_reprice>0 then property.amount*cost_after_reprice else  property.amount*cost_per_one end as FullCost  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.aud_num = \'{textBox1.Text}\' and audiences.materially_responsible = materially_responsible.id";
                    }
                    else if (textBox1.Text == "Все")
                    {
                        s1 = "Select property.id, property.name, property.delivery_date, property.cost_per_one, property.reprice_date, " +
                        "property.cost_after_reprice, property.lifetime, property.amount, property.depreciation, property.aud_num, materially_responsible.second_name, " +
                        "materially_responsible.first_name, materially_responsible.fathers_name, case when reprice_date<now() and cost_after_reprice>0 then property.amount*cost_after_reprice else  property.amount*cost_per_one end as FullCost  " +
                        "from " +
                        "((property inner join audiences on property.aud_num = audiences.aud_num) " +
                        "inner join materially_responsible on materially_responsible=audiences.materially_responsible) " +
                        $"where audiences.materially_responsible = materially_responsible.id ";
                    }

                    return s1;
                 default: return s1;

            }
        }
    }
}
