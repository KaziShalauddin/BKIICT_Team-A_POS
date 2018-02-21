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
using BKIICT_POS_Management.Models.ItemModels;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupItemCategoryUi : Form
    {
        public SetupItemCategoryUi()
        {
            InitializeComponent();
            itemRootCategoryComboBox.Visible = false;
<<<<<<< HEAD

=======
            GetBarCode();
>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
            GetAll_ItemCategories();
        }
        private void GetAll_ItemCategories()
        {
            var itemCategories = db.ItemCategories.ToList();
            itemCategoryDataGridView.DataSource = itemCategories;
<<<<<<< HEAD
        
            itemCategoryDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)itemCategoryDataGridView.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
=======
            ((DataGridViewImageColumn)itemCategoryDataGridView.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            itemCategoryDataGridView.RowTemplate.Height = 80;
>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
        }

        private PosManagementDbContext db = new PosManagementDbContext();
        private int _rootId=0;
        private int _childId;
     
      
        private void rootCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemRootCategoryComboBox.Visible = false;

        }
        private void childCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemRootCategoryComboBox.Visible = true;

            GetItemCategory();
        }

        private void GetItemCategory()
        {
            itemRootCategoryComboBox.DataSource = db.ItemCategories.ToList();
<<<<<<< HEAD
            itemRootCategoryComboBox.ValueMember = "Id";
            itemRootCategoryComboBox.DisplayMember = "Name";

           
        }
        private void AddChildCategory()
        {
            var sameRoot = db.ItemCategories.Where(r => r.RootId == id).ToList();
            if (sameRoot.Count == 0)
            {
                _childId = 1;
                return;
            }
            var maxChildId = sameRoot.Max(r => r.ChildId);
            _childId = maxChildId + 1;

        }
        int id;
=======
            itemRootCategoryComboBox.ValueMember = "RootId";
            itemRootCategoryComboBox.DisplayMember = "Name";           
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
>>>>>>> 1d0c2b911d41ee1b9d0628d34bfb0d4691bd05f5
        private void itemRootCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            bool result = int.TryParse(itemRootCategoryComboBox.SelectedValue.ToString(), out id);
           
        }
        byte[] itemImage = null;
        string img = null;

        private void uploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.Jpg)|*.JPG|GIF Files(*.gif)|*.GIF|All Files(*.*)|*.*";
            openFileDialog.FileName = "Upload Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = openFileDialog.FileName;
                imgPictureBox.ImageLocation = img;
            }
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            itemImage = br.ReadBytes((int)fs.Length);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (rootCategoryRadioButton.Checked==true)
            {
                _rootId = 0;
                _childId = 0;
            }
            if (childCategoryRadioButton.Checked == true)
            {
                
                AddChildCategory();
                _rootId = id;
            }

            try
            {
                if (db.ItemCategories.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Name");
                    return;
                }
                else if (db.ProductItems.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check Your Code");
                    return;
                }

                ItemCategory aItemCategory = new ItemCategory();
                aItemCategory.Name = nameTextBox.Text;
               
                aItemCategory.Description= descriptionTextBox.Text;
                aItemCategory.Image =itemImage;

                aItemCategory.RootId = _rootId;
                aItemCategory.ChildId = _childId;

                aItemCategory.Code = GetBarCode();


                db.ItemCategories.Add(aItemCategory);
                var check = db.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show(" Saved! ");
                    GetAll_ItemCategories();
                    GetItemCategory();
                }
                else
                {
                    MessageBox.Show(" Not Saved! ");
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

        private void loadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_rootId.ToString());
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchForText = searchTextBox.Text;
            var matchingvalues = db.ItemCategories.ToList();
            itemCategoryDataGridView.DataSource = matchingvalues;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from itemCategory in db.ItemCategories
                                    where (itemCategory.Name.Contains(searchText) || itemCategory.Code.Contains(searchText))
                                    select itemCategory).ToList();
            itemCategoryDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }
    }
}
