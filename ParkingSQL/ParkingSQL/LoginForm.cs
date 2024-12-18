using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            password.Size = new Size(229, 27);
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 44);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = login.Text;
            string passUser = password.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM автостоянка.користувачі WHERE `Логін` = @uL AND `Пароль` = @uP", db.getConnection());
            MySqlCommand command = mySqlCommand;
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Вхід успішний!");
                this.Hide();
                MainForm mainMenu = new MainForm();
                mainMenu.Show();
            }

            else
                MessageBox.Show("Невірний логін або пароль.", "Помилка");
        }
    }
}