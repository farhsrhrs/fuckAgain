using fuckAgain.Properties;
using Npgsql;
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


    public partial class addTovar : UserControl
    {
        public string Name_tovar { get; set; }
        public string edinic_izm { get; set; }
        public int Price { get; set; }
        public string Postavshic { get; set; }

        public string Proizvoditel { get; set; }
        public string Category { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

        public string roleName { get; set; }

        public string IdArticle { get; set; }
        public string RoleName { get; set; }

        public string ArticleTovar { get; set; }
        public addTovar(bool isEditMode)
        {
            InitializeComponent();
            //id_artical.Text = ArticleTovar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = this.FindForm() as Form1;
            
            form1.LoadTavar();
        }
        public void setAddcontrols()
        {
 
            id_artical.Text = ArticleTovar;

        }
        public void LoadTovarData()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Resources.ConactionDB))
            {
                connection.Open();
                string query = $@"SELECT id_artical, name_tovar.name_tovar_pk, edinic_izm, price, postavshic.name_postavshic_pk, proizvoditel.name_proizvoditel_pk, category.category_pk, discount, quantity, description, photo
                                 FROM public.tovar
                                 JOIN name_tovar ON name_tovar.id = tovar.name_tovar_fk
                                 JOIN postavshic ON postavshic.id = tovar.postavshic_fk
                                 JOIN proizvoditel ON proizvoditel.id = tovar.proizvoditel_fk
                                 JOIN category ON category.id = tovar.category_fk
                                 WHERE id_artical = '{id_artical.Text}' ";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxPrice.Text = reader.GetInt32(3).ToString();
                            textBoxQuantity.Text = reader.GetInt32(8).ToString();
                            textBoxDiscount.Text = reader.GetInt32(7).ToString();
                            richTextBox1.Text = reader.GetString(9);
                            comboBox2.Text = reader.GetString(5);
                        }
                    }
                }
            }
        }
    }
}
