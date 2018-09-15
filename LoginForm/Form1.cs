using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using MySql.Data.MySqlClient;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        MySqlConnection myConnection = new MySqlConnection("server=localhost;uid = root;pwd = root;database=users");
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    myConnection.Open();
        //    MySqlCommand cmd = myConnection.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = "select * from users.userlist where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'";
        //    cmd.ExecuteNonQuery();
        //    DataTable dt = new DataTable();
        //    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    i = Convert.ToInt32(dt.Rows.Count.ToString());
        //    if (i == 0)
        //    {
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //        MessageBoxIcon icon = MessageBoxIcon.Warning;
        //        MessageBox.Show("Bad username or password" + "\t\t\t", "Important Note", buttons, icon);
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //        MessageBoxIcon iconYea = MessageBoxIcon.None;
        //        MessageBox.Show("You're in!" + "\t\t\t\t\t", "Congratulations!", buttons, iconYea);
        //        Close();
        //    }

        //    /*
        //     * lori' or '1=1
        //     * l or 'select * from users.userlist
        //    */
        //}

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*
             * This method introduces parameterization
            */
            i = 0;
            myConnection.Open();
            MySqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from users.userlist where username='" + txtUsername.Text + "' and password= @txtPassword";
            cmd.Parameters.Add(new MySqlParameter("@txtPassword", txtPassword.Text));
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Stop;
                MessageBox.Show("Bad username or password" + "\t\t\t", "Important Note", buttons, icon);
                Close();
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon iconYea = MessageBoxIcon.Asterisk;
                MessageBox.Show("You're in!" + "\t\t\t\t\t", "Congratulations!", buttons, iconYea);
                Close();
            }
			myConnection.Close();
            /*
             * lori' or '1=1
             * l or 'select * from users.userlist
            */
        }
    }
}
