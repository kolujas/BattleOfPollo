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
            double dmgDouble;

            // Obtengo el valor del textBox def
            string defText = dmgTextBox.Text;
            double defDouble;

            // Intento parsear ambos valores
            bool parseoDmg = double.TryParse(dmgText, out dmgDouble);
            bool parseoDef = double.TryParse(defText, out defDouble);

            
            if (parseoDmg && parseoDef) // Si se parsea correctamente
            {
                // Se hace el calculo del daño recibido
                double resultado = (dmgDouble) - (defDouble * 0.6);

                // Redondeamos el resultado
                double resultRounded = Math.Round(resultado);

                if (resultRounded < 0) // Si el valor da menos de 0 muestro en pantalla 0 (como daño minimo recibido)
                {
                    lblRes.Content = "Daño recibido: " + 0;
                }
                else // Sino muestro en pantalla el daño recibido
                {
                    lblRes.Content = "Daño recibido: " + resultRounded.ToString();
                }
            } 
            else // Sino se parsea correctamente muestro en pantalla mensajes de errores
            {
                lblRes.Content = "¡ERROR!";
                MessageBox.Show("¡Error! Ingresa formato numérico PELOTUDO");
            }

            







            

            
            
            
        }
    }
}