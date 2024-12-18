using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Owners : Form
    {
        DB db = new DB();

        public Owners()
        {
            InitializeComponent(); 
        }

        // Завантаження даних у DataGridView
        private void Owners_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Власники");
        }


        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = textBoxNameAdd.Text;
            string phone = textBoxPhoneAdd.Text;

            if (name == "" || phone == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Власники (ПІБ, Телефон) VALUES (@name, @phone)", db.getConnection());
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone", phone);

            ExecuteQuery(command, "Запис додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string name = textBoxNameEdit.Text;
            string phone = textBoxPhoneEdit.Text;

            MySqlCommand command = new MySqlCommand("UPDATE Власники SET ПІБ = @name, Телефон = @phone WHERE ID_власника = @id", db.getConnection());
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone", phone);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Власники WHERE ID_власника = @id", db.getConnection());
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис видалено успішно!");
        }


        // Виконання SQL-запиту
        private void ExecuteQuery(MySqlCommand command, string successMessage)
        {
            try
            {
                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                    MessageBox.Show(successMessage);
                else
                    MessageBox.Show("Помилка виконання запиту.");
                db.closeConnection();
                db.ShowTable(dataGridView1, "Власники");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void BackToMenuButton_Click(object sender, EventArgs e)
        {
            MainForm mainMenu = new MainForm();
            mainMenu.Show();
            this.Hide();
            mainMenu.FormClosed += (s, args) => this.Close();
        }
    }
}
