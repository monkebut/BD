using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class Cars : Form
    {
        DB db = new DB();

        public Cars()
        {
            InitializeComponent();
        }

        // Завантаження даних у DataGridView
        private void Cars_Load(object sender, EventArgs e)
        {
            db.ShowTable(dataGridView1, "Автомобілі");
        }

        // Додавання запису
        private void AddButton_Click(object sender, EventArgs e)
        {
            string brand = textBoxBrandAdd.Text;
            string model = textBoxModelAdd.Text;
            string plate = textBoxPlateAdd.Text;
            string ownerId = textBoxOwnerIdAdd.Text;

            if (brand == "" || model == "" || plate == "" || ownerId == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            MySqlCommand command = new MySqlCommand("INSERT INTO Автомобілі (Марка, Модель, Номерний_знак, ID_власника) VALUES (@brand, @model, @plate, @ownerId)", db.getConnection());
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@plate", plate);
            command.Parameters.AddWithValue("@ownerId", ownerId);

            ExecuteQuery(command, "Автомобіль додано успішно!");
        }

        // Редагування запису
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string brand = textBoxBrandEdit.Text;
            string model = textBoxModelEdit.Text;
            string plate = textBoxPlateEdit.Text;
            string ownerId = textBoxOwnerIdEdit.Text;

            MySqlCommand command = new MySqlCommand("UPDATE Автомобілі SET Марка = @brand, Модель = @model, Номерний_знак = @plate, ID_власника = @ownerId WHERE ID_автомобіля = @id", db.getConnection());
            command.Parameters.AddWithValue("@brand", brand);
            command.Parameters.AddWithValue("@model", model);
            command.Parameters.AddWithValue("@plate", plate);
            command.Parameters.AddWithValue("@ownerId", ownerId);
            command.Parameters.AddWithValue("@id", id);

            ExecuteQuery(command, "Запис оновлено успішно!");
        }

        // Видалення запису
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            MySqlCommand command = new MySqlCommand("DELETE FROM Автомобілі WHERE ID_автомобіля = @id", db.getConnection());
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
                db.ShowTable(dataGridView1, "Автомобілі");
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
