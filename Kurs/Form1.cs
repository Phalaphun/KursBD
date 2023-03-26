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
    
    public partial class Form1 : Form
    {
        static string connString = "Server=localhost;Port=5432;User ID=postgres;Password=123;Database=University property;";
        NpgsqlConnection conn = new NpgsqlConnection(connString);

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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();  
        }
        private void LoadData()
        {
            try
            {
                conn.Open();

                buildingAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from buildings", conn));
                audAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from audiences", conn));
                departmentAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from department", conn));
                citiesAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from cities_handbook", conn));
                deansAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from deans_handbook", conn));
                materialAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from material_handbook", conn));
                materialResAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from materially_responsible", conn));
                propertyAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from property", conn));
                streetsAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *  from streets_handbook", conn));

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
                conn.Close();
            }

        }

        private void buildingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "buildings";
            //dataGridView1.DataSource = dataSet.Tables[currentTable];
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void audiencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "audiences";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "property";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void materiallyResponsiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "materially_responsible";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "department";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void deansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "deans_handbook";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "material_handbook";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void citiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "cities_handbook";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void streetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "streets_handbook";
            bs.DataSource = dataSet.Tables[currentTable];
            dataGridView1.DataSource = bs;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
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
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentTable == String.Empty)
                return;
            switch (currentTable)
            {
                case "buildings":
                    Form buildings = new Insert_Update_Delete_buildings(bs, "Insert", conn);
                    buildings.ShowDialog();
                    break;
                case "audiences":
                    Form aud = new IUAud();
                    aud.ShowDialog();
                    break;
                case "department":

                    break;
                case "cities_handbook":

                    break;
                case "deans_handbook":

                    break;
                case "material_handbook":

                    break;
                case "materially_responsible":

                    break;
                case "property":

                    break;
                case "streets_handbook":

                    break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTable == String.Empty)
                return;
            switch (currentTable)
            {
                case "buildings":
                    Form buildings = new Insert_Update_Delete_buildings(bs, "Update", conn);
                    buildings.ShowDialog();
                    break;
                case "audiences":
                    
                    break;
                case "department":

                    break;
                case "cities_handbook":

                    break;
                case "deans_handbook":

                    break;
                case "material_handbook":

                    break;
                case "materially_responsible":

                    break;
                case "property":

                    break;
                case "streets_handbook":

                    break;
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTable == String.Empty)
                return;
            string command = $"DELETE FROM {currentTable} WHERE {dataGridView1.Columns[0].HeaderText} = {dataGridView1.SelectedRows[0].Cells[0].Value}";
            NpgsqlCommand cmd = new NpgsqlCommand(command, conn);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            conn.Close();
            this.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
