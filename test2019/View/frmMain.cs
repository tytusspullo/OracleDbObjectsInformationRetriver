using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2019
{
    public partial class FrmMain : Form , IView<DbColumn>
    {
        Controller controller = null;

        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
        }
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            controller.TestConnection_Click();
        }
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            controller.LoadData_Click();
        }
        #region IView
        public void SetControler(Controller con)
        {
            this.controller = con;
        }
        public string User
        {
            get { return tbUser.Text; }
            set { tbUser.Text = value; }
        }
        public string Password
        {
            get { return tbPassword.Text; }
            set { tbPassword.Text = value; }
        }
        public void LoadDataToGrid(IList<DbColumn> list)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;
        }
        public void ShowMessage(string messageText)
        {
            MessageBox.Show(messageText , "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void ShowLoadDataButton()
        {
            btnLoadData.Visible = true;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
