namespace WinFormsHotel
{
    partial class FormClientOld
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
            buttonCancel = new Button();
            buttonSendToServer = new Button();
            buttonDelete = new Button();
            buttonUpdate = new Button();
            buttonAdd = new Button();
            groupBox1 = new GroupBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(734, 559);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(133, 43);
            buttonCancel.TabIndex = 13;
            buttonCancel.Text = "Отменить изменения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(575, 559);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(136, 45);
            buttonSendToServer.TabIndex = 12;
            buttonSendToServer.Text = "Загрузить на сревер";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(279, 559);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(100, 34);
            buttonDelete.TabIndex = 11;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(159, 559);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(89, 33);
            buttonUpdate.TabIndex = 10;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(24, 559);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(97, 34);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(712, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(190, 424);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(660, 424);
            dataGridView1.TabIndex = 7;
            // 
            // FormClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 631);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "FormClient";
            Text = "FormClient";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCancel;
        private Button buttonSendToServer;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonAdd;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
    }
}