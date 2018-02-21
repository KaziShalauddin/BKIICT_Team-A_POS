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
using BKIICT_POS_Management.Models.ItemModels;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupItemCategoryUi : Form
    {
        public SetupItemCategoryUi()
        {
            InitializeComponent();
            itemRootCategoryComboBox.Visible = false;

            GetAll_ItemCategories();
        }
        private void GetAll_ItemCategories()
        {
            var itemCategories = db.ItemCategories.ToList();
            itemCategoryDataGridView.DataSource = itemCategories;
        
            itemCategoryDataGridView.RowTemplate.Height = 60;
            ((DataGridViewImageColumn)itemCategoryDataGridView.Columns["Image"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
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
                ItemCategory aItemCategory = new ItemCategory();
                aItemCategory.Name = nameTextBox.Text;
               
                aItemCategory.Description= descriptionTextBox.Text;
                aItemCategory.Image =itemImage;

                aItemCategory.RootId = _rootId;
                aItemCategory.ChildId = _childId;

                Random number = new Random();
                aItemCategory.Code = number.Next(100, 200).ToString();
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                barCodePictureBox.Image = barcode.Draw(aItemCategory.Code, 14);


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
            //string searchForText = searchTextBox.Text;
            //var matchingvalues = db.ItemCategories.ToList();
            //itemCategoryDataGridView.DataSource = matchingvalues;
        }
    }
}
