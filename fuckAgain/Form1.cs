using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fuckAgain.Properties;
using Npgsql;

namespace fuckAgain
{
    public partial class Form1 : Form
    {
        public string roleName { get; set;  }
        public string fio { get; set; }
        //public int user_id { get; set; }
        public Form1(string roleName, string fio)
        {
            this.roleName = roleName;
            this.fio = fio;
            InitializeComponent();
            //LoadUser();
            LoadTavar();
            if (roleName == "Гость")
            {
                labelRoleName.Hide();
                labelFio.Hide();
                label2.Hide();
                textBox1.Hide();

                label4.Hide();
                checkBox1.Hide();
                checkBox2.Hide();
                label3.Hide();
                comboBox1.Hide();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                button4.Hide();
                


            }


        }
//        public void LoadUser()
//        {
//            using (NpgsqlConnection connection = new NpgsqlConnection(Resources.ConactionDB))
//            {
//                connection.Open();
//                string query = @"SELECT user_id, public.user_role.role_pk, fio, login, password
//	                            FROM public.user
//	                            JOIN public.user_role on user_role.id = public.user.role_fk
                                                  
//";
//                using (NpgsqlCommand command = new NpgsqlCommand(query,connection))
//                {
//                    using (NpgsqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {

//                        }
//                    }
//                }
//            }
//        }
        public void LoadTavar()
        {
            flowLayoutPanel1.Controls.Clear();
            labelRoleName.Text = roleName;
            labelFio.Text = fio;
            labelRoleName.Text = roleName;
            using (NpgsqlConnection conaction = new NpgsqlConnection(Resources.ConactionDB))
            {
                conaction.Open();

                string query = @"SELECT id_artical, name_tovar.name_tovar_pk, edinic_izm,  price, postavshic.name_postavshic_pk , proizvoditel.name_proizvoditel_pk, category.category_pk, discount, quantity, description, photo
	FROM public.tovar
	JOIN name_tovar on name_tovar.id = public.tovar.name_tovar_fk
	JOIN postavshic on postavshic.id = tovar.postavshic_fk
	JOIN proizvoditel on proizvoditel.id = tovar.proizvoditel_fk
	JOIN category on category.id = tovar.category_fk	
                ";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conaction))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //int id = Convert.ToString(reader["id_artical"]);
                            var tovar = new tovar(roleName);
                           
                            PopulateTovarFromReader(reader, tovar);
                            tovar.Labels();
                            flowLayoutPanel1.Controls.Add(tovar);
                            
                        }
                        flowLayoutPanel1.ResumeLayout(true);
                    }





                }
            }

        }
        private void PopulateTovarFromReader(NpgsqlDataReader reader, tovar tovar)
        {
            tovar.name_tovar = reader.IsDBNull(1) ? "" : reader.GetString(1);
            tovar.edinic_izm = reader.IsDBNull(2) ? null : reader.GetString(2);
            tovar.price = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
            tovar.postavshic = reader.IsDBNull(4)? null : reader.GetString(4);
            tovar.proizvoditel = reader.IsDBNull(5) ? null : reader.GetString(5);
            tovar.category = reader.IsDBNull(6) ? null : reader.GetString(6);
            tovar.discount = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
            tovar.quantity = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
            tovar.description = reader.IsDBNull(9) ? null : reader.GetString(9);












        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTavar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addTovar addtovar =new addTovar();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(addtovar);
        }
    }
}
