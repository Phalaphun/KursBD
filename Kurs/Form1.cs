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

                buildingAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from buildings",conn));
                audAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from audiences",conn));
                departmentAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from department", conn));
                citiesAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from cities_handbook", conn));
                deansAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from deans_handbook", conn));
                materialAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from material_handbook", conn));
                materialResAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from materially_responsible", conn));
                propertyAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from property", conn));
                streetsAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from streets_handbook", conn));

                dataSet = new DataSet();
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
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            
        }

        private void audiencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "audiences";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "property";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void materiallyResponsiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "materially_responsible";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "department";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void deansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "deans_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "material_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void citiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "cities_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }

        private void streetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "streets_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
        }
    }
}
