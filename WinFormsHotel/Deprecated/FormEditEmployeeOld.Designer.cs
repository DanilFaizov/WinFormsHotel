namespace WinFormsHotel
{
    partial class FormEditEmployeeOld
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
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonSendToServer = new Button();
            buttonCancel = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(707, 428);
            dataGridView1.TabIndex = 0;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(101, 533);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(109, 45);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Изменить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(249, 533);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(112, 45);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить ";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonSendToServer
            // 
            buttonSendToServer.Location = new Point(607, 521);
            buttonSendToServer.Name = "buttonSendToServer";
            buttonSendToServer.Size = new Size(212, 69);
            buttonSendToServer.TabIndex = 3;
            buttonSendToServer.Text = "Загрузить на сервер ";
            buttonSendToServer.UseVisualStyleBackColor = true;
            buttonSendToServer.Click += buttonSendToServer_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(866, 521);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(193, 69);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Отменить изменения";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(801, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(233, 428);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // FormEditEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 641);
            Controls.Add(groupBox1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSendToServer);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(dataGridView1);
            Name = "FormEditEmployee";
            Text = "FormEditEmployee";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonSendToServer;
        private Button buttonCancel;
        private GroupBox groupBox1;
    }
}