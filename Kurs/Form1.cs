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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kurs
{
    
    public partial class Form1 : Form
    {
        static readonly string connString = "Server=localhost;Port=5432;User ID=postgres;Password=123;Database=University property;";
        readonly NpgsqlConnection conn = new NpgsqlConnection(connString);

        NpgsqlDataAdapter buildingAdapter;
        NpgsqlDataAdapter audAdapter;
        NpgsqlDataAdapter departmentAdapter;
        NpgsqlDataAdapter citiesAdapter;
        NpgsqlDataAdapter deansAdapter;
        NpgsqlDataAdapter materialAdapter;
        NpgsqlDataAdapter materialResAdapter;
        NpgsqlDataAdapter propertyAdapter;
        NpgsqlDataAdapter streetsAdapter;

        DataSet dataSet;
        BindingSource bs;

        string currentTable = String.Empty;
        List<Dictionary<string, int>> dictionaries;
        Dictionary<string, string> BuildDic;
        List<string>[] keys;


        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory + "\\images";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form log = new LoginForm();

            if (log.ShowDialog() == DialogResult.Cancel)
                Close();

            LoadData();  
        }
        private void LoadData()
        {
            try
            {
                conn.Open();

                buildingAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select cadastre AS Кадастр, name AS Название, square as Площадь, " +
                    "year_built as \"Год постройки\", num_of_floors as \"Число этажей\", comment as Комментарий, photo as Фото, material as Материал, city as Город, address as Адрес, house_number as \"Номер здания\"" +
                    "  from buildings", conn));
                audAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select aud_num as \"Номер аудитории\", square as Площадь, windows_nums as \"Число окон\", battery_nums as \"Число батарей\", " +
                    "type as Назначение, materially_responsible as \"Материально ответственный\", department as Кафедра, name_of_building \"Кадастр здания\"  from audiences", conn));
                departmentAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, name as Название, second_name as \"Фамилия заведующего\", first_name as \"Имя заведующего\", fathers_name as \"Отчество заведующего\", " +
                    "phone as Телефон, deans as \"Деканат или Директорат\" from department", conn));
                citiesAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, type as Тип, name as Название  from cities_handbook", conn));
                deansAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, name as Название  from deans_handbook", conn));
                materialAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, material as Материал  from material_handbook", conn));
                materialResAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, start_year as \"Год начала работы\", second_name as \"Фамилия ответственного\", first_name as \"Имя ответственного\", fathers_name as \"Отчество ответственного\", " +
                    "city as Город, address as Адрес, num_of_house as \"Номер дома\", num_of_flat as \"Номер квартиры\" from materially_responsible", conn));
                propertyAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, name as Название, delivery_date as \"Дата поставки\", cost_per_one as \"Стоимость за единицу\", " +
                    "reprice_date as \"Дата переоценки\", cost_after_reprice as \"Стоимость после переоценки\", lifetime as \"Срок эксплуатации\", " +
                    "amount as Количество, depreciation as Износ, aud_num as \"Номер аудитории\"  from property", conn));
                streetsAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select id as ID, address_attribute as Тип, address_order as Порядок, name as Название  from streets_handbook", conn));

                dataSet = new DataSet();
                bs = new BindingSource();

                buildingAdapter.Fill(dataSet, "buildings");
                audAdapter.Fill(dataSet, "audiences");
                departmentAdapter.Fill(dataSet, "department");
                citiesAdapter.Fill(dataSet, "cities_handbook");
                deansAdapter.Fill(dataSet, "deans_handbook");
                materialAdapter.Fill(dataSet, "material_handbook");
                materialResAdapter.Fill(dataSet, "materially_responsible");
                propertyAdapter.Fill(dataSet, "property");
                streetsAdapter.Fill(dataSet, "streets_handbook");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //conn.Close();
            }
            Make_Dictionaries();

        }

        private void BuildingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "buildings";
            Refresh1();
            //dataGridView1.DataSource = dataSet.Tables[currentTable];
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Make_Dictionaries();
        }
        private void AudiencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "audiences";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "property";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void MateriallyResponsiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "materially_responsible";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void MepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "department";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void DeansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "deans_handbook";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void MaterialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "material_handbook";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "cities_handbook";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void StreetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "streets_handbook";
            Refresh1();
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Refresh1();
        }
        private void Refresh1()
        {
            if (currentTable == String.Empty)
                return;

            dataSet.Tables[currentTable].Clear();

            switch (currentTable)
            {
                case "buildings":
                    buildingAdapter.Fill(dataSet, "buildings");
                    break;
                case "audiences":
                    audAdapter.Fill(dataSet, "audiences");
                    break;
                case "department":
                    departmentAdapter.Fill(dataSet, "department");
                    break;
                case "cities_handbook":
                    citiesAdapter.Fill(dataSet, "cities_handbook");
                    break;
                case "deans_handbook":
                    deansAdapter.Fill(dataSet, "deans_handbook");
                    break;
                case "material_handbook":
                    materialAdapter.Fill(dataSet, "material_handbook");
                    break;
                case "materially_responsible":
                    materialResAdapter.Fill(dataSet, "materially_responsible");
                    break;
                case "property":
                    propertyAdapter.Fill(dataSet, "property");
                    break;
                case "streets_handbook":
                    streetsAdapter.Fill(dataSet, "streets_handbook");
                    break;
            }
            Make_Dictionaries();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (currentTable == String.Empty)
                return;
            switch (currentTable)
            {
                case "buildings":
                    Form buildings = new IUBuildings(bs, "Insert", conn, dictionaries,keys);
                    buildings.ShowDialog();
                    break;
                case "audiences":
                    Form aud = new IUAud(bs, "Insert", conn, dictionaries, keys, BuildDic);
                    aud.ShowDialog();
                    break;
                case "department":
                    Form dep = new IUDepartment(bs, "Insert", conn, dictionaries, keys);
                    dep.ShowDialog();
                    break;
                case "cities_handbook":
                    Form cit = new IUCities(bs, "Insert", conn);
                    cit.ShowDialog();
                    break;
                case "deans_handbook":
                    Form dean = new IUDeans(bs, "Insert", conn);
                    dean.ShowDialog();
                    break;
                case "material_handbook":
                    Form mat = new IUMaterial(bs, "Insert", conn);
                    mat.ShowDialog();
                    break;
                case "materially_responsible":
                    Form matRes = new IUMatRes(bs, "Insert", conn, dictionaries, keys);
                    matRes.ShowDialog();
                    break;
                case "property":
                    Form pro = new IUProperty(bs, "Insert", conn);
                    pro.ShowDialog();
                    break;
                case "streets_handbook":
                    Form str = new IUStreets(bs, "Insert", conn);
                    str.ShowDialog();
                    break;
            }

        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (currentTable == String.Empty)
                return;
            switch (currentTable)
            {
                case "buildings":
                    Form buildings = new IUBuildings(bs, "Update", conn, dictionaries, keys);
                    buildings.ShowDialog();
                    break;
                case "audiences":
                    Form aud = new IUAud(bs, "Update", conn, dictionaries, keys, BuildDic);
                    aud.ShowDialog();
                    break;
                case "department":
                    Form dep = new IUDepartment(bs, "Update", conn, dictionaries, keys);
                    dep.ShowDialog();
                    break;
                case "cities_handbook":
                    Form cit = new IUCities(bs, "Update", conn);
                    cit.ShowDialog();
                    break;
                case "deans_handbook":
                    Form dean = new IUDeans(bs, "Update", conn);
                    dean.ShowDialog();
                    break;
                case "material_handbook":
                    Form mat = new IUMaterial(bs, "Update", conn);
                    mat.ShowDialog();
                    break;
                case "materially_responsible":
                    Form matRes = new IUMatRes(bs, "Update", conn, dictionaries, keys);
                    matRes.ShowDialog();
                    break;
                case "property":
                    Form pro = new IUProperty(bs, "Update", conn);
                    pro.ShowDialog();
                    break;
                case "streets_handbook":
                    Form str = new IUStreets(bs, "Update", conn);
                    str.ShowDialog();
                    break;
            }
           
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            string command = String.Empty;
            switch (currentTable)
            {
                case "buildings":
                    command = $"DELETE FROM {currentTable} WHERE cadastre = '{dataGridView1.SelectedRows[0].Cells[0].Value}'";
                    break;
                case "audiences":
                    command = $"DELETE FROM {currentTable} WHERE aud_num = '{dataGridView1.SelectedRows[0].Cells[0].Value}'";
                    break;
                case "department":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "cities_handbook":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "deans_handbook":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "material_handbook":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "materially_responsible":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "property":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                case "streets_handbook":
                    command = $"DELETE FROM {currentTable} WHERE id = {dataGridView1.SelectedRows[0].Cells[0].Value}";
                    break;
                default:
                    break;
            }
            try
            {
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
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
            Refresh1();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            Refresh1();
        }
        private void Make_Dictionaries()
        {
            keys = new List<string>[7];
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i] = new List<string>();
            }
            int count = dataSet.Tables["material_handbook"].Rows.Count;
            Dictionary<string,int> materialsDic = new Dictionary<string,int>();
            for (int i = 0; i < count; i++)
            {
                materialsDic.Add((string)dataSet.Tables["material_handbook"].Rows[i].ItemArray[1], (int)dataSet.Tables["material_handbook"].Rows[i].ItemArray[0]);
                keys[5].Add((string)dataSet.Tables["material_handbook"].Rows[i].ItemArray[1]);
            }

            count = dataSet.Tables["streets_handbook"].Rows.Count;
            Dictionary<string, int> streetsDic = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                string s;
                if (!(bool)dataSet.Tables["streets_handbook"].Rows[i].ItemArray[2])
                {
                    s = dataSet.Tables["streets_handbook"].Rows[i].ItemArray[1] + " " + dataSet.Tables["streets_handbook"].Rows[i].ItemArray[3];
                }
                else
                {
                    s = dataSet.Tables["streets_handbook"].Rows[i].ItemArray[3] + " " + dataSet.Tables["streets_handbook"].Rows[i].ItemArray[1];
                }

                streetsDic.Add(s, (int)dataSet.Tables["streets_handbook"].Rows[i].ItemArray[0]);
                keys[0].Add(s);
            }

            count = dataSet.Tables["cities_handbook"].Rows.Count;
            Dictionary<string, int> citiesDic = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                citiesDic.Add((string)dataSet.Tables["cities_handbook"].Rows[i].ItemArray[1] + " "+(string)dataSet.Tables["cities_handbook"].Rows[i].ItemArray[2], (int)dataSet.Tables["cities_handbook"].Rows[i].ItemArray[0]);
                keys[1].Add((string)dataSet.Tables["cities_handbook"].Rows[i].ItemArray[1] + " " + (string)dataSet.Tables["cities_handbook"].Rows[i].ItemArray[2]);
            }

            count = dataSet.Tables["deans_handbook"].Rows.Count;
            Dictionary<string, int> deansDic = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                deansDic.Add((string)dataSet.Tables["deans_handbook"].Rows[i].ItemArray[1], (int)dataSet.Tables["deans_handbook"].Rows[i].ItemArray[0]);
                keys[2].Add((string)dataSet.Tables["deans_handbook"].Rows[i].ItemArray[1]);
            }

            count = dataSet.Tables["materially_responsible"].Rows.Count;
            Dictionary<string, int> matResDic = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                string s2,s3,s4;
                s2 = (string)dataSet.Tables["materially_responsible"].Rows[i].ItemArray[2];
                s3 = (string)dataSet.Tables["materially_responsible"].Rows[i].ItemArray[3];
                s4 = (dataSet.Tables["materially_responsible"].Rows[i].ItemArray[4]).GetType()!=s2.GetType()? "": (string)dataSet.Tables["materially_responsible"].Rows[i].ItemArray[4];
                matResDic.Add(s2+" "+ s3+" "+ s4, (int)dataSet.Tables["materially_responsible"].Rows[i].ItemArray[0]);
                keys[3].Add(s2 + " " + s3 + " " + s4);
            }

            count = dataSet.Tables["department"].Rows.Count;
            Dictionary<string, int> DepDic = new Dictionary<string, int>();
            for (int i = 0; i < count; i++)
            {
                DepDic.Add((string)dataSet.Tables["department"].Rows[i].ItemArray[1], (int)dataSet.Tables["department"].Rows[i].ItemArray[0]);
                keys[4].Add((string)dataSet.Tables["department"].Rows[i].ItemArray[1]);
            }

            count = dataSet.Tables["buildings"].Rows.Count;
            BuildDic = new Dictionary<string, string>();
            for (int i = 0; i < count; i++)
            {
                BuildDic.Add((string)dataSet.Tables["buildings"].Rows[i].ItemArray[1], (string)dataSet.Tables["buildings"].Rows[i].ItemArray[0]);
                keys[6].Add((string)dataSet.Tables["buildings"].Rows[i].ItemArray[1]);
            }
            dictionaries = new List<Dictionary<string, int>> { streetsDic, citiesDic, deansDic , matResDic, DepDic, materialsDic };
        }

        private void PropertyToRepriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form propAndAud = new QuerryPropAud(conn, dictionaries, keys, "Aud");
            propAndAud.ShowDialog();
        }

        private void TrashPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form propAndAud = new QuerryPropAud(conn, dictionaries, keys, "Rem");
            propAndAud.ShowDialog();
        }

        private void FullCostToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form propAndAud = new QuerryPropAud(conn, dictionaries, keys, "FullCost");
            propAndAud.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void asdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form propAndAud = new QuerryPropAud(conn, dictionaries, keys, "ReCost");
            propAndAud.ShowDialog();
        }
    }
}
