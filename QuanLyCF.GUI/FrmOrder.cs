using System;

using System.Collections.Generic;

using System.Data;

using System.Drawing;

using System.Windows.Forms;

namespace QuanLyCF.GUI

{

    public partial class FrmOrder : Form

    {

        private Dictionary<string, string> tableStates = new Dictionary<string, string>();

        private Dictionary<string, decimal> tableTotals = new Dictionary<string, decimal>();

        private string activeArea = "Ngoài trời";
        private bool isTransferring = false;
        private int sourceTableId = -1;
        private FormDangNhap _loginForm;

        public FrmOrder()

        {

            InitializeComponent();

            // Cài đặt chung cho form

            this.StartPosition = FormStartPosition.CenterScreen;

            this.FormBorderStyle = FormBorderStyle.None;

            this.MaximizeBox = false;

            this.MinimizeBox = false;

            this.DoubleBuffered = true;

        }

        public FrmOrder(FormDangNhap loginForm) : this()
        {
            _loginForm = loginForm;
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {

            panelLeft.Controls.SetChildIndex(btnVuon, 0);
        }

        private void lblLogout_Click(object sender, EventArgs e)

        {

            if (_loginForm != null)

            {

                this.Hide();

                _loginForm.Show();

            }
            else

                Application.Exit();

        }
    }
}