using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters.Entities;

namespace QuanLyCF.GUI
{
    public static class AppSettings
    {
        // 🎨 Màu sắc chủ đạo
        public static readonly Color PrimaryColor = Color.FromArgb(117, 61, 38);
        public static readonly Color BackgroundWhiteColor = Color.White;
        public static readonly Color BackgroundDarkColor = Color.FromArgb(32, 31, 30);
        public static readonly Color BeigeColor = Color.FromArgb(209, 180, 140);
        public static readonly Color LightBrownColor = Color.FromArgb(140, 103, 84);
        public static readonly Color GrayColor = Color.FromArgb(140, 103, 84);
        public static readonly Color PrimaryTextColor = Color.FromArgb(62, 39, 35);
        public static readonly Color YellowColor = Color.FromArgb(254, 215, 0);
        public static readonly Color RedColor = Color.FromArgb(198, 96, 90);
        public static readonly Color GreenoColor = Color.FromArgb(59, 180, 113);

        public static readonly string AppVersion = "2.0.0";
        public static readonly string Author = "Nhóm phát triển QuanLyCF";

        // Thông tin Form
        // Size 1260, 750

        // Thông tin ButtonBig
        // Size 218, 48

        // Thông tin ButtonMedium
        // Size 14

        // Thông tin ButtonSmall
        // Size 108, 42

        public static readonly string soundFolder = Path.GetFullPath(
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\Sound\"));

        // === Hàm gốc dùng chung ===
        private static async Task ShowToastInternal(this Form form, string message, Color backColor, int durationMs = 2000)
        {
            // 🔊 Phát âm thanh thông báo
            string soundPath = Path.Combine(soundFolder, "ShowToast.wav");
            if (File.Exists(soundPath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
                player.Play();
            }

            Label toast = new Label
            {
                Text = message,
                AutoSize = true,
                BackColor = backColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Padding(20, 10, 20, 10),
                BorderStyle = BorderStyle.None,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            form.Controls.Add(toast);
            toast.BringToFront();

            int startY = -toast.Height;
            int endY = 40;
            toast.Left = (form.ClientSize.Width - toast.Width) / 2;
            toast.Top = startY;
            toast.Visible = true;

            // Trượt xuống
            for (int i = startY; i <= endY; i += 4)
            {
                toast.Top = i;
                await Task.Delay(3);
            }

            // Giữ trong thời gian hiển thị
            await Task.Delay(durationMs);

            // Mờ dần
            for (int opacity = 100; opacity >= 0; opacity -= 5)
            {
                toast.BackColor = Color.FromArgb(opacity * backColor.A / 100, backColor.R, backColor.G, backColor.B);
                toast.ForeColor = Color.FromArgb(opacity * 255 / 100, 255, 255, 255);
                await Task.Delay(20);
            }

            form.Controls.Remove(toast);
            toast.Dispose();
        }

        // === Các hàm public tiện dụng ===
        public static async void ShowSuccessToast(this Form form, string message, int durationMs = 2000)
            => await ShowToastInternal(form, message, GreenoColor, durationMs);

        public static async void ShowWarningToast(this Form form, string message, int durationMs = 2000)
            => await ShowToastInternal(form, message, YellowColor, durationMs);

        public static async void ShowErrorToast(this Form form, string message, int durationMs = 2000)
            => await ShowToastInternal(form, message, RedColor, durationMs);

        public static void ShowToastTest(this Form form, string message)
        {
            // Nếu đã có toast cũ đang hiện, xóa trước
            foreach (Control c in form.Controls.OfType<Label>().Where(x => x.Tag?.ToString() == "toast").ToList())
            {
                form.Controls.Remove(c);
                c.Dispose();
            }

            Label toast = new Label
            {
                Text = message,
                AutoSize = true,
                BackColor = PrimaryColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Padding(20, 10, 20, 10),
                BorderStyle = BorderStyle.None,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = "toast"
            };

            form.Controls.Add(toast);
            toast.BringToFront();

            // Căn giữa màn hình
            toast.Left = (form.ClientSize.Width - toast.Width) / 2;
            toast.Top = 40;

            // Phát âm thanh (tùy chọn)
            string soundPath = Path.Combine(soundFolder, "ShowToast.wav");
            if (File.Exists(soundPath))
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
                player.Play();
            }

            // Tự động biến mất sau 2 giây
            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
            timer.Tick += (s, e) =>
            {
                form.Controls.Remove(toast);
                toast.Dispose();
                timer.Stop();
            };
            timer.Start();
        }

    }
}
