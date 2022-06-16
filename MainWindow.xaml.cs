using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZXing;
using ZXing.ZKWeb;
/**
*Author: Dalton Price
*Version: 6/15/22
*/

namespace GenerateQRCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /**
         *code behind for button to generate.
         *Creates button based on text entered into textbox
         **/
        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage bimg = new BitmapImage();
                using (var ms = new MemoryStream())
                {
                    ZXing.BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
                    writer.Options.Height = 80;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    System.Drawing.Image img = writer.Write(this.txtbarcodecontent.Text);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = null;
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.imgbarcode.Source = bimg;
                    //Message under generated code
                    this.tbkbarcodecontent.Text = "Enjoy your QR code!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

    }

}
