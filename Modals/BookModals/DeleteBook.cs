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

        private void DeleteBook_Load(object sender, EventArgs e)
        {
            //BookID = Classes.BookData.getBookID();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "DELETE FROM tblBook WHERE BookID = :1";
                OracleCommand delete_cmd = new OracleCommand(sql, conn);
                //delete_cmd.CommandType = CommandType.StoredProcedure;
                delete_cmd.Parameters.Add("1", 41);

                if (delete_cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("One record has deleted from Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fail to delete!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //MessageBox.Show(Classes.BookData.getBookTitle());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
