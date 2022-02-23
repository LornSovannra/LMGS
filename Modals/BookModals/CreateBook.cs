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
    public partial class CreateBook : Form
    {
        OracleConnection conn;
        string BookTypeID;

        public CreateBook()
        {
            InitializeComponent();
        }

        private void CreateBook_Load(object sender, EventArgs e)
        {
            EditionDropDown();
            //BookTypeIDDropDown();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCreate.Text == "Create")
                {
                    btnCreate.Text = "Save";
                    btnClose.Text = "Cancel";
                    //ClearField();
                }
                else if (btnCreate.Text == "Save")
                {
                    if (string.IsNullOrEmpty(txtBookTitle.Text))
                    {
                        MessageBox.Show("Book Title can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpPublishDate.Text))
                    {
                        MessageBox.Show("Publish can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtNumOfPages.Text))
                    {
                        MessageBox.Show("Number of Pages can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtNumCopies.Text))
                    {
                        MessageBox.Show("Number Copies can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbEdition.Text))
                    {
                        MessageBox.Show("Edition can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbPublisher.Text))
                    {
                        MessageBox.Show("Publisher can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtBookSource.Text))
                    {
                        MessageBox.Show("Book Source can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbBookTypeID.Text))
                    {
                        MessageBox.Show("Book Type ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO tblBook(BookTitle, PublishDate, NumOfPages, NumCopies, Edition, Publisher, BookSource, BookTypeID, Remark) VALUES(:2, :3, :4, :5, :6, :7, :8, :9, :10)";
                        OracleCommand insert_command = new OracleCommand(sql, conn);
                        insert_command.Parameters.Add(new OracleParameter("2", txtBookTitle.Text));
                        insert_command.Parameters.Add(new OracleParameter("3", dtpPublishDate.Text));
                        insert_command.Parameters.Add(new OracleParameter("4", Int32.Parse(txtNumOfPages.Text)));
                        insert_command.Parameters.Add(new OracleParameter("5", Int32.Parse(txtNumCopies.Text)));
                        insert_command.Parameters.Add(new OracleParameter("6", cbEdition.Text));
                        insert_command.Parameters.Add(new OracleParameter("7", "Lorn Sovannra"));
                        insert_command.Parameters.Add(new OracleParameter("8", txtBookSource.Text));
                        insert_command.Parameters.Add(new OracleParameter("9", Int32.Parse(cbBookTypeID.Text)));
                        insert_command.Parameters.Add(new OracleParameter("10", rtbRemark.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has added to Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCreate.Text = "Create";
                            btnClose.Text = "Close";
                            //ClearField();
                            //LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to add!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Cancel")
            {
                btnCreate.Text = "Create";
                btnClose.Text = "Close";
            }
            else
            {
                this.Close();
            }
        }

        void EditionDropDown()
        {
            //Thrid way
            List<string> edition = new List<string>();
            edition.Add("Standard Edition");
            edition.Add("Limited Edition");

            foreach (string editionList in edition)
            {
                cbEdition.Items.Add(editionList);
            }
        }

        private void cbBookTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string search_cmd = "SELECT BookTypeID FROM tblBookType WHERE TypeName = '" + cbBookTypeID.SelectedItem + "'";
                OracleCommand cmd = new OracleCommand(search_cmd, conn);
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    BookTypeID = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        void BookTypeIDDropDown()
        {
            string select_sql = "SELECT BookTypeID, TypeName FROM tblBookType";
            OracleCommand cmd = new OracleCommand(select_sql, conn);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbBookTypeID.Items.Add(dr["TypeName"].ToString());
                cbBookTypeID.DisplayMember = (dr["TypeName"].ToString());
                cbBookTypeID.ValueMember = (dr["BookTypeID"].ToString());
            }
        }
    }
}
