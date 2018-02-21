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
            codeTextBox.Visible = false;
        }

        private PosManagementDbContext db = new PosManagementDbContext();
        private ProductItem item;

        private void GetAllItems()
        {
            var items = db.ProductItems.ToList();

            itemsDataGridView.DataSource =
                items.Select
                    (o =>
                        new
                        {
                            o.Id,
                            ItemName = o.Name,
                            o.CostPrice,
                            o.SalePrice,
                            o.Code,
                            o.Image,
                            o.Description,
                            ItemCategoryId = o.ItemCategory.Id,
                            ItemCategoryName = o.ItemCategory.Name
                        }).ToList();
            ((DataGridViewImageColumn) itemsDataGridView.Columns["Image"]).ImageLayout =
                DataGridViewImageCellLayout.Stretch;
        }

        private void GetItemCategory()
        {
            itemCategoryComboBox.ValueMember = "Id";
            itemCategoryComboBox.DisplayMember = "Name";
            itemCategoryComboBox.DataSource = db.ItemCategories.ToList();
        }

        private byte[] itemImage = null;
        private string img = null;

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
            itemImage = br.ReadBytes((int) fs.Length);
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
                if (db.ProductItems.Count(c => c.Name == nameTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check your Name");
                    return;
                }
                else if (db.ProductItems.Count(c => c.Code == codeTextBox.Text) > 0)
                {
                    MessageBox.Show("Please Check Your Code");
                    return;
                }
                item = new ProductItem();

                item.Name = nameTextBox.Text;
                item.ItemCategoryId = id;
                item.Image = itemImage;
                item.Description = descriptionTextBox.Text;
                item.CostPrice = Convert.ToDecimal(costPriceTextBox.Text);
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
                items.Select(o => new {o.Id, o.Name, o.Code, o.Description})
                    .Where(o => o.Code == code).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            string searchText = textBox1.Text;

            var organizationInfo = (from item1 in db.ProductItems
                where (item1.Name.Contains(searchText) || item1.Code.Contains(searchText))
                select item1).ToList();
            itemsDataGridView.DataSource = organizationInfo;

        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsLetter(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void costPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void salePriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsNumber(e.KeyChar) || e.KeyChar == 8 ? false : true;
        }

        private void itemsDataGridView_DoubleClick(object sender, EventArgs e)
        {
            var db = new PosManagementDbContext();
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in itemsDataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                nameTextBox.Text = row.Cells[1].Value.ToString();
                //byte[] logoa = (byte[])orgLogo;
                ////MemoryStream imgbit = new MemoryStream(logoa);
                //barCodePictureBox.Image = Image.FromStream(imgbit);
                imgPictureBox.Visible = false;
                codeTextBox.Visible = true;
                codeTextBox.Text = row.Cells[4].Value.ToString();
                costPriceTextBox.Text = row.Cells[2].Value.ToString();
                salePriceTextBox.Text = row.Cells[3].Value.ToString();
                descriptionTextBox.Text = row.Cells[6].Value.ToString();
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(itemsDataGridView.CurrentRow.Cells["Id"].Value);
            var db = new PosManagementDbContext();
            var b = db.ProductItems.FirstOrDefault(c => c.Id == y);
            b.Name = nameTextBox.Text;
            b.Code = codeTextBox.Text;
            b.CostPrice = Convert.ToDecimal(costPriceTextBox.Text);
            b.SalePrice = Convert.ToDecimal(codeTextBox.Text);
            b.Image = itemImage;

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
    }
}
