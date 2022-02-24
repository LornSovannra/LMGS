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
            EditionDropDown();
            BookTypeIDDropDown();
            LoadData();
        }

        void LoadData()
        {
            string select_sql = "SELECT tblBook.BookID, tblBook.BookTitle, tblBook.PublishDate, tblBook.NumOfPages, tblBook.NumCopies, tblBook.Edition, tblBook.Publisher," +
                         "tblBook.BookSource, tblBookType.TypeName, tblBook.Remark FROM tblBook, tblBookType WHERE tblBookType.BookTypeID = tblBook.BookTypeID ORDER BY tblBook.BookID ASC";
            OracleCommand select_cmd = new OracleCommand(select_sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(select_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvBook.DataSource = dt;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        void ClearField()
        {
            txtBookID.Text = string.Empty;
            txtBookTitle.Text = string.Empty;
            dtpPublishDate.Text = string.Empty;
            txtNumOfPages.Text = string.Empty;
            txtNumCopies.Text = string.Empty;
            cbEdition.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtBookSource.Text = string.Empty;
            cbBookTypeID.Text = string.Empty;
            rtbRemark.Text = string.Empty;
            txtBookID.Focus();
        }

        void EditionDropDown()
        {
            List<string> edition = new List<string>();
            edition.Add("Standard Edition");
            edition.Add("Limited Edition");

            foreach (string editionList in edition)
            {
                cbEdition.Items.Add(editionList);
            }
        }

        string BookTypeID;

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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnCreate.Text == "Create")
                {
                    btnCreate.Text = "Save";
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = true;
                    btnDelete.Text = "Cancel";
                    dgvBook.Enabled = false;
                    ClearField();
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
                    else if (string.IsNullOrEmpty(txtPublisher.Text))
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
                        insert_command.Parameters.Add(new OracleParameter("7", txtPublisher.Text));
                        insert_command.Parameters.Add(new OracleParameter("8", txtBookSource.Text));
                        insert_command.Parameters.Add(new OracleParameter("9", Int32.Parse(BookTypeID)));
                        insert_command.Parameters.Add(new OracleParameter("10", rtbRemark.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has added to Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCreate.Text = "Create";
                            btnUpdate.Enabled = true;
                            btnDelete.Text = "Delete";
                            dgvBook.Enabled = true;
                            ClearField();
                            LoadData();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to update, " + txtBookTitle.Text + "?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtBookID.Text))
                    {
                        MessageBox.Show("Book ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtBookTitle.Text))
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
                    else if (string.IsNullOrEmpty(txtPublisher.Text))
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
                        string sql = "UPDATE tblBook SET BookTitle = :2, PublishDate = :3, NumOfPages = :4, NumCopies = :5, Edition = :6, Publisher = :7, BookSource = :8, BookTypeID = :9, Remark = :10 WHERE BookID = :1";
                        OracleCommand update_cmd = new OracleCommand(sql, conn);
                        update_cmd.Parameters.Add(new OracleParameter("2", txtBookTitle.Text));
                        update_cmd.Parameters.Add(new OracleParameter("3", dtpPublishDate.Text));
                        update_cmd.Parameters.Add(new OracleParameter("4", Int32.Parse(txtNumOfPages.Text)));
                        update_cmd.Parameters.Add(new OracleParameter("5", Int32.Parse(txtNumCopies.Text)));
                        update_cmd.Parameters.Add(new OracleParameter("6", cbEdition.Text));
                        update_cmd.Parameters.Add(new OracleParameter("7", txtPublisher.Text));
                        update_cmd.Parameters.Add(new OracleParameter("8", txtBookSource.Text));
                        update_cmd.Parameters.Add(new OracleParameter("9", BookTypeID));
                        update_cmd.Parameters.Add(new OracleParameter("10", rtbRemark.Text));
                        update_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBookID.Text)));

                        if (update_cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has updated to Database!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Fail to updated!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (btnDelete.Text == "Cancel")
            {
                btnCreate.Text = "Create";
                btnDelete.Enabled = false;
                btnDelete.Text = "Delete";
                dgvBook.Enabled = true;
            }
            else if (btnDelete.Text == "Delete")
            {
                if (MessageBox.Show("Are you sure to delete, " + txtBookTitle.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "DELETE tblBook WHERE BookID = :1";
                    OracleCommand delete_cmd = new OracleCommand(sql, conn);
                    delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(txtBookID.Text)));

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

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtBookID.Text = dgvBook.CurrentRow.Cells[0].Value.ToString();
            txtBookTitle.Text = dgvBook.CurrentRow.Cells[1].Value.ToString();
            dtpPublishDate.Text = dgvBook.CurrentRow.Cells[2].Value.ToString();
            txtNumOfPages.Text = dgvBook.CurrentRow.Cells[3].Value.ToString();
            txtNumCopies.Text = dgvBook.CurrentRow.Cells[4].Value.ToString();
            cbEdition.Text = dgvBook.CurrentRow.Cells[5].Value.ToString();
            txtPublisher.Text = dgvBook.CurrentRow.Cells[6].Value.ToString();
            txtBookSource.Text = dgvBook.CurrentRow.Cells[7].Value.ToString();

            BookTypeID = dgvBook.CurrentRow.Cells[8].Value.ToString();
            cbBookTypeID.Text = dgvBook.CurrentRow.Cells[8].Value.ToString();

            rtbRemark.Text = dgvBook.CurrentRow.Cells[9].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string select_sql = "SELECT tblBook.BookID, tblBook.BookTitle, tblBook.PublishDate, tblBook.NumOfPages, tblBook.NumCopies, tblBook.Edition, tblBook.Publisher," +
                        "tblBook.BookSource, tblBookType.TypeName, tblBook.Remark FROM tblBook, tblBookType WHERE tblBookType.BookTypeID = tblBook.BookTypeID AND UPPER (BookTitle || Edition || Publisher || BookSource)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY tblBook.BookID ASC";
                OracleCommand sql_search = new OracleCommand(select_sql, conn);
                OracleDataAdapter adapt = new OracleDataAdapter(sql_search);
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dgvBook.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtNumOfPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNumCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
