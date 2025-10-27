using Guna.UI2.WinForms;
using QuanLyCF.BUS;
using QuanLyCF.GUI.FormAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCF.GUI
{
    public partial class FrmOrder : Form
    {
        private FormDangNhap _loginForm;
        private Guna2Panel pnlTableMenu;
        private int selectedTableId = -1;
        private int currentAreaId = -1; // Lưu khu vực hiện tại

        public FrmOrder()
        {
            InitializeComponent();
            InitializeTablePopupMenu();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            ApplyHoverEffectToAllButtons(this);
        }

        public FrmOrder(FormDangNhap loginForm) : this()
        {
            _loginForm = loginForm;
        }

        // ===============================
        // 🔹 KHỞI TẠO POPUP MENU
        // ===============================
        private void InitializeTablePopupMenu()
        {
            pnlTableMenu = new Guna2Panel
            {
                Size = new Size(190, 170),
                BorderRadius = 0,
                BackColor = Color.Transparent,
                FillColor = Color.Transparent,
                BorderThickness = 0,
                Visible = false,
            };

            var innerPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BorderRadius = 0,
                FillColor = AppSettings.BackgroundWhiteColor,
                ShadowDecoration = { Enabled = true, Depth = 8, Shadow = new Padding(0) },
                Padding = new Padding(10)
            };
            pnlTableMenu.Controls.Add(innerPanel);

            Font btnFont = new Font("Segoe UI", 11, FontStyle.Bold);

            Guna2Button MakeButton(string text, string icon)
            {
                return new Guna2Button
                {
                    Text = $"{icon}  {text}",
                    Height = 48,
                    Dock = DockStyle.Top,
                    Margin = new Padding(2,0,2,0),
                    BorderRadius = 0,
                    Font = btnFont,
                    FillColor = AppSettings.LightBrownColor,
                    ForeColor = Color.White,
                    HoverState = { FillColor = AppSettings.BeigeColor },
                    Cursor = Cursors.Hand
                };
            }

            var btnAdd = MakeButton("Thêm món", "🍹");
            var btnPay = MakeButton("Thanh toán", "💰");
            var btnCancel = MakeButton("Hủy", "❌");

            btnAdd.Click += BtnAdd_Click;
            btnPay.Click += BtnPay_Click;
            btnCancel.Click += (s, e) => pnlTableMenu.Visible = false;

            innerPanel.Controls.Add(btnCancel);
            innerPanel.Controls.Add(btnPay);
            innerPanel.Controls.Add(btnAdd);

            this.Controls.Add(pnlTableMenu);
            
            // Khi click ra ngoài thì ẩn popup
            this.Click += (s, e) =>
            {
                if (pnlTableMenu.Visible) pnlTableMenu.Visible = false;
            };
        }

        // ===============================
        // 🔹 Hiển thị popup menu ở giữa màn hình
        // ===============================
        private void ShowTablePopupMenu()
        {
            // Tính toán vị trí giữa form
            int x = (this.ClientSize.Width - pnlTableMenu.Width) / 2;
            int y = (this.ClientSize.Height - pnlTableMenu.Height) / 2;

            pnlTableMenu.Location = new Point(x, y);
            pnlTableMenu.Visible = true;
            pnlTableMenu.BringToFront();
        }

        // ===============================
        // 🔹 LOAD FORM
        // ===============================
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            var areas = AreaBUS.GetAllAreas();
            panelLeft.Controls.Clear();

            int top = 6;
            foreach (var area in areas)
            {
                Guna2Button btnArea = new Guna2Button
                {
                    Text = area.AreaName,
                    Tag = area.AreaID,
                    Size = new Size(146, 48),
                    Location = new Point(8, top),
                    BorderRadius = 20,
                    FillColor = Color.White,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Animated = true
                };

                btnArea.HoverState.FillColor = Color.FromArgb(240, 248, 255);
                btnArea.HoverState.ForeColor = Color.FromArgb(0, 64, 128);
                btnArea.HoverState.BorderColor = Color.SteelBlue;

                btnArea.Click += (s, ev) =>
                {
                    currentAreaId = (int)((Guna2Button)s).Tag;
                    LoadTablesByArea(currentAreaId);
                };

                panelLeft.Controls.Add(btnArea);
                top += btnArea.Height + 10;
            }
        }

        // ===============================
        // 🔹 HIỂN THỊ DANH SÁCH BÀN
        // ===============================
        private void LoadTablesByArea(int areaId)
        {
            flpTables.Controls.Clear();
            var tables = TableBUS.GetTablesByArea(areaId);

            foreach (var table in tables)
            {
                var btnTable = new Guna2Button
                {
                    Text = $"{table.TableName}\n({table.MaxGuests} người)",
                    Tag = table.TableID,
                    Size = new Size(160, 100),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    BorderRadius = 15,
                    Margin = new Padding(15),
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Animated = true,
                    TextAlign = HorizontalAlignment.Center
                };

                if (table.IsOccupied)
                {
                    btnTable.FillColor = AppSettings.BackgroundWhiteColor;
                    btnTable.BorderColor = Color.Gray;
                    btnTable.Text += "\n(Ordered)";
                }
                else
                {
                    btnTable.FillColor = AppSettings.LightBrownColor;
                    btnTable.BorderColor = Color.DeepSkyBlue;
                }

                btnTable.HoverState.FillColor = AppSettings.BeigeColor;

                btnTable.Click += (s, e) =>
                {
                    var btn = (Guna2Button)s;
                    selectedTableId = (int)btn.Tag;

                    var tableInfo = TableBUS.GetTableById(selectedTableId);
                    if (tableInfo == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!tableInfo.IsOccupied)
                    {
                        // Bàn trống → mở menu để order mới
                        Action onSaveCallback = () => LoadTablesByArea(currentAreaId);
                        FrmMenu frm = new FrmMenu(selectedTableId, onSaveCallback);
                        frm.ShowDialog();
                    }
                    else
                    {
                        // Bàn đã có người → hiện popup menu
                        Point pos = flpTables.PointToScreen(btn.Location);
                        pos = this.PointToClient(pos);
                        pnlTableMenu.Location = new Point(pos.X + btn.Width + 10, pos.Y);
                        pnlTableMenu.BringToFront();
                        //pnlTableMenu.Visible = true;
                        ShowTablePopupMenu();
                    }
                };

                flpTables.Controls.Add(btnTable);
            }
        }

        // ===============================
        // 🔹 SỰ KIỆN NÚT TRONG POPUP
        // ===============================
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            pnlTableMenu.Visible = false;

            if (selectedTableId <= 0)
            {
                MessageBox.Show("Vui lòng chọn bàn hợp lệ!");
                return;
            }

            Action onSaveCallback = () => LoadTablesByArea(currentAreaId);
            FrmMenu frm = new FrmMenu(selectedTableId, onSaveCallback);
            frm.ShowDialog();
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            pnlTableMenu.Visible = false;

            if (selectedTableId <= 0)
            {
                MessageBox.Show("Vui lòng chọn bàn hợp lệ!");
                return;
            }

            var pendingOrder = PendingOrderBUS.GetPendingOrderByTableId(selectedTableId);
            if (pendingOrder != null)
            {
                FrmBill frmBill = new FrmBill();
                frmBill.TableId = this.selectedTableId;
                frmBill.ShowDialog();
                LoadTablesByArea(currentAreaId);
            }
            else
            {
                 MessageBox.Show("Không tìm thấy order cho bàn này để thanh toán!");
            }
        }

        // ===============================
        // 🔹 CÁC NÚT KHÁC (logout, report,…)
        // ===============================
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

        private void btnStore_Click(object sender, EventArgs e)
        {
            FrmStore frm = new FrmStore(this);
            this.Hide();
            frm.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FrmArea frm = new FrmArea(this);
            this.Hide();
            frm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FrmReport frm = new FrmReport(this);
            this.Hide();
            frm.Show();
        }

        private void ApplyHoverEffectToAllButtons(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button btn)
                {
                    // Lưu lại màu gốc
                    Color originalColor = btn.FillColor;
                    Color originalColor2 = btn.ForeColor;

                    btn.MouseEnter += (s, e) =>
                    {
                        btn.FillColor = Color.Gray;
                        btn.ForeColor = Color.White;
                    };
                    btn.MouseLeave += (s, e) =>
                    {
                        btn.FillColor = originalColor;
                        btn.ForeColor = originalColor2;
                    };
                }

                // Đệ quy: tìm button trong panel, groupbox, v.v...
                if (control.HasChildren)
                    ApplyHoverEffectToAllButtons(control);
            }
        }

        private void BtnEditTables_Click(object sender, EventArgs e)
        {
            FrmEditTables frmEditTables = new FrmEditTables();
            this.Hide();
            frmEditTables.ShowDialog();
            this.Show();
        }
    }
}
