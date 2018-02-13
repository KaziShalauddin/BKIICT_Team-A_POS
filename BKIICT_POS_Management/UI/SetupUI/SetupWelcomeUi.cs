using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BKIICT_POS_Management.UI.SetupUI
{
    public partial class SetupWelcomeUi : Form
    {
        public SetupWelcomeUi()
        {
            InitializeComponent();
        }

        private void setupOrganizationFormButton_Click(object sender, EventArgs e)
        {
            OrganizationSetupUi organization=new OrganizationSetupUi();
            organization.Show();
        }

        private void setupOutletFormButton_Click(object sender, EventArgs e)
        {
            OutletSetupUi outletSetupUi = new OutletSetupUi();
            outletSetupUi.Show();

        }

        private void setupEmployeeFormButton_Click(object sender, EventArgs e)
        {
            EmployeeSetupUi employeeSetup=new EmployeeSetupUi();
            employeeSetup.Show();
        }

        private void setupPartyFormButton_Click(object sender, EventArgs e)
        {
            PartySetupUi partySetup=new PartySetupUi();
            partySetup.Show();
        }

        private void setupItemCategoryFormButton_Click(object sender, EventArgs e)
        {
            SetupItemCategoryUi setupItemCategory=new SetupItemCategoryUi();
            setupItemCategory.Show();
        }

        private void setupItemFormButton_Click(object sender, EventArgs e)
        {
            SetupItemUi setupItem=new SetupItemUi();
            setupItem.Show();
        }

        private void setupExpenseCategoryFormButton_Click(object sender, EventArgs e)
        {
            SetupExpenseCategoryUi setupExpenseCategory=new SetupExpenseCategoryUi();
            setupExpenseCategory.Show();
        }

        private void setupExpenseFormButton_Click(object sender, EventArgs e)
        {
            SetupExpenseUi setupExpense=new SetupExpenseUi();
            setupExpense.Show();
        }
    }
}
