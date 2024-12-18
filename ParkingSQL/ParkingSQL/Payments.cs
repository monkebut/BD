using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Payments : Form
    {
        DB db = new DB();

        public Payments()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void Payments_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Оплата");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string parkingId = textBoxParkingIdAdd.Text;
            string amount = textBoxAmountAdd.Text;
            string date = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd HH:mm:ss");

            if (parkingId == "" || amount == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Оплата (ID_паркування, Сума, Дата_оплати) VALUES (@parkingId, @amount, @date)", db.getConnection());
            command.Parameters.AddWithValue("@parkingId", parkingId);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@date", date);

            ExecuteQuery(command, "Оплата додана успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string parkingId = textBoxParkingIdEdit.Text;
            string amount = textBoxAmountEdit.Text;
            string date = dateTimePickerDateEdit.Value.ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand command = new MySqlCommand("UPDATE Оплата SET ID_паркування = @parkingId, Сума = @amount, Дата_оплати = @date WHERE ID_оплати = @id", db.getConnection());
            command.Parameters.AddWithValue("@parkingId", parkingId);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Оплата WHERE ID_оплати = @id", db.getConnection());
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
                db.ShowTable(dataGridView1, "Оплата");
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