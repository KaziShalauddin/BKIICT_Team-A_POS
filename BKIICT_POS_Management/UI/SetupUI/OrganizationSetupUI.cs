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
    public partial class OrganizationSetupUi : Form
    {
        public OrganizationSetupUi()
        {
            InitializeComponent();
            GetOrganizations();
        }

        
        private void GetOrganizations()
        {
             db = new PosManagementDbContext();
            var organizationInfo = db.Organizations.ToList();
            orgDataGridView.DataSource = organizationInfo;
            orgDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)orgDataGridView.Columns["Logo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        byte[] orgLogo = null;
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
            orgLogo = br.ReadBytes((int)fs.Length);
        }

        private PosManagementDbContext db;
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (db == null)
            {
                db = new PosManagementDbContext();
            }
            try
            {
                Organization aOrganization = new Organization();
                aOrganization.Name = nameOrgTextBox.Text;
                aOrganization.ContactNo = mobNoTextBox.Text;
                aOrganization.Address = addressTextBox.Text;
                aOrganization.Logo = orgLogo;

                Random number = new Random();
                aOrganization.Code = number.Next(100, 200).ToString();
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                barCodePictureBox.Image = barcode.Draw(aOrganization.Code, 14);

                
                db.Organizations.Add(aOrganization);
                var check = db.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("Organization Saved!");
                    GetOrganizations();
                }
                else
                {
                    MessageBox.Show("Organization Not Saved!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please check your input");
            }

        }

        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            db = new PosManagementDbContext();
            string searchText = searchTextBox.Text;
           
            var organizationInfo = (from organizations in db.Organizations
                                    where ( organizations.Name.Contains(searchText)|| organizations.ContactNo.Contains(searchText))
                                    select organizations).ToList();
            orgDataGridView.DataSource = organizationInfo;
             orgDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)orgDataGridView.Columns["Logo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        //private void clearButton_Click(object sender, EventArgs e)
        //{
        //    nameOrgTextBox.Clear();
        //    barCodePictureBox = null;
        //    mobNoTextBox.Clear();
        //    addressTextBox.Clear();
        //    orgPictureBox = null;
        //}
    }
}
