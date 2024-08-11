using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BattleOfPollo2
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
            // Obtengo el valor del textBox dmg
            string dmgText = dmgTextBox.Text;
            // double dmg = double.Parse(dmgText);
            double dmgDouble;

            string defText = dmgTextBox.Text;
            // double dmg = double.Parse(dmgText);
            double defDouble;

            bool parseoDmg = double.TryParse(dmgText, out dmgDouble);
            bool parseoDef = double.TryParse(defText, out defDouble);
            if (parseoDmg && parseoDef)
            {
                // Se hace el calculo del daño recibido
                double resultado = (dmgDouble) - (defDouble * 0.6);

                // Redondeamos el resultado
                double resultRounded = Math.Round(resultado);

                if (resultRounded < 0)
                {
                    lblRes.Content = "Daño recibido: " + 0;
                }
                else
                {
                    lblRes.Content = "Daño recibido: " + resultRounded.ToString();
                }
            }
            else
            {
                lblRes.Content = "¡ERROR!";
                MessageBox.Show("¡Error! Ingresa formato numérico PELOTUDO");
            }

            







            

            
            
            
        }
    }
}