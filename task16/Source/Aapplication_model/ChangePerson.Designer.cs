using System.Windows.Forms;

namespace Aapplication_model
{
    partial class ChangePerson
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
            this.textBox_Id_Person = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_new_SurName = new System.Windows.Forms.TextBox();
            this.textBox_new_Name = new System.Windows.Forms.TextBox();
            this.textBox_new_Patronymic = new System.Windows.Forms.TextBox();
            this.textBox_new_Organization = new System.Windows.Forms.TextBox();
            this.textBox_new_Position = new System.Windows.Forms.TextBox();
            this.textBox_new_Email = new System.Windows.Forms.TextBox();
            this.textBox_new_NumberPhone = new System.Windows.Forms.TextBox();
            this.Change = new System.Windows.Forms.Button();
            this.Id_Person = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Id_Person
            // 
            this.textBox_Id_Person.Location = new System.Drawing.Point(88, 12);
            this.textBox_Id_Person.Name = "textBox_Id_Person";
            this.textBox_Id_Person.Size = new System.Drawing.Size(51, 20);
            this.textBox_Id_Person.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "SurName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Patronymic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Organization";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "NumberPhone";
            // 
            // textBox_new_SurName
            // 
            this.textBox_new_SurName.Location = new System.Drawing.Point(88, 38);
            this.textBox_new_SurName.Name = "textBox_new_SurName";
            this.textBox_new_SurName.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_SurName.TabIndex = 43;
            this.textBox_new_SurName.Text = this._person.SurName;
            // 
            // textBox_new_Name
            // 
            this.textBox_new_Name.Location = new System.Drawing.Point(88, 64);
            this.textBox_new_Name.Name = "textBox_new_Name";
            this.textBox_new_Name.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_Name.TabIndex = 44;
            this.textBox_new_Name.Text = this._person.Name;
            // 
            // textBox_new_Patronymic
            // 
            this.textBox_new_Patronymic.Location = new System.Drawing.Point(88, 90);
            this.textBox_new_Patronymic.Name = "textBox_new_Patronymic";
            this.textBox_new_Patronymic.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_Patronymic.TabIndex = 45;
            this.textBox_new_Patronymic.Text = this._person.Patronymic;
            // 
            // textBox_new_Organization
            // 
            this.textBox_new_Organization.Location = new System.Drawing.Point(88, 116);
            this.textBox_new_Organization.Name = "textBox_new_Organization";
            this.textBox_new_Organization.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_Organization.TabIndex = 46;
            this.textBox_new_Organization.Text = this._person.Organization;
            // 
            // textBox_new_Position
            // 
            this.textBox_new_Position.Location = new System.Drawing.Point(88, 142);
            this.textBox_new_Position.Name = "textBox_new_Position";
            this.textBox_new_Position.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_Position.TabIndex = 47;
            this.textBox_new_Position.Text = this._person.Position;
            // 
            // textBox_new_Email
            // 
            this.textBox_new_Email.Location = new System.Drawing.Point(88, 168);
            this.textBox_new_Email.Name = "textBox_new_Email";
            this.textBox_new_Email.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_Email.TabIndex = 48;
            this.textBox_new_Email.Text = this._person.Email;
            // 
            // textBox_new_NumberPhone
            // 
            this.textBox_new_NumberPhone.Location = new System.Drawing.Point(88, 197);
            this.textBox_new_NumberPhone.Name = "textBox_new_NumberPhone";
            this.textBox_new_NumberPhone.Size = new System.Drawing.Size(173, 20);
            this.textBox_new_NumberPhone.TabIndex = 49;
            this.textBox_new_NumberPhone.Text = this._person.NumberPhone;
            // 
            // Change
            // 
            this.Change.Location = new System.Drawing.Point(186, 223);
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(75, 23);
            this.Change.TabIndex = 50;
            this.Change.Text = "Change";
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // Id_Person
            // 
            this.Id_Person.AutoSize = true;
            this.Id_Person.Location = new System.Drawing.Point(13, 18);
            this.Id_Person.Name = "Id_Person";
            this.Id_Person.Size = new System.Drawing.Size(52, 13);
            this.Id_Person.TabIndex = 51;
            this.Id_Person.Text = "Id Person";
            // 
            // ChangePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 296);
            this.Controls.Add(this.Id_Person);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.textBox_new_NumberPhone);
            this.Controls.Add(this.textBox_new_Email);
            this.Controls.Add(this.textBox_new_Position);
            this.Controls.Add(this.textBox_new_Organization);
            this.Controls.Add(this.textBox_new_Patronymic);
            this.Controls.Add(this.textBox_new_Name);
            this.Controls.Add(this.textBox_new_SurName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Id_Person);
            this.Name = "ChangePerson";
            this.Text = "ChangePerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Id_Person;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_new_SurName;
        private System.Windows.Forms.TextBox textBox_new_Name;
        private System.Windows.Forms.TextBox textBox_new_Patronymic;
        private System.Windows.Forms.TextBox textBox_new_Organization;
        private System.Windows.Forms.TextBox textBox_new_Position;
        private System.Windows.Forms.TextBox textBox_new_Email;
        private System.Windows.Forms.TextBox textBox_new_NumberPhone;
        private System.Windows.Forms.Button Change;
        private System.Windows.Forms.Label Id_Person;
    }
}