using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;

public class RenderBill
{
    static Color RGB(int r, int g, int b) => Color.FromArgb(r, g, b);

    static void CanChinhPhai(Graphics g, Bitmap image, float fontSize, float y, Color color, string fontPath, string text, float customX = 98)
    {
        // Tạo bộ sưu tập font riêng
        using (PrivateFontCollection pfc = new PrivateFontCollection())
        {
            pfc.AddFontFile(fontPath); // Load file .ttf (giống $font trong PHP)
            using (Font font = new Font(pfc.Families[0], fontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(color))
            {
                SizeF textSize = g.MeasureString(text, font);
                float x = image.Width - textSize.Width - customX;

                // Vẽ chữ
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.DrawString(text, font, brush, x, y);
            }
        }
    }

   

    public static void CanLeTrai(Graphics g, Bitmap image, float fontSize, float y, Color color, string fontPath, string text, float x_tcb)
    {
        using (PrivateFontCollection pfc = new PrivateFontCollection())
        {
            pfc.AddFontFile(fontPath);
            using (Font font = new Font(pfc.Families[0], fontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(color))
            {
                g.DrawString(text, font, brush, x_tcb, y);
            }
        }
    }

    public static void CanChinhGiua(Graphics g, Bitmap image, float fontSize, float y, Color color, string fontPath, string text)
    {
        using (PrivateFontCollection pfc = new PrivateFontCollection())
        {
            pfc.AddFontFile(fontPath);
            using (Font font = new Font(pfc.Families[0], fontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(color))
            {
                SizeF textSize = g.MeasureString(text, font);
                float x = (image.Width - textSize.Width) / 2;
                g.DrawString(text, font, brush, x, y);
            }
        }
    }

    public static void CanGiua_NganHang(Graphics g, Bitmap image, float y, Color color, string fontPath, string iconBank, string name_bank, float fontSize, float iconOffsetY = 5)
    {
        using (Image icon = Image.FromFile(iconBank))
        using (PrivateFontCollection pfc = new PrivateFontCollection())
        {
            pfc.AddFontFile(fontPath);
            using (Font font = new Font(pfc.Families[0], fontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (Brush brush = new SolidBrush(color))
            {
                int iconWidth = 47, iconHeight = 47;
                using (Bitmap resizedIcon = new Bitmap(icon, new Size(iconWidth, iconHeight)))
                {
                    SizeF textSize = g.MeasureString(name_bank, font);
                    float totalWidth = iconWidth + 20 + textSize.Width;
                    float x = (image.Width - totalWidth) / 2;
                    float iconY = y - iconHeight + iconOffsetY;

                    // Vẽ icon
                    g.DrawImage(resizedIcon, x, iconY, iconWidth, iconHeight);

                    // Vẽ text
                    g.DrawString(name_bank, font, brush, x + iconWidth + 18, y);
                }
            }
        }
    }
    static void DrawTinHieu(Bitmap image, string iconTinHieu, int x, int y, int targetW, int targetH)
    {
        using (var icon = new Bitmap(iconTinHieu))
        {
            float iconRatio = (float)icon.Width / icon.Height;
            float targetRatio = (float)targetW / targetH;

            int newW = targetW;
            int newH = targetH;

            // Giữ nguyên tỉ lệ gốc (không bị bè)
            if (iconRatio > targetRatio)
            {
                // Icon rộng hơn, giảm chiều cao
                newH = (int)(targetW / iconRatio);
            }
            else
            {
                // Icon cao hơn, giảm chiều rộng
                newW = (int)(targetH * iconRatio);
            }

            using (var resized = new Bitmap(newW, newH))
            {
                using (Graphics g = Graphics.FromImage(resized))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(icon, new Rectangle(0, 0, newW, newH));
                }

                int imageWidth = image.Width;
                int x1 = imageWidth - newW - x;

                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawImage(resized, x1, y, newW, newH);
                }
            }
        }
    }
        static void drawPin(Graphics g, Bitmap image, string iconPath)
    {
        using (Bitmap icon = new Bitmap(iconPath))
        using (Bitmap resized = new Bitmap(icon, 63, 41))
        {
            float x = image.Width - resized.Width - 100;
            float y = 42;
            g.DrawImage(resized, x, y, resized.Width, resized.Height);
        }
    }
    public static void DrawDynamicsIsland(Graphics g, Bitmap image, string iconDynamicsIslandPath)
    {
        using (Image icon = Image.FromFile(iconDynamicsIslandPath))
        {
            int newIconWidth = 360;
            int newIconHeight = 151;

            using (Bitmap resizedIcon = new Bitmap(newIconWidth, newIconHeight))
            using (Graphics g2 = Graphics.FromImage(resizedIcon))
            {
                g2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g2.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g2.DrawImage(icon, 0, 0, newIconWidth, newIconHeight);

                int imageWidth = image.Width;
                float x = (imageWidth - newIconWidth) / 2f;
                float y = -10; // giữ nguyên như PHP

                // Vẽ icon Dynamics Island lên ảnh chính
                g.DrawImage(resizedIcon, x, y, newIconWidth, newIconHeight);
            }
        }
    }

    static void canchinhbdsd(Graphics g, Bitmap image, float fontSize, float y, Color color, string fontPath, string text)
    {
        using (Font font = new Font("Arial", fontSize, FontStyle.Regular))
        using (Brush brush = new SolidBrush(color))
        {
            g.DrawString(text, font, brush, 230, y);
        }
    }

    public static Bitmap Render(Dictionary<string, string> data)
    {
        // === Input từ form (giống PHP) ===
        string tennguoinhan = data["tennguoinhan"];
        string stk = data["stk"];
        string sotienchuyen = data["sotienchuyen"];
        string nganhangnhan = data["nganhangnhan"];
        string thoigianchuyen = data["thoigianchuyen"];
        string thoigiantrendt = data["thoigiantrendt"];
        string noidungchuyen = data["noidungchuyen"];
        string stkchinh = data["stkchinh"];
        string soduchinh = data["soduchinh"];
        string kieuchuyen = data["kieuchuyen"];
        string tinhieu = "4g";
        string Pin = "100";

        string phoiBank = kieuchuyen == "macdinh" ? "phoi/bill/mb.jpg" : "phoi/mb-bdsd.jpg";
        string fontPath = "fonts/";
        string iconBank = $"icon/bank/{nganhangnhan}.png";
        string iconTinHieu = "icon/network/dark/wifi-3-vach.png";
        string iconPin = "icon/pin/dark/93.png";

        Bitmap image = new Bitmap(phoiBank);
        using (Graphics g = Graphics.FromImage(image))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            DrawDynamicsIsland(g, image, "icon/dynamics2.png");

            // === Draw Pin ===
            if (!string.IsNullOrEmpty(Pin) && File.Exists(iconPin))
                drawPin(g, image, iconPin);

            // === Draw Tín hiệu ===
            if (tinhieu == "4g")
                CanChinhPhai(g, image, 28, 48, RGB(39, 39, 39), fontPath + "common/San Francisco/SanFranciscoText-Medium.otf", "5G", 171);
            else if (tinhieu == "wifi-3-vach")
                DrawTinHieu(image, iconTinHieu, 170, 42, 44, 44);
            else
                DrawTinHieu(image, iconTinHieu, 165, 49, 52, 30);

            // === Giờ trên điện thoại ===
            CanLeTrai(g, image, 40, 44, RGB(0, 1, 2), fontPath + "common/San Francisco/SanFranciscoDisplay-Semibold.otf", thoigiantrendt, 100);

            // === Nếu là kiểu bdsd ===
            if (kieuchuyen != "macdinh")
            {
                string textBdsd = $"TK {stkchinh} | GD: -{sotienchuyen}VND {thoigianchuyen} | SD: {soduchinh}VND | DEN: {tennguoinhan} - {stk} | {noidungchuyen}";
                canchinhbdsd(g, image, 25, 230, RGB(16, 23, 33), fontPath + "Inter-Regular.ttf", textBdsd);
            }
            //y-80, font + 18
            // === Số tiền chuyển ===
            CanChinhGiua(g, image, 66, 560, RGB(33, 33, 200), fontPath + "common/San Francisco/SanFranciscoDisplay-Semibold.otf", $"{sotienchuyen} VND");



            // === Thời gian chuyển ===
            CanChinhGiua(g, image, 33, 660, RGB(122, 125, 130), fontPath + "common/Helvetica/Helvetica.ttf", thoigianchuyen);

            // === Tên người nhận ===
            CanChinhGiua(g, image, 41, 835, RGB(50, 51, 53), fontPath + "common/San Francisco/SanFranciscoDisplay-Semibold.otf", tennguoinhan);

            // === Ngân hàng người nhận ===
            string nameBank ="MBBank (MB) - " + stk;
            CanGiua_NganHang(g, image, 910, RGB(49, 55, 58), fontPath + "common/Roboto/Roboto-Regular.ttf", iconBank, nameBank, 28, 32);

            // === Nội dung chuyển ===
            CanChinhGiua(g, image, 27, 970, RGB(49, 55, 58), fontPath + "common/Roboto/Roboto-Regular.ttf", noidungchuyen);
        }

        return image;
    }
}
