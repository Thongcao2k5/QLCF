using System;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmEditTableDetail : Form
    {
        private int _tableId;

        public FrmEditTableDetail(int tableId)
        {
            InitializeComponent();
            _tableId = tableId;
            this.Text = $"Edit Table: {tableId}";
            // TODO: Load table details and populate controls
        }
    }
}
