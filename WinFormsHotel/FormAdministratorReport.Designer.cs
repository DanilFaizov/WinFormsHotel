namespace WinFormsHotel.Helpers
{
    partial class FormAdministratorReport
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
            labelReport = new Label();
            labelStart = new Label();
            datePickerStart = new DateTimePicker();
            labelEnd = new Label();
            datePickerEnd = new DateTimePicker();
            buttonGenerate = new Button();
            buttonSortByDate = new Button();
            dataGridViewRevenue = new DataGridView();
            dataGridViewClients = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRevenue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            SuspendLayout();
            // 
            // labelReport
            // 
            labelReport.AutoSize = true;
            labelReport.BackColor = SystemColors.ActiveCaption;
            labelReport.Font = new Font("Segoe UI", 30F);
            labelReport.Location = new Point(472, -2);
            labelReport.Name = "labelReport";
            labelReport.Size = new Size(157, 54);
            labelReport.TabIndex = 0;
            labelReport.Text = "Отчеты";
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Font = new Font("Segoe UI", 15F);
            labelStart.Location = new Point(12, 115);
            labelStart.Name = "labelStart";
            labelStart.Size = new Size(39, 28);
            labelStart.TabIndex = 1;
            labelStart.Text = "От:";
            // 
            // datePickerStart
            // 
            datePickerStart.Location = new Point(51, 120);
            datePickerStart.Name = "datePickerStart";
            datePickerStart.Size = new Size(200, 23);
            datePickerStart.TabIndex = 2;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Font = new Font("Segoe UI", 15F);
            labelEnd.Location = new Point(257, 115);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new Size(39, 28);
            labelEnd.TabIndex = 3;
            labelEnd.Text = "до:";
            // 
            // datePickerEnd
            // 
            datePickerEnd.CalendarMonthBackground = SystemColors.ScrollBar;
            datePickerEnd.Location = new Point(293, 120);
            datePickerEnd.Name = "datePickerEnd";
            datePickerEnd.Size = new Size(200, 23);
            datePickerEnd.TabIndex = 4;
            // 
            // buttonGenerate
            // 
            buttonGenerate.BackColor = SystemColors.ControlLight;
            buttonGenerate.Font = new Font("Segoe UI", 15F);
            buttonGenerate.Location = new Point(711, 131);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(255, 36);
            buttonGenerate.TabIndex = 5;
            buttonGenerate.Text = "Генерация отчета";
            buttonGenerate.UseVisualStyleBackColor = false;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // buttonSortByDate
            // 
            buttonSortByDate.BackColor = SystemColors.ControlLight;
            buttonSortByDate.Font = new Font("Segoe UI", 15F);
            buttonSortByDate.Location = new Point(711, 71);
            buttonSortByDate.Name = "buttonSortByDate";
            buttonSortByDate.Size = new Size(255, 36);
            buttonSortByDate.TabIndex = 6;
            buttonSortByDate.Text = "Сортировать по дате ";
            buttonSortByDate.UseVisualStyleBackColor = false;
            buttonSortByDate.Click += buttonSortByDate_Click;
            // 
            // dataGridViewRevenue
            // 
            dataGridViewRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRevenue.Location = new Point(9, 245);
            dataGridViewRevenue.Name = "dataGridViewRevenue";
            dataGridViewRevenue.Size = new Size(533, 371);
            dataGridViewRevenue.TabIndex = 7;
            // 
            // dataGridViewClients
            // 
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Location = new Point(548, 245);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.Size = new Size(535, 371);
            dataGridViewClients.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(131, 68);
            label1.Name = "label1";
            label1.Size = new Size(266, 37);
            label1.TabIndex = 9;
            label1.Text = "Сортировка по дате";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(9, 214);
            label2.Name = "label2";
            label2.Size = new Size(72, 28);
            label2.TabIndex = 10;
            label2.Text = "Сумма";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(548, 214);
            label3.Name = "label3";
            label3.Size = new Size(91, 28);
            label3.TabIndex = 11;
            label3.Text = "Клиенты";
            // 
            // FormAdministratorReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1095, 640);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewClients);
            Controls.Add(dataGridViewRevenue);
            Controls.Add(buttonSortByDate);
            Controls.Add(buttonGenerate);
            Controls.Add(datePickerEnd);
            Controls.Add(labelEnd);
            Controls.Add(datePickerStart);
            Controls.Add(labelStart);
            Controls.Add(labelReport);
            Name = "FormAdministratorReport";
            Text = "FormAdministratorReport";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRevenue).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelReport;
        private Label labelStart;
        private DateTimePicker datePickerStart;
        private Label labelEnd;
        private DateTimePicker datePickerEnd;
        private Button buttonGenerate;
        private Button buttonSortByDate;
        private DataGridView dataGridViewRevenue;
        private DataGridView dataGridViewClients;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}