namespace WinFormsHotel
{
    partial class FormRoomBooking
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
            comboBoxRoom = new ComboBox();
            labelRoom = new Label();
            comboBoxClient = new ComboBox();
            labelClient = new Label();
            datePickerStart = new DateTimePicker();
            labelStartDate = new Label();
            datePickerEnd = new DateTimePicker();
            labelEndDate = new Label();
            buttonBook = new Button();
            buttonPay = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxRoom
            // 
            comboBoxRoom.FormattingEnabled = true;
            comboBoxRoom.Location = new Point(114, 111);
            comboBoxRoom.Name = "comboBoxRoom";
            comboBoxRoom.Size = new Size(200, 23);
            comboBoxRoom.TabIndex = 1;
            comboBoxRoom.Tag = "room_id";
            // 
            // labelRoom
            // 
            labelRoom.AutoSize = true;
            labelRoom.Location = new Point(60, 114);
            labelRoom.Name = "labelRoom";
            labelRoom.Size = new Size(48, 15);
            labelRoom.TabIndex = 2;
            labelRoom.Text = "Номер:";
            // 
            // comboBoxClient
            // 
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(114, 172);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(200, 23);
            comboBoxClient.TabIndex = 3;
            comboBoxClient.Tag = "client_id";
            // 
            // labelClient
            // 
            labelClient.AutoSize = true;
            labelClient.Location = new Point(59, 175);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(49, 15);
            labelClient.TabIndex = 4;
            labelClient.Text = "Клиент:";
            // 
            // datePickerStart
            // 
            datePickerStart.Location = new Point(114, 294);
            datePickerStart.Name = "datePickerStart";
            datePickerStart.Size = new Size(200, 23);
            datePickerStart.TabIndex = 5;
            datePickerStart.Tag = "start_date";
            // 
            // labelStartDate
            // 
            labelStartDate.AutoSize = true;
            labelStartDate.Location = new Point(36, 300);
            labelStartDate.Name = "labelStartDate";
            labelStartDate.Size = new Size(72, 15);
            labelStartDate.TabIndex = 6;
            labelStartDate.Text = "Дата заезда:";
            // 
            // datePickerEnd
            // 
            datePickerEnd.Location = new Point(114, 233);
            datePickerEnd.Name = "datePickerEnd";
            datePickerEnd.Size = new Size(200, 23);
            datePickerEnd.TabIndex = 7;
            datePickerEnd.Tag = "end_date";
            // 
            // labelEndDate
            // 
            labelEndDate.AutoSize = true;
            labelEndDate.Location = new Point(32, 239);
            labelEndDate.Name = "labelEndDate";
            labelEndDate.Size = new Size(76, 15);
            labelEndDate.TabIndex = 8;
            labelEndDate.Text = "Дата выезда:";
            // 
            // buttonBook
            // 
            buttonBook.Font = new Font("Segoe UI", 15F);
            buttonBook.Location = new Point(383, 120);
            buttonBook.Name = "buttonBook";
            buttonBook.Size = new Size(174, 75);
            buttonBook.TabIndex = 15;
            buttonBook.Text = "Забронировать";
            buttonBook.UseVisualStyleBackColor = true;
            buttonBook.Click += buttonBook_Click;
            // 
            // buttonPay
            // 
            buttonPay.Font = new Font("Segoe UI", 15F);
            buttonPay.Location = new Point(383, 225);
            buttonPay.Name = "buttonPay";
            buttonPay.Size = new Size(174, 78);
            buttonPay.TabIndex = 16;
            buttonPay.Text = "Оплатить";
            buttonPay.UseVisualStyleBackColor = true;
            buttonPay.Click += buttonPay_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 369);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(635, 230);
            dataGridView1.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(102, 9);
            label1.Name = "label1";
            label1.Size = new Size(444, 54);
            label1.TabIndex = 20;
            label1.Text = "Бронирование номера";
            // 
            // FormRoomBooking
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(662, 614);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(buttonPay);
            Controls.Add(buttonBook);
            Controls.Add(labelEndDate);
            Controls.Add(datePickerEnd);
            Controls.Add(labelStartDate);
            Controls.Add(datePickerStart);
            Controls.Add(labelClient);
            Controls.Add(comboBoxClient);
            Controls.Add(labelRoom);
            Controls.Add(comboBoxRoom);
            Name = "FormRoomBooking";
            Text = "FormRoomBooking";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBoxRoom;
        private Label labelRoom;
        private ComboBox comboBoxClient;
        private Label labelClient;
        private DateTimePicker datePickerStart;
        private Label labelStartDate;
        private DateTimePicker datePickerEnd;
        private Label labelEndDate;
        private Button buttonBook;
        private Button buttonPay;
        private DataGridView dataGridView1;
        private Label label1;
    }
}