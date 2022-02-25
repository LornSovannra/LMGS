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

        void LoadData()
        {
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

        void ClearField()
        {
            txtBorrowID.Text = string.Empty;
            cbStudentID.Text = string.Empty;
            txtLibrarianID.Text = string.Empty;
            cbBookID.Text = string.Empty;
            dtpBorrowDate.Text = string.Empty;
            dtpReturnDate.Text = string.Empty;
            rtbRemark.Text = string.Empty;
            txtBorrowID.Focus();
        }

        string StudentID;

        private void cbStudentID_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void cbBookID_SelectedIndexChanged_1(object sender, EventArgs e)
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

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnBorrow.Text == "Borrow")
                {
                    btnBorrow.Text = "Save";
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete.Text = "Cancel";
                    dgvBorrow.Enabled = false;
                    ClearField();
                }
                else if (btnBorrow.Text == "Save")
                {
                    if (string.IsNullOrEmpty(cbStudentID.Text))
                    {
                        MessageBox.Show("Student ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbBookID.Text))
                    {
                        MessageBox.Show("Book IDcan't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        insert_command.Parameters.Add(new OracleParameter("3", Classes.UserLogin.getLibrarianID()));
                        insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(BookID)));
                        insert_command.Parameters.Add(new OracleParameter("5", dtpBorrowDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("6", dtpReturnDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("7", rtbRemark.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has added to Database!", "BORROWED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnBorrow.Text = "Borrow";
                            btnUpdate.Enabled = true;
                            btnDelete.Text = "Delete";
                            dgvBorrow.Enabled = true;
                            ClearField();
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
            try
            {
                if (MessageBox.Show("Are you sure to return, " + txtBorrowID.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtBorrowID.Text))
                    {
                        MessageBox.Show("Borrow ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbStudentID.Text))
                    {
                        MessageBox.Show("Student ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbBookID.Text))
                    {
                        MessageBox.Show("Book IDcan't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpReturnDate.Text))
                    {
                        MessageBox.Show("Return Date can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO tblReturn(ReturnID, StuID, LibrarianID, BookID, ReturnDate, Remark) VALUES(:1, :2, :3, :4, :5, :6)";
                        OracleCommand insert_command = new OracleCommand(sql, conn);
                        insert_command.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBorrowID.Text)));
                        insert_command.Parameters.Add(new OracleParameter("2", Int32.Parse(StudentID)));
                        insert_command.Parameters.Add(new OracleParameter("3", Classes.UserLogin.getLibrarianID()));
                        insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(BookID)));
                        insert_command.Parameters.Add(new OracleParameter("5", dtpReturnDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("6", rtbRemark.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has return to Database!", "RETURNED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DeleteBorrow();
                            ClearField();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to return!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to update, " + txtBorrowID.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtBorrowID.Text))
                    {
                        MessageBox.Show("Borrow ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbStudentID.Text))
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
                        MessageBox.Show("Return Date not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "UPDATE tblBorrow SET StuID = :2, LibrarianID = :3, BookID = :4, BorrowDate = :5, ReturnDate = :6, Remark = :7 WHERE BorrowID = :1";
                        OracleCommand insert_command = new OracleCommand(sql, conn);
                        insert_command.Parameters.Add(new OracleParameter("2", Int32.Parse(StudentID)));
                        insert_command.Parameters.Add(new OracleParameter("3", Classes.UserLogin.getLibrarianID()));
                        insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(BookID)));
                        insert_command.Parameters.Add(new OracleParameter("5", dtpBorrowDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("6", dtpReturnDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("7", rtbRemark.Text));
                        insert_command.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBorrowID.Text)));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has updated to Database!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearField();
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to update!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnDelete.Text == "Cancel")
                {
                    btnBorrow.Text = "Borrow";
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
                            MessageBox.Show("One record has deleted from Database!", "DELETED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void DeleteBorrow()
        {
            string sql = "DELETE tblBorrow WHERE BorrowID = :1";
            OracleCommand delete_cmd = new OracleCommand(sql, conn);
            delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBorrowID.Text)));

            delete_cmd.ExecuteNonQuery();
        }

        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnReturn.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                txtBorrowID.Text = dgvBorrow.CurrentRow.Cells[0].Value.ToString();
                cbStudentID.Text = dgvBorrow.CurrentRow.Cells[1].Value.ToString();
                cbBookID.Text = dgvBorrow.CurrentRow.Cells[2].Value.ToString();
                txtLibrarianID.Text = dgvBorrow.CurrentRow.Cells[3].Value.ToString();
                dtpBorrowDate.Text = dgvBorrow.CurrentRow.Cells[4].Value.ToString();
                dtpReturnDate.Text = dgvBorrow.CurrentRow.Cells[5].Value.ToString();
                rtbRemark.Text = dgvBorrow.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search_sql = "SELECT bo.borrowid, s.stuname, l.librarianname, b.booktitle, bo.borrowdate, bo.returndate, bo.remark FROM tblborrow bo, tblstudent s, tbllibrarian l, tblbook b " +
                    "WHERE s.stuid = bo.stuid AND l.librarianid = bo.librarianid AND b.bookid = bo.bookid AND UPPER (s.stuname || l.librarianname || b.booktitle || bo.remark)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY BorrowID ASC";
                OracleCommand search_cmd = new OracleCommand(search_sql, conn);
                OracleDataAdapter adapt = new OracleDataAdapter(search_cmd);
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dgvBorrow.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void rtbRemark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBorrow.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnDelete.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
    }
}
