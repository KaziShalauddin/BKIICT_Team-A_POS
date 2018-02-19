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
using System.Windows.Forms.VisualStyles;
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
            GetBarCode();

        }

        private void GetOrganizations()
        {
            PosManagementDbContext or = new PosManagementDbContext();
            var organizationInfo = or.Organizations.ToList();
            orgDataGridView.DataSource = organizationInfo;
            ((DataGridViewImageColumn)orgDataGridView.Columns["Logo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private byte[] orgLogo = null;
        private string img = null;

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
            orgLogo = br.ReadBytes((int) fs.Length);
        }

        private PosManagementDbContext org;

        private void nameOrgTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar)|| e.KeyChar ==8 ? false : true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (org == null)
            {
                org = new PosManagementDbContext();
            }
            try
            {
                
                if (org.Organizations.Count(c => c.ContactNo == mobNoTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Contact No");
                    return;
                    
                }
                else if (org.Organizations.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Code");
                    return;
                }
                else if (org.Organizations.Count(c => c.Name == nameOrgTextBox.Text)>0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }
                Organization aOrganization = new Organization();

                aOrganization.Name = nameOrgTextBox.Text;
                aOrganization.ContactNo = mobNoTextBox.Text;
                aOrganization.Address = addressTextBox.Text;
                aOrganization.Logo = orgLogo;
                aOrganization.Code = GetBarCode();

   
                if (nameOrgTextBox==null)
                {
                    MessageBox.Show("Insert Name");
                }
                else
                {
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
               
            }
            catch (Exception)
            {

                MessageBox.Show("Please check your input");
            }

        }

        private string GetBarCode()
        {
            Random number = new Random();
            var l = new Organization();
            l.Code = number.Next(100, 200).ToString();
            string b = l.Code;
            Bitmap a = new Bitmap(b.Length*50, 60);
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
            GetOrganizations();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = seTextBox.Text;
            //var search1= 
            var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            //var search = org.Organizations.Where().ToList();

            orgDataGridView.DataSource = s;
        }

        private void serchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = serchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Organizations.Where(o => o.Name.StartsWith(a)).ToList();

            orgDataGridView.DataSource = search;
        }
        private int gvId = 0;
        private void orgDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in orgDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                nameOrgTextBox.Text = row.Cells[1].Value.ToString();
                //byte[] logoa = (byte[])orgLogo;
                ////MemoryStream imgbit = new MemoryStream(logoa);
                //barCodePictureBox.Image = Image.FromStream(imgbit);
                mobNoTextBox.Text = row.Cells[3].Value.ToString();
                codeTextBox.Visible = true;
                barCodePictureBox.Visible = false;
                codeTextBox.Text = row.Cells[2].Value.ToString();
                addressTextBox.Text = row.Cells[5].Value.ToString();
                int gvId = orgDataGridView.CurrentRow.Index;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from organizations in db.Organizations
                                    where (organizations.Name.Contains(searchText) || organizations.Code.Contains(searchText) || organizations.Address.Contains(searchText))
                                    select organizations).ToList();
            orgDataGridView.DataSource = organizationInfo;
        }



        private void mobNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

       
    }
}
