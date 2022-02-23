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
    public partial class DashboardForm : Form
    {
        OracleConnection conn;

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();

            OracleCommand sql_select_borow = new OracleCommand("SELECT * FROM tblBorrow", conn);
            OracleDataAdapter adapter_borrow = new OracleDataAdapter(sql_select_borow);
            DataTable dt_borrow = new DataTable();
            adapter_borrow.Fill(dt_borrow);
            txtBorrows.Text = dt_borrow.Rows.Count.ToString();

            OracleCommand sql_select_books = new OracleCommand("SELECT * FROM tblBook", conn);
            OracleDataAdapter adapter_book = new OracleDataAdapter(sql_select_books);
            DataTable dt_book = new DataTable();
            adapter_book.Fill(dt_book);
            txtBooks.Text = dt_book.Rows.Count.ToString();

            OracleCommand sql_select_return = new OracleCommand("SELECT * FROM tblReturn", conn);
            OracleDataAdapter adapter_return = new OracleDataAdapter(sql_select_return);
            DataTable dt_return = new DataTable();
            adapter_return.Fill(dt_return);
            txtReturns.Text = dt_return.Rows.Count.ToString();

            OracleCommand sql_select_student = new OracleCommand("SELECT * FROM tblStudent", conn);
            OracleDataAdapter adapter_student = new OracleDataAdapter(sql_select_student);
            DataTable dt_student = new DataTable();
            adapter_student.Fill(dt_student);
            txtStudents.Text = dt_student.Rows.Count.ToString();

            OracleCommand sql_select_blacklist = new OracleCommand("SELECT * FROM tblBlacklist", conn);
            OracleDataAdapter adapter_blacklist = new OracleDataAdapter(sql_select_blacklist);
            DataTable dt_blacklist = new DataTable();
            adapter_blacklist.Fill(dt_blacklist);
            txtBlacklist.Text = dt_blacklist.Rows.Count.ToString();

            OracleCommand sql_select_librarian = new OracleCommand("SELECT * FROM tblLibrarian", conn);
            OracleDataAdapter adapter_librarian = new OracleDataAdapter(sql_select_librarian);
            DataTable dt_librarian = new DataTable();
            adapter_librarian.Fill(dt_librarian);
            txtLibrarians.Text = dt_librarian.Rows.Count.ToString();
        }
    }
}
