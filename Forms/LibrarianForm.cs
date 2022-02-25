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
using Library_MGS.Properties;

namespace Library_MGS.Forms
{
    public partial class Librarian : Form
    {
        OracleConnection conn;

        public Librarian()
        {
            InitializeComponent();
        }

        private void LibrarianForm_Load(object sender, EventArgs e)
        {
            conn = Classes.DBConnection.Connect();
            GenderDropDown();
            PlaceOfBirthDropDown();
            AddressDropDown();
            UserTypeDropDown();
            LoadData();
        }

        void LoadData()
        {
            string sql = "SELECT * FROM tblLibrarian ORDER BY LibrarianID ASC";
            OracleCommand search_cmd = new OracleCommand(sql, conn);
            OracleDataAdapter adapter = new OracleDataAdapter(search_cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvLibrarian.DataSource = dt;

            DataGridViewImageColumn imgcolumn = new DataGridViewImageColumn();
            dgvLibrarian.RowTemplate.Height = 80;
            imgcolumn = (DataGridViewImageColumn)dgvLibrarian.Columns[8];
            imgcolumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        void ClearField()
        {
            txtLibrarianID.Text = string.Empty;
            txtLibrarianName.Text = string.Empty;
            cbGender.Text = string.Empty;
            dtpDateOfBirth.Text = string.Empty;
            cbPlaceOfBirth.Text = string.Empty;
            cbAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            pbPhoto.Image = Resources.Avatar;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cbUserType.Text = string.Empty;
            txtLibrarianID.Focus();
        }

        void GenderDropDown()
        {
            List<string> gender = new List<string>();
            gender.Add("Male");
            gender.Add("Female");
            gender.Add("Other");

            foreach (string genderList in gender)
            {
                cbGender.Items.Add(genderList);
            }
        }

        void PlaceOfBirthDropDown()
        {
            List<string> placeOfBirth = new List<string>();
            placeOfBirth.Add("Banteay Meanchey");
            placeOfBirth.Add("Battambang");
            placeOfBirth.Add("Kampong Chan");
            placeOfBirth.Add("Kampong Chnang");
            placeOfBirth.Add("Kampong Speu");
            placeOfBirth.Add("Kampong Thom");
            placeOfBirth.Add("Kampot");
            placeOfBirth.Add("Kandal");
            placeOfBirth.Add("Koh Kong");
            placeOfBirth.Add("Kratie");
            placeOfBirth.Add("Mondulkiri");
            placeOfBirth.Add("Phnom Penh");
            placeOfBirth.Add("Preah Vihear");
            placeOfBirth.Add("Prey Veng");
            placeOfBirth.Add("Pursat");
            placeOfBirth.Add("Ratanak Kiri");
            placeOfBirth.Add("Siem Reap");
            placeOfBirth.Add("Preah Sihanouk");
            placeOfBirth.Add("Steung Treng");
            placeOfBirth.Add("Svay Rieng");
            placeOfBirth.Add("Takeo");
            placeOfBirth.Add("Oddar Meanchey");
            placeOfBirth.Add("Kep");
            placeOfBirth.Add("Pailin");
            placeOfBirth.Add("Tboung Khmumn");

            foreach (string placeOfBirthList in placeOfBirth)
            {
                cbPlaceOfBirth.Items.Add(placeOfBirthList);
            }
        }

        void AddressDropDown()
        {
            List<string> Address = new List<string>();
            Address.Add("Banteay Meanchey");
            Address.Add("Battambang");
            Address.Add("Kampong Chan");
            Address.Add("Kampong Chnang");
            Address.Add("Kampong Speu");
            Address.Add("Kampong Thom");
            Address.Add("Kampot");
            Address.Add("Kandal");
            Address.Add("Koh Kong");
            Address.Add("Kratie");
            Address.Add("Mondulkiri");
            Address.Add("Phnom Penh");
            Address.Add("Preah Vihear");
            Address.Add("Prey Veng");
            Address.Add("Pursat");
            Address.Add("Ratanak Kiri");
            Address.Add("Siem Reap");
            Address.Add("Preah Sihanouk");
            Address.Add("Steung Treng");
            Address.Add("Svay Rieng");
            Address.Add("Takeo");
            Address.Add("Oddar Meanchey");
            Address.Add("Kep");
            Address.Add("Pailin");
            Address.Add("Tboung Khmumn");

            foreach (string addressList in Address)
            {
                cbAddress.Items.Add(addressList);
            }
        }

        void UserTypeDropDown()
        {
            List<string> userType = new List<string>();
            userType.Add("Admin");
            userType.Add("User");

            foreach (string userTypeList in userType)
            {
                cbUserType.Items.Add(userTypeList);
            }
        }

        private void pbPhoto_Click(object sender, EventArgs e)
        {
            ofdPhoto.FilterIndex = 4;
            ofdPhoto.Filter = ("Images | *.png; *.jpg; *.jpeg; *.bmp;");
            ofdPhoto.FileName = string.Empty;

            //get image and show back in openFileDialog
            if (ofdPhoto.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = Image.FromFile(ofdPhoto.FileName);
            }
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            ofdPhoto.FilterIndex = 4;
            ofdPhoto.Filter = ("Images | *.png; *.jpg; *.jpeg; *.bmp;");
            ofdPhoto.FileName = string.Empty;

            //get image and show back in openFileDialog
            if (ofdPhoto.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = Image.FromFile(ofdPhoto.FileName);
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            pbPhoto.Image = Resources.Avatar;
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
                    dgvLibrarian.Enabled = false;
                    ClearField();
                }
                else if (btnCreate.Text == "Save")
                {
                    if (string.IsNullOrEmpty(txtLibrarianName.Text))
                    {
                        MessageBox.Show("Librarian Name can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbGender.Text))
                    {
                        MessageBox.Show("Gender can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpDateOfBirth.Text))
                    {
                        MessageBox.Show("Date of Birth can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbPlaceOfBirth.Text))
                    {
                        MessageBox.Show("Place of Birth can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbAddress.Text))
                    {
                        MessageBox.Show("Address can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        MessageBox.Show("Email can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        MessageBox.Show("Phone can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtUsername.Text))
                    {
                        MessageBox.Show("Username can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Password can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbUserType.Text))
                    {
                        MessageBox.Show("User Type can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "INSERT INTO tblLibrarian(LibrarianName, Gender, DOB, POB, Address, Phone, Email, Photo, UserName, UserPassword, UserType) VALUES(:2, :3, :4, :5, :6, :7, :8, :9, :10, :11, :12)";
                        OracleCommand insert_command = new OracleCommand(sql, conn);
                        insert_command.Parameters.Add(new OracleParameter("2", txtLibrarianName.Text));
                        insert_command.Parameters.Add(new OracleParameter("3", cbGender.Text));
                        insert_command.Parameters.Add(new OracleParameter("4", dtpDateOfBirth.Text));
                        insert_command.Parameters.Add(new OracleParameter("5", cbPlaceOfBirth.Text));
                        insert_command.Parameters.Add(new OracleParameter("6", cbAddress.Text));
                        insert_command.Parameters.Add(new OracleParameter("7", txtPhone.Text));
                        insert_command.Parameters.Add(new OracleParameter("8", txtEmail.Text));

                        MemoryStream ms = new MemoryStream();
                        pbPhoto.Image.Save(ms, pbPhoto.Image.RawFormat);
                        insert_command.Parameters.Add(new OracleParameter("9", OracleDbType.Blob)).Value = ms.ToArray();

                        insert_command.Parameters.Add(new OracleParameter("10", txtUsername.Text));
                        insert_command.Parameters.Add(new OracleParameter("11", txtPassword.Text));
                        insert_command.Parameters.Add(new OracleParameter("12", cbUserType.Text));

                        if (insert_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has added to Database!", "CREATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnCreate.Text = "Create";
                            btnUpdate.Enabled = true;
                            btnDelete.Text = "Delete";
                            dgvLibrarian.Enabled = true;
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
                if (MessageBox.Show("Are you sure to update, " + txtLibrarianName.Text + "?", "UPDATE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtLibrarianID.Text))
                    {
                        MessageBox.Show("Librarian ID can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtLibrarianName.Text))
                    {
                        MessageBox.Show("Librarian Name can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbGender.Text))
                    {
                        MessageBox.Show("Gender can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(dtpDateOfBirth.Text))
                    {
                        MessageBox.Show("Date of Birth can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbPlaceOfBirth.Text))
                    {
                        MessageBox.Show("Place of Birth can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbAddress.Text))
                    {
                        MessageBox.Show("Address can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        MessageBox.Show("Email can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtPhone.Text))
                    {
                        MessageBox.Show("Phone can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtUsername.Text))
                    {
                        MessageBox.Show("Username can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(txtPassword.Text))
                    {
                        MessageBox.Show("Password can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (string.IsNullOrEmpty(cbUserType.Text))
                    {
                        MessageBox.Show("User Type can't not be blank!", "EMPTY FIELD", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "UPDATE tblLibrarian SET LibrarianName = :2, Gender = :3, DOB = :4, POB = :5, Address = :6, Phone = :7, Email = :8, Photo = :9, UserName = :10, UserPassword = :11, UserType = :12 WHERE LibrarianID = :1";
                        OracleCommand update_command = new OracleCommand(sql, conn);
                        update_command.Parameters.Add(new OracleParameter("2", txtLibrarianName.Text));
                        update_command.Parameters.Add(new OracleParameter("3", cbGender.Text));
                        update_command.Parameters.Add(new OracleParameter("4", dtpDateOfBirth.Text));
                        update_command.Parameters.Add(new OracleParameter("5", cbPlaceOfBirth.Text));
                        update_command.Parameters.Add(new OracleParameter("6", cbAddress.Text));
                        update_command.Parameters.Add(new OracleParameter("7", txtPhone.Text));
                        update_command.Parameters.Add(new OracleParameter("8", txtEmail.Text));

                        MemoryStream ms = new MemoryStream();
                        pbPhoto.Image.Save(ms, pbPhoto.Image.RawFormat);
                        update_command.Parameters.Add(new OracleParameter("9", OracleDbType.Blob)).Value = ms.ToArray();

                        update_command.Parameters.Add(new OracleParameter("10", txtUsername.Text));
                        update_command.Parameters.Add(new OracleParameter("11", txtPassword.Text));
                        update_command.Parameters.Add(new OracleParameter("12", cbUserType.Text));
                        update_command.Parameters.Add(new OracleParameter("1", Int32.Parse(txtLibrarianID.Text)));

                        if (update_command.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("One record has updated to Database!", "UPDATED", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    btnCreate.Text = "Create";
                    btnDelete.Enabled = false;
                    btnDelete.Text = "Delete";
                    dgvLibrarian.Enabled = true;
                }
                else if (btnDelete.Text == "Delete")
                {
                    if (MessageBox.Show("Are you sure to delete, " + txtLibrarianName.Text + "?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sql = "DELETE tblLibrarian WHERE LibrarianID = :1";
                        OracleCommand delete_cmd = new OracleCommand(sql, conn);
                        delete_cmd.Parameters.Add(new OracleParameter("1", Int32.Parse(txtLibrarianID.Text)));

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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvLibrarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtLibrarianID.Text = dgvLibrarian.CurrentRow.Cells[0].Value.ToString();
                txtLibrarianName.Text = dgvLibrarian.CurrentRow.Cells[1].Value.ToString();
                cbGender.Text = dgvLibrarian.CurrentRow.Cells[2].Value.ToString();
                dtpDateOfBirth.Text = dgvLibrarian.CurrentRow.Cells[3].Value.ToString();
                cbPlaceOfBirth.Text = dgvLibrarian.CurrentRow.Cells[4].Value.ToString();
                cbAddress.Text = dgvLibrarian.CurrentRow.Cells[5].Value.ToString();
                txtPhone.Text = dgvLibrarian.CurrentRow.Cells[6].Value.ToString();
                txtEmail.Text = dgvLibrarian.CurrentRow.Cells[7].Value.ToString();

                //get and show image
                byte[] img = (byte[])dgvLibrarian.CurrentRow.Cells[8].Value;
                MemoryStream ms = new MemoryStream(img);
                pbPhoto.Image = Image.FromStream(ms);

                txtUsername.Text = dgvLibrarian.CurrentRow.Cells[9].Value.ToString();
                txtPassword.Text = dgvLibrarian.CurrentRow.Cells[10].Value.ToString();
                cbUserType.Text = dgvLibrarian.CurrentRow.Cells[11].Value.ToString();

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OracleCommand sql_search = new OracleCommand("SELECT * FROM tblLibrarian WHERE" + " UPPER (LibrarianID || LibrarianName || Gender || DOB || POB || Address || Phone || Email || UserName)" + " LIKE UPPER ('%" + txtSearch.Text + "%') ORDER BY LibrarianID ASC", conn);
                OracleDataAdapter adapt = new OracleDataAdapter(sql_search);
                DataTable dt = new DataTable();
                adapt.Fill(dt);

                dgvLibrarian.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbUserType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreate.PerformClick();
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