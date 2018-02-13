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
            PosManagementDbContext or = new PosManagementDbContext();
            var organizationInfo = or.Organizations.ToList();
            orgDataGridView.DataSource = organizationInfo;
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

        private PosManagementDbContext org;
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (org == null)
            {
                org = new PosManagementDbContext();
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

                
                org.Organizations.Add(aOrganization);
                var check = org.SaveChanges();
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

        private void showButton_Click(object sender, EventArgs e)
        {
            GetOrganizations();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
