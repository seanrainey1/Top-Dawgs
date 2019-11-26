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

                var first_name = string.Empty;
                var last_name = string.Empty;
                List<int> usedSeats = new List<int>();
                
              

                for (int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i];
                    var column = line.Split(',');
                    first_name = column[0];
                    last_name = column[1];
                    int assignedSeat = rand.Next(50);
                    
                   
                    if(usedSeats.Contains(assignedSeat))
                    {
                        do
                        {
                            assignedSeat = rand.Next(50);
                        } while (usedSeats.Contains(assignedSeat) == true);
                    }

                    usedSeats.Add(assignedSeat);

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
    }
}
