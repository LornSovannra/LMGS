
namespace Library_MGS.Forms
{
    partial class BookForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbRemark = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBookTypeID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBookSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumCopies = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumOfPages = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEdition = new System.Windows.Forms.ComboBox();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.CausesValidation = false;
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.dgvBook);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1205, 662);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.rtbRemark);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cbBookTypeID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtBookSource);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPublisher);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNumCopies);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtNumOfPages);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbEdition);
            this.panel1.Controls.Add(this.dtpPublishDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtBookTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBookID);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 234);
            this.panel1.TabIndex = 2;
            // 
            // rtbRemark
            // 
            this.rtbRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRemark.Location = new System.Drawing.Point(772, 108);
            this.rtbRemark.Name = "rtbRemark";
            this.rtbRemark.Size = new System.Drawing.Size(277, 112);
            this.rtbRemark.TabIndex = 9;
            this.rtbRemark.Text = "";
            this.rtbRemark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtbRemark_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(766, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 32);
            this.label10.TabIndex = 103;
            this.label10.Text = "Remark";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(766, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 32);
            this.label9.TabIndex = 101;
            this.label9.Text = "Type ID";
            // 
            // cbBookTypeID
            // 
            this.cbBookTypeID.DropDownHeight = 200;
            this.cbBookTypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBookTypeID.FormattingEnabled = true;
            this.cbBookTypeID.IntegralHeight = false;
            this.cbBookTypeID.Location = new System.Drawing.Point(858, 20);
            this.cbBookTypeID.Name = "cbBookTypeID";
            this.cbBookTypeID.Size = new System.Drawing.Size(191, 28);
            this.cbBookTypeID.TabIndex = 8;
            this.cbBookTypeID.SelectedIndexChanged += new System.EventHandler(this.cbBookTypeID_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(399, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 32);
            this.label8.TabIndex = 99;
            this.label8.Text = "Book Source";
            // 
            // txtBookSource
            // 
            this.txtBookSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookSource.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtBookSource.Location = new System.Drawing.Point(531, 181);
            this.txtBookSource.Name = "txtBookSource";
            this.txtBookSource.Size = new System.Drawing.Size(215, 39);
            this.txtBookSource.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(399, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 32);
            this.label5.TabIndex = 97;
            this.label5.Text = "Publisher";
            // 
            // txtPublisher
            // 
            this.txtPublisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublisher.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtPublisher.Location = new System.Drawing.Point(531, 124);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(215, 39);
            this.txtPublisher.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(399, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 32);
            this.label3.TabIndex = 95;
            this.label3.Text = "Num Copies";
            // 
            // txtNumCopies
            // 
            this.txtNumCopies.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumCopies.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtNumCopies.Location = new System.Drawing.Point(531, 14);
            this.txtNumCopies.Name = "txtNumCopies";
            this.txtNumCopies.Size = new System.Drawing.Size(215, 39);
            this.txtNumCopies.TabIndex = 4;
            this.txtNumCopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCopies_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(13, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 32);
            this.label7.TabIndex = 93;
            this.label7.Text = "Num of Pages";
            // 
            // txtNumOfPages
            // 
            this.txtNumOfPages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumOfPages.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtNumOfPages.Location = new System.Drawing.Point(159, 180);
            this.txtNumOfPages.Name = "txtNumOfPages";
            this.txtNumOfPages.Size = new System.Drawing.Size(217, 39);
            this.txtNumOfPages.TabIndex = 3;
            this.txtNumOfPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumOfPages_KeyPress);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(65)))), ((int)(((byte)(68)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1065, 137);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 50);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(1065, 81);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 50);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(116)))), ((int)(((byte)(117)))));
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(1065, 14);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(101, 61);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(399, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 32);
            this.label2.TabIndex = 79;
            this.label2.Text = "Edition";
            // 
            // cbEdition
            // 
            this.cbEdition.DropDownHeight = 200;
            this.cbEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEdition.FormattingEnabled = true;
            this.cbEdition.IntegralHeight = false;
            this.cbEdition.Location = new System.Drawing.Point(531, 74);
            this.cbEdition.Name = "cbEdition";
            this.cbEdition.Size = new System.Drawing.Size(215, 28);
            this.cbEdition.TabIndex = 5;
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.CustomFormat = "dd-MMMM-yy";
            this.dtpPublishDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPublishDate.Location = new System.Drawing.Point(159, 129);
            this.dtpPublishDate.Name = "dtpPublishDate";
            this.dtpPublishDate.Size = new System.Drawing.Size(217, 26);
            this.dtpPublishDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(13, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 32);
            this.label6.TabIndex = 77;
            this.label6.Text = "Publish Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(13, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 32);
            this.label4.TabIndex = 73;
            this.label4.Text = "Book Title";
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookTitle.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtBookTitle.Location = new System.Drawing.Point(159, 69);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(217, 39);
            this.txtBookTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 30;
            this.label1.Text = "Book ID";
            // 
            // txtBookID
            // 
            this.txtBookID.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtBookID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBookID.Enabled = false;
            this.txtBookID.Font = new System.Drawing.Font("Khmer Moul", 12F, System.Drawing.FontStyle.Bold);
            this.txtBookID.Location = new System.Drawing.Point(159, 14);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(217, 39);
            this.txtBookID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(5, 249);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 46);
            this.panel2.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(213, 31);
            this.label11.TabIndex = 59;
            this.label11.Text = "SEARCH BOOK";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(224, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(951, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvBook
            // 
            this.dgvBook.AllowUserToAddRows = false;
            this.dgvBook.AllowUserToDeleteRows = false;
            this.dgvBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBook.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBook.BackgroundColor = System.Drawing.Color.White;
            this.dgvBook.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Location = new System.Drawing.Point(5, 305);
            this.dgvBook.Margin = new System.Windows.Forms.Padding(5, 5, 4, 5);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.ReadOnly = true;
            this.dgvBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBook.Size = new System.Drawing.Size(1175, 570);
            this.dgvBook.TabIndex = 54;
            this.dgvBook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellClick);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 662);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BookForm";
            this.Text = "Book";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEdition;
        private System.Windows.Forms.DateTimePicker dtpPublishDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumCopies;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumOfPages;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBookSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBookTypeID;
        private System.Windows.Forms.RichTextBox rtbRemark;
        private System.Windows.Forms.Label label10;
    }
}