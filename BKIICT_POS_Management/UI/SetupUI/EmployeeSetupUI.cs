using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKIICT_POS_Management.DatabaseContext;
using BKIICT_POS_Management.Models;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class EmployeeSetupUi : Form
    {
        public EmployeeSetupUi()
        {
            InitializeComponent();
            GetOutLet();
            GetBarCode();
            ShowGridView();
        }

        private void GetOutLet()
        {
           outletComboBox.ValueMember = "Id";
            outletComboBox.DisplayMember = "Name";
            outletComboBox.DataSource = db.Outlets.ToList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private PosManagementDbContext db = new PosManagementDbContext();
        private Employee employee;

        byte[] empImage = null;
        string img = null;
        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.Jpg)|*.JPG|GIF Files(*.gif)|*.GIF|All Files(*.*)|*.*";
            openFileDialog.FileName = "Upload Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = openFileDialog.FileName;
                employeePictureBox.ImageLocation = img;
            }
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            empImage = br.ReadBytes((int)fs.Length);

        }
        private void save_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(outletComboBox.SelectedValue.ToString(), out id);


            try
            {
                if (db.Employees.Count(c => c.ContactNo == contactNoTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Contact No");
                    return;

                }
                else if (db.Employees.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Code");
                    return;
                }
                else if (db.Employees.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }
                else if (db.Employees.Count(c => c.NID == nidTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check NId No");
                    return;
                }
                employee = new Employee();
                employee.Name = nameTextBox.Text;
                employee.ContactNo = conNoTextBoxEM.Text;
                employee.StartDate = joinDateTimePicker.Value.Date;
                employee.Email = emailTextBox.Text;
                employee.EmergencyContactNo = conNoTextBoxEM.Text;
                employee.NID = nidTextBox.Text;
                employee.PresentAddress = presentAddressTextBox.Text;
                employee.PermanentAddress = parmanentAddressTextBox.Text;
                employee.FathersName = nameFatherTextBox.Text;
                employee.MothersName = nameMotherTextBox.Text;
                employee.Img = empImage;
                employee.OutletId = id;
                employee.Code = GetBarCode();
                
                db.Employees.Add(employee);
                int count = db.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Employee Saved!");
                }
                else
                {
                    MessageBox.Show("Save Failed!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error");
            }
        }
        private string GetBarCode()
        {
            Random number = new Random();
            var l = new Organization();
            l.Code = number.Next(100, 200).ToString();
            string b = l.Code;
            Bitmap a = new Bitmap(b.Length * 50, 60);
            using (Graphics graphic = Graphics.FromImage(a))
            {
                Font o = new System.Drawing.Font("IDAutomationHC39M Free Version", 10);
                PointF f = new PointF(2f, 2f);
                SolidBrush brush = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphic.FillRectangle(white, 0, 0, a.Width, a.Height);
                graphic.DrawString("*" + b + "*", o, brush, f);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                a.Save(ms, ImageFormat.Png);
                barCodePictureBox.Image = a;
                barCodePictureBox.Height = a.Height;
                barCodePictureBox.Width = a.Width;
            }
            return l.Code;
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            ShowGridView();
        }

        private void ShowGridView()
        {
            var employees = db.Employees.ToList();

            employeeDataGridView.DataSource =
                employees.Select
                    (c =>
                        new
                        {
                            OutletAddress = c.Outlet.Address,
                            c.Id,
                            c.Code,
                            c.Name,
                            c.NID,
                            c.ContactNo,
                            c.Email,
                            c.EmergencyContactNo,
                            c.FathersName,
                            c.MothersName,
                            c.Img,
                            c.PresentAddress,
                            c.PermanentAddress
                        }).ToList();
            ((DataGridViewImageColumn)employeeDataGridView.Columns["Img"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void serchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = serchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Outlets.Where(o => o.Name.StartsWith(a)).ToList();

            employeeDataGridView.DataSource = search;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = searchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Outlets.Where(o => o.Code.StartsWith(a)).ToList();

            employeeDataGridView.DataSource = search;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private int gvId;
        private void employeeDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in employeeDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                nameTextBox.Text = row.Cells[2].Value.ToString();
                codeTextBox.Text = row.Cells[3].Value.ToString();
                codeTextBox.Visible = true;
                barCodePictureBox.Visible = false;
                contactNoTextBox.Text = row.Cells[4].Value.ToString();
                emailTextBox.Text = row.Cells[5].Value.ToString();
                conNoTextBoxEM.Text = row.Cells[6].Value.ToString();
                nidTextBox.Text = row.Cells[7].Value.ToString();
                nameFatherTextBox.Text = row.Cells[8].Value.ToString();
                nameMotherTextBox.Text = row.Cells[9].Value.ToString();
                presentAddressTextBox.Text = row.Cells[11].Value.ToString();
                parmanentAddressTextBox.Text = row.Cells[12].Value.ToString();
                gvId = employeeDataGridView.CurrentRow.Index;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from emplyee in db.Employees
                                    where (emplyee.Name.Contains(searchText) || emplyee.Code.Contains(searchText) || emplyee.NID.Contains(searchText) ||employee.ContactNo.Contains(searchText))
                                    select emplyee).ToList();
            employeeDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void nameFatherTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void nameMotherTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void contactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void conNoTextBoxEM_KeyPress(object sender, KeyPressEventArgs e)
        {
    e.Handled= char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void nidTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            //System.Text.RegularExpressions.Regex email = new System.Text.RegularExpressions.Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            //+ @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            //+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
            //if (emailTextBox.Text.Length > 0)
            //{
            //    if (!email.IsMatch(emailTextBox.Text))
            //    {
            //        MessageBox.Show("Invalid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        emailTextBox.SelectAll();
            //        e.Cancel = true;
            //    }
            //}
        }
    }
    //OutletAddress = c.Outlet.Address,
    //OrganizationName=c.Outlet.Organization.Name,
}
