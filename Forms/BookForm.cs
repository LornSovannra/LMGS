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
    public partial class BookForm : Form
    {
        OracleConnection conn;

        public BookForm()
        {
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();
            LoadData();
        }

        void LoadData()
        {
            string sql = "SELECT * FROM tblBook ORDER BY BookID ASC";
            OracleCommand search_cmd = new OracleCommand(sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(search_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvBook.DataSource = dt;
            dgvBook.ClearSelection();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        string BookID;
        string BookTitle;
        string PublishDate;
        string NumOfPages;
        string NumCopies;
        string Edition;
        string Publisher;
        string BookSource;
        string BookTypeID;
        string Remark;

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            BookID = dgvBook.CurrentRow.Cells[0].Value.ToString();
            BookTitle = dgvBook.CurrentRow.Cells[1].Value.ToString();
            PublishDate = dgvBook.CurrentRow.Cells[2].Value.ToString();
            NumOfPages = dgvBook.CurrentRow.Cells[3].Value.ToString();
            NumCopies = dgvBook.CurrentRow.Cells[4].Value.ToString();
            Edition = dgvBook.CurrentRow.Cells[5].Value.ToString();
            Publisher = dgvBook.CurrentRow.Cells[6].Value.ToString();
            BookSource = dgvBook.CurrentRow.Cells[7].Value.ToString();
            BookTypeID = dgvBook.CurrentRow.Cells[8].Value.ToString();
            Remark = dgvBook.CurrentRow.Cells[9].Value.ToString();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Modals.BookModals.CreateBook cb = new Modals.BookModals.CreateBook();
            cb.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Modals.BookModals.UpdateBook db = new Modals.BookModals.UpdateBook();
            SetData();
            db.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Modals.BookModals.DeleteBook db = new Modals.BookModals.DeleteBook();
            Classes.BookData.setBookID(BookID.ToString());
            db.FormBorderStyle = FormBorderStyle.None;
            db.ShowDialog();
        }

        void SetData()
        {
            Classes.BookData.setBookID(BookID.ToString());
            Classes.BookData.setBookTitle(BookTitle.ToString());
            Classes.BookData.setPublishDate(PublishDate.ToString());
            Classes.BookData.setNumOfPages(NumOfPages.ToString());
            Classes.BookData.setNumCopies(NumCopies.ToString());
            Classes.BookData.setEdition(Edition.ToString());
            Classes.BookData.setPublisher(Publisher.ToString());
            Classes.BookData.setBookSource(BookSource.ToString());
            Classes.BookData.setBookTypeID(BookTypeID.ToString());
            Classes.BookData.setRemark(Remark.ToString());
        }
    }
}
