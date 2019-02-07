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
    /// Interaction logic for adminsoption.xaml
    /// </summary>
    public partial class adminsoption : Window
    {
        public adminsoption()
        {
            InitializeComponent();
            addstd.Visibility = Visibility.Collapsed;
            addquestion.Visibility = Visibility.Collapsed;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Addexambtn_Click(object sender, RoutedEventArgs e)
        {
            addquestion.Visibility = Visibility.Visible;
            Options.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            
           // addquestions aq = new addquestions();
            //aq.Show();
            //this.Close();

        }

        private void Addstdbtn_Click(object sender, RoutedEventArgs e)
        {
            addstd.Visibility = Visibility.Visible;
            Options.Visibility = Visibility.Collapsed;
            back.Visibility = Visibility.Collapsed;
            //addstudents ad = new addstudents();
            //ad.Show();
            //this.Close();

        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            addstd.Visibility = Visibility.Collapsed;
            Options.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;
        }

        private void Btnadd_Click(object sender, RoutedEventArgs e)
        {
            if (!studisempty())
            {
                MessageBox.Show("one or more empty fields");
            }
            else
            {
                MySqlConnection mysqlConnection = new MySqlConnection("Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''");
                try
                {
                    {
                        if (mysqlConnection.State == ConnectionState.Closed)
                        {

                            mysqlConnection.Open();
                            String sql = "insert into students (std_name,std_password) values(@stdname,@stdpswd)";

                            using (MySqlCommand scmd = new MySqlCommand(sql, mysqlConnection))
                            {
                                scmd.Parameters.AddWithValue("@stdname", txtstudusrname.Text);
                                scmd.Parameters.AddWithValue("@stdpswd", txtstudpswd.Password);

                                scmd.ExecuteNonQuery();
                                MessageBox.Show("student added!! ");
                                txtstudusrname.Text = "";
                                txtstudpswd.Password = "";


                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mysqlConnection.Close();
                }
            }
        }
        private Boolean studisempty()
        {
            if (txtstudusrname.Text == "" || txtstudpswd.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Xbtn_Click(object sender, RoutedEventArgs e)
        {
            addquestion.Visibility = Visibility.Collapsed;
            Options.Visibility = Visibility.Visible;
            back.Visibility = Visibility.Visible;

        }

        private void Btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!quisempty())
            {
                MessageBox.Show("one or more empty fields");
            }
            else
            {
                MySqlConnection mysqlConnection = new MySqlConnection("Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''");
                try
                {
                    {
                        if (mysqlConnection.State == ConnectionState.Closed)
                        {

                            mysqlConnection.Open();
                            String sql = "insert into questions (q_title,q_opa,q_opb,q_opc,q_opd,q_correct) values(@title,@opa,@opb,@opc,@opd,@opcorrect)";

                            using (MySqlCommand scmd = new MySqlCommand(sql, mysqlConnection))
                            {
                                scmd.Parameters.AddWithValue("@title", txtQ.Text);
                                scmd.Parameters.AddWithValue("@opa", txtopa.Text);
                                scmd.Parameters.AddWithValue("@opb", txtopb.Text);
                                scmd.Parameters.AddWithValue("@opc", txtopc.Text);
                                scmd.Parameters.AddWithValue("@opd", txtopd.Text);
                                scmd.Parameters.AddWithValue("@opcorrect", txtans.Text);



                                scmd.ExecuteNonQuery();
                                MessageBox.Show("question inserted !! ");
                                txtQ.Text = "";
                                txtopa.Text = "";
                                txtopb.Text = "";
                                txtopc.Text = "";
                                txtopd.Text = "";
                                txtans.Text = "";

                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mysqlConnection.Close();
                }
            }
        }
        private Boolean quisempty()
        {
            if (txtQ.Text == "" || txtopa.Text == "" || txtopb.Text == "" || txtopc.Text == "" || txtopd.Text == "" || txtans.Text == "")
            {
                return false;


            }
            else
            {
                return true;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Clos_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

      

        private void Viewstdbtn_Click(object sender, RoutedEventArgs e)
        {
            view v = new view();
            v.showdata();
            v.qshowdata();
            v.Show();
            
            this.Close();
        }
    }
}
      
           
