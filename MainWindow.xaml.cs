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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace quizapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            adminlogin.Visibility = Visibility.Collapsed;
            stdlogin.Visibility = Visibility.Collapsed;
            
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Admin_btn_Click(object sender, RoutedEventArgs e)
        {
            adminlogin.Visibility = Visibility.Visible;
            aaa.Visibility = Visibility.Collapsed;

            // LoginAdmin login = new LoginAdmin();
            //login.Show();
            //this.Close();
        }

        private void Std_btn_Click(object sender, RoutedEventArgs e)
        {
            stdlogin.Visibility = Visibility.Visible;
            aaa.Visibility = Visibility.Collapsed;
            //stdLogin sl = new stdLogin();
            //sl.Show();
            //this.Close();
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (adminisempty())
            {
                MySqlConnection mysqlConnection = new MySqlConnection("Data Source= localhost;Initial Catalog=quiz;Integrated Security=true;username=root;password=''");
                try
                {
                    {
                        if (mysqlConnection.State == ConnectionState.Closed)
                        {

                            mysqlConnection.Open();
                            string query = "SELECT COUNT(1) FROM admin_athu WHERE adminname=@username AND adminpassword=@password";
                            MySqlCommand mysqlcmd = new MySqlCommand(query, mysqlConnection);
                            mysqlcmd.CommandType = CommandType.Text;
                            mysqlcmd.Parameters.AddWithValue("@username", txtusrname.Text);
                            mysqlcmd.Parameters.AddWithValue("@password", txtpswd.Password);
                            int count = Convert.ToInt32(mysqlcmd.ExecuteScalar());
                            if (count == 1)
                            {




                                adminsoption ao = new adminsoption();
                                ao.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("u are u username or password is not correct");
                                txtusrname.Text = "";
                                txtpswd.Password = "";
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


            else
            {
                MessageBox.Show("login failed due to empty fields");

            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            adminlogin.Visibility = Visibility.Collapsed;
            aaa.Visibility = Visibility.Visible;

        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (!stdisempty())
            {
                MessageBox.Show("login failed one or more empty fields");
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
                            string query = "SELECT COUNT(1) FROM students WHERE std_name=@stdname AND std_password=@stdpassword";
                            MySqlCommand mysqlcmd = new MySqlCommand(query, mysqlConnection);
                            mysqlcmd.CommandType = CommandType.Text;
                            mysqlcmd.Parameters.AddWithValue("@stdname", txtstdusrname.Text);
                            mysqlcmd.Parameters.AddWithValue("@stdpassword", txtstdpswd.Password);
                            int count = Convert.ToInt32(mysqlcmd.ExecuteScalar());
                            if (count == 1)
                            {




                                challenge ch = new challenge();
                                ch.Show();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("u are u username or password is not correct");
                                txtstdusrname.Text = "";
                                txtstdpswd.Password = "";
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            stdlogin.Visibility = Visibility.Collapsed;
            aaa.Visibility = Visibility.Visible;
        }
        private Boolean adminisempty()
        {
            if (txtusrname.Text == "" || txtpswd.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Boolean stdisempty()
        {
            if (txtstdusrname.Text == "" || txtstdpswd.Password == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Mini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Closing_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
