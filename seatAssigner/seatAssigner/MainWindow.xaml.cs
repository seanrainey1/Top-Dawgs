using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO; 
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace seatAssigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numStudents = 0;
            Random rand = new Random();


            if (File.Exists(fileReadTXT.Text)== true)
            {
                
                var lines = File.ReadAllLines(fileReadTXT.Text);

                foreach (var item in lines)
                {
                    
                    numStudents++;
                    
                }



                if (numStudents>50)
                {
                    MessageBox.Show("Number of students is greater than available seats");
                }

                if(numStudents<=50)
                {
                    int x = 0;
                    do
                    {
                        rand.Next(numStudents-1);
                    } while (x <= numStudents-1);
                    
                }

            }
        }

        private void nameReadBut_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            fileReadTXT.Text = dlg.FileName;
            
        }
    }
}
