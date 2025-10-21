using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormMeNu;

namespace QuanLyCF.GUI

{
    public partial class FormTachBan : Form
    {
        // --- P/Invoke for rounded corners and shadow ---
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );

        private const int CS_DROPSHADOW = 0x20000;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        // --- End of P/Invoke ---

        public string SelectedAction { get; private set; }

        private readonly Color _originalColor = Color.White;
        private readonly Color _hoverColor = Color.FromArgb(240, 240, 240);
        private int _tableId;
        private FrmOrder _parentForm;

        public FormTachBan(int tableId, FrmOrder parentForm)
        {
            InitializeComponent();
            _tableId = tableId;
            _parentForm = parentForm;
            SelectedAction = string.Empty; // Initialize

            // --- Form appearance ---
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            if (!DesignMode)
            {
                Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
            }

            // --- Title setup ---
            this.lblTitle.Text = "Tùy chọn bàn";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Blue;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.pbLogo.Visible = false; // Ẩn logo nếu không cần

            // --- Labels ---
            this.lblTachBan.Text = "Order Thêm";
            this.lblChuyenBan.Text = "Chuyển bàn";
            this.lblThanhToanNhanh.Text = "Thanh toán nhanh";

            // --- Separator màu ---
            var separatorColor = Color.FromArgb(230, 230, 230);
            this.separatorHeader.BackColor = separatorColor;
            this.separator1.BackColor = separatorColor;

            // --- Hover và Click ---
            SetupRowInteraction(panelTachBan, "Order Thêm");
            SetupRowInteraction(panelChuyenBan, "Chuyển bàn");
            SetupRowInteraction(panelThanhToanNhanh, "Thanh toán nhanh");

            // --- Tự đóng khi mất focus ---
            this.Deactivate += (sender, e) => this.Close();
        }

        private void SetupRowInteraction(Panel panel, string actionName)
        {
            var controls = panel.Controls.OfType<Control>().ToList();
            controls.Add(panel);

            foreach (var control in controls)
            {
                control.MouseEnter += (sender, e) =>
                {
                    panel.BackColor = _hoverColor;
                };
                control.MouseLeave += (sender, e) =>
                {
                    if (!panel.ClientRectangle.Contains(panel.PointToClient(Cursor.Position)))
                    {
                        panel.BackColor = _originalColor;
                    }
                };
                control.Click += (sender, e) =>
                {
                    HandleAction(actionName);
                };
            }
        }

        private void HandleAction(string actionName)
        {
            SelectedAction = actionName;
            this.Close();
        }

        private void panelTachBan_Paint(object sender, PaintEventArgs e)
        {
            // Giữ để Designer không báo lỗi
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            // Tùy chọn: thêm sự kiện click tiêu đề nếu cần
        }

        private void lblChuyenBan_Click(object sender, EventArgs e)
        {
            // Tùy chọn
        }

        private void lblTitle_Click_1(object sender, EventArgs e)
        {

        }
    }
}