using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSQL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOwners_Click(object sender, EventArgs e)
        {
            Owners ownersForm = new Owners();
            ownersForm.Show();
            this.Hide();
            ownersForm.FormClosed += (s, arg) => this.Close();
        }

        private void CarsButton_Click(object sender, EventArgs e)
        {
            Cars carsForm = new Cars();
            carsForm.Show();
            this.Hide();
            carsForm.FormClosed += (s, arg) => this.Close();
        }

        private void ParkingButton_Click(object sender, EventArgs e)
        {
            Parking parkingForm = new Parking();
            parkingForm.Show();
            this.Hide();
            parkingForm.FormClosed += (s, arg) => this.Close();
        }

        private void ParkingSpotsButton_Click(object sender, EventArgs e)
        {
            ParkingSpots parkingspotsForm = new ParkingSpots();
            parkingspotsForm.Show();
            this.Hide();
            parkingspotsForm.FormClosed += (s, arg) => this.Close();
        }

        private void Fines_Click(object sender, EventArgs e)
        {
            Fines finesForm = new Fines();
            finesForm.Show();
            this.Hide();
            finesForm.FormClosed += (s, arg) => this.Close();
        }

        private void Payments_Click(object sender, EventArgs e)
        {
            Payments paymentsForm = new Payments();
            paymentsForm.Show();
            this.Hide();
            paymentsForm.FormClosed += (s, arg) => this.Close();
        }

        private void Tariffs_Click(object sender, EventArgs e)
        {
            Tariffs tariffsForm = new Tariffs();
            tariffsForm.Show();
            this.Hide();
            tariffsForm.FormClosed += (s, arg) => this.Close();
        }

        private void EventLog_Click(object sender, EventArgs e)
        {
            EventLog eventlogForm = new EventLog();
            eventlogForm.Show();
            this.Hide();
            eventlogForm.FormClosed += (s, arg) => this.Close();
        }
    }
}
