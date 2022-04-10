
namespace C969_LatoyaH
{
    partial class Appointments
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.btnAppt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewAppt = new System.Windows.Forms.DataGridView();
            this.rdBtnMnth = new System.Windows.Forms.RadioButton();
            this.rdBtnWk = new System.Windows.Forms.RadioButton();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.btnUpdtApp = new System.Windows.Forms.Button();
            this.btnDlApp = new System.Windows.Forms.Button();
            this.client_scheduleDataSet = new C969_LatoyaH.client_scheduleDataSet();
            this.clientscheduleDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientscheduleDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnRecords);
            this.panel1.Controls.Add(this.btnAppt);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 679);
            this.panel1.TabIndex = 0;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::C969_LatoyaH.Properties.Resources.statistics_32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 359);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(161, 94);
            this.btnReports.TabIndex = 3;
            this.btnReports.Text = "Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click_1);
            // 
            // btnRecords
            // 
            this.btnRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecords.FlatAppearance.BorderSize = 0;
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.Image = global::C969_LatoyaH.Properties.Resources.database_32;
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(0, 159);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnRecords.Size = new System.Drawing.Size(161, 94);
            this.btnRecords.TabIndex = 2;
            this.btnRecords.Text = "Records";
            this.btnRecords.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecords.UseVisualStyleBackColor = false;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click_1);
            // 
            // btnAppt
            // 
            this.btnAppt.BackColor = System.Drawing.Color.Red;
            this.btnAppt.FlatAppearance.BorderSize = 0;
            this.btnAppt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppt.ForeColor = System.Drawing.Color.White;
            this.btnAppt.Image = global::C969_LatoyaH.Properties.Resources.clipboard_8_32;
            this.btnAppt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppt.Location = new System.Drawing.Point(0, 259);
            this.btnAppt.Name = "btnAppt";
            this.btnAppt.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnAppt.Size = new System.Drawing.Size(161, 94);
            this.btnAppt.TabIndex = 1;
            this.btnAppt.Text = "Appointments";
            this.btnAppt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppt.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 52);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(159, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1026, 55);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(443, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointments";
            // 
            // dataGridViewAppt
            // 
            this.dataGridViewAppt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppt.Location = new System.Drawing.Point(167, 85);
            this.dataGridViewAppt.Name = "dataGridViewAppt";
            this.dataGridViewAppt.ReadOnly = true;
            this.dataGridViewAppt.RowHeadersVisible = false;
            this.dataGridViewAppt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAppt.Size = new System.Drawing.Size(1012, 262);
            this.dataGridViewAppt.TabIndex = 2;
            // 
            // rdBtnMnth
            // 
            this.rdBtnMnth.AutoSize = true;
            this.rdBtnMnth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnMnth.ForeColor = System.Drawing.Color.Red;
            this.rdBtnMnth.Location = new System.Drawing.Point(696, 59);
            this.rdBtnMnth.Name = "rdBtnMnth";
            this.rdBtnMnth.Size = new System.Drawing.Size(65, 19);
            this.rdBtnMnth.TabIndex = 3;
            this.rdBtnMnth.TabStop = true;
            this.rdBtnMnth.Text = "Month";
            this.rdBtnMnth.UseVisualStyleBackColor = true;
            // 
            // rdBtnWk
            // 
            this.rdBtnWk.AutoSize = true;
            this.rdBtnWk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnWk.ForeColor = System.Drawing.Color.Red;
            this.rdBtnWk.Location = new System.Drawing.Point(351, 59);
            this.rdBtnWk.Name = "rdBtnWk";
            this.rdBtnWk.Size = new System.Drawing.Size(60, 19);
            this.rdBtnWk.TabIndex = 4;
            this.rdBtnWk.TabStop = true;
            this.rdBtnWk.Text = "Week\r\n";
            this.rdBtnWk.UseVisualStyleBackColor = true;
            // 
            // btnAddApp
            // 
            this.btnAddApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddApp.Location = new System.Drawing.Point(259, 586);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(75, 41);
            this.btnAddApp.TabIndex = 16;
            this.btnAddApp.Text = "Add";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // btnUpdtApp
            // 
            this.btnUpdtApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdtApp.Location = new System.Drawing.Point(556, 586);
            this.btnUpdtApp.Name = "btnUpdtApp";
            this.btnUpdtApp.Size = new System.Drawing.Size(75, 41);
            this.btnUpdtApp.TabIndex = 17;
            this.btnUpdtApp.Text = "Update";
            this.btnUpdtApp.UseVisualStyleBackColor = true;
            this.btnUpdtApp.Click += new System.EventHandler(this.btnUpdtApp_Click);
            // 
            // btnDlApp
            // 
            this.btnDlApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDlApp.Location = new System.Drawing.Point(832, 586);
            this.btnDlApp.Name = "btnDlApp";
            this.btnDlApp.Size = new System.Drawing.Size(75, 41);
            this.btnDlApp.TabIndex = 18;
            this.btnDlApp.Text = "Delete";
            this.btnDlApp.UseVisualStyleBackColor = true;
            this.btnDlApp.Click += new System.EventHandler(this.btnDlApp_Click);
            // 
            // client_scheduleDataSet
            // 
            this.client_scheduleDataSet.DataSetName = "client_scheduleDataSet";
            this.client_scheduleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientscheduleDataSetBindingSource
            // 
            this.clientscheduleDataSetBindingSource.DataSource = this.client_scheduleDataSet;
            this.clientscheduleDataSetBindingSource.Position = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(369, 369);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 19;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // Appointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 676);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnDlApp);
            this.Controls.Add(this.btnUpdtApp);
            this.Controls.Add(this.btnAddApp);
            this.Controls.Add(this.rdBtnWk);
            this.Controls.Add(this.rdBtnMnth);
            this.Controls.Add(this.dataGridViewAppt);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Appointments";
            this.Text = "Schedule";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Appointments_FormClosed);
            this.Load += new System.EventHandler(this.Appointments_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.client_scheduleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientscheduleDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAppt;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.DataGridView dataGridViewAppt;
        private System.Windows.Forms.RadioButton rdBtnMnth;
        private System.Windows.Forms.RadioButton rdBtnWk;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.Button btnUpdtApp;
        private System.Windows.Forms.Button btnDlApp;
        private System.Windows.Forms.BindingSource clientscheduleDataSetBindingSource;
        private client_scheduleDataSet client_scheduleDataSet;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}