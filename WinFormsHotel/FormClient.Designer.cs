namespace WinFormsHotel
{
    partial class FormClient
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
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxMiddleName = new TextBox();
            textBoxPassport = new TextBox();
            textBoxCity = new TextBox();
            textBoxPhone = new TextBox();
            labelFirstName = new Label();
            labelLastName = new Label();
            labelMiddleName = new Label();
            labelPassport = new Label();
            labelCity = new Label();
            labelPhone = new Label();
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            buttonBooking = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(228, 251);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(256, 23);
            textBoxFirstName.TabIndex = 0;
            textBoxFirstName.Tag = "first_name";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(228, 298);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(256, 23);
            textBoxLastName.TabIndex = 1;
            textBoxLastName.Tag = "last_name";
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(228, 346);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(256, 23);
            textBoxMiddleName.TabIndex = 2;
            textBoxMiddleName.Tag = "middle_name";
            // 
            // textBoxPassport
            // 
            textBoxPassport.Location = new Point(228, 395);
            textBoxPassport.Name = "textBoxPassport";
            textBoxPassport.Size = new Size(256, 23);
            textBoxPassport.TabIndex = 3;
            textBoxPassport.Tag = "passport";
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(228, 441);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(256, 23);
            textBoxCity.TabIndex = 4;
            textBoxCity.Tag = "city";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(228, 488);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(256, 23);
            textBoxPhone.TabIndex = 5;
            textBoxPhone.Tag = "phone";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 13F);
            labelFirstName.Location = new Point(174, 251);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(51, 25);
            labelFirstName.TabIndex = 6;
            labelFirstName.Text = "Имя:";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 13F);
            labelLastName.Location = new Point(133, 298);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(89, 25);
            labelLastName.TabIndex = 7;
            labelLastName.Text = "Фамилия:";
            // 
            // labelMiddleName
            // 
            labelMiddleName.AutoSize = true;
            labelMiddleName.Font = new Font("Segoe UI", 13F);
            labelMiddleName.Location = new Point(130, 343);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(92, 25);
            labelMiddleName.TabIndex = 8;
            labelMiddleName.Text = "Отчество:";
            // 
            // labelPassport
            // 
            labelPassport.AutoSize = true;
            labelPassport.Font = new Font("Segoe UI", 13F);
            labelPassport.Location = new Point(133, 392);
            labelPassport.Name = "labelPassport";
            labelPassport.Size = new Size(85, 25);
            labelPassport.TabIndex = 9;
            labelPassport.Text = "Паспорт:";
            // 
            // labelCity
            // 
            labelCity.AutoSize = true;
            labelCity.Font = new Font("Segoe UI", 13F);
            labelCity.Location = new Point(155, 438);
            labelCity.Name = "labelCity";
            labelCity.Size = new Size(67, 25);
            labelCity.TabIndex = 10;
            labelCity.Text = "Город:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 13F);
            labelPhone.Location = new Point(140, 488);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(85, 25);
            labelPhone.TabIndex = 11;
            labelPhone.Text = "Телефон:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(957, 150);
            dataGridView1.TabIndex = 12;
            // 
            // buttonAdd
            // 
            buttonAdd.BackgroundImageLayout = ImageLayout.Stretch;
            buttonAdd.Cursor = Cursors.Hand;
            buttonAdd.Font = new Font("Segoe UI", 9F);
            buttonAdd.Location = new Point(636, 299);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(143, 50);
            buttonAdd.TabIndex = 13;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUpdate.Cursor = Cursors.Hand;
            buttonUpdate.Font = new Font("Segoe UI", 9F);
            buttonUpdate.Location = new Point(636, 355);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(143, 50);
            buttonUpdate.TabIndex = 14;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.BackgroundImageLayout = ImageLayout.Stretch;
            buttonSendToServer.Cursor = Cursors.Hand;
            buttonSendToServer.Font = new Font("Segoe UI", 9F);
            buttonSendToServer.Location = new Point(636, 411);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(143, 50);
            buttonSendToServer.TabIndex = 16;
            buttonSendToServer.Text = "Отправить на сервер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.Font = new Font("Segoe UI", 9F);
            buttonCancel.Location = new Point(636, 470);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(143, 50);
            buttonCancel.TabIndex = 17;
            buttonCancel.Text = "Отменить изменения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonBooking
            // 
            buttonBooking.BackgroundImageLayout = ImageLayout.Stretch;
            buttonBooking.Cursor = Cursors.Hand;
            buttonBooking.Font = new Font("Segoe UI", 9F);
            buttonBooking.Location = new Point(636, 237);
            buttonBooking.Name = "buttonBooking";
            buttonBooking.Size = new Size(143, 50);
            buttonBooking.TabIndex = 18;
            buttonBooking.Text = "Забронировать номер ";
            buttonBooking.UseVisualStyleBackColor = true;
            buttonBooking.Click += buttonBooking_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(294, 0);
            label1.Name = "label1";
            label1.Size = new Size(370, 54);
            label1.TabIndex = 19;
            label1.Text = "Реадктор клиентов";
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(981, 553);
            Controls.Add(label1);
            Controls.Add(buttonBooking);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Controls.Add(labelPhone);
            Controls.Add(labelCity);
            Controls.Add(labelPassport);
            Controls.Add(labelMiddleName);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxPassport);
            Controls.Add(textBoxMiddleName);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Name = "FormClient";
            Text = "Клиент";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxMiddleName;
        private TextBox textBoxPassport;
        private TextBox textBoxCity;
        private TextBox textBoxPhone;
        private Label labelFirstName;
        private Label labelLastName;
        private Label labelMiddleName;
        private Label labelPassport;
        private Label labelCity;
        private Label labelPhone;
        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonSendToServer;
        private Button buttonCancel;
        private Button buttonBooking;
        private Label label1;
    }
}