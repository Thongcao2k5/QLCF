using QuanLyCF.BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyCF.GUI.FormAdmin
{
    public partial class FrmArea : Form
    {
        private Form previousForm;

        public FrmArea(Form prevForm)
        {
            InitializeComponent();
            previousForm = prevForm;

            this.Load += FrmArea_Load;
            this.Shown += FrmArea_Shown;
            this.FormClosed += FrmArea_FormClosed;
        }

        private void FrmArea_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            StyleDataGridView();
        }

        private void FrmArea_Shown(object sender, EventArgs e)
        {
            LoadAreas();
        }

        private void SetupDataGridView()
        {
            dgvArea.Columns.Clear();
            dgvArea.AutoGenerateColumns = false;
            dgvArea.AllowUserToAddRows = false;
            dgvArea.RowHeadersVisible = false;
            dgvArea.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArea.MultiSelect = false;
            dgvArea.ReadOnly = true;

            dgvArea.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã Khu Vực",
                DataPropertyName = "AreaID",
                Name = "colID",
                Width = 150
            });

            dgvArea.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên Khu Vực",
                DataPropertyName = "AreaName",
                Name = "colName",
                Width = 250
            });

            dgvArea.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mô Tả",
                DataPropertyName = "Description",
                Name = "colDesc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvArea.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Sửa",
                Text = "✏️",
                UseColumnTextForButtonValue = true,
                Name = "colEdit",
                Width = 70,
                FlatStyle = FlatStyle.Flat
            });

            dgvArea.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Name = "colDelete",
                Width = 70,
                FlatStyle = FlatStyle.Flat
            });
        }

        private void StyleDataGridView()
        {
            dgvArea.BorderStyle = BorderStyle.None;
            dgvArea.BackgroundColor = AppSettings.BackgroundWhiteColor;
            dgvArea.GridColor = Color.FromArgb(230, 220, 210);
            dgvArea.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvArea.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArea.RowTemplate.Height = 42;
            dgvArea.ColumnHeadersHeight = 48;
            dgvArea.EnableHeadersVisualStyles = false;
            dgvArea.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvArea.RowHeadersVisible = false;

            dgvArea.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            dgvArea.DefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            dgvArea.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvArea.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvArea.DefaultCellStyle.Padding = new Padding(10, 6, 10, 6);

            dgvArea.ColumnHeadersDefaultCellStyle.BackColor = AppSettings.PrimaryColor;
            dgvArea.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvArea.ColumnHeadersDefaultCellStyle.SelectionBackColor = AppSettings.PrimaryColor;

            dgvArea.DefaultCellStyle.BackColor = Color.White;
            dgvArea.DefaultCellStyle.ForeColor = Color.FromArgb(90, 60, 40);
            dgvArea.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 245, 240);
            dgvArea.DefaultCellStyle.SelectionBackColor = AppSettings.LightBrownColor;
            dgvArea.DefaultCellStyle.SelectionForeColor = Color.White;

            foreach (DataGridViewColumn col in dgvArea.Columns)
            {
                if (col is DataGridViewButtonColumn btnCol)
                {
                    btnCol.FlatStyle = FlatStyle.Flat;
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = AppSettings.BeigeColor;
                    style.ForeColor = Color.White;
                    style.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    style.SelectionBackColor = AppSettings.PrimaryColor;
                    style.SelectionForeColor = Color.White;
                    style.Padding = new Padding(5, 3, 5, 3);
                    btnCol.DefaultCellStyle = style;
                }
            }

            dgvArea.RowPrePaint += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgvArea.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(250, 245, 240);
                }
            };

            dgvArea.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgvArea.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(235, 225, 215);
            };

            dgvArea.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    dgvArea.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(250, 245, 240);
                }
            };
        }

        private void LoadAreas()
        {
            var areas = AreaBUS.GetAllAreas();

            dgvArea.DataSource = null;
            dgvArea.Rows.Clear();

            if (areas != null && areas.Count > 0)
            {
                dgvArea.DataSource = areas;
            }
        }

        private void dgvArea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int areaId = Convert.ToInt32(dgvArea.Rows[e.RowIndex].Cells["colID"].Value);
            string column = dgvArea.Columns[e.ColumnIndex].Name;

            if (column == "colEdit")
            {
                FrmEditArea frm = new FrmEditArea(this, areaId); // có id = sửa
                this.Hide();
                frm.Show();
            }
            else if (column == "colDelete")
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khu vực này?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    AreaBUS.DeleteArea(areaId);
                    LoadAreas();
                }
            }
        }

        public void ReloadAreaList()
        {
            LoadAreas();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmEditArea frm = new FrmEditArea(this, null); // null = thêm mới
            this.Hide();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousForm?.Show();
        }
    }
}
