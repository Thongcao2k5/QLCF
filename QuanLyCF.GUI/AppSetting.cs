using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static readonly string AppVersion = "2.0.0";
        public static readonly string Author = "Nhóm phát triển QuanLyCF";

        public static readonly string soundFolder = Path.GetFullPath(
    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\QuanLyCF.DAL\Image\Sound\"));

        // 📣 Toast mở rộng cho Form
        public static async void ShowToast(this Form form, string message, int durationMs = 2000)
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
                BackColor = Color.FromArgb(230, 50, 50, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Padding = new Padding(20, 10, 20, 10),
                BorderStyle = BorderStyle.None,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            form.Controls.Add(toast);
            toast.BringToFront();

            // Bắt đầu ở trên rìa
            int startY = -toast.Height;
            int endY = 40; // Cách mép trên form 40px
            toast.Left = (form.ClientSize.Width - toast.Width) / 2;
            toast.Top = startY;
            toast.Visible = true;

            // Hiệu ứng trượt xuống
            for (int i = startY; i <= endY; i += 4)
            {
                toast.Top = i;
                await Task.Delay(3);
            }

            // Giữ nguyên trong duration
            await Task.Delay(durationMs);

            // Mờ dần
            for (int opacity = 100; opacity >= 0; opacity -= 5)
            {
                toast.BackColor = Color.FromArgb(opacity * 230 / 100, 50, 50, 50);
                toast.ForeColor = Color.FromArgb(opacity * 255 / 100, 255, 255, 255);
                await Task.Delay(20);
            }

            form.Controls.Remove(toast);
            toast.Dispose();
        }
    }
}
