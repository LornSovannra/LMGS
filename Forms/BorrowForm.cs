using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_MGS.Forms
{
    public partial class BorrowForm : Form
    {
        OracleConnection conn;

        public BorrowForm()
        {
            InitializeComponent();
        }

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();
            StudentIDDropDown();
            BookIDDropDown();
            LoadData();
        }

        string StudentID;

        private void cbStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string search_cmd = "SELECT StuID FROM tblStudent WHERE StuName = '" + cbStudentID.SelectedItem + "'";
                OracleCommand cmd = new OracleCommand(search_cmd, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    StudentID = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void StudentIDDropDown()
        {
            string select_sql = "SELECT StuID, StuName FROM tblStudent WHERE IsBlackListed = 0 ORDER BY StuID ASC";
            OracleCommand cmd = new OracleCommand(select_sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbStudentID.Items.Add(dr["StuName"].ToString());
                cbStudentID.DisplayMember = (dr["StuName"].ToString());
                cbStudentID.ValueMember = (dr["StuID"].ToString());
            }
        }

        string BookID;

        private void cbBookID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string search_cmd = "SELECT BookID FROM tblBook WHERE BookTitle = '" + cbBookID.SelectedItem + "'";
                OracleCommand cmd = new OracleCommand(search_cmd, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    BookID = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void BookIDDropDown()
        {
            string select_sql = "SELECT BookID, BookTitle FROM tblBook ORDER BY BookID ASC";
            OracleCommand cmd = new OracleCommand(select_sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbBookID.Items.Add(dr["BookTitle"].ToString());
                cbBookID.DisplayMember = (dr["BookTitle"].ToString());
                cbBookID.ValueMember = (dr["BookID"].ToString());
            }
        }

        void LoadData()
        {
            //string sql = "SELECT tblBorrow.BorrowID, tblStudent.StuName, tblLibrarian.LibrarianName, tblBook.BookTitle, tblBorrow.BorrowDate, tblBorrow.Remark FROM tblBorrow, tblStudent, tblLibrarian, tblBook WHERE tblStudent.StuID = tblBorrow.StuID AND tblLibrarian.LibrarianID = tblBorrow.LibrarianID AND tblBook.BookID = tblBorrow.BookID ORDER BY tblBorrow.BorrowID ASC";
            //string sql = "SELECT * FROM tblBorrow, tblStudent, tblLibrarian, tblBook WHERE tblstudent.stuid = tblborrow.stuid AND tbllibrarian.librarianid = tblborrow.librarianid AND tblbook.bookid = tblborrow.bookid";

            OracleCommand select_cmd = new OracleCommand("SelectBorrow", conn);
            select_cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter adapter = new OracleDataAdapter(select_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvBorrow.DataSource = dt;
            btnReturn.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCreate.Text == "Borrow")
                {
                    btnCreate.Text = "Save";
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete.Text = "Cancel";
                    dgvBorrow.Enabled = false;
                    //ClearField();
                }
                else if (btnCreate.Text == "Save")
                {
                    if (string.IsNullOrEmpty(cbStudentID.Text))
                    {
                        MessageBox.Show("Student ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbBookID.Text))
                    {
                        MessageBox.Show("Book ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpBorrowDate.Text))
                    {
                        MessageBox.Show("Borrow Date can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpReturnDate.Text))
                    {
                        MessageBox.Show("Return Date can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO tblBorrow(StuID, LibrarianID, BookID, BorrowDate, ReturnDate, Remark) VALUES(:2, :3, :4, :5, :6, :7)";
                        OracleCommand insert_command = new OracleCommand(sql, conn);
                        insert_command.Parameters.Add(new OracleParameter("2", Int32.Parse(StudentID)));
                        insert_command.Parameters.Add(new OracleParameter("3", /*Classes.UserLogin.getLibrarianID()*/1));
                        insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(BookID)));
                        insert_command.Parameters.Add(new OracleParameter("5", dtpBorrowDate.Value));
                        insert_command.Parameters.Add(new OracleParameter("6", dtpReturnDate.Value));
                        insert_command.Parameters.Add(new OracleParameter("7", rtbRemark.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has added to Database!", "BORROWED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCreate.Text = "Borrow";
                            btnUpdate.Enabled = true;
                            btnDelete.Text = "Delete";
                            dgvBorrow.Enabled = true;
                            //ClearField();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to borrow!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelete.Text == "Cancel")
                {
                    btnCreate.Text = "Borrow";
                    btnDelete.Enabled = false;
                    btnDelete.Text = "Delete";
                    dgvBorrow.Enabled = true;
                }
                else if (btnDelete.Text == "Delete")
                {
                    if (MessageBox.Show("Are you sure to delete, " + txtBorrowID.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = "DELETE tblBorrow WHERE BorrowID = :1";
                        OracleCommand delete_cmd = new OracleCommand(sql, conn);
                        delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBorrowID.Text)));

                        if (delete_cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has deleted from Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to delete!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    }
}
