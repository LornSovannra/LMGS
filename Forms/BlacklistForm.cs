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
using System.IO;

namespace Library_MGS.Forms
{
    public partial class BlacklistForm : Form
    {
        OracleConnection conn;
        string BlackListID;
        string StudentID;
        string StudentName;

        public BlacklistForm()
        {
            InitializeComponent();
        }

        private void BlacklistForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();
            LoadData();
        }

        void LoadData()
        {
            string sql = "SELECT * FROM tblBlackList ORDER BY BlackListID ASC";
            OracleCommand search_cmd = new OracleCommand(sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(search_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvBlacklist.DataSource = dt;

            btnRelease.Enabled = false;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to release, " + StudentName + "?", "RELEASE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "UPDATE tblStudent SET IsBlackListed = :2 WHERE StuID = :1";
                    OracleCommand update_command = new OracleCommand(sql, conn);
                    update_command.Parameters.Add(new OracleParameter("2", '0'));

                    update_command.Parameters.Add(new OracleParameter("1", StudentID));

                    if (update_command.ExecuteNonQuery() > 0)
                    {

                        string sql_delete_black_list = "DELETE tblBlackList WHERE BlackListID = :1";
                        OracleCommand delete_black_list_cmd = new OracleCommand(sql_delete_black_list, conn);
                        delete_black_list_cmd.Parameters.Add(new OracleParameter("1", BlackListID));

                        if (delete_black_list_cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has released!", "RELEASED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fail to release!", "FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvBlacklist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRelease.Enabled = true;

            BlackListID = dgvBlacklist.CurrentRow.Cells[0].Value.ToString();
            StudentID = dgvBlacklist.CurrentRow.Cells[1].Value.ToString();
            StudentName = dgvBlacklist.CurrentRow.Cells[2].Value.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OracleCommand sql_search = new OracleCommand("SELECT * FROM tblBlackList WHERE" + " UPPER (BlackListID || StuID || StuName || Phone)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY BlackListID ASC", conn);
                OracleDataAdapter adapt = new OracleDataAdapter(sql_search);
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dgvBlacklist.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BlacklistForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRelease_Click(sender, new EventArgs());
            }
        }
    }
}
