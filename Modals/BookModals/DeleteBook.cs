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
    public partial class DeleteBook : Form
    {
        OracleConnection conn;

        public DeleteBook()
        {
            InitializeComponent();
        }

        string BookID;
        string BookTitle;

        private void DeleteBook_Load(object sender, EventArgs e)
        {
            BookID = Classes.BookData.getBookID();
            BookTitle = Classes.BookData.getBookTitle();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to delete, " + BookTitle + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "DELETE tblBook WHERE BookID = :1";
                    OracleCommand delete_cmd = new OracleCommand(sql, conn);
                    delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(BookID)));

                    if (delete_cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("One record has deleted from Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fail to delete!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errpr: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
