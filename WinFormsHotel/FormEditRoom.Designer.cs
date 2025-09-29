namespace WinFormsHotel
{
    partial class FormEditRoom
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
            dataGridView1 = new DataGridView();
            textBoxRoomNumber = new TextBox();
            textBoxPhone = new TextBox();
            comboBoxRoomType = new ComboBox();
            comboBoxStatus = new ComboBox();
            numericFloor = new NumericUpDown();
            comboBoxResponsibleStaff = new ComboBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            labelRoomNumber = new Label();
            labelRoomType = new Label();
            labelStatus = new Label();
            labelFloor = new Label();
            labelPhone = new Label();
            labelResponsibleStaff = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFloor).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 345);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(609, 258);
            dataGridView1.TabIndex = 0;
            // 
            // textBoxRoomNumber
            // 
            textBoxRoomNumber.Location = new Point(133, 106);
            textBoxRoomNumber.Name = "textBoxRoomNumber";
            textBoxRoomNumber.Size = new Size(218, 23);
            textBoxRoomNumber.TabIndex = 1;
            textBoxRoomNumber.Tag = "room_number";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(548, 106);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(218, 23);
            textBoxPhone.TabIndex = 2;
            textBoxPhone.Tag = "phone";
            // 
            // comboBoxRoomType
            // 
            comboBoxRoomType.DisplayMember = "name";
            comboBoxRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRoomType.FormattingEnabled = true;
            comboBoxRoomType.Location = new Point(133, 177);
            comboBoxRoomType.Name = "comboBoxRoomType";
            comboBoxRoomType.Size = new Size(218, 23);
            comboBoxRoomType.TabIndex = 3;
            comboBoxRoomType.Tag = "room_type_id";
            comboBoxRoomType.ValueMember = "id";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.DisplayMember = "name";
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(133, 252);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(218, 23);
            comboBoxStatus.TabIndex = 4;
            comboBoxStatus.Tag = "status_id";
            comboBoxStatus.ValueMember = "id";
            // 
            // numericFloor
            // 
            numericFloor.Location = new Point(548, 252);
            numericFloor.Name = "numericFloor";
            numericFloor.Size = new Size(218, 23);
            numericFloor.TabIndex = 5;
            numericFloor.Tag = "floor";
            // 
            // comboBoxResponsibleStaff
            // 
            comboBoxResponsibleStaff.DisplayMember = "last_name";
            comboBoxResponsibleStaff.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxResponsibleStaff.FormattingEnabled = true;
            comboBoxResponsibleStaff.Location = new Point(548, 177);
            comboBoxResponsibleStaff.Name = "comboBoxResponsibleStaff";
            comboBoxResponsibleStaff.Size = new Size(218, 23);
            comboBoxResponsibleStaff.TabIndex = 6;
            comboBoxResponsibleStaff.Tag = "responsible_staff_id";
            comboBoxResponsibleStaff.ValueMember = "id";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(681, 345);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(121, 37);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(681, 437);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(121, 39);
            buttonUpdate.TabIndex = 8;
            buttonUpdate.Text = "Изменить ";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(681, 388);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(121, 42);
            buttonDelete.TabIndex = 9;
            buttonDelete.Text = "Удалить ";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(655, 492);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(186, 47);
            buttonSendToServer.TabIndex = 10;
            buttonSendToServer.Text = "Загрузить на сервер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(655, 555);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(186, 47);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Отменить изменения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // labelRoomNumber
            // 
            labelRoomNumber.AutoSize = true;
            labelRoomNumber.Location = new Point(64, 109);
            labelRoomNumber.Name = "labelRoomNumber";
            labelRoomNumber.Size = new Size(48, 15);
            labelRoomNumber.TabIndex = 12;
            labelRoomNumber.Text = "Номер:";
            // 
            // labelRoomType
            // 
            labelRoomType.AutoSize = true;
            labelRoomType.Location = new Point(47, 180);
            labelRoomType.Name = "labelRoomType";
            labelRoomType.Size = new Size(76, 15);
            labelRoomType.TabIndex = 13;
            labelRoomType.Text = "Тип номера:";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(36, 255);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(91, 15);
            labelStatus.TabIndex = 14;
            labelStatus.Text = "Статус номера:";
            // 
            // labelFloor
            // 
            labelFloor.AutoSize = true;
            labelFloor.Location = new Point(505, 255);
            labelFloor.Name = "labelFloor";
            labelFloor.Size = new Size(37, 15);
            labelFloor.TabIndex = 15;
            labelFloor.Text = "Этаж:";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(483, 109);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(59, 15);
            labelPhone.TabIndex = 16;
            labelPhone.Text = "Телефон:";
            // 
            // labelResponsibleStaff
            // 
            labelResponsibleStaff.AutoSize = true;
            labelResponsibleStaff.Location = new Point(400, 180);
            labelResponsibleStaff.Name = "labelResponsibleStaff";
            labelResponsibleStaff.Size = new Size(142, 15);
            labelResponsibleStaff.TabIndex = 17;
            labelResponsibleStaff.Text = "Отвественный за номер:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(208, -1);
            label1.Name = "label1";
            label1.Size = new Size(382, 54);
            label1.TabIndex = 18;
            label1.Text = "Просмотр номеров";
            // 
            // FormEditRoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(853, 615);
            Controls.Add(label1);
            Controls.Add(labelResponsibleStaff);
            Controls.Add(labelPhone);
            Controls.Add(labelFloor);
            Controls.Add(labelStatus);
            Controls.Add(labelRoomType);
            Controls.Add(labelRoomNumber);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(comboBoxResponsibleStaff);
            Controls.Add(numericFloor);
            Controls.Add(comboBoxStatus);
            Controls.Add(comboBoxRoomType);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxRoomNumber);
            Controls.Add(dataGridView1);
            Name = "FormEditRoom";
            Text = "FormEditRoom";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFloor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBoxRoomNumber;
        private TextBox textBoxPhone;
        private ComboBox comboBoxRoomType;
        private ComboBox comboBoxStatus;
        private NumericUpDown numericFloor;
        private ComboBox comboBoxResponsibleStaff;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonSendToServer;
        private Button buttonCancel;
        private Label labelRoomNumber;
        private Label labelRoomType;
        private Label labelStatus;
        private Label labelFloor;
        private Label labelPhone;
        private Label labelResponsibleStaff;
        private Label label1;
    }
}