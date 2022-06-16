using Microsoft.Win32;
using System;
using System.Collections;
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
                    writer.Options.Height = 175;
                    writer.Options.Width = 350;
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

        private void Button_Click(object sender, RoutedEventArgs e)

        {
             var arlist1 = new List<string>()
        {
            "https://stackoverflow.com/",
            "https://www.youtube.com/",
            "https://www.nfl.com/",
            "https://www.spotify.com/",
            "https://twitter.com/explore",
            "https://www.netflix.com/",
            "https://www.hulu.com/start",
            "https://www.apple.com/",
            "https://www.disney.com/",
            "https://www.mlb.com/",
            "https://www.nba.com/",
            "https://www.google.com/",
            "https://www.wikipedia.org/",
            "https://www.espn.com/",
            "https://weather.com/"

        };
            Random random = new Random();
            int index = random.Next(arlist1.Count);
            var name = arlist1[index].ToString();
            arlist1.RemoveAt(index);
            txtbarcodecontent.Text = name;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtbarcodecontent.Text = null;
            this.imgbarcode.Source = null;
            this.tbkbarcodecontent.Text = null;
        }
    }

}
