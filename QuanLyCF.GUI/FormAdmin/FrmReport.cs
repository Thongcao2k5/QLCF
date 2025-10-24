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
    public partial class FrmReport : Form
    {
        private Form previousForm;
        public FrmReport()
        {
            InitializeComponent();
        }

        public FrmReport(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;
        }
    }
}
