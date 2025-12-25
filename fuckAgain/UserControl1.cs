using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fuckAgain
{
    public partial class UserControl1 : UserControl
    {
        public string name_tovar { get; set; }
        public UserControl1()
        {
            InitializeComponent();
        }
        public void Labels()
        {
            label1.Text = "Наименование: " + name_tovar;
        }
    }
}
