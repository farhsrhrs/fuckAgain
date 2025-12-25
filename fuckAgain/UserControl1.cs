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
        public string edinic_izm { get; set; }
        public int price { get; set; }
        public string postavshic { get; set; }

        public string proizvoditel { get; set; }
        public string category { get; set; }
        public int discount { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        //public string photo { get; set; }

        public UserControl1()
        {
            InitializeComponent();
        }
        public void Labels()
        {
            label1.Text = "Наименование: " + name_tovar + "   |   " ;
            label2.Text = "Описание товара: " + description;
            label3.Text = "Производитель: " + proizvoditel;
            label4.Text = "Поставщик: " + postavshic;
            label5.Text = "Цена: " + price;
            label6.Text = "Единицы измерения: " + edinic_izm;
            label7.Text = "Количество на складе: " + quantity;



        }
    }
}
