namespace WinFormsHotel
{
    partial class FormEditEmployee
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
            labelStatus = new Label();
            comboBoxStatus = new ComboBox();
            labelDismissal = new Label();
            datePickerDismissal = new DateTimePicker();
            buttonUpdate = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 239);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1036, 309);
            dataGridView1.TabIndex = 0;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(86, 111);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(85, 15);
            labelStatus.TabIndex = 1;
            labelStatus.Text = "Статус заявки:";
            // 
            // comboBoxStatus
            // 
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Location = new Point(177, 108);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(200, 23);
            comboBoxStatus.TabIndex = 2;
            comboBoxStatus.Tag = "status_id";
            // 
            // labelDismissal
            // 
            labelDismissal.AutoSize = true;
            labelDismissal.Location = new Point(68, 177);
            labelDismissal.Name = "labelDismissal";
            labelDismissal.Size = new Size(103, 15);
            labelDismissal.TabIndex = 3;
            labelDismissal.Text = "Дата увольнения:";
            // 
            // datePickerDismissal
            // 
            datePickerDismissal.Location = new Point(177, 171);
            datePickerDismissal.Name = "datePickerDismissal";
            datePickerDismissal.Size = new Size(200, 23);
            datePickerDismissal.TabIndex = 4;
            datePickerDismissal.Tag = "dismissal_date";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(864, 123);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(156, 52);
            buttonUpdate.TabIndex = 5;
            buttonUpdate.Text = "обновить ";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(702, 123);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(156, 52);
            buttonSendToServer.TabIndex = 6;
            buttonSendToServer.Text = "Загрузать на сервер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(529, 123);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(156, 52);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "отмена изменений";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(277, 9);
            label1.Name = "label1";
            label1.Size = new Size(513, 54);
            label1.TabIndex = 8;
            label1.Text = "Управление сотрудниками";
            // 
            // FormEditEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1060, 563);
            Controls.Add(label1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonUpdate);
            Controls.Add(datePickerDismissal);
            Controls.Add(labelDismissal);
            Controls.Add(comboBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(dataGridView1);
            Name = "FormEditEmployee";
            Text = "Редактирование сотрудника";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label labelStatus;
        private ComboBox comboBoxStatus;
        private Label labelDismissal;
        private DateTimePicker datePickerDismissal;
        private Button buttonUpdate;
        private Button buttonSendToServer;
        private Button buttonCancel;
        private Label label1;
    }
}