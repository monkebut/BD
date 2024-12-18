using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Parking : Form
    {
        DB db = new DB();

        public Parking()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void Parking_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Паркування");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string carId = textBoxCarIdAdd.Text;
            string placeId = textBoxPlaceIdAdd.Text;
            string entryDate = dateTimePickerEntryAdd.Value.ToString("yyyy-MM-dd HH:mm:ss");

            if (carId == "" || placeId == "" || entryDate == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Паркування (ID_автомобіля, ID_місця, Дата_заїзду) VALUES (@carId, @placeId, @entryDate)", db.getConnection());
            command.Parameters.AddWithValue("@carId", carId);
            command.Parameters.AddWithValue("@placeId", placeId);
            command.Parameters.AddWithValue("@entryDate", entryDate);

            ExecuteQuery(command, "Паркування додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string carId = textBoxCarIdEdit.Text;
            string placeId = textBoxPlaceIdEdit.Text;
            string entryDate = dateTimePickerEntryEdit.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string exitDate = dateTimePickerExitEdit.Value.ToString("yyyy-MM-dd HH:mm:ss");

            MySqlCommand command = new MySqlCommand("UPDATE Паркування SET ID_автомобіля = @carId, ID_місця = @placeId, Дата_заїзду = @entryDate, Дата_виїзду = @exitDate WHERE ID_паркування = @id", db.getConnection());
            command.Parameters.AddWithValue("@carId", carId);
            command.Parameters.AddWithValue("@placeId", placeId);
            command.Parameters.AddWithValue("@entryDate", entryDate);
            command.Parameters.AddWithValue("@exitDate", exitDate);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Паркування оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Паркування WHERE ID_паркування = @id", db.getConnection());
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
                db.ShowTable(dataGridView1, "Паркування");
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
