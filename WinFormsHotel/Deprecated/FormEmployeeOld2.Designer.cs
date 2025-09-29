namespace WinFormsHotel
{
    partial class FormEmployeeOld2
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
            labelFirstName = new Label();
            labelLastName = new Label();
            labelMiddleName = new Label();
            labelHireDate = new Label();
            labelDismissalDate = new Label();
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            datePickerHireDate = new DateTimePicker();
            datePickerDismissalDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(97, 49);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(200, 23);
            textBoxFirstName.TabIndex = 0;
            textBoxFirstName.Tag = "first_name";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(97, 106);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(200, 23);
            textBoxLastName.TabIndex = 1;
            textBoxLastName.Tag = "last_name";
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(97, 166);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(200, 23);
            textBoxMiddleName.TabIndex = 2;
            textBoxMiddleName.Tag = "middle_name";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(33, 49);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(31, 15);
            labelFirstName.TabIndex = 5;
            labelFirstName.Text = "Имя";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(33, 109);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(58, 15);
            labelLastName.TabIndex = 6;
            labelLastName.Text = "Фамилия";
            // 
            // labelMiddleName
            // 
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(33, 169);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(58, 15);
            labelMiddleName.TabIndex = 7;
            labelMiddleName.Text = "Отчество";
            // 
            // labelHireDate
            // 
            labelHireDate.AutoSize = true;
            labelHireDate.Location = new Point(448, 52);
            labelHireDate.Name = "labelHireDate";
            labelHireDate.Size = new Size(70, 15);
            labelHireDate.TabIndex = 8;
            labelHireDate.Text = "Дата найма";
            // 
            // labelDismissalDate
            // 
            labelDismissalDate.AutoSize = true;
            labelDismissalDate.Location = new Point(418, 109);
            labelDismissalDate.Name = "labelDismissalDate";
            labelDismissalDate.Size = new Size(100, 15);
            labelDismissalDate.TabIndex = 9;
            labelDismissalDate.Text = "Дата увольнения";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(42, 269);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(690, 164);
            dataGridView1.TabIndex = 10;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(22, 520);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(89, 27);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(133, 520);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(87, 27);
            buttonUpdate.TabIndex = 12;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(246, 520);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(81, 27);
            buttonDelete.TabIndex = 13;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(358, 502);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(182, 45);
            buttonSendToServer.TabIndex = 14;
            buttonSendToServer.Text = "Сохранить на сервер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(564, 502);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(168, 45);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Отменить сохранения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // datePickerHireDate
            // 
            datePickerHireDate.Location = new Point(532, 49);
            datePickerHireDate.Name = "datePickerHireDate";
            datePickerHireDate.Size = new Size(200, 23);
            datePickerHireDate.TabIndex = 16;
            datePickerHireDate.Tag = "hire_date";
            // 
            // datePickerDismissalDate
            // 
            datePickerDismissalDate.Location = new Point(532, 106);
            datePickerDismissalDate.Name = "datePickerDismissalDate";
            datePickerDismissalDate.Size = new Size(200, 23);
            datePickerDismissalDate.TabIndex = 17;
            datePickerDismissalDate.Tag = "dismissal_date";
            // 
            // FormEmployeeTwo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 627);
            Controls.Add(datePickerDismissalDate);
            Controls.Add(datePickerHireDate);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Controls.Add(labelDismissalDate);
            Controls.Add(labelHireDate);
            Controls.Add(labelMiddleName);
            Controls.Add(labelLastName);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxMiddleName);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirstName);
            Name = "FormEmployeeTwo";
            Text = "FormEmployeeTwo";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxMiddleName;
        private Label labelFirstName;
        private Label labelLastName;
        private Label labelMiddleName;
        private Label labelHireDate;
        private Label labelDismissalDate;
        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonSendToServer;
        private Button buttonCancel;
        private DateTimePicker datePickerHireDate;
        private DateTimePicker datePickerDismissalDate;
    }
}