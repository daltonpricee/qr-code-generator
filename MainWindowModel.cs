using System.Windows;
using System.Collections.Generic;
using System.Text;
using System;

namespace GenerateQRCode
{
    public class MainWindowModel : NotifyPropertyChanged
    {
        //public MainWindow main;

        /**
         * Get set for code value
         */
        private string _codeContent;
        public string codeContent
        {
            get
            {
                return _codeContent;
            }
            set
            {
                _codeContent = value;
                RaisePropertyChange("codeContent");
            }
        }

        //public MainWindowModel(MainWindow mainWin)
        //{
        //    this.main = mainWin;
        //}

        public void clearText()
        {
            //this.main.txtbarcodecontent.Text = null;
            //this.main.imgbarcode.Source = null;
            //this.main.tbkbarcodecontent.Text = null;
        }

        public void getRandomLink()
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
            codeContent = name;
        }
    }
}
