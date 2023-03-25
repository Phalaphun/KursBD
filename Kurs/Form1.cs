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
        bool newRowAdding = false;
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

                //buildingAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select * from buildings",conn));
                buildingAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from buildings", conn));
                audAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del  from audiences", conn));
                departmentAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from department", conn));
                citiesAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from cities_handbook", conn));
                deansAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from deans_handbook", conn));
                materialAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from material_handbook", conn));
                materialResAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from materially_responsible", conn));
                propertyAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from property", conn));
                streetsAdapter = new NpgsqlDataAdapter(new NpgsqlCommand("Select *, 'DELETE' As del from streets_handbook", conn));
                var a = new NpgsqlCommandBuilder(buildingAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(audAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(departmentAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(citiesAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(deansAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(materialAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(materialResAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(propertyAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();

                a = new NpgsqlCommandBuilder(streetsAdapter);
                a.GetDeleteCommand();
                a.GetInsertCommand();
                a.GetUpdateCommand();


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
            //var column1 = new DataGridViewTextBoxColumn();
            //column1.HeaderText = "Del";
            //column1.Name = "Columnn";

            //dataGridView1.Columns.Add(column1);

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    {
            //        dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
            //        dataGridView1[dataGridView1.ColumnCount - 1, i].Value = "DELETE";
            //    }
            //}
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }

        }

        private void audiencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "audiences";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "property";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void materiallyResponsiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "materially_responsible";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "department";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void deansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "deans_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void materialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "material_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void citiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "cities_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void streetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentTable = "streets_handbook";
            dataGridView1.DataSource = dataSet.Tables[currentTable];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                {
                    dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.ColumnIndex == dataGridView1.ColumnCount-1)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.ColumnCount-1].Value.ToString();

                    if(task == "DELETE")
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        dataSet.Tables[currentTable].Rows[rowIndex].Delete();
                        switch (currentTable)
                        {
                            case "buildings":
                                buildingAdapter.Update(dataSet, "buildings");
                                break;
                            case "audiences":
                                audAdapter.Update(dataSet, "audiences");
                                break;
                            case "department":
                                departmentAdapter.Update(dataSet, "department");
                                break;
                            case "cities_handbook":
                                citiesAdapter.Update(dataSet, "cities_handbook");
                                break;
                            case "deans_handbook":
                                deansAdapter.Update(dataSet, "deans_handbook");
                                break;
                            case "material_handbook":
                                materialAdapter.Update(dataSet, "material_handbook");
                                break;
                            case "materially_responsible":
                                materialResAdapter.Update(dataSet, "materially_responsible");
                                break;
                            case "property":
                                propertyAdapter.Update(dataSet, "property");
                                break;
                            case "streets_handbook":
                                streetsAdapter.Update(dataSet, "streets_handbook");
                                break;
                        }

                    }
                    else if(task == "INSERT")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables[currentTable].NewRow();
                        for (int i = 0; i < dataGridView1.Columns.Count-1; i++)
                        {
                            row[i] = dataGridView1.Rows[rowIndex].Cells[i].Value;
                        }
                        dataSet.Tables[currentTable].Rows.Add(row);
                        dataSet.Tables[currentTable].Rows.RemoveAt(dataSet.Tables[currentTable].Rows.Count-1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "DELETE";
                        switch (currentTable)
                        {
                            case "buildings":
                                buildingAdapter.Update(dataSet, "buildings");
                                break;
                            case "audiences":
                                audAdapter.Update(dataSet, "audiences");
                                break;
                            case "department":
                                departmentAdapter.Update(dataSet, "department");
                                break;
                            case "cities_handbook":
                                citiesAdapter.Update(dataSet, "cities_handbook");
                                break;
                            case "deans_handbook":
                                deansAdapter.Update(dataSet, "deans_handbook");
                                break;
                            case "material_handbook":
                                materialAdapter.Update(dataSet, "material_handbook");
                                break;
                            case "materially_responsible":
                                materialResAdapter.Update(dataSet, "materially_responsible");
                                break;
                            case "property":
                                propertyAdapter.Update(dataSet, "property");
                                break;
                            case "streets_handbook":
                                streetsAdapter.Update(dataSet, "streets_handbook");
                                break;
                        }
                        newRowAdding = false;

                    }
                    else if(task == "UPDATE")
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                        {
                            dataSet.Tables[currentTable].Rows[e.RowIndex][i] = dataGridView1.Rows[e.RowIndex].Cells[i].Value;
                        }
                        switch (currentTable)
                        {
                            case "buildings":
                                buildingAdapter.Update(dataSet, "buildings");
                                break;
                            case "audiences":
                                audAdapter.Update(dataSet, "audiences");
                                break;
                            case "department":
                                departmentAdapter.Update(dataSet, "department");
                                break;
                            case "cities_handbook":
                                citiesAdapter.Update(dataSet, "cities_handbook");
                                break;
                            case "deans_handbook":
                                deansAdapter.Update(dataSet, "deans_handbook");
                                break;
                            case "material_handbook":
                                materialAdapter.Update(dataSet, "material_handbook");
                                break;
                            case "materially_responsible":
                                materialResAdapter.Update(dataSet, "materially_responsible");
                                break;
                            case "property":
                                propertyAdapter.Update(dataSet, "property");
                                break;
                            case "streets_handbook":
                                streetsAdapter.Update(dataSet, "streets_handbook");
                                break;
                        }
                        dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "DELETE";


                    }
                    Refresh();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if(!newRowAdding)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView1.RowCount - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.ColumnCount - 1,lastRow] = linkCell;
                    row.Cells["del"].Value = "INSERT";
                }    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "audiences":
                    audAdapter.Fill(dataSet, "audiences");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "department":
                    departmentAdapter.Fill(dataSet, "department");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "cities_handbook":
                    citiesAdapter.Fill(dataSet, "cities_handbook");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "deans_handbook":
                    deansAdapter.Fill(dataSet, "deans_handbook");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "material_handbook":
                    materialAdapter.Fill(dataSet, "material_handbook");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "materially_responsible":
                    materialResAdapter.Fill(dataSet, "materially_responsible");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "property":
                    propertyAdapter.Fill(dataSet, "property");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
                case "streets_handbook":
                    streetsAdapter.Fill(dataSet, "streets_handbook");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        {
                            dataGridView1[dataGridView1.ColumnCount - 1, i] = linkCell;
                        }
                    }
                    break;
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(!newRowAdding)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.ColumnCount - 1, rowIndex] = linkCell;
                    editingRow.Cells["del"].Value = "UPDATE";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
