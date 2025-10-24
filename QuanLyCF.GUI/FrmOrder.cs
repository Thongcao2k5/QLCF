using Guna.UI2.WinForms;
using QuanLyCF.BUS;
using System;
using Guna.UI2.WinForms;

using System.Collections.Generic;

using System.Data;

using System.Drawing;

using System.Windows.Forms;

namespace QuanLyCF.GUI

{

    public partial class FrmOrder : Form

    {

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
                    btnTable.FillColor = Color.White;
                    btnTable.BorderColor = Color.Gray;
                    btnTable.Text += "\n(Ordered)";
                }
                else
                {
                    btnTable.FillColor = Color.FromArgb(209, 180, 140);
                    btnTable.BorderColor = Color.DeepSkyBlue;
                }

                // Hiệu ứng hover
                btnTable.HoverState.FillColor = Color.FromArgb(140, 103, 84);
                btnTable.HoverState.BorderColor = Color.SteelBlue;

                // Sự kiện click bàn
                btnTable.Click += (s, e) =>
                {
                    int tableId = (int)((Guna2Button)s).Tag;
                    MessageBox.Show($"Bạn chọn bàn: {table.TableName}");
                    // TODO: mở form order chi tiết, load order hiện tại...
                };

                flpTables.Controls.Add(btnTable);
            }
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
