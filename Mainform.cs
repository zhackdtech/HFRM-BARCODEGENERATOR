using HFRM_BARCODEGENERATOR.Properties;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HFRM_BARCODEGENERATOR
{
    public partial class Mainform : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Mainform()
        {
            InitializeComponent();
        }

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode = 0);
        }
        Bitmap qrCodeImage;
        Bitmap QRCodeImage
        {
            get => qrCodeImage;
            set => qrCodeImage = value;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtInput.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
             qrCodeImage = qrCode.GetGraphic(4);
            pctOutput.Image = qrCodeImage;

            
        }
        private void SaveToJpg(String file)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "JPG IMAGES | *.jpg,*.jpeg"
            };
            //var userDir = new DirectoryInfo(Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile));
            //Directory.CreateDirectory(userDir.FullName+"/Documents/Barcodes/"+filename);
            //Debug.Write(userDir);
            dialog.FileName = file;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                QRCodeImage.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SaveToJpg(txtFileName.Text);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //public static Bitmap CreateBitmap(string text, int height, int width, Color foregroundColor, Color backgroundColor, string fontName, int fontSize, bool antialias)
        //{
        //     // Initialize graphics
        //    Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //    //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //    if (antialias)
        //    {
        //        g.SmoothingMode = SmoothingMode.AntiAlias;
        //        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        //    }

        //    // Set colors
        //    SolidBrush fgBrush = new SolidBrush(foregroundColor);
        //    SolidBrush bgBrush = new SolidBrush(backgroundColor);

        //    // paint background
        //    RectangleF rectF = new RectangleF(0, 0, width, height);
        //    g.FillRectangle(bgBrush, rectF);

        //    // Load font
        //    FontFamily fontFamily = FontFamily.GenericSerif;
        //    Font font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        //    try
        //    {
        //        fontFamily = new FontFamily(fontName);
        //        font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        //    }
        //    catch { }

        //    // Set font direction & alignment
        //    StringFormat format = new StringFormat();
        //    format.Alignment = StringAlignment.Center;
        //    format.LineAlignment = StringAlignment.Center;

        //    // Finally, draw the text
        //    g.DrawString(text, font, fgBrush, rectF, format);

        //    return bmp;
        //    }
        //}
    }
}
