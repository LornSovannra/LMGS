using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Oracle.ManagedDataAccess.Client;

namespace Library_MGS
{
    public partial class MainForm : Form
    {
        OracleConnection conn;
        bool mouseDown;
        private Point offset;
        private Form activeForm;

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        private void pnHeader_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void pnHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void pnHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnDesktop.Controls.Add(childForm);
            this.pnDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblScreen.Text = "Library Management System - [" + childForm.Text + "]";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblLibrarianName.Text = Classes.UserLogin.getLibrarianName();
            lblLibrarianUserType.Text = Classes.UserLogin.getUserType();
            OpenChildForm(new Forms.DashboardForm(), sender);

            if(Classes.UserLogin.getUserType() != "Admin")
            {
                btnLibrarian.Visible = false;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.DashboardForm(), sender);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BookForm(), sender);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BorrowForm(), sender);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ReturnForm(), sender);
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.StudentForm(), sender);
        }

        private void btnBlacklist_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.BlacklistForm(), sender);
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Librarian(), sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to logout from the system?", "You're going to log out from the system.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Forms.LoginForm lf = new Forms.LoginForm();
                this.Hide();
                lf.Show();
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "You're going to exit this application.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Alt && e.KeyCode == Keys.D)
            {
                OpenChildForm(new Forms.DashboardForm(), sender);
            }
            else if(e.Alt && e.KeyCode == Keys.B)
            {
                OpenChildForm(new Forms.BorrowForm(), sender);
            }
            else if (e.Alt && e.KeyCode == Keys.E)
            {
                OpenChildForm(new Forms.ReturnForm(), sender);
            }
            else if (e.Alt && e.KeyCode == Keys.O)
            {
                OpenChildForm(new Forms.BookForm(), sender);
            }
            else if (e.Alt && e.KeyCode == Keys.A)
            {
                OpenChildForm(new Forms.BlacklistForm(), sender);
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                OpenChildForm(new Forms.StudentForm(), sender);
            }
            else if (e.Alt && e.KeyCode == Keys.L)
            {
                OpenChildForm(new Forms.Librarian(), sender);
            }
        }
    }
}
