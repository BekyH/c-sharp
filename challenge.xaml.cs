using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace quizapp
{
    /// <summary>
    /// Interaction logic for challenge.xaml
    /// </summary>
    public partial class challenge : Window
    {
        int i,score=0,missed=0,got=0;
        String correctans;
        public challenge()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            displayresult.Visibility = Visibility.Collapsed;
            btn_next.IsEnabled=false;
            ch.Visibility = Visibility.Collapsed;
        }
        @return rc = new @return();

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Btn_start_Click(object sender, RoutedEventArgs e)
        {
            int k = 1;
           
            ch.Visibility = Visibility.Visible;
            labelscoretxt.Content = score.ToString();
            i = Convert.ToInt32(rc.scalarreturn("select min(q_id) from questions"));
            labelq.Content = k +". " + rc.scalarreturn("select q_title from questions where q_id=" + i);
            rba.Content = rc.scalarreturn("select q_opa from questions where q_id=" + i);
            rbb.Content = rc.scalarreturn("select q_opb from questions where q_id=" + i);
            rbc.Content = rc.scalarreturn("select q_opc from questions where q_id=" + i);
            rbd.Content = rc.scalarreturn("select q_opd from questions where q_id=" + i);
            correctans = rc.scalarreturn("select q_correct from questions where q_id=" + i);
            btn_start.IsEnabled = false;
            btn_next.IsEnabled = true;
        }
        string str,checkedvalue;
        int j = 2;

        private void Minim_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Closeing_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            // stdLogin st = new stdLogin();
            //st.Show();
            //this.Close();
            MainWindow ma = new MainWindow();
            ma.Show();
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            displayresult.Visibility = Visibility.Collapsed;
        }

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            if ((rba.IsChecked==true) || (rbb.IsChecked==true) || (rbc.IsChecked==true) || (rbd.IsChecked==true))
            {
                if (rba.IsChecked == true)
                {
                    checkedvalue = rba.Content.ToString();
                }
                else if (rbb.IsChecked == true)
                {
                    checkedvalue = rbb.Content.ToString();
                }
                else if (rbc.IsChecked == true)
                {
                    checkedvalue = rbc.Content.ToString();
                }
                else if (rbd.IsChecked == true)
                {
                    checkedvalue = rbd.Content.ToString();
                }
                if (checkedvalue == correctans)
                {
                    score += 5;
                    got++; 
                    labelscoretxt.Content = score.ToString();
                }
                else
                {
                       
                    missed++;
                }
                str = rc.scalarreturn("select min(q_id) from questions where q_id>" + i);
                if (str.Equals(""))
                {
                    scoredisplay.Text = "your final score is  " + score.ToString() + "\n" + " you answered " + got + " questions\n " + " you missed  " + missed + " questions\n" + " quiz is over";
                    displayresult.Visibility = Visibility.Visible;
                    score = 0;
                    labelscoretxt.Content = score.ToString();
                    labelq.Content = " ";
                    rba.Content = " ";
                    rbb.Content = " ";
                    rbc.Content = " ";
                    rbd.Content = " ";
                    btn_start.IsEnabled = true;
                    btn_next.IsEnabled = false;
                    ch.Visibility = Visibility.Collapsed;
                    missed = 0;
                    got = 0;
                    //MessageBox.Show("your final score is " + score.ToString() + "\n" + " quiz is over");
                    //btn_next.IsEnabled = false;
                }
                else
                {
                    i = Convert.ToInt32(str);
                    labelq.Content = j + ". " + rc.scalarreturn("select q_title from questions where q_id=" + i);
                    rba.Content = rc.scalarreturn("select q_opa from questions where q_id=" + i);
                    rbb.Content = rc.scalarreturn("select q_opb from questions where q_id=" + i);
                    rbc.Content = rc.scalarreturn("select q_opc from questions where q_id=" + i);
                    rbd.Content = rc.scalarreturn("select q_opd from questions where q_id=" + i);
                    correctans = rc.scalarreturn("select q_correct from questions where q_id=" + i);
                    j++;
                }
                radiobtn();
            }
           
            else
            {
                MessageBox.Show("please select one option");
            }
           

        }
       public void radiobtn()
        {
            rba.IsChecked = false;
            rbb.IsChecked = false;
            rbc.IsChecked = false;
            rbd.IsChecked = false;
        }

      
    }
}