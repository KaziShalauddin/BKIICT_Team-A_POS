using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            GetEmployees();
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

                Random number = new Random();
                employee.Code = number.Next(100).ToString();
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                barCodePictureBox.Image = barcode.Draw(employee.Code, 35);

                
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

        private void showButton_Click(object sender, EventArgs e)
        {
            GetEmployees();
        }

        private void GetEmployees()
        {
            var employees = db.Employees.ToList();

            employeeDataGridView.DataSource =
                employees.Select
                (c => new { OutletAddress = c.Outlet.Address, c.Id, c.Code, c.Name, c.NID, c.ContactNo, c.Email, c.EmergencyContactNo, c.FathersName, c.MothersName, c.Img }).ToList();
        }
    }
    //OutletAddress = c.Outlet.Address,
    //OrganizationName=c.Outlet.Organization.Name,
}
