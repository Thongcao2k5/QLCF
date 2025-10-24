using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmStore : Form
    {
        private Form previousForm;
        public FrmStore()
        {
            InitializeComponent();
        }

        public FrmStore(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            previousForm.Show();
        }
    }
}
