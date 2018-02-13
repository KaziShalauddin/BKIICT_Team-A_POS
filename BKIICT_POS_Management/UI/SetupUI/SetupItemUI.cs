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
using BKIICT_POS_Management.Models.Expense;
using BKIICT_POS_Management.Models.Item;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupItemUi : Form
    {
        public SetupItemUi()
        {
            InitializeComponent();
            GetItemCategory();
            GetAllItems();
        }
        private PosManagementDbContext db = new PosManagementDbContext();
       ProductItem item;

        private void GetAllItems()
        {
            var items = db.ProductItems.ToList();

            itemsDataGridView.DataSource =
                items.Select
                    (o => new { o.Id, ItemName = o.Name, o.Code, o.Description, ItemCategoryId = o.ItemCategory.Id, ItemCategoryName = o.ItemCategory.Name }).ToList();
        }

        private void GetItemCategory()
        {
            itemCategoryComboBox.ValueMember = "Id";
            itemCategoryComboBox.DisplayMember = "Name";
            itemCategoryComboBox.DataSource = db.ItemCategories.ToList();
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
            int id;
            bool result = int.TryParse(itemCategoryComboBox.SelectedValue.ToString(), out id);

            if (db == null)
            {
                db = new PosManagementDbContext();
            }
            try
            {
                item = new ProductItem();
               
               item.Name = nameTextBox.Text;
               item.ItemCategoryId = id;
               item.Image = itemImage;
               item.Description = descriptionTextBox.Text;
               item.CostPrice =Convert.ToDecimal(costPriceTextBox.Text) ;
               item.SalePrice = Convert.ToDecimal(salePriceTextBox.Text);

                Random number = new Random();
               item.Code = number.Next(100, 200).ToString();
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                barCodePictureBox.Image = barcode.Draw(item.Code, 14);

                db.ProductItems.Add(item);
                var check = db.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show(" Saved! ");
                    GetAllItems();
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            string code = searchTextBox.Text;
            var items = db.ProductItems.ToList();

            itemsDataGridView.DataSource =
                items.Select(o => new { o.Id, o.Name, o.Code, o.Description })
                    .Where(o => o.Code == code).ToList();
        }
    }
}
