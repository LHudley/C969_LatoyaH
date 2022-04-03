
namespace C969_LatoyaH
{
    partial class CustomerRecords
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.RecordsdataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRcAdd = new System.Windows.Forms.Button();
            this.btnRcUpdate = new System.Windows.Forms.Button();
            this.btnRcDelete = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.lblCusAdd1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblCusCity = new System.Windows.Forms.Label();
            this.lblCusZip = new System.Windows.Forms.Label();
            this.lblCusCountry = new System.Windows.Forms.Label();
            this.lblCusPhone = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtCusAdd1 = new System.Windows.Forms.TextBox();
            this.txtCusAdd2 = new System.Windows.Forms.TextBox();
            this.txtCusCity = new System.Windows.Forms.TextBox();
            this.txtCusZip = new System.Windows.Forms.TextBox();
            this.txtCusCountry = new System.Windows.Forms.TextBox();
            this.txtCusPhone = new System.Windows.Forms.TextBox();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnAppt = new System.Windows.Forms.Button();
            this.btnRecords = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordsdataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnAppt);
            this.panel1.Controls.Add(this.btnRecords);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 679);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 52);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(195)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(159, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(640, 55);
            this.panel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(229, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Records";
            // 
            // RecordsdataGridView1
            // 
            this.RecordsdataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecordsdataGridView1.Location = new System.Drawing.Point(190, 98);
            this.RecordsdataGridView1.Name = "RecordsdataGridView1";
            this.RecordsdataGridView1.RowHeadersVisible = false;
            this.RecordsdataGridView1.Size = new System.Drawing.Size(583, 284);
            this.RecordsdataGridView1.TabIndex = 2;
            this.RecordsdataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RecordsdataGridView1_CellContentClick);
            // 
            // btnRcAdd
            // 
            this.btnRcAdd.BackColor = System.Drawing.Color.Black;
            this.btnRcAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRcAdd.ForeColor = System.Drawing.Color.White;
            this.btnRcAdd.Location = new System.Drawing.Point(190, 388);
            this.btnRcAdd.Name = "btnRcAdd";
            this.btnRcAdd.Size = new System.Drawing.Size(75, 37);
            this.btnRcAdd.TabIndex = 3;
            this.btnRcAdd.Text = "Add";
            this.btnRcAdd.UseVisualStyleBackColor = false;
            this.btnRcAdd.Click += new System.EventHandler(this.btnRcAdd_Click);
            // 
            // btnRcUpdate
            // 
            this.btnRcUpdate.BackColor = System.Drawing.Color.Black;
            this.btnRcUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRcUpdate.ForeColor = System.Drawing.Color.White;
            this.btnRcUpdate.Location = new System.Drawing.Point(304, 388);
            this.btnRcUpdate.Name = "btnRcUpdate";
            this.btnRcUpdate.Size = new System.Drawing.Size(75, 37);
            this.btnRcUpdate.TabIndex = 4;
            this.btnRcUpdate.Text = "Update";
            this.btnRcUpdate.UseVisualStyleBackColor = false;
            this.btnRcUpdate.Click += new System.EventHandler(this.btnRcUpdate_Click);
            // 
            // btnRcDelete
            // 
            this.btnRcDelete.BackColor = System.Drawing.Color.Black;
            this.btnRcDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRcDelete.ForeColor = System.Drawing.Color.White;
            this.btnRcDelete.Location = new System.Drawing.Point(413, 388);
            this.btnRcDelete.Name = "btnRcDelete";
            this.btnRcDelete.Size = new System.Drawing.Size(75, 37);
            this.btnRcDelete.TabIndex = 5;
            this.btnRcDelete.Text = "Delete";
            this.btnRcDelete.UseVisualStyleBackColor = false;
            this.btnRcDelete.Click += new System.EventHandler(this.btnRcDelete_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(337, 73);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 15);
            this.labelTime.TabIndex = 6;
            // 
            // lblCusAdd1
            // 
            this.lblCusAdd1.AutoSize = true;
            this.lblCusAdd1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusAdd1.Location = new System.Drawing.Point(177, 481);
            this.lblCusAdd1.Name = "lblCusAdd1";
            this.lblCusAdd1.Size = new System.Drawing.Size(62, 15);
            this.lblCusAdd1.TabIndex = 7;
            this.lblCusAdd1.Text = "Address:";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.Location = new System.Drawing.Point(177, 511);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(74, 15);
            this.lblAddress2.TabIndex = 8;
            this.lblAddress2.Text = "Address 2:";
            // 
            // lblCusCity
            // 
            this.lblCusCity.AutoSize = true;
            this.lblCusCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusCity.Location = new System.Drawing.Point(177, 544);
            this.lblCusCity.Name = "lblCusCity";
            this.lblCusCity.Size = new System.Drawing.Size(34, 15);
            this.lblCusCity.TabIndex = 9;
            this.lblCusCity.Text = "City:";
            // 
            // lblCusZip
            // 
            this.lblCusZip.AutoSize = true;
            this.lblCusZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusZip.Location = new System.Drawing.Point(177, 578);
            this.lblCusZip.Name = "lblCusZip";
            this.lblCusZip.Size = new System.Drawing.Size(31, 15);
            this.lblCusZip.TabIndex = 10;
            this.lblCusZip.Text = "Zip:";
            // 
            // lblCusCountry
            // 
            this.lblCusCountry.AutoSize = true;
            this.lblCusCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusCountry.Location = new System.Drawing.Point(177, 608);
            this.lblCusCountry.Name = "lblCusCountry";
            this.lblCusCountry.Size = new System.Drawing.Size(59, 15);
            this.lblCusCountry.TabIndex = 11;
            this.lblCusCountry.Text = "Country:";
            // 
            // lblCusPhone
            // 
            this.lblCusPhone.AutoSize = true;
            this.lblCusPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusPhone.Location = new System.Drawing.Point(177, 635);
            this.lblCusPhone.Name = "lblCusPhone";
            this.lblCusPhone.Size = new System.Drawing.Size(52, 15);
            this.lblCusPhone.TabIndex = 12;
            this.lblCusPhone.Text = "Phone:";
            // 
            // lblCusName
            // 
            this.lblCusName.AutoSize = true;
            this.lblCusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCusName.Location = new System.Drawing.Point(177, 447);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(49, 15);
            this.lblCusName.TabIndex = 13;
            this.lblCusName.Text = "Name:";
            // 
            // txtCusName
            // 
            this.txtCusName.Location = new System.Drawing.Point(313, 447);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.Size = new System.Drawing.Size(345, 20);
            this.txtCusName.TabIndex = 14;
            // 
            // txtCusAdd1
            // 
            this.txtCusAdd1.Location = new System.Drawing.Point(313, 476);
            this.txtCusAdd1.Name = "txtCusAdd1";
            this.txtCusAdd1.Size = new System.Drawing.Size(345, 20);
            this.txtCusAdd1.TabIndex = 15;
            // 
            // txtCusAdd2
            // 
            this.txtCusAdd2.Location = new System.Drawing.Point(313, 506);
            this.txtCusAdd2.Name = "txtCusAdd2";
            this.txtCusAdd2.Size = new System.Drawing.Size(345, 20);
            this.txtCusAdd2.TabIndex = 16;
            // 
            // txtCusCity
            // 
            this.txtCusCity.Location = new System.Drawing.Point(313, 539);
            this.txtCusCity.Name = "txtCusCity";
            this.txtCusCity.Size = new System.Drawing.Size(345, 20);
            this.txtCusCity.TabIndex = 17;
            // 
            // txtCusZip
            // 
            this.txtCusZip.Location = new System.Drawing.Point(313, 573);
            this.txtCusZip.Name = "txtCusZip";
            this.txtCusZip.Size = new System.Drawing.Size(345, 20);
            this.txtCusZip.TabIndex = 18;
            // 
            // txtCusCountry
            // 
            this.txtCusCountry.Location = new System.Drawing.Point(313, 603);
            this.txtCusCountry.Name = "txtCusCountry";
            this.txtCusCountry.Size = new System.Drawing.Size(345, 20);
            this.txtCusCountry.TabIndex = 19;
            // 
            // txtCusPhone
            // 
            this.txtCusPhone.Location = new System.Drawing.Point(313, 630);
            this.txtCusPhone.Name = "txtCusPhone";
            this.txtCusPhone.Size = new System.Drawing.Size(345, 20);
            this.txtCusPhone.TabIndex = 20;
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Image = global::C969_LatoyaH.Properties.Resources.statistics_32;
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(0, 290);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(161, 94);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnAppt
            // 
            this.btnAppt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAppt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAppt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppt.ForeColor = System.Drawing.Color.White;
            this.btnAppt.Image = global::C969_LatoyaH.Properties.Resources.clipboard_8_32;
            this.btnAppt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAppt.Location = new System.Drawing.Point(0, 75);
            this.btnAppt.Name = "btnAppt";
            this.btnAppt.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnAppt.Size = new System.Drawing.Size(161, 94);
            this.btnAppt.TabIndex = 3;
            this.btnAppt.Text = "Appointments";
            this.btnAppt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAppt.UseVisualStyleBackColor = false;
            this.btnAppt.Click += new System.EventHandler(this.btnAppt_Click);
            // 
            // btnRecords
            // 
            this.btnRecords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRecords.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecords.ForeColor = System.Drawing.Color.White;
            this.btnRecords.Image = global::C969_LatoyaH.Properties.Resources.database_32;
            this.btnRecords.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecords.Location = new System.Drawing.Point(0, 184);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Padding = new System.Windows.Forms.Padding(11, 0, 0, 0);
            this.btnRecords.Size = new System.Drawing.Size(161, 94);
            this.btnRecords.TabIndex = 2;
            this.btnRecords.Text = "Records";
            this.btnRecords.UseVisualStyleBackColor = false;
            // 
            // CustomerRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 676);
            this.Controls.Add(this.txtCusPhone);
            this.Controls.Add(this.txtCusCountry);
            this.Controls.Add(this.txtCusZip);
            this.Controls.Add(this.txtCusCity);
            this.Controls.Add(this.txtCusAdd2);
            this.Controls.Add(this.txtCusAdd1);
            this.Controls.Add(this.txtCusName);
            this.Controls.Add(this.lblCusName);
            this.Controls.Add(this.lblCusPhone);
            this.Controls.Add(this.lblCusCountry);
            this.Controls.Add(this.lblCusZip);
            this.Controls.Add(this.lblCusCity);
            this.Controls.Add(this.lblAddress2);
            this.Controls.Add(this.lblCusAdd1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.btnRcDelete);
            this.Controls.Add(this.btnRcUpdate);
            this.Controls.Add(this.btnRcAdd);
            this.Controls.Add(this.RecordsdataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerRecords";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecordsdataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAppt;
        private System.Windows.Forms.Button btnRecords;
        private System.Windows.Forms.DataGridView RecordsdataGridView1;
        private System.Windows.Forms.Button btnRcAdd;
        private System.Windows.Forms.Button btnRcUpdate;
        private System.Windows.Forms.Button btnRcDelete;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label lblCusAdd1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblCusCity;
        private System.Windows.Forms.Label lblCusZip;
        private System.Windows.Forms.Label lblCusCountry;
        private System.Windows.Forms.Label lblCusPhone;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtCusAdd1;
        private System.Windows.Forms.TextBox txtCusAdd2;
        private System.Windows.Forms.TextBox txtCusCity;
        private System.Windows.Forms.TextBox txtCusZip;
        private System.Windows.Forms.TextBox txtCusCountry;
        private System.Windows.Forms.TextBox txtCusPhone;
    }
}