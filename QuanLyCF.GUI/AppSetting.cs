using System.Drawing;

namespace QuanLyCF.GUI
{
    public static class AppSettings
    {
        // 🎨 Màu sắc chủ đạo
        public static readonly Color PrimaryColor = Color.FromArgb(117, 61, 38); // Màu nâu cafe
        public static readonly Color BackgroundWhiteColor = Color.White; 
        public static readonly Color BackgroundDarkColor = Color.FromArgb(32,31,30);
        public static readonly Color BeigeColor = Color.FromArgb(209, 180, 140); // Màu be
        public static readonly Color LightBrownColor = Color.FromArgb(140, 103, 84); // Màu nâu nhạt
        public static readonly Color GrayColor = Color.FromArgb(140, 103, 84); // Màu nâu nhạt

        public static readonly Color PrimaryTextColor = Color.FromArgb(62, 39, 35); // Màu nâu nhạt


        // 🗄️ Database


        // ⚙️ Cấu hình chung
        public static readonly string AppVersion = "2.0.0";
        public static readonly string Author = "Nhóm phát triển QuanLyCF";

        // Đường dẫn sử dụng Icon
        public static readonly string LinkIcon = "https://fontawesome.com/search?o=r";
        public static readonly string LinkHtmlColor = "https://www.w3schools.com/colors/colors_picker.asp";
    }
}
