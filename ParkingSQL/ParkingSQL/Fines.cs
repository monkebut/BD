using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Fines : Form
    {
        DB db = new DB();

        public Fines()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void Fines_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Штрафи");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string parkingId = textBoxCarIdAdd.Text; // ID паркування
            string reason = textBoxReasonAdd.Text;   // Причина штрафу
            string amount = textBoxAmountAdd.Text;   // Сума штрафу
            string date = dateTimePickerDateAdd.Value.ToString("yyyy-MM-dd HH:mm:ss"); // Дата штрафу

            if (parkingId == "" || reason == "" || amount == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand(
                "INSERT INTO Штрафи (ID_паркування, Опис, Сума, Дата_штрафу) VALUES (@parkingId, @reason, @amount, @date)",
                db.getConnection());
            command.Parameters.AddWithValue("@parkingId", parkingId);
            command.Parameters.AddWithValue("@reason", reason);
            command.Parameters.AddWithValue("@amount", amount);
            command.Parameters.AddWithValue("@date", date);

            ExecuteQuery(command, "Штраф додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string parkingId = textBoxCarIdEdit.Text;
            string reason = textBoxReasonEdit.Text;
            string amount = textBoxAmountEdit.Text;
            string date = dateTimePickerDateEdit.Value.ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand command = new MySqlCommand(
                "UPDATE Штрафи SET ID_паркування = @parkingId, Опис = @reason, Сума = @amount, Дата_штрафу = @date WHERE ID_штрафу = @id",
                db.getConnection());
            command.Parameters.AddWithValue("@parkingId", parkingId);
            command.Parameters.AddWithValue("@reason", reason);
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

            MySqlCommand command = new MySqlCommand(
                "DELETE FROM Штрафи WHERE ID_штрафу = @id",
                db.getConnection());
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
                db.ShowTable(dataGridView1, "Штрафи");
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
