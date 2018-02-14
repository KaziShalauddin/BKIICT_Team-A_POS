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
            GetBarCode();
            GetAll_ItemCategories();
        }
        private void GetAll_ItemCategories()
        {
            var itemCategories = db.ItemCategories.ToList();
            itemCategoryDataGridView.DataSource = itemCategories;
            //itemCategoryDataGridView.RowTemplate.Height = 120;
        }
        private PosManagementDbContext db = new PosManagementDbContext();
       // private ItemCategory _itemCategory;
        private int _rootId=0;
        private int _childId;
        private void Get_Max_Id()
        {
            var itemCategoryList = db.ItemCategories.ToList();
            if(itemCategoryList.Count==0)
                return;
             var   maxId = db.ItemCategories.Max(r => r.Id);
                _rootId = maxId + 1;
            _childId = 0;

        }
        
        private void Get_Max_ChildId()
        {
            var sameRoot = db.ItemCategories.Where(r => r.RootId == _rootId);
            var maxChildId = sameRoot.Max(r => r.ChildId);
            _childId = maxChildId+1;
        }
      
        private void rootCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemRootCategoryComboBox.Visible = false;
            

        }
        private void childCategoryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemRootCategoryComboBox.Visible = true;
            addChildComboBox.Visible =false;
            GetItemCategory();

        }

        private void GetItemCategory()
        {
            itemRootCategoryComboBox.DataSource = db.ItemCategories.ToList();
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
        private void itemRootCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(itemRootCategoryComboBox.SelectedValue.ToString(), out id);
            _rootId = id;
           
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
                Get_Max_Id();
            }
            if (childCategoryRadioButton.Checked == true)
            {
                Get_Max_ChildId();
            }
            if (addChildsRadioButton.Checked == true)
            {
                AddChildCategory();
            }

            try
            {
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

        private void addChildsRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            itemRootCategoryComboBox.Visible = false;
            addChildComboBox.Visible = true;
            GetItemCategory_Id();
        }
        private void GetItemCategory_Id()
        {
            addChildComboBox.DataSource = db.ItemCategories.ToList();
            addChildComboBox.ValueMember = "Id";
            addChildComboBox.DisplayMember = "Name";
        }
        private void AddChildCategory()
        {
           
            var sameRoot = db.ItemCategories.Where(r => r.RootId == _rootId).ToList();
            if (sameRoot.Count == 0)
            {
                _childId = 1;
                return;
            }
            var maxChildId = sameRoot.Max(r => r.ChildId);
            _childId = maxChildId + 1;

        }
        private void addChildComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            bool result = int.TryParse(addChildComboBox.SelectedValue.ToString(), out id);
            _rootId = id;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchForText = searchTextBox.Text;
            var matchingvalues = db.ItemCategories.ToList();
            itemCategoryDataGridView.DataSource = matchingvalues;
        }
    }
}
