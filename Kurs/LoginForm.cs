using System;

using System.Data;

using System.Security.Cryptography;
using System.Text;

using System.Windows.Forms;
using Npgsql;

namespace Kurs
{
    public partial class LoginForm : Form
    {
        readonly static string connString = "Server=localhost;Port=5432;User ID=postgres;Password=123;Database=University property;";

        public LoginForm()
        {
            InitializeComponent();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlDataAdapter adapter;
            DataTable dt = new DataTable();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from login where login=@p1 and password=@p2", conn);
            SHA256 hash = SHA256.Create();

            byte[] password = hash.ComputeHash(Encoding.UTF8.GetBytes(textBox2.Text));


            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", password);

            try
            {
                conn.Open();
                adapter = new NpgsqlDataAdapter(cmd);



                //NpgsqlCommand a = new NpgsqlCommand($"Insert into login (login, password) values (@p1, @p2) ", conn);
                //a.Parameters.AddWithValue("@p1",textBox1.Text);
                //a.Parameters.AddWithValue("@p2", password);
                //a.ExecuteNonQuery();
                



                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Авторизация пройдена успешно");
                this.DialogResult = DialogResult.OK;
                Close();
                
                //new Form1().Show();
                //Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }
    }
}
