namespace WinFormsHotel
{
    partial class FormEmployeeTwo
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
            label1 = new Label();
            textBoxFirstName = new TextBox();
            labelFirstName = new Label();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            textBoxMiddleName = new TextBox();
            labelMiddleName = new Label();
            textBoxPassport = new TextBox();
            labelPassport = new Label();
            textBoxPhone = new TextBox();
            labelPhone = new Label();
            labelHireDate = new Label();
            buttonSubmit = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(65, 9);
            label1.Name = "label1";
            label1.Size = new Size(293, 54);
            label1.TabIndex = 0;
            label1.Text = "Подача заявки";
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(133, 94);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(213, 23);
            textBoxFirstName.TabIndex = 1;
            textBoxFirstName.Tag = "first_name";
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(36, 97);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(34, 15);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Имя:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(133, 162);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(213, 23);
            textBoxLastName.TabIndex = 3;
            textBoxLastName.Tag = "last_name";
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(36, 162);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(61, 15);
            labelLastName.TabIndex = 4;
            labelLastName.Text = "Фамилия:";
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Location = new Point(133, 223);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(213, 23);
            textBoxMiddleName.TabIndex = 5;
            textBoxMiddleName.Tag = "middle_name";
            // 
            // labelMiddleName
            // 
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(36, 226);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(58, 15);
            labelMiddleName.TabIndex = 6;
            labelMiddleName.Text = "Отчество";
            // 
            // textBoxPassport
            // 
            textBoxPassport.Location = new Point(133, 293);
            textBoxPassport.Name = "textBoxPassport";
            textBoxPassport.Size = new Size(213, 23);
            textBoxPassport.TabIndex = 7;
            textBoxPassport.Tag = "passport";
            // 
            // labelPassport
            // 
            labelPassport.AutoSize = true;
            labelPassport.Location = new Point(36, 296);
            labelPassport.Name = "labelPassport";
            labelPassport.Size = new Size(57, 15);
            labelPassport.TabIndex = 8;
            labelPassport.Text = "Паспорт:";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(133, 340);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(213, 23);
            textBoxPhone.TabIndex = 9;
            textBoxPhone.Tag = "phone";
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(36, 343);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(56, 15);
            labelPhone.TabIndex = 10;
            labelPhone.Text = "Телефон";
            // 
            // labelHireDate
            // 
            labelHireDate.AutoSize = true;
            labelHireDate.Location = new Point(133, 393);
            labelHireDate.Name = "labelHireDate";
            labelHireDate.Size = new Size(38, 15);
            labelHireDate.TabIndex = 11;
            labelHireDate.Text = "label7";
            // 
            // buttonSubmit
            // 
            buttonSubmit.Font = new Font("Segoe UI", 15F);
            buttonSubmit.Location = new Point(76, 452);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(243, 52);
            buttonSubmit.TabIndex = 12;
            buttonSubmit.Text = "Отправить заявку";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 393);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 13;
            label2.Text = "Дата найма:";
            // 
            // FormEmployeeTwo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(411, 536);
            Controls.Add(label2);
            Controls.Add(buttonSubmit);
            Controls.Add(labelHireDate);
            Controls.Add(labelPhone);
            Controls.Add(textBoxPhone);
            Controls.Add(labelPassport);
            Controls.Add(textBoxPassport);
            Controls.Add(labelMiddleName);
            Controls.Add(textBoxMiddleName);
            Controls.Add(labelLastName);
            Controls.Add(textBoxLastName);
            Controls.Add(labelFirstName);
            Controls.Add(textBoxFirstName);
            Controls.Add(label1);
            Name = "FormEmployeeTwo";
            Text = "FormEditEpmloyeeTwo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFirstName;
        private Label labelFirstName;
        private TextBox textBoxLastName;
        private Label labelLastName;
        private TextBox textBoxMiddleName;
        private Label labelMiddleName;
        private TextBox textBoxPassport;
        private Label labelPassport;
        private TextBox textBoxPhone;
        private Label labelPhone;
        private Label labelHireDate;
        private Button buttonSubmit;
        private Label label2;
    }
}