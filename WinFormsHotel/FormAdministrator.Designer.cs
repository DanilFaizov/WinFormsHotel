namespace WinFormsHotel
{
    partial class FormAdministrator
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
            buttonEditRoom = new Button();
            buttonEditEmployee = new Button();
            buttonReport = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonEditRoom
            // 
            buttonEditRoom.BackColor = SystemColors.ControlLight;
            buttonEditRoom.Font = new Font("Segoe UI", 15F);
            buttonEditRoom.Location = new Point(89, 102);
            buttonEditRoom.Name = "buttonEditRoom";
            buttonEditRoom.Size = new Size(223, 54);
            buttonEditRoom.TabIndex = 2;
            buttonEditRoom.Text = "Номера ";
            buttonEditRoom.UseVisualStyleBackColor = false;
            buttonEditRoom.Click += buttonEditRoom_Click;
            // 
            // buttonEditEmployee
            // 
            buttonEditEmployee.BackColor = SystemColors.ControlLight;
            buttonEditEmployee.Font = new Font("Segoe UI", 15F);
            buttonEditEmployee.Location = new Point(89, 176);
            buttonEditEmployee.Name = "buttonEditEmployee";
            buttonEditEmployee.Size = new Size(223, 54);
            buttonEditEmployee.TabIndex = 3;
            buttonEditEmployee.Text = "Служащие";
            buttonEditEmployee.UseVisualStyleBackColor = false;
            buttonEditEmployee.Click += buttonEditEmployee_Click;
            // 
            // buttonReport
            // 
            buttonReport.BackColor = SystemColors.ControlLight;
            buttonReport.Font = new Font("Segoe UI", 15F);
            buttonReport.Location = new Point(89, 257);
            buttonReport.Name = "buttonReport";
            buttonReport.Size = new Size(223, 54);
            buttonReport.TabIndex = 4;
            buttonReport.Text = "Отчеты";
            buttonReport.UseVisualStyleBackColor = false;
            buttonReport.Click += buttonReport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(53, 0);
            label1.Name = "label1";
            label1.Size = new Size(309, 54);
            label1.TabIndex = 5;
            label1.Text = "Администратор";
            // 
            // FormAdministrator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(417, 341);
            Controls.Add(label1);
            Controls.Add(buttonReport);
            Controls.Add(buttonEditEmployee);
            Controls.Add(buttonEditRoom);
            Name = "FormAdministrator";
            Text = "FormAdministrator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonEditRoom;
        private Button buttonEditEmployee;
        private Button buttonReport;
        private Label label1;
    }
}