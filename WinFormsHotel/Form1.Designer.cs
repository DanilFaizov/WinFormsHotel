namespace WinFormsHotel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonClient = new Button();
            buttonAdminisrator = new Button();
            buttonEmployee = new Button();
            buttonLoad = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonClient
            // 
            buttonClient.BackColor = SystemColors.ControlLight;
            buttonClient.Cursor = Cursors.Hand;
            buttonClient.Font = new Font("Segoe UI", 15F);
            buttonClient.Location = new Point(15, 85);
            buttonClient.Name = "buttonClient";
            buttonClient.Size = new Size(282, 44);
            buttonClient.TabIndex = 0;
            buttonClient.Text = "Клиент";
            buttonClient.TextAlign = ContentAlignment.TopCenter;
            buttonClient.UseVisualStyleBackColor = false;
            buttonClient.Click += buttonClient_Click;
            // 
            // buttonAdminisrator
            // 
            buttonAdminisrator.BackColor = SystemColors.ControlLight;
            buttonAdminisrator.Font = new Font("Segoe UI", 15F);
            buttonAdminisrator.Location = new Point(15, 151);
            buttonAdminisrator.Name = "buttonAdminisrator";
            buttonAdminisrator.Size = new Size(282, 47);
            buttonAdminisrator.TabIndex = 1;
            buttonAdminisrator.Text = "Администратор";
            buttonAdminisrator.UseVisualStyleBackColor = false;
            buttonAdminisrator.Click += buttonAdminisrator_Click;
            // 
            // buttonEmployee
            // 
            buttonEmployee.BackColor = SystemColors.ControlLight;
            buttonEmployee.Font = new Font("Segoe UI", 15F);
            buttonEmployee.Location = new Point(15, 221);
            buttonEmployee.Name = "buttonEmployee";
            buttonEmployee.RightToLeft = RightToLeft.Yes;
            buttonEmployee.Size = new Size(282, 39);
            buttonEmployee.TabIndex = 2;
            buttonEmployee.Text = "Служащие";
            buttonEmployee.UseVisualStyleBackColor = false;
            buttonEmployee.Click += ButtonEmployee_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.BackColor = SystemColors.ControlLight;
            buttonLoad.Location = new Point(67, 286);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(173, 63);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Загрузка с сервера";
            buttonLoad.UseVisualStyleBackColor = false;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(39, 9);
            label1.Name = "label1";
            label1.Size = new Size(223, 54);
            label1.TabIndex = 4;
            label1.Text = "Гостиница ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(311, 373);
            Controls.Add(label1);
            Controls.Add(buttonLoad);
            Controls.Add(buttonEmployee);
            Controls.Add(buttonAdminisrator);
            Controls.Add(buttonClient);
            ForeColor = SystemColors.ControlText;
            Name = "Form1";
            Text = "Гостиница";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClient;
        private Button buttonAdminisrator;
        private Button buttonEmployee;
        private Button buttonLoad;
        private Label label1;
    }
}
