using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
namespace quizapp
{
    /// <summary>
    /// Interaction logic for view.xaml
    /// </summary>
    public partial class view : Window
    {
        public view()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }

        private void Minier_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Closer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Re_btn_Click(object sender, RoutedEventArgs e)
        {
            adminsoption ao = new adminsoption();
            ao.Show();
            this.Close();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Closer_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void showdata()
        {


            string mysqlConnection = "Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''";
            try
            {

                MySqlConnection conn = new MySqlConnection(mysqlConnection);
                conn.Open();
                string q = "SELECT * FROM students";
                MySqlCommand cmd = new MySqlCommand(q);



                MySqlDataAdapter da = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable(" students");
                da.Fill(dt);
                datagrid.ItemsSource = dt.DefaultView;
                da.Update(dt);

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public void qshowdata()
        {


            string mysqlConnection = "Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''";
            try
            {

                MySqlConnection conn = new MySqlConnection(mysqlConnection);
                conn.Open();
                string q = "SELECT q_id , q_title FROM questions";
                MySqlCommand cmd = new MySqlCommand(q);



                MySqlDataAdapter dap = new MySqlDataAdapter(q, conn);
                DataTable dt = new DataTable(" questions");
                dap.Fill(dt);
                qdatagrid.ItemsSource = dt.DefaultView;
                dap.Update(dt);
                conn.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);



            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string mysqlConnection = "Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''";
            try
            {

                using (MySqlConnection conn = new MySqlConnection(mysqlConnection))
                {
                    string q = "DELETE FROM students";
                    MySqlCommand cmd = new MySqlCommand(q,conn);
                    conn.Open();
                  
                    cmd.ExecuteNonQuery();
                    string qq = "DELETE FROM questions";
                    MySqlCommand ccmd = new MySqlCommand(qq, conn);
                  
                    ccmd.ExecuteNonQuery();
                    MessageBox.Show("All data deleted");
                    showdata();
                    qshowdata();
                    conn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
        }
    }
}