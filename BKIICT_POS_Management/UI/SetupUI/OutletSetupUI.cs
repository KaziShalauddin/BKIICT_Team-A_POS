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
using BKIICT_POS_Management.Models.Expense;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class OutletSetupUi : Form
    {
        public OutletSetupUi()
        {
            InitializeComponent();
            GetOrganizations();
            GetOutlets();

        }

        private void GetOutlets()
        {
            var outleList = db.Outlets.ToList();

            branchDataGridView.DataSource =
                outleList.Select(o => new { o.Id, Organization = o.Organization.Name, o.Name,o.Logo, o.Code, o.ContactNo, o.Address }).ToList();
            branchDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)branchDataGridView.Columns["Logo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private PosManagementDbContext db = new PosManagementDbContext();
       private Outlet outlet;
        private void GetOrganizations()
        {
            organizationComboBox.ValueMember = "Id";
            organizationComboBox.DisplayMember = "Name";
            organizationComboBox.DataSource = db.Organizations.ToList();
            organizationComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            organizationComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        byte[] outletLogo = null;
        string img = null;
        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.Jpg)|*.JPG|GIF Files(*.gif)|*.GIF|All Files(*.*)|*.*";
            openFileDialog.FileName = "Upload Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = openFileDialog.FileName;
                logoPictureBox.ImageLocation = img;
            }
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            outletLogo = br.ReadBytes((int)fs.Length);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(organizationComboBox.SelectedValue.ToString(), out id);

           

            //outlet.Code = barCodePictureBox.Text;
            //outlet.Address = addressTextBox.Text;
            //outlet.OrganizationId = id;

            if (db == null)
            {
                db = new PosManagementDbContext();
            }
            try
            {
              outlet = new Outlet();
                outlet.ContactNo = contactNoTextBox.Text;
                outlet.Name = nameTextBox.Text;
                outlet.Address = addressTextBox.Text;
                outlet.OrganizationId = id;
                outlet.Logo = outletLogo;

                Random number = new Random();
                outlet.Code = number.Next(100, 200).ToString();
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                barCodePictureBox.Image = barcode.Draw(outlet.Code, 14);

                db.Outlets.Add(outlet);
                var check = db.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("Outlet Saved!");
                    GetOutlets();
                }
                else
                {
                    MessageBox.Show("Outlet Not Saved!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Please check your input");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = searchTextBox.Text;
            var outlets = db.Outlets.ToList();

            branchDataGridView.DataSource =
                outlets.Select(o => new { o.Id, Organization = o.Organization.Name, o.Name, o.Code, o.ContactNo, o.Address })
                    .Where(o => o.Code == code).ToList();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
           // db = new PosManagementDbContext();
            string searchText = searchTextBox.Text;

            var outletInfo = (from outlets in db.Outlets
                                    where (outlets.Name.Contains(searchText) || outlets.ContactNo.Contains(searchText))
                                    select outlets).ToList();
            branchDataGridView.DataSource = outletInfo;
            branchDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)branchDataGridView.Columns["Logo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;

        }
    }
}
