using Guna.UI2.WinForms;
using QuanLyCF.BUS;
using QuanLyCF.GUI.FormAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCF.GUI

{

    public partial class FrmOrder : Form

    {

        private FormDangNhap _loginForm;
        private Guna2Panel pnlTableMenu;
        private int selectedTableId = -1;

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

            // Panel con chứa các nút
            var innerPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BorderRadius = 0,
                FillColor = AppSettings.BackgroundWhiteColor,
                ShadowDecoration = { Enabled = true, Depth = 8, Shadow = new Padding(4) },
                Padding = new Padding(10)
            };
            pnlTableMenu.Controls.Add(innerPanel);

            // Style chung
            Font btnFont = new Font("Segoe UI", 11, FontStyle.Bold);

            // Hàm tạo nút có style đồng nhất
            Guna2Button MakeButton(string text, string icon, Color fill, Color fore)
            {
                return new Guna2Button
                {
                    Text = $"{icon}  {text}",
                    Height = 45,
                    Dock = DockStyle.Top,
                    Margin = new Padding(0, 0, 0, 8),
                    BorderRadius = 12,
                    Font = btnFont,
                    FillColor = fill,
                    ForeColor = fore,
                    HoverState = { FillColor = AppSettings.BeigeColor },
                    Cursor = Cursors.Hand
                };
            }

            // Tạo các nút
            var btnAdd = MakeButton("Thêm món", "🍹", AppSettings.LightBrownColor, Color.White);
            var btnPay = MakeButton("Thanh toán", "💰", AppSettings.LightBrownColor, Color.White);
            var btnCancel = MakeButton("Hủy", "❌", AppSettings.LightBrownColor, Color.White);

            // Gắn sự kiện click
            btnAdd.Click += BtnAdd_Click;
            btnPay.Click += BtnPay_Click;
            btnCancel.Click += (s, e) => pnlTableMenu.Visible = false;

            // Thêm nút vào panel (thứ tự đảo ngược để hiển thị đúng)
            innerPanel.Controls.Add(btnCancel);
            innerPanel.Controls.Add(btnPay);
            innerPanel.Controls.Add(btnAdd);

            this.Controls.Add(pnlTableMenu);

            // Ẩn khi click ra ngoài form
            this.Click += (s, e) =>
            {
                if (pnlTableMenu.Visible) pnlTableMenu.Visible = false;
            };
        }

        public FrmOrder()

        {

            InitializeComponent();
            InitializeTablePopupMenu();
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
            // Lấy danh sách khu vực
            var areas = AreaBUS.GetAllAreas();

            // Xóa nút cũ (nếu có)
            panelLeft.Controls.Clear();

            int top = 6; // khoảng cách trên

            foreach (var area in areas)
            {
                // Dùng Guna2Button thay vì Button thường
                Guna2Button btnArea = new Guna2Button
                {
                    Text = area.AreaName,
                    Name = "btnArea_" + area.AreaID,
                    Tag = area.AreaID,
                    Size = new Size(216, 48),
                    Location = new Point(8, top),
                    BorderRadius = 20,
                    FillColor = Color.White,
                    Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Animated = true,
                    //ShadowDecoration = { Parent = panelLeft }
                };

                // Hiệu ứng hover
                btnArea.HoverState.FillColor = Color.FromArgb(240, 248, 255);
                btnArea.HoverState.ForeColor = Color.FromArgb(0, 64, 128);
                btnArea.HoverState.BorderColor = Color.SteelBlue;

                // Sự kiện click
                btnArea.Click += (s, ev) =>
                {
                    int areaId = (int)((Guna2Button)s).Tag;
                    LoadTablesByArea(areaId); // gọi hàm load bàn theo khu vực
                };

                // Thêm vào panel
                panelLeft.Controls.Add(btnArea);

                top += btnArea.Height + 10; // khoảng cách giữa các nút
            }
        }

        private void LoadTablesByArea(int areaId)
        {
            // Xóa bàn cũ
            flpTables.Controls.Clear();

            // Lấy danh sách bàn theo khu vực
            var tables = TableBUS.GetTablesByArea(areaId);

            foreach (var table in tables)
            {
                var btnTable = new Guna2Button
                {
                    Text = $"{table.TableName}\n({table.MaxGuests} Pass)",
                    Name = $"btnTable_{table.TableID}",
                    Tag = table.TableID,
                    Size = new Size(160, 100),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    BorderRadius = 15,
                    Margin = new Padding(15),
                    ForeColor = Color.Black,
                    Cursor = Cursors.Hand,
                    Animated = true,
                    TextAlign = HorizontalAlignment.Center,
                    TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
                };

                // Màu theo trạng thái bàn
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

                // Hiệu ứng hover
                btnTable.HoverState.FillColor = AppSettings.BeigeColor;
                btnTable.HoverState.BorderColor = Color.SteelBlue;

                // Sự kiện click bàn
                btnTable.Click += (s, e) =>
                {
                    var btn = (Guna2Button)s;
                    selectedTableId = (int)btn.Tag;

                    // Vị trí hiển thị popup menu ngay dưới nút
                    Point pos = flpTables.PointToScreen(btn.Location);
                    pos = this.PointToClient(pos);

                    pnlTableMenu.Location = new Point(pos.X + btn.Width + 10, pos.Y);
                    pnlTableMenu.BringToFront();
                    pnlTableMenu.Visible = true;
                };

                flpTables.Controls.Add(btnTable);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            pnlTableMenu.Visible = false;
            MessageBox.Show($"🧋 Thêm món cho bàn ID: {selectedTableId}");
            // TODO: Mở form thêm món
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            pnlTableMenu.Visible = false;
            MessageBox.Show($"💰 Thanh toán cho bàn ID: {selectedTableId}");
            // TODO: Mở form thanh toán
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
    }
}
