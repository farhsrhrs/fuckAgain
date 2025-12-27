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
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection conaction = new NpgsqlConnection(Resources.ConactionDB))
            {
                conaction.Open();

                string query = @"SELECT user_id, public.user_role.role_pk, fio, login, password
	                            FROM public.users
	                            JOIN public.user_role on user_role.id = public.users.role_fk
	                                WHERE login = @login AND password = @password";
                using (NpgsqlCommand command = new NpgsqlCommand(query, conaction))
                {
                    command.Parameters.AddWithValue("login", textBoxLogin.Text);
                    command.Parameters.AddWithValue("password", textBoxPassword.Text);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {               
                            if (!reader.IsDBNull(0))
                            {
                                Form1 form1 = new Form1(reader.GetString(1), reader.GetString(2));
                                MessageBox.Show("Авторизация успешна!", "Информация", MessageBoxButtons.OK);
                                this.Hide();
                                
                                
                                form1.Show();
                            }
                            else {

                            }

                        }
                        if (textBoxLogin.Text== "" ||  textBoxPassword.Text=="")
                            MessageBox.Show("Error 1");
                    }

                }

                }
            }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;

            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form1 form1 = new Form1("Гость","");
            //form1.role
            form1.Show();

        }
    }
    }
