using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data; // Added this

namespace QuanLyCF.GUI
{
    public partial class FrmOrder : Form
    {
        private Dictionary<string, string> tableStates = new Dictionary<string, string>();
        private Dictionary<string, decimal> tableTotals = new Dictionary<string, decimal>();

        private string activeArea = "Ngoài trời";
        private bool isTransferring = false;
        private int sourceTableId = -1; // Corrected field name

        private FormDangNhap _loginForm;

        // ===== Constructor =====
        public FrmOrder()
        {
            InitializeComponent();
        }

        public FrmOrder(FormDangNhap loginForm) : this()
        {
            _loginForm = loginForm;
        }

        // ===== Khi Form Load =====
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 40; i++)
            {
                tableStates[i.ToString()] = "off";
                tableTotals[i.ToString()] = 0m;
            }

            // Đảm bảo thứ tự nút đúng: Ngoài trời – Ban công – Trong nhà
            panelLeft.Controls.SetChildIndex(btnVuon, 0);
            panelLeft.Controls.SetChildIndex(btnBanCong, 1);
            panelLeft.Controls.SetChildIndex(btnTrongNha, 2);

            LoadTables();
        }

        // ===== Load bàn theo khu vực =====
        private void LoadTables()
        {
            flpTables.Controls.Clear();

            // Bố cục thoáng hơn
            flpTables.WrapContents = true;
            flpTables.FlowDirection = FlowDirection.LeftToRight;
            flpTables.Padding = new Padding(40, 30, 40, 30);
            flpTables.AutoScroll = true;

            //Xác định khu vực
            int start = 1, end = 20;
            if (activeArea == "Ban công") { start = 21; end = 30; }
            else if (activeArea == "Trong nhà") { start = 31; end = 40; }

            // Thêm các bàn
            for (int i = start; i <= end; i++)
            {
                string id = i.ToString();
                var btn = CreateTableButton(id);
                flpTables.Controls.Add(btn);
            }
        }

        // ===== Tạo nút bàn =====
        private Button CreateTableButton(string id)
        {
            Button btn = new Button
            {
                Text = $"Bàn {id}",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                Width = 180,
                Height = 120,
                Margin = new Padding(35, 25, 35, 25), // khoảng cách giữa các bàn
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(150, 210, 255), // xanh nhẹ hơn
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = id
            };

            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.DeepSkyBlue;

            // Màu theo trạng thái
            string state = tableStates[id];
            if (state == "occupied")
            {
                btn.BackColor = Color.LightGray;
                btn.Text += $"\n{tableTotals[id]:N0} đ";
            }
            else if (state == "on")
            {
                btn.BackColor = Color.DeepSkyBlue;
            }

            // Hiệu ứng hover
            btn.MouseEnter += (s, e) =>
            {
                if (tableStates[id] == "off")
                    btn.BackColor = Color.FromArgb(170, 230, 255);
            };
            btn.MouseLeave += (s, e) =>
            {
                if (tableStates[id] == "off")
                    btn.BackColor = Color.FromArgb(150, 210, 255);
            };

            // Bo góc nhẹ
            btn.Paint += (s, e) =>
            {
                var b = (Button)s;
                var gp = new System.Drawing.Drawing2D.GraphicsPath();
                int radius = 18;
                gp.AddArc(0, 0, radius, radius, 180, 90);
                gp.AddArc(b.Width - radius, 0, radius, radius, 270, 90);
                gp.AddArc(b.Width - radius, b.Height - radius, radius, radius, 0, 90);
                gp.AddArc(0, b.Height - radius, radius, radius, 90, 90);
                gp.CloseAllFigures();
                b.Region = new Region(gp);
            };

            btn.Click += (s, e) => HandleTableClick(btn);
            return btn;
        }

        private Button FindButtonByTableId(int tableId)
        {
            foreach (Control control in flpTables.Controls)
            {
                if (control is Button && Convert.ToInt32(control.Tag) == tableId)
                {
                    return (Button)control;
                }
            }
            return null;
        }

        // ===== Xử lý khi click bàn =====
        private void HandleTableClick(Button btn)
        {
            int clickedTableId = Convert.ToInt32(btn.Tag);

            if (isTransferring)
            {
                int destinationTableId = clickedTableId;

                if (sourceTableId == destinationTableId)
                {
                    isTransferring = false;
                    sourceTableId = -1;
                    MessageBox.Show("Đã hủy chuyển bàn.", "Chuyển bàn");
                    return;
                }

                string destinationState = tableStates[destinationTableId.ToString()];

                if (destinationState == "off") // Empty table
                {
                    DataRow sourceOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(sourceTableId);
                    if (sourceOrder != null)
                    {
                        int orderId = Convert.ToInt32(sourceOrder["OrderID"]);
                        QuanLyCF.DAL.OrderDAO.UpdateOrderTable(orderId, destinationTableId);

                        tableStates[sourceTableId.ToString()] = "off";
                        tableTotals[sourceTableId.ToString()] = 0;
                        Button sourceButton = FindButtonByTableId(sourceTableId);
                        if (sourceButton != null)
                        {
                            sourceButton.BackColor = Color.FromArgb(150, 210, 255);
                            sourceButton.Text = $"Bàn {sourceTableId}";
                        }

                        decimal total = Convert.ToDecimal(sourceOrder["FinalAmount"]);
                        tableStates[destinationTableId.ToString()] = "occupied";
                        tableTotals[destinationTableId.ToString()] = total;
                        Button destButton = btn;
                        destButton.BackColor = Color.LightGray;
                        destButton.Text = $"{total:N0} đ";
                    }
                }
                else // Occupied table
                {
                    var confirmResult = MessageBox.Show("Bàn này đã có người. Bạn có muốn gộp order không?",
                                                     "Xác nhận gộp order",
                                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DataRow sourceOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(sourceTableId);
                        DataRow destOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(destinationTableId);

                        if (sourceOrder != null && destOrder != null)
                        {
                            int sourceOrderId = Convert.ToInt32(sourceOrder["OrderID"]);
                            int destOrderId = Convert.ToInt32(destOrder["OrderID"]);

                            QuanLyCF.DAL.OrderDAO.MergeOrders(sourceOrderId, destOrderId);

                            tableStates[sourceTableId.ToString()] = "off";
                            tableTotals[sourceTableId.ToString()] = 0;
                            Button sourceButton = FindButtonByTableId(sourceTableId);
                            if (sourceButton != null)
                            {
                                sourceButton.BackColor = Color.FromArgb(150, 210, 255);
                                sourceButton.Text = $"Bàn {sourceTableId}";
                            }

                            DataRow updatedDestOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(destinationTableId);
                            decimal newTotal = Convert.ToDecimal(updatedDestOrder["FinalAmount"]);
                            tableTotals[destinationTableId.ToString()] = newTotal;
                            Button destButton = btn;
                            destButton.Text = $"{newTotal:N0} đ";
                        }
                    }
                }

                isTransferring = false;
                sourceTableId = -1;
                return;
            }

            string tableState = tableStates[clickedTableId.ToString()];

            Action<decimal, bool> onOrderSaved = (total, isPayment) =>
            {
                Button tableButton = FindButtonByTableId(clickedTableId);

                if (tableButton != null)
                {
                    string tableIdStr = clickedTableId.ToString();
                    if (!isPayment && total > 0)
                    {
                        tableStates[tableIdStr] = "occupied";
                        tableTotals[tableIdStr] = total;

                        tableButton.BackColor = Color.LightGray;
                        tableButton.Text = $"{total:N0} đ";
                    }
                    else
                    {
                        tableStates[tableIdStr] = "off";
                        tableTotals[tableIdStr] = 0;

                        tableButton.BackColor = Color.FromArgb(150, 210, 255);
                        tableButton.Text = $"Bàn {clickedTableId}";
                    }
                }
            };

            if (tableState == "occupied")
            {
                FormTachBan formTachBan = new FormTachBan(clickedTableId, this);
                formTachBan.ShowDialog();

                string selectedAction = formTachBan.SelectedAction;

                switch (selectedAction)
                {
                    case "Order Thêm":
                        FrmMenu frmMenuAdd = new FrmMenu(onOrderSaved, clickedTableId);
                        frmMenuAdd.Show();
                        break;
                    case "Chuyển bàn":
                        isTransferring = true;
                        sourceTableId = clickedTableId;
                        MessageBox.Show("Vui lòng chọn bàn trống để chuyển đến.", "Chuyển bàn");
                        break;
                    case "Thanh toán nhanh":
                        DataRow activeOrder = QuanLyCF.DAL.OrderDAO.GetActiveOrderByTableId(clickedTableId);
                        if (activeOrder != null)
                        {
                            int orderId = Convert.ToInt32(activeOrder["OrderID"]);
                            QuanLyCF.DAL.OrderDAO.ProcessPayment(orderId, "Cash");

                            tableStates[clickedTableId.ToString()] = "off";
                            tableTotals[clickedTableId.ToString()] = 0;
                            Button tableButton = FindButtonByTableId(clickedTableId);
                            if (tableButton != null)
                            {
                                tableButton.BackColor = Color.FromArgb(150, 210, 255);
                                tableButton.Text = $"Bàn {clickedTableId}";
                            }
                            MessageBox.Show($"Bàn {clickedTableId} đã thanh toán nhanh thành công!", "Thanh toán nhanh");
                        }
                        else
                        {
                            MessageBox.Show($"Bàn {clickedTableId} không có order nào để thanh toán.", "Thanh toán nhanh");
                        }
                        break;
                }
            }
            else // table is "off" or "on"
            {
                FrmMenu frmMenu = new FrmMenu(onOrderSaved, clickedTableId);
                frmMenu.Show();
            }
        }

        // ===== Các khu vực =====
        private void btnVuon_Click(object sender, EventArgs e)
        {
            activeArea = "Ngoài trời"; // 1–20
            LoadTables();
        }

        private void btnBanCong_Click(object sender, EventArgs e)
        {
            activeArea = "Ban công"; // 21–30
            LoadTables();
        }

        private void btnTrongNha_Click(object sender, EventArgs e)
        {
            activeArea = "Trong nhà"; // 31–40
            LoadTables();
        }

        // ===== Thanh công cụ =====
        private void lblHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trang chủ");
        }

        private void lblBanPhucVu_Click(object sender, EventArgs e)
        {
            FrmHoaDon frmHoaDon = new FrmHoaDon();
            frmHoaDon.ShowDialog();
        }

        private void lblDoanhThu_Click(object sender, EventArgs e)
        {
            FormDoanhThu formDoanhThu = new FormDoanhThu();
            formDoanhThu.ShowDialog();
        }

        private void lblLogout_Click(object sender, EventArgs e)
        {
            if (_loginForm != null)
            {
                this.Hide();
                _loginForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}