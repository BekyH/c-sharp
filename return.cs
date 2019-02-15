using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
namespace quizapp
{
    class @return
    {
        private string constring = "Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''";
        public string scalarreturn(string q)
        {
            string s;
            MySqlConnection conn = new MySqlConnection(constring);
            conn.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(q,conn);
                s = cmd.ExecuteScalar().ToString();

            }
            catch (Exception)
            {
                
                s = "";
            }
            return s;
        }
    }
}
