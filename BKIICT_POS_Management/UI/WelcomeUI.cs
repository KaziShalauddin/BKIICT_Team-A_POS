
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BKIICT_POS_Management.UI.Operations;
using BKIICT_POS_Management.UI.ReportUI;
using BKIICT_POS_Management.UI.SetupUI;


namespace BKIICT_POS_Management.UI
{
    public partial class WelcomeUi : Form
    {
        public WelcomeUi()
        {
            InitializeComponent();
        }

        private void setupUiButton_Click(object sender, EventArgs e)
        {
             SetupWelcomeUi setupWelcome=new SetupWelcomeUi();
            setupWelcome.Show();
        }

        private void operationsWelcomeUiButton_Click(object sender, EventArgs e)
        {
            OperationsWelcomeUi operationsWelcome=new OperationsWelcomeUi();
            operationsWelcome.Show();
        }

        private void reportWelcomeUiButton_Click(object sender, EventArgs e)
        {
            ReportWelcomeUi reportWelcome=new ReportWelcomeUi();
            reportWelcome.Show();
        }
    }
}
