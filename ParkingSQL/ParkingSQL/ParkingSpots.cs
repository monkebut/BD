using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class ParkingSpots : Form
    {
        DB db = new DB();

        public ParkingSpots()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void ParkingSpots_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Місця_стоянки");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string spotNumber = textBoxSpotNumberAdd.Text;
            string spotType = textBoxSpotTypeAdd.Text; // Поле для "Тип_місця"
            int status = checkBoxStatusAdd.Checked ? 1 : 0; // CheckBox для статусу (1 = зайнятий, 0 = вільний)

            if (spotNumber == "" || spotType == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Місця_стоянки (Номер_місця, Тип_місця, Статус) VALUES (@spotNumber, @spotType, @status)", db.getConnection());
            command.Parameters.AddWithValue("@spotNumber", spotNumber);
            command.Parameters.AddWithValue("@spotType", spotType);
            command.Parameters.AddWithValue("@status", status);

            ExecuteQuery(command, "Місце стоянки додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string spotNumber = textBoxSpotNumberEdit.Text;
            string spotType = textBoxSpotTypeEdit.Text; // Поле для "Тип_місця"
            int status = checkBoxStatusEdit.Checked ? 1 : 0; // CheckBox для статусу

            if (spotNumber == "" || spotType == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("UPDATE Місця_стоянки SET Номер_місця = @spotNumber, Тип_місця = @spotType, Статус = @status WHERE ID_місця = @id", db.getConnection());
            command.Parameters.AddWithValue("@spotNumber", spotNumber);
            command.Parameters.AddWithValue("@spotType", spotType);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Місця_стоянки WHERE ID_місця = @id", db.getConnection());
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
                db.ShowTable(dataGridView1, "Місця_стоянки");
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

        private void textBoxSpotNumberAdd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
