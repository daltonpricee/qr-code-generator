using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateQRCode
{
    public class MainWindowViewModel : MainWindowModel
    {
        public MainWindowViewModel()
        {
            codeContent = "";
            CreateCommand c = new CreateCommand();
            
           
        }
    }
}
