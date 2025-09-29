namespace WinFormsHotel
{
    partial class FormEmployeeOld
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
            groupBox1 = new GroupBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(660, 424);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(713, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(190, 424);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(25, 545);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(97, 34);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(160, 545);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(89, 33);
            buttonUpdate.TabIndex = 3;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(280, 545);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 34);
            buttonDelete.TabIndex = 4;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(576, 545);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(136, 45);
            buttonSendToServer.TabIndex = 5;
            buttonSendToServer.Text = "Загрузить на сревер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(735, 545);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(133, 43);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "Отменить изменения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 616);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonCancel);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "FormEmployee";
            Text = "FormEmployee";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonSendToServer;
        private Button buttonCancel;
    }
}