namespace task16
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.databasetask16DataSet = new task16.databasetask16DataSet();
            this.humanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.humanTableAdapter = new task16.databasetask16DataSetTableAdapters.humanTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patronymicDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textId = new System.Windows.Forms.TextBox();
            this.textSurName = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.textPatronymic = new System.Windows.Forms.TextBox();
            this.textOrganization = new System.Windows.Forms.TextBox();
            this.textPosition = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textNumberPhone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Add_but = new System.Windows.Forms.Button();
            this.UpDate_but = new System.Windows.Forms.Button();
            this.Delete_but = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.databasetask16DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // databasetask16DataSet
            // 
            this.databasetask16DataSet.DataSetName = "databasetask16DataSet";
            this.databasetask16DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // humanBindingSource
            // 
            this.humanBindingSource.DataMember = "human";
            this.humanBindingSource.DataSource = this.databasetask16DataSet;
            // 
            // humanTableAdapter
            // 
            this.humanTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.surNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.patronymicDataGridViewTextBoxColumn,
            this.organizationDataGridViewTextBoxColumn,
            this.positionDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.numberPhoneDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.humanBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(-21, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(849, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // surNameDataGridViewTextBoxColumn
            // 
            this.surNameDataGridViewTextBoxColumn.DataPropertyName = "SurName";
            this.surNameDataGridViewTextBoxColumn.HeaderText = "SurName";
            this.surNameDataGridViewTextBoxColumn.Name = "surNameDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // patronymicDataGridViewTextBoxColumn
            // 
            this.patronymicDataGridViewTextBoxColumn.DataPropertyName = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn.HeaderText = "Patronymic";
            this.patronymicDataGridViewTextBoxColumn.Name = "patronymicDataGridViewTextBoxColumn";
            // 
            // organizationDataGridViewTextBoxColumn
            // 
            this.organizationDataGridViewTextBoxColumn.DataPropertyName = "Organization";
            this.organizationDataGridViewTextBoxColumn.HeaderText = "Organization";
            this.organizationDataGridViewTextBoxColumn.Name = "organizationDataGridViewTextBoxColumn";
            // 
            // positionDataGridViewTextBoxColumn
            // 
            this.positionDataGridViewTextBoxColumn.DataPropertyName = "Position";
            this.positionDataGridViewTextBoxColumn.HeaderText = "Position";
            this.positionDataGridViewTextBoxColumn.Name = "positionDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // numberPhoneDataGridViewTextBoxColumn
            // 
            this.numberPhoneDataGridViewTextBoxColumn.DataPropertyName = "NumberPhone";
            this.numberPhoneDataGridViewTextBoxColumn.HeaderText = "NumberPhone";
            this.numberPhoneDataGridViewTextBoxColumn.Name = "numberPhoneDataGridViewTextBoxColumn";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(132, 18);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(46, 20);
            this.textId.TabIndex = 1;
            // 
            // textSurName
            // 
            this.textSurName.Location = new System.Drawing.Point(132, 44);
            this.textSurName.Name = "textSurName";
            this.textSurName.Size = new System.Drawing.Size(155, 20);
            this.textSurName.TabIndex = 2;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(132, 70);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(155, 20);
            this.textName.TabIndex = 3;
            // 
            // textPatronymic
            // 
            this.textPatronymic.Location = new System.Drawing.Point(132, 96);
            this.textPatronymic.Name = "textPatronymic";
            this.textPatronymic.Size = new System.Drawing.Size(155, 20);
            this.textPatronymic.TabIndex = 4;
            // 
            // textOrganization
            // 
            this.textOrganization.Location = new System.Drawing.Point(132, 122);
            this.textOrganization.Name = "textOrganization";
            this.textOrganization.Size = new System.Drawing.Size(155, 20);
            this.textOrganization.TabIndex = 5;
            // 
            // textPosition
            // 
            this.textPosition.Location = new System.Drawing.Point(132, 148);
            this.textPosition.Name = "textPosition";
            this.textPosition.Size = new System.Drawing.Size(155, 20);
            this.textPosition.TabIndex = 6;
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(132, 174);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(155, 20);
            this.textEmail.TabIndex = 7;
            // 
            // textNumberPhone
            // 
            this.textNumberPhone.Location = new System.Drawing.Point(132, 203);
            this.textNumberPhone.Name = "textNumberPhone";
            this.textNumberPhone.Size = new System.Drawing.Size(155, 20);
            this.textNumberPhone.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "SurName";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Patronymic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Organization";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "NumberPhone";
            // 
            // Add_but
            // 
            this.Add_but.Location = new System.Drawing.Point(325, 203);
            this.Add_but.Name = "Add_but";
            this.Add_but.Size = new System.Drawing.Size(75, 23);
            this.Add_but.TabIndex = 17;
            this.Add_but.Text = "Добавить";
            this.Add_but.UseVisualStyleBackColor = true;
            this.Add_but.Click += new System.EventHandler(this.Add_but_Click);
            // 
            // UpDate_but
            // 
            this.UpDate_but.Location = new System.Drawing.Point(427, 205);
            this.UpDate_but.Name = "UpDate_but";
            this.UpDate_but.Size = new System.Drawing.Size(75, 23);
            this.UpDate_but.TabIndex = 18;
            this.UpDate_but.Text = "Обновитть";
            this.UpDate_but.UseVisualStyleBackColor = true;
            this.UpDate_but.Click += new System.EventHandler(this.UpDate_but_Click);
            // 
            // Delete_but
            // 
            this.Delete_but.Location = new System.Drawing.Point(552, 203);
            this.Delete_but.Name = "Delete_but";
            this.Delete_but.Size = new System.Drawing.Size(75, 23);
            this.Delete_but.TabIndex = 19;
            this.Delete_but.Text = "Удалить";
            this.Delete_but.UseVisualStyleBackColor = true;
            this.Delete_but.Click += new System.EventHandler(this.Delete_but_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 408);
            this.Controls.Add(this.Delete_but);
            this.Controls.Add(this.UpDate_but);
            this.Controls.Add(this.Add_but);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNumberPhone);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.textPosition);
            this.Controls.Add(this.textOrganization);
            this.Controls.Add(this.textPatronymic);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.textSurName);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.databasetask16DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private databasetask16DataSet databasetask16DataSet;
        private System.Windows.Forms.BindingSource humanBindingSource;
        private databasetask16DataSetTableAdapters.humanTableAdapter humanTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patronymicDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textSurName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textPatronymic;
        private System.Windows.Forms.TextBox textOrganization;
        private System.Windows.Forms.TextBox textPosition;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textNumberPhone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Add_but;
        private System.Windows.Forms.Button UpDate_but;
        private System.Windows.Forms.Button Delete_but;
    }
}

