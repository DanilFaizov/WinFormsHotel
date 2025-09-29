namespace WinFormsHotel
{
    partial class FormRoomBookingPayment
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
            label1 = new Label();
            textBoxBookingId = new TextBox();
            textBoxClientName = new TextBox();
            textBoxRoomNumber = new TextBox();
            textBoxDates = new TextBox();
            textBoxTotalAmount = new TextBox();
            comboBoxPaymentMethod = new ComboBox();
            datePickerPayment = new DateTimePicker();
            buttonPay = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(382, 46);
            label1.TabIndex = 0;
            label1.Text = "Оплата бронирования ";
            // 
            // textBoxBookingId
            // 
            textBoxBookingId.Enabled = false;
            textBoxBookingId.Location = new Point(75, 95);
            textBoxBookingId.Name = "textBoxBookingId";
            textBoxBookingId.Size = new Size(254, 23);
            textBoxBookingId.TabIndex = 1;
            // 
            // textBoxClientName
            // 
            textBoxClientName.Enabled = false;
            textBoxClientName.Location = new Point(75, 152);
            textBoxClientName.Name = "textBoxClientName";
            textBoxClientName.Size = new Size(254, 23);
            textBoxClientName.TabIndex = 2;
            // 
            // textBoxRoomNumber
            // 
            textBoxRoomNumber.Enabled = false;
            textBoxRoomNumber.Location = new Point(75, 206);
            textBoxRoomNumber.Name = "textBoxRoomNumber";
            textBoxRoomNumber.Size = new Size(254, 23);
            textBoxRoomNumber.TabIndex = 3;
            // 
            // textBoxDates
            // 
            textBoxDates.Enabled = false;
            textBoxDates.Location = new Point(75, 271);
            textBoxDates.Name = "textBoxDates";
            textBoxDates.Size = new Size(254, 23);
            textBoxDates.TabIndex = 4;
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.Enabled = false;
            textBoxTotalAmount.Location = new Point(75, 340);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.Size = new Size(254, 23);
            textBoxTotalAmount.TabIndex = 5;
            // 
            // comboBoxPaymentMethod
            // 
            comboBoxPaymentMethod.FormattingEnabled = true;
            comboBoxPaymentMethod.Location = new Point(75, 393);
            comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            comboBoxPaymentMethod.Size = new Size(254, 23);
            comboBoxPaymentMethod.TabIndex = 6;
            // 
            // datePickerPayment
            // 
            datePickerPayment.Location = new Point(76, 449);
            datePickerPayment.Name = "datePickerPayment";
            datePickerPayment.Size = new Size(254, 23);
            datePickerPayment.TabIndex = 7;
            datePickerPayment.Tag = "payment_method";
            // 
            // buttonPay
            // 
            buttonPay.Location = new Point(12, 520);
            buttonPay.Name = "buttonPay";
            buttonPay.Size = new Size(406, 50);
            buttonPay.TabIndex = 8;
            buttonPay.Text = "Оплатить";
            buttonPay.UseVisualStyleBackColor = true;
            buttonPay.Click += buttonPay_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 77);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 9;
            label2.Text = "Номер бронирования";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 134);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 10;
            label3.Text = "Клиент";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 190);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 11;
            label4.Text = "Номер";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(75, 253);
            label5.Name = "label5";
            label5.Size = new Size(120, 15);
            label5.TabIndex = 12;
            label5.Text = "Дата заезда и выезда";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(75, 322);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 13;
            label6.Text = "Сумма оплаты";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(75, 375);
            label7.Name = "label7";
            label7.Size = new Size(93, 15);
            label7.TabIndex = 14;
            label7.Text = "Способ оплаты";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(75, 431);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 15;
            label8.Text = "Дата оплаты";
            // 
            // FormRoomBookingPayment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(430, 593);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(buttonPay);
            Controls.Add(datePickerPayment);
            Controls.Add(comboBoxPaymentMethod);
            Controls.Add(textBoxTotalAmount);
            Controls.Add(textBoxDates);
            Controls.Add(textBoxRoomNumber);
            Controls.Add(textBoxClientName);
            Controls.Add(textBoxBookingId);
            Controls.Add(label1);
            Name = "FormRoomBookingPayment";
            Text = "FormRoomBookingPayment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxBookingId;
        private TextBox textBoxClientName;
        private TextBox textBoxRoomNumber;
        private TextBox textBoxDates;
        private TextBox textBoxTotalAmount;
        private ComboBox comboBoxPaymentMethod;
        private DateTimePicker datePickerPayment;
        private Button buttonPay;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}