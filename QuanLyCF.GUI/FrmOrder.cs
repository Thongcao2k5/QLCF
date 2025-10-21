using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FormMeNu; // Giả sử bạn có form Menu riêng

namespace QuanLyCF.GUI
{
    public partial class FrmOrder : Form
    {
        public Dictionary<string, string> tableStates = new Dictionary<string, string>();
        public Dictionary<string, decimal> tableOrderTotals = new Dictionary<string, decimal>();

        private FormDangNhap loginForm;
        private string activeTab = "Khu Vườn"; // tab mặc định

        private bool isTransferringTable = false;
        private int sourceTableId = -1;
        private FlowLayoutPanel flowLayoutPanelTables;

        private void InitializeCustomLayout()
        {
            flowLayoutPanelTables = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(20)
            };

            this.Controls.Add(flowLayoutPanelTables);
        }

        public FrmOrder(FormDangNhap loginForm)
        {
            InitializeComponent();
            InitializeCustomLayout(); // thêm dòng này
            this.FormClosed += FrmOrder_FormClosed;
            this.loginForm = loginForm;
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            // Khởi tạo 40 bàn
            for (int i = 1; i <= 40; i++)
            {
                tableStates[i.ToString()] = "off";
                tableOrderTotals[i.ToString()] = 0m;
            }

            LoadBanVuon();
        }

        private void FrmOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // ========== Load bàn theo khu ==========
        private void LoadBanVuon()
        {
            activeTab = "Khu Vườn";
            LoadBanTheoTabDangChon();
        }

        private void LoadBanTang()
        {
            activeTab = "Tầng Trệt";
            LoadBanTheoTabDangChon();
        }

        private void LoadBanTheoTabDangChon()
        {
            flowLayoutPanelTables.Controls.Clear();

            int start = activeTab == "Khu Vườn" ? 1 : 21;
            int end = activeTab == "Khu Vườn" ? 20 : 40;

            for (int i = start; i <= end; i++)
            {
                string tableId = i.ToString();
                Button btn = TaoBanButton(tableId);
                flowLayoutPanelTables.Controls.Add(btn);
            }
        }

        // ========== Top Bar ==========
        private void TopBar_Home_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Về màn hình chính");
        }

        private void TopBar_Menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginForm.Show();
        }

        private void lblDoanhThu_Click(object sender, EventArgs e)
        {
            FormDoanhThu frmDoanhThu = new FormDoanhThu(this);
            frmDoanhThu.ShowDialog();
        }

        // ========== Tạo Button Bàn ==========
        private Button TaoBanButton(string tenBan)
        {
            var btn = new Button
            {
                Text = tenBan,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 100,
                Margin = new Padding(8),
                Cursor = Cursors.Hand
            };

            // Lấy trạng thái hiện tại
            string state = tableStates.ContainsKey(tenBan) ? tableStates[tenBan] : "off";
            decimal total = tableOrderTotals.ContainsKey(tenBan) ? tableOrderTotals[tenBan] : 0m;

            if (state == "occupied")
                btn.Text = $"{tenBan}\n{total:N0} đ";

            btn.Tag = state;

            switch (state)
            {
                case "occupied": btn.BackColor = Color.Gray; break;
                case "on": btn.BackColor = Color.DeepSkyBlue; break;
                default: btn.BackColor = Color.LightSkyBlue; break;
            }

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.SkyBlue;

            // Bo góc nhẹ
            btn.Paint += (s, e) =>
            {
                var b = (Button)s;
                var gp = new System.Drawing.Drawing2D.GraphicsPath();
                gp.AddArc(0, 0, 15, 15, 180, 90);
                gp.AddArc(b.Width - 15, 0, 15, 15, 270, 90);
                gp.AddArc(b.Width - 15, b.Height - 15, 15, 15, 0, 90);
                gp.AddArc(0, b.Height - 15, 15, 15, 90, 90);
                gp.CloseAllFigures();
                b.Region = new Region(gp);
            };

            // Sự kiện click
            btn.Click += (s, e) => XuLyClickBan(btn);

            return btn;
        }

        // ========== Xử lý Click Bàn ==========
        private void XuLyClickBan(Button clickedButton)
        {
            string currentTableId = clickedButton.Text.Split('\n')[0];
            int tableId = Convert.ToInt32(currentTableId);

            Action<decimal, bool> onSaveCallback = (finalAmount, isPaid) =>
            {
                if (isPaid)
                {
                    tableStates[currentTableId] = "off";
                    tableOrderTotals[currentTableId] = 0m;
                }
                else
                {
                    tableStates[currentTableId] = "occupied";
                    tableOrderTotals[currentTableId] = finalAmount;
                }
                LoadBanTheoTabDangChon();
            };

            // Nếu đang ở chế độ chuyển bàn
            if (isTransferringTable)
            {
                if (tableId == sourceTableId)
                {
                    MessageBox.Show("Không thể chuyển bàn đến chính bàn đó.", "Thông báo");
                    isTransferringTable = false;
                    sourceTableId = -1;
                    return;
                }

                if (tableStates[currentTableId] == "occupied")
                {
                    DialogResult result = MessageBox.Show(
                        $"Bàn {currentTableId} đang có khách. Gộp bàn {sourceTableId} vào bàn {currentTableId}?",
                        "Gộp bàn",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        decimal tongMoi = tableOrderTotals[sourceTableId.ToString()] + tableOrderTotals[currentTableId];
                        tableOrderTotals[currentTableId] = tongMoi;
                        tableStates[sourceTableId.ToString()] = "off";
                        tableOrderTotals[sourceTableId.ToString()] = 0m;

                        MessageBox.Show($"Đã gộp bàn {sourceTableId} vào bàn {currentTableId}.", "Thành công");
                    }
                }
                else
                {
                    tableOrderTotals[currentTableId] = tableOrderTotals[sourceTableId.ToString()];
                    tableStates[currentTableId] = "occupied";

                    tableStates[sourceTableId.ToString()] = "off";
                    tableOrderTotals[sourceTableId.ToString()] = 0m;

                    MessageBox.Show($"Đã chuyển order từ bàn {sourceTableId} sang bàn {currentTableId}.", "Thành công");
                }

                isTransferringTable = false;
                sourceTableId = -1;
                LoadBanTheoTabDangChon();
                return;
            }

            // Bàn đang "occupied" => mở FormTachBan
            if (tableStates[currentTableId] == "occupied")
            {
                FormTachBan frmTachBan = new FormTachBan(tableId, this);
                frmTachBan.ShowDialog();

                if (frmTachBan.SelectedAction == "Order Thêm")
                {
                    FrmMenu frmMenu = new FrmMenu(onSaveCallback, tableId);
                    frmMenu.Show();
                }
                else if (frmTachBan.SelectedAction == "Chuyển bàn")
                {
                    isTransferringTable = true;
                    sourceTableId = tableId;
                    MessageBox.Show($"Chọn bàn đích để chuyển order từ bàn {sourceTableId}.", "Chuyển bàn");
                }
                else if (frmTachBan.SelectedAction == "Thanh toán nhanh")
                {
                    tableStates[currentTableId] = "off";
                    tableOrderTotals[currentTableId] = 0m;
                    MessageBox.Show($"Đã thanh toán bàn {currentTableId}.", "Hoàn tất");
                }

                LoadBanTheoTabDangChon();
                return;
            }

            // Nếu bàn đang “off” => mở FrmMenu mới
            if (tableStates[currentTableId] == "off")
            {
                tableStates[currentTableId] = "on";
                clickedButton.BackColor = Color.DeepSkyBlue;

                FrmMenu frmMenu = new FrmMenu(onSaveCallback, tableId);
                frmMenu.FormClosed += (s2, e2) =>
                {
                    if (tableStates[currentTableId] == "on")
                        tableStates[currentTableId] = "off";
                    LoadBanTheoTabDangChon();
                };
                frmMenu.Show();
            }
        }
    }
}
