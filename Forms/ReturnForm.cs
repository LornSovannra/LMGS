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
    public partial class ReturnForm : Form
    {
        OracleConnection conn;

        public ReturnForm()
        {
            InitializeComponent();
        }

        private void ReturnForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();
            LoadData();
        }

        void LoadData()
        {
            string sql = "SELECT r.returnid, s.stuname, l.librarianname, b.booktitle, r.returndate, r.remark FROM tblReturn r, tblStudent s, tblLibrarian l, tblBook b WHERE s.stuid = r.stuid AND l.librarianid = r.librarianid AND b.bookid = r.bookid ORDER BY ReturnID ASC";
            OracleCommand search_cmd = new OracleCommand(sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(search_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvReturn.DataSource = dt;

            btnUndoReturn.Enabled = false;
        }

        string ReturnID;
        string StudentID;
        string LibrarianID;
        string BookID;
        string BorrowDate;
        string ReturnDate;
        string Remark;

        private void btnUndoReturn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to undo return, Return ID = " + ReturnID + "?", "UNDO RETURN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "INSERT INTO tblBorrow(BorrowID, StuID, LibrarianID, BookID, BorrowDate, ReturnDate, Remark) VALUES(:1, :2, :3, :4, :5, :6, :7)";
                    OracleCommand insert_command = new OracleCommand(sql, conn);
                    insert_command.Parameters.Add(new OracleParameter("1", Int32.Parse(ReturnID)));
                    insert_command.Parameters.Add(new OracleParameter("2", Int32.Parse(StudentID)));
                    insert_command.Parameters.Add(new OracleParameter("3", Int32.Parse(LibrarianID)));
                    insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(BookID)));
                    insert_command.Parameters.Add(new OracleParameter("5", BorrowDate));
                    insert_command.Parameters.Add(new OracleParameter("6", ReturnDate));
                    insert_command.Parameters.Add(new OracleParameter("7", Remark));

                    if (insert_command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("One record has undo return to Database!", "UNDO RETURNED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DeleteReturn();
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Fail to undo return!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            //MessageBox.Show(StudentID);
            //MessageBox.Show(LibrarianID);
            //MessageBox.Show(BookID);
        }

        void DeleteReturn()
        {
            string sql = "DELETE tblReturn WHERE ReturnID = :1";
            OracleCommand delete_cmd = new OracleCommand(sql, conn);
            delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(ReturnID)));

            delete_cmd.ExecuteNonQuery();
        }

        private void dgvReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUndoReturn.Enabled = true;

            ReturnID = dgvReturn.CurrentRow.Cells[0].Value.ToString();

            string select_sql = "SELECT * FROM tblReturn WHERE ReturnID = :1";
            OracleCommand select_cmd = new OracleCommand(select_sql, conn);
            select_cmd.Parameters.Add("1", ReturnID);
            OracleDataReader dr = select_cmd.ExecuteReader();

            while (dr.Read())
            {
                StudentID = dr[1].ToString();
                LibrarianID = dr[2].ToString();
                BookID = dr[3].ToString();
            }

            BorrowDate = DateTime.Now.ToString("dd-MMMM-yy");
            ReturnDate = DateTime.Now.ToString("dd-MMMM-yy");
            Remark = dgvReturn.CurrentRow.Cells[5].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //OracleCommand sql_search = new OracleCommand("SELECT * FROM tblReturn WHERE" + " UPPER (StuID || LibrarianID || BookID || Remark)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY ReturnID ASC", conn);
                OracleCommand sql_search = new OracleCommand("SELECT r.returnid, s.stuname, l.librarianname, b.booktitle, r.returndate, r.remark FROM tblReturn r, tblStudent s, tblLibrarian l, tblBook b WHERE s.stuid = r.stuid AND l.librarianid = r.librarianid AND b.bookid = r.bookid AND UPPER (s.StuName || l.LibrarianName || b.BookTitle || r.Remark)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY ReturnID ASC", conn);
                OracleDataAdapter adapt = new OracleDataAdapter(sql_search);
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dgvReturn.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}