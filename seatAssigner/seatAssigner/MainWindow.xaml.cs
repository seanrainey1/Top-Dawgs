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
         
            Random rand = new Random();
          

            if (File.Exists(fileReadTXT.Text)== true && File.Exists(brokeCompsTXT.Text) == true)
            {


                var lines = File.ReadAllLines(fileReadTXT.Text); //reads in each line of the student name csv

                var first_name = string.Empty;
                var last_name = string.Empty;

                List<string> usedSeats = new List<string>(); //creates list to hold seat numbers which have already been used

                var values = File.ReadAllLines(brokeCompsTXT.Text); //reads in each line of broken computer csv

                var comps = string.Empty;

                List<string> brokeComps = new List<string>(); // creates list to hold the broken computer csv values



                for (int i = 1; i < values.Length; i++) //adds all broken computer numbers to the brokecomps list
                {
                    brokeComps.Add(comps);
                }

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var column = line.Split(',');
                    first_name = column[0];
                    last_name = column[1];
                    int assignedSeat = rand.Next(50);
                  

                    if (usedSeats.Contains(Convert.ToString(assignedSeat)) || usedSeats.Contains(Convert.ToString(brokeComps)))
                    {
                        do
                        {
                            assignedSeat = rand.Next(50);
                        } while (usedSeats.Contains(Convert.ToString(assignedSeat)) || usedSeats.Contains(Convert.ToString(brokeComps)));
                    }

                    usedSeats.Add(Convert.ToString(assignedSeat));

                    assignedSeatsLB.Items.Add($"{first_name} {last_name} seat {assignedSeat}");
                }

              


            }
        }

        private void nameReadBut_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            fileReadTXT.Text = dlg.FileName;
            
        }

        private void ReadWorkstationsBut_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            brokeCompsTXT.Text = dlg.FileName;
        }
    }
}
