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


        private double GetDamageValue()
        {
            return GetDoubleValue(dmgTextBox.Text);
        }

        private double GetDefenseValue()
        {
            return GetDoubleValue(defTextBox.Text);
        }

        private double GetBonusDamageValue()
        {
            return GetDoubleValue(dmgBonusTextBox.Text);
        }

        private double GetBonusDefenseValue()
        {
            return GetDoubleValue(defBonusTextBox.Text);
        }

        private double GetDamageIncrease(double porcentaje)
        {
            double valorPorcentajeDmg = GetDoubleValue(porcentajeDmg.Text);
            double aumento = valorPorcentajeDmg * porcentajeDecimal;
        }

        private double GetDoubleValue(string text)
        {
            double value;
            if (double.TryParse(text, out value))
            {
                return value;
            }
            else
            {
                MessageBox.Show("¡Error! Ingresa formato numérico PELOTUDO");
                return 0; // Or throw an exception for stricter error handling
            }
        }

        private double CalculateDamage(double damage, double defense, double bonusDamage, double bonusDefense, double damageIncrease)
        {
            double netDamage = damage + bonusDamage + damageIncrease;
            double netDefense = defense + bonusDefense;
            double reducedDamage = netDamage - (netDefense * 0.6);
            return Math.Max(0, reducedDamage); // Ensure damage is non-negative
        }


        private void CalculateDamageReceived()
        {
            double damage = GetDamageValue();
            double defense = GetDefenseValue();
            double bonusDamage = GetBonusDamageValue();
            double bonusDefense = GetBonusDefenseValue();
            double damageIncrease = GetDamageIncrease(porcentajeAumento);

            double result = damage - (defense * 0.6) + (bonusDamage - bonusDefense);
            double resultRounded = Math.Round(result);

            if (resultRounded < 0)
            {
                lblRes.Content = "Daño recibido: " + 0;
            }
            else
            {
                lblRes.Content = "Daño recibido: " + resultRounded.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CalculateDamageReceived();
        }

        /* private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             List<string> characters = new List<string>() { "Umbra", "Rinach", "Corvus", "Balhaar", "Aila", "Norfin", "Eiron", "Maneki", "Kaeru" };

             characters.Sort();
             ComboBox comboBox = sender as ComboBox;
             comboBox.Items.Clear();

             foreach (string character in characters)
             {
                 ComboBoxItem item = new ComboBoxItem();
                 item.Content = character;
                 comboBox.Items.Add(item);
             }
         }*/


    }
}