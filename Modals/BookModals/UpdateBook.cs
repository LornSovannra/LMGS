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

namespace Library_MGS.Modals.BookModals
{
    public partial class UpdateBook : Form
    {
        OracleConnection conn;

        public UpdateBook()
        {
            InitializeComponent();
        }

        private void UpdateBook_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        void ShowData()
        {
            txtBookID.Text = Classes.BookData.getBookID();
            txtBookTitle.Text = Classes.BookData.getBookTitle();
            dtpPublishDate.Text = Classes.BookData.getPublishDate();
            txtNumOfPages.Text = Classes.BookData.getNumOfPages();
            txtNumCopies.Text = Classes.BookData.getNumCopies();
            cbEdition.Text = Classes.BookData.getEdition();
            cbPublisher.Text = Classes.BookData.getPublisher();
            txtBookSource.Text = Classes.BookData.getBookSource();
            cbBookTypeID.Text = Classes.BookData.getBookTypeID();
            rtbRemark.Text = Classes.BookData.getRemark();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}