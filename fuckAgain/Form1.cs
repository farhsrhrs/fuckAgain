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
        public Form1()
        {

            InitializeComponent();
            LoadTavar();

        }
        public void LoadTavar()
        {
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
                            var tovar = new UserControl1();
                            PopulateTovarFromReader(reader, tovar);
                            tovar.Labels();
                            flowLayoutPanel1.Controls.Add(tovar);
                        }
                        flowLayoutPanel1.ResumeLayout(true);
                    }





                }
            }

        }
        private void PopulateTovarFromReader(NpgsqlDataReader reader, UserControl1 tovar)
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
    }
}
