namespace ParkingSQL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOwners = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ParkingButton = new System.Windows.Forms.Button();
            this.ParkingSpotsButton = new System.Windows.Forms.Button();
            this.Fines = new System.Windows.Forms.Button();
            this.Payments = new System.Windows.Forms.Button();
            this.Tariffs = new System.Windows.Forms.Button();
            this.EventLog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOwners
            // 
            this.buttonOwners.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOwners.Location = new System.Drawing.Point(9, 44);
            this.buttonOwners.Name = "buttonOwners";
            this.buttonOwners.Size = new System.Drawing.Size(196, 93);
            this.buttonOwners.TabIndex = 0;
            this.buttonOwners.Text = "Власники";
            this.buttonOwners.UseVisualStyleBackColor = true;
            this.buttonOwners.Click += new System.EventHandler(this.buttonOwners_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(211, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 93);
            this.button2.TabIndex = 1;
            this.button2.Text = "Автомобілі";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CarsButton_Click);
            // 
            // ParkingButton
            // 
            this.ParkingButton.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParkingButton.Location = new System.Drawing.Point(9, 143);
            this.ParkingButton.Name = "ParkingButton";
            this.ParkingButton.Size = new System.Drawing.Size(196, 93);
            this.ParkingButton.TabIndex = 2;
            this.ParkingButton.Text = "Паркування";
            this.ParkingButton.UseVisualStyleBackColor = true;
            this.ParkingButton.Click += new System.EventHandler(this.ParkingButton_Click);
            // 
            // ParkingSpotsButton
            // 
            this.ParkingSpotsButton.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParkingSpotsButton.Location = new System.Drawing.Point(211, 143);
            this.ParkingSpotsButton.Name = "ParkingSpotsButton";
            this.ParkingSpotsButton.Size = new System.Drawing.Size(196, 93);
            this.ParkingSpotsButton.TabIndex = 3;
            this.ParkingSpotsButton.Text = "Місця стоянки";
            this.ParkingSpotsButton.UseVisualStyleBackColor = true;
            this.ParkingSpotsButton.Click += new System.EventHandler(this.ParkingSpotsButton_Click);
            // 
            // Fines
            // 
            this.Fines.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fines.Location = new System.Drawing.Point(9, 242);
            this.Fines.Name = "Fines";
            this.Fines.Size = new System.Drawing.Size(196, 93);
            this.Fines.TabIndex = 4;
            this.Fines.Text = "Штрафи";
            this.Fines.UseVisualStyleBackColor = true;
            this.Fines.Click += new System.EventHandler(this.Fines_Click);
            // 
            // Payments
            // 
            this.Payments.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Payments.Location = new System.Drawing.Point(211, 242);
            this.Payments.Name = "Payments";
            this.Payments.Size = new System.Drawing.Size(196, 93);
            this.Payments.TabIndex = 5;
            this.Payments.Text = "Оплата";
            this.Payments.UseVisualStyleBackColor = true;
            this.Payments.Click += new System.EventHandler(this.Payments_Click);
            // 
            // Tariffs
            // 
            this.Tariffs.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Tariffs.Location = new System.Drawing.Point(9, 341);
            this.Tariffs.Name = "Tariffs";
            this.Tariffs.Size = new System.Drawing.Size(196, 93);
            this.Tariffs.TabIndex = 6;
            this.Tariffs.Text = "Тарифи";
            this.Tariffs.UseVisualStyleBackColor = true;
            this.Tariffs.Click += new System.EventHandler(this.Tariffs_Click);
            // 
            // EventLog
            // 
            this.EventLog.Font = new System.Drawing.Font("Gilroy SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EventLog.Location = new System.Drawing.Point(211, 341);
            this.EventLog.Name = "EventLog";
            this.EventLog.Size = new System.Drawing.Size(196, 93);
            this.EventLog.TabIndex = 7;
            this.EventLog.Text = "Журнал подій";
            this.EventLog.UseVisualStyleBackColor = true;
            this.EventLog.Click += new System.EventHandler(this.EventLog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gilroy SemiBold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Головне меню";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(415, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EventLog);
            this.Controls.Add(this.Tariffs);
            this.Controls.Add(this.Payments);
            this.Controls.Add(this.Fines);
            this.Controls.Add(this.ParkingSpotsButton);
            this.Controls.Add(this.ParkingButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonOwners);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOwners;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button ParkingButton;
        private System.Windows.Forms.Button ParkingSpotsButton;
        private System.Windows.Forms.Button Fines;
        private System.Windows.Forms.Button Payments;
        private System.Windows.Forms.Button Tariffs;
        private System.Windows.Forms.Button EventLog;
        private System.Windows.Forms.Label label1;
    }
}