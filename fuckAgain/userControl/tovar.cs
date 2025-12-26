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
    public partial class tovar : UserControl
    {
        public string name_tovar { get; set; }
        public string edinic_izm { get; set; }
        public int Price { get; set; }
        public string postavshic { get; set; }

        public string proizvoditel { get; set; }
        public string Category { get; set; }
        public int discount { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        //public string photo { get; set; }
        public string roleName { get; set; }

        public string IdArticle { get; set; }
        public tovar(string roleName)
        {
            InitializeComponent();
            if (roleName != "Администратор")
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            this.roleName = roleName;
        }
        public void Labels()
        {
            label1.Text = "Категория: " + Category + "   |   " +"Наименование: " + name_tovar;
            label2.Text = "Описание товара: " + description;
            label3.Text = "Производитель: " + proizvoditel;
            label4.Text = "Поставщик: " + postavshic;
            label5.Text = "Цена: " + Price;
            label6.Text = "Единицы измерения: " + edinic_izm;
            label7.Text = "Количество на складе: " + quantity;
            label8.Text = "Действующая скидка: " + discount + '%';


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = this.FindForm() as Form1;
            form1.LoadTavarAdd(IdArticle);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
