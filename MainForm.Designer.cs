
namespace Library_MGS
{
    partial class MainForm
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
            this.pnNavigation = new System.Windows.Forms.Panel();
            this.btnBlacklist = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLibrarian = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblScreen = new System.Windows.Forms.Label();
            this.lblLibrarianUserType = new System.Windows.Forms.Label();
            this.lblLibrarianName = new System.Windows.Forms.Label();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.pnDesktop = new System.Windows.Forms.Panel();
            this.toolTipNavigation = new System.Windows.Forms.ToolTip(this.components);
            this.pnNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnNavigation
            // 
            this.pnNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.pnNavigation.Controls.Add(this.btnBlacklist);
            this.pnNavigation.Controls.Add(this.btnBook);
            this.pnNavigation.Controls.Add(this.btnLogout);
            this.pnNavigation.Controls.Add(this.btnLibrarian);
            this.pnNavigation.Controls.Add(this.btnStudent);
            this.pnNavigation.Controls.Add(this.btnReturn);
            this.pnNavigation.Controls.Add(this.btnBorrow);
            this.pnNavigation.Controls.Add(this.btnDashboard);
            this.pnNavigation.Controls.Add(this.label1);
            this.pnNavigation.Controls.Add(this.pictureBox1);
            this.pnNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnNavigation.Location = new System.Drawing.Point(0, 0);
            this.pnNavigation.Name = "pnNavigation";
            this.pnNavigation.Size = new System.Drawing.Size(195, 727);
            this.pnNavigation.TabIndex = 0;
            // 
            // btnBlacklist
            // 
            this.btnBlacklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnBlacklist.FlatAppearance.BorderSize = 0;
            this.btnBlacklist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlacklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlacklist.ForeColor = System.Drawing.Color.White;
            this.btnBlacklist.Image = global::Library_MGS.Properties.Resources.blacklist_32px;
            this.btnBlacklist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBlacklist.Location = new System.Drawing.Point(1, 370);
            this.btnBlacklist.Name = "btnBlacklist";
            this.btnBlacklist.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnBlacklist.Size = new System.Drawing.Size(194, 51);
            this.btnBlacklist.TabIndex = 4;
            this.btnBlacklist.Text = "  Bl&acklist";
            this.btnBlacklist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnBlacklist, "Blacklist (Alt+A)");
            this.btnBlacklist.UseVisualStyleBackColor = false;
            this.btnBlacklist.Click += new System.EventHandler(this.btnBlacklist_Click);
            // 
            // btnBook
            // 
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Image = global::Library_MGS.Properties.Resources.book_32px;
            this.btnBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBook.Location = new System.Drawing.Point(0, 313);
            this.btnBook.Name = "btnBook";
            this.btnBook.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnBook.Size = new System.Drawing.Size(194, 51);
            this.btnBook.TabIndex = 3;
            this.btnBook.Text = "  B&ook";
            this.btnBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnBook, "Book (Alt+O)");
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::Library_MGS.Properties.Resources.login_32px;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(1, 676);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(194, 51);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "  Logout";
            this.btnLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnLogout, "Logout");
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLibrarian
            // 
            this.btnLibrarian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnLibrarian.FlatAppearance.BorderSize = 0;
            this.btnLibrarian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLibrarian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLibrarian.ForeColor = System.Drawing.Color.White;
            this.btnLibrarian.Image = global::Library_MGS.Properties.Resources.librarian_32px;
            this.btnLibrarian.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLibrarian.Location = new System.Drawing.Point(1, 484);
            this.btnLibrarian.Name = "btnLibrarian";
            this.btnLibrarian.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnLibrarian.Size = new System.Drawing.Size(194, 51);
            this.btnLibrarian.TabIndex = 6;
            this.btnLibrarian.Text = "  &Librarian";
            this.btnLibrarian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnLibrarian, "Librarian (Alt+L)");
            this.btnLibrarian.UseVisualStyleBackColor = false;
            this.btnLibrarian.Click += new System.EventHandler(this.btnLibrarian_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnStudent.FlatAppearance.BorderSize = 0;
            this.btnStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudent.ForeColor = System.Drawing.Color.White;
            this.btnStudent.Image = global::Library_MGS.Properties.Resources.student_male_32px;
            this.btnStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStudent.Location = new System.Drawing.Point(0, 427);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnStudent.Size = new System.Drawing.Size(194, 51);
            this.btnStudent.TabIndex = 5;
            this.btnStudent.Text = "  &Student";
            this.btnStudent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnStudent, "Student (Alt+S)");
            this.btnStudent.UseVisualStyleBackColor = false;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Image = global::Library_MGS.Properties.Resources.borrow_book_32px1;
            this.btnReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReturn.Location = new System.Drawing.Point(1, 256);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnReturn.Size = new System.Drawing.Size(194, 51);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "  R&eturn";
            this.btnReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnReturn, "Return (Alt+E)");
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Image = global::Library_MGS.Properties.Resources.return_book_48px2;
            this.btnBorrow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrow.Location = new System.Drawing.Point(0, 199);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnBorrow.Size = new System.Drawing.Size(194, 51);
            this.btnBorrow.TabIndex = 1;
            this.btnBorrow.Text = "  &Borrow";
            this.btnBorrow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnBorrow, "Borrow (Alt+B)");
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(56)))), ((int)(((byte)(59)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::Library_MGS.Properties.Resources.dashboard_32px;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 142);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(194, 51);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "  &Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTipNavigation.SetToolTip(this.btnDashboard, "Dashboard (Alt+D)");
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer Moul", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 67);
            this.label1.TabIndex = 0;
            this.label1.Text = "អំណាន";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Library_MGS.Properties.Resources.reading_100px;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(119)))));
            this.pnHeader.Controls.Add(this.lblScreen);
            this.pnHeader.Controls.Add(this.lblLibrarianUserType);
            this.pnHeader.Controls.Add(this.lblLibrarianName);
            this.pnHeader.Controls.Add(this.pbExit);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(195, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1201, 61);
            this.pnHeader.TabIndex = 1;
            this.pnHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseDown);
            this.pnHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseMove);
            this.pnHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnHeader_MouseUp);
            // 
            // lblScreen
            // 
            this.lblScreen.AutoSize = true;
            this.lblScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblScreen.ForeColor = System.Drawing.Color.White;
            this.lblScreen.Location = new System.Drawing.Point(417, 19);
            this.lblScreen.Name = "lblScreen";
            this.lblScreen.Size = new System.Drawing.Size(412, 25);
            this.lblScreen.TabIndex = 10;
            this.lblScreen.Text = "Library Management System - Dashboard";
            // 
            // lblLibrarianUserType
            // 
            this.lblLibrarianUserType.AutoSize = true;
            this.lblLibrarianUserType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLibrarianUserType.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblLibrarianUserType.Location = new System.Drawing.Point(6, 35);
            this.lblLibrarianUserType.Name = "lblLibrarianUserType";
            this.lblLibrarianUserType.Size = new System.Drawing.Size(47, 15);
            this.lblLibrarianUserType.TabIndex = 9;
            this.lblLibrarianUserType.Text = "Admin";
            // 
            // lblLibrarianName
            // 
            this.lblLibrarianName.AutoSize = true;
            this.lblLibrarianName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblLibrarianName.ForeColor = System.Drawing.Color.White;
            this.lblLibrarianName.Location = new System.Drawing.Point(6, 12);
            this.lblLibrarianName.Name = "lblLibrarianName";
            this.lblLibrarianName.Size = new System.Drawing.Size(116, 20);
            this.lblLibrarianName.TabIndex = 8;
            this.lblLibrarianName.Text = "Lorn Sovanra";
            // 
            // pbExit
            // 
            this.pbExit.Image = global::Library_MGS.Properties.Resources.Close_512px;
            this.pbExit.Location = new System.Drawing.Point(1164, 12);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(25, 23);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 7;
            this.pbExit.TabStop = false;
            this.toolTipNavigation.SetToolTip(this.pbExit, "Close");
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // pnDesktop
            // 
            this.pnDesktop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDesktop.Location = new System.Drawing.Point(195, 61);
            this.pnDesktop.Name = "pnDesktop";
            this.pnDesktop.Size = new System.Drawing.Size(1201, 666);
            this.pnDesktop.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 727);
            this.Controls.Add(this.pnDesktop);
            this.Controls.Add(this.pnHeader);
            this.Controls.Add(this.pnNavigation);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.pnNavigation.ResumeLayout(false);
            this.pnNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnNavigation;
        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnLibrarian;
        private System.Windows.Forms.Button btnBlacklist;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnDesktop;
        private System.Windows.Forms.Label lblLibrarianUserType;
        private System.Windows.Forms.Label lblLibrarianName;
        private System.Windows.Forms.Label lblScreen;
        private System.Windows.Forms.ToolTip toolTipNavigation;
    }
}

