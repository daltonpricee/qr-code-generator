
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
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
                List<BitmapImage> imageList = new List<BitmapImage>();
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

                    this.tbkbarcodecontent.Text = "Enjoy your QR code!";
                    this.tbkbarcodecontent.FontSize = 15;



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter something to create first.");
            }
        }

        public void DiceRollButton(object sender, RoutedEventArgs e)

        {
            var arlist1 = new List<string>();
            int counter = 0;

            // Read the file and display it line by line.  
            foreach (string line in System.IO.File.ReadLines("C:\\Users\\TDL_User\\Documents\\sites.txt"))
            {
                System.Console.WriteLine(line);
                arlist1.Add(line);
                counter++;
            }

            Random random = new Random();
            int index = random.Next(arlist1.Count);
            var name = arlist1[index].ToString();
            arlist1.RemoveAt(index);
            this.txtbarcodecontent.Text = name;
            
        }

        public void ClearcontentsButton(object sender, RoutedEventArgs e)
        {
            this.txtbarcodecontent.Text = null;
            this.imgbarcode.Source = null;
            this.tbkbarcodecontent.Text = null;
        }
    }

   
   
}
