using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Tariffs : Form
    {
        DB db = new DB();

        public Tariffs()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void Tariffs_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Тарифи");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string type = textBoxNameAdd.Text;
            string price = textBoxPriceAdd.Text;

            if (type == "" || price == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Тарифи (Тип_місця, Ціна_за_годину) VALUES (@type, @price)", db.getConnection());
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@price", price);

            ExecuteQuery(command, "Тариф додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string type = textBoxNameEdit.Text; // Замінено name на type
            string price = textBoxPriceEdit.Text;

            MySqlCommand command = new MySqlCommand("UPDATE Тарифи SET Тип_місця = @type, Ціна_за_годину = @price WHERE ID_тарифу = @id", db.getConnection());
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@price", price);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Тарифи WHERE ID_тарифу = @id", db.getConnection());
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
                db.ShowTable(dataGridView1, "Тарифи");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
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
