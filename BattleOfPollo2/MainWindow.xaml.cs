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
            // VARIABLES

            // Obtengo el valor del TextBox dmg
            string dmgText = dmgTextBox.Text;
            double dmgDouble;

            // Obtengo el valor del TextBox def
            string defText = dmgTextBox.Text;
            double defDouble;

            // Obtengo el valor del TextBox Bonus Damage 
            string dmgBonus = dmgBonusTextBox.Text;
            double dmgBonusDouble;

            // Obtengo el valor del Textbos Bonus defense
            string defBonus = defBonusTextBox.Text;
            double defBonusDouble;


            // COMPROBACIÓN DEL PARSEO


            // Intento parsear los valores
            bool parseoDmg = double.TryParse(dmgText, out dmgDouble);
            bool parseoDef = double.TryParse(defText, out defDouble);
            bool parseoBonusDmg = double.TryParse(dmgBonus, out dmgBonusDouble);
            bool parseoBonusDef = double.TryParse(defBonus, out defBonusDouble);

            double resultado; // Resultado Final
            double resultRounded; // Redondeo del resultado final

            #region

            if (parseoDmg && parseoDef && parseoBonusDmg && parseoBonusDef) // Si se parsea correctamente
            {
                // Se hace el calculo del daño recibido
                resultado = (dmgDouble) - (defDouble * 0.6);
                resultado += (dmgBonusDouble - defBonusDouble);

                // Redondeamos el resultado
                resultRounded = Math.Round(resultado);

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
            #endregion
        }
    }
}