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
            GetBarCode();
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
                if (db.Outlets.Count(c => c.ContactNo == contactNoTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Contact No");
                    return;

                }
                else if (db.Outlets.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Code");
                    return;
                }
                else if (db.Outlets.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check yourName");
                    return;
                }
              outlet = new Outlet();
                outlet.ContactNo = contactNoTextBox.Text;
                outlet.Name = nameTextBox.Text;
                outlet.Address = addressTextBox.Text;
                outlet.OrganizationId = id;
                outlet.Logo = outletLogo;
                outlet.Code = GetBarCode();

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
        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = searchTextBox.Text;
            var outlets = db.Outlets.ToList();

            branchDataGridView.DataSource =
                outlets.Select(o => new { o.Id, Organization = o.Organization.Name, o.Name, o.Code, o.ContactNo, o.Address })
                    .Where(o => o.Code == code).ToList();
        }

<<<<<<< HEAD
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
=======
        private void serchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = serchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Outlets.Where(o => o.Name.StartsWith(a)).ToList();

            branchDataGridView.DataSource = search;
        }

        private int gvId;
        private void branchDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in branchDataGridView.SelectedCells)
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
                addressTextBox.Text = row.Cells[5].Value.ToString();
                gvId = branchDataGridView.CurrentRow.Index;

            }
        }

        private void organizationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from aoutlet in db.Outlets
                                    where (aoutlet.Name.Contains(searchText) || aoutlet.Code.Contains(searchText) || aoutlet.Address.Contains(searchText))
                                    select aoutlet).ToList();
            branchDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void contactNoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(branchDataGridView.CurrentRow.Cells["Id"].Value);
            var db = new PosManagementDbContext();
            var b = db.Outlets.FirstOrDefault(c => c.Id == y);
            b.Name = nameTextBox.Text;
            b.Address = addressTextBox.Text;          
            b.Code = codeTextBox.Text;
            b.ContactNo = contactNoTextBox.Text;
            bool update = db.SaveChanges() > 0;
            if (update)
            {
                MessageBox.Show("update");
            }
            else
            {
                MessageBox.Show("not updated");
            }

        }


>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
    }
}
