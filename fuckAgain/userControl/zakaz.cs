using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fuckAgain
{
    
    public partial class zakaz : UserControl
    {
        public int Artical { get; set; }

        public string Status { get; set; }  

        public string Address { get; set; }

        public string DateZakaz { get; set; }
        public string DateDelivery { get; set; }
        public zakaz()
        {
            InitializeComponent();
        }
        public void Labels()
        {
            label2.Text = "Артикул заказа:" + Artical;
        }
    }
}
