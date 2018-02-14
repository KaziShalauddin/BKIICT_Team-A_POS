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

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class PartySetupUi : Form
    {
       
        public PartySetupUi()
        {

            InitializeComponent();
            partyPart2GroupBox.Visible = false;
            organizationComboBox.SelectedIndexChanged +=organizationComboBox_SelectedIndexChanged;
            GetOrganizations();
            GetPartyTable_V2();
            GetBarCode();
            //  GetPartyTable();
            //List<Outlet>outlets= db.Outlets.ToList();

        }
        
        private void GetOrganizations()
        {
            organizationComboBox.ValueMember = "Id";
            organizationComboBox.DisplayMember = "Name";
            organizationComboBox.DataSource = db.Organizations.ToList();
            
        }

        byte[] orgLogo = null;
        string img = null;
        string partyType = null;
        Party aParty = new Party();

        int organizationId;

        private PosManagementDbContext db = new PosManagementDbContext();
        private void nextButton_Click(object sender, EventArgs e)
        {
            partyPart2GroupBox.Visible = true;
        }

        private string code = null;
        private void customerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            partyType = "Customer";
        }

        private void supplierRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            partyType = "Supplier";
        }
        private void uploadButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.Jpg)|*.JPG|GIF Files(*.gif)|*.GIF|All Files(*.*)|*.*";
            openFileDialog.FileName = "Upload Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                img = openFileDialog.FileName;
                orgPictureBox.ImageLocation = img;
            }
            FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            orgLogo = br.ReadBytes((int)fs.Length);
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (db == null)
            {
                db = new PosManagementDbContext();
            }

            int outletId;
            bool result = int.TryParse(outletComboBox.SelectedValue.ToString(), out outletId);

           
            try
            {
                
                aParty.Name = nameTextBox.Text;
                aParty.ContactNo = mobNoTextBox.Text;
                aParty.Address = addressTextBox.Text;
                aParty.Img = orgLogo;
                aParty.Email = emailTextBox.Text;
                aParty.PartyType = partyType;
                aParty.OrganizationId = organizationId;
                aParty.OutletId = outletId;
                aParty.Code = GetBarCode();


                //org.Organizations.Add(aOrganization);
                db.Parties.Add(aParty);
                var check = db.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("Party Saved!");
                }
                else
                {
                    MessageBox.Show("Party Not Saved!");
                }
                GetPartyTable();
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

        private void showButton_Click(object sender, EventArgs e)
        {
            GetPartyTable();
            //MessageBox.Show(outletComboBox.SelectedValue.ToString());
        }

        private void GetPartyTable()
        {

            //var parties = db.Parties.ToList();
            //partyDataGridView.DataSource =
            //    parties.Select(o => new
            //    {
            //        o.Id, o.Name, o.PartyType, o.OrganizationId, Organization = o.Organization.Name, o.OutletId, Outlet =new Party().Outlet.Name ,
            //        o.Img, o.Code, o.Address
            //    }).ToList();

            var parties = db.Parties.ToList();
            partyDataGridView.DataSource = parties;

            //at first create a list of object using outlet id and name;
            //then use it in the lambda


        }
        private void GetPartyTable_V2()
        {
            
          //  int n = 0;
          //  var allPartiesList = db.Parties.ToList();
          //partyDataGridView.DataSource = allPartiesList.Select(o=> new {sl=(n+=1),o.Id,o.Name,o.PartyType, Organization = o.Organization.Name}).ToList();
           
            var parties = (from prt in db.Parties
                                    join org in db.Organizations on prt.OrganizationId equals org.Id into orgGroup
                                    from o in orgGroup.DefaultIfEmpty()
                                    join outlet in db.Outlets on prt.OutletId equals outlet.Id
                                    select new
                                    {

                                        // prt.Id,
                                        prt.Name,
                                        prt.Code,
                                        OrgName = o != null ? o.Name : "Not Found",
                                        OutletName = o != null ? outlet.Name : "Not Found",
                                        prt.PartyType,
                                        prt.Address
                                    }).ToList();
            partyDataGridView.DataSource = parties;

        }



        private void GetOutLet(int organizationId)
        {
            outletComboBox.ValueMember = "Id";
            outletComboBox.DisplayMember = "Name";
            outletComboBox.DataSource = db.Outlets.Where(o => o.OrganizationId == organizationId).ToList();
            
        }

        private void organizationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(organizationComboBox.SelectedValue.ToString(), out organizationId);
            GetOutLet(organizationId);
          
        }

        private void serchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = serchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Parties.Where(o => o.Name.StartsWith(a)).ToList();

            partyDataGridView.DataSource = search;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            var org = new PosManagementDbContext();
            String a = searchTextBox.Text;
            //var search1= 
            //var s = org.Organizations.Where(o => o.Code.StartsWith(a)).ToList();
            var search = org.Parties.Where(o => o.Code.StartsWith(a)).ToList();

            partyDataGridView.DataSource = search;
        }

        
    }
}
