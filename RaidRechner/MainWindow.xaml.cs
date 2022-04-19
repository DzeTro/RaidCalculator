using System;
using System.Windows;
using System.Windows.Controls;


namespace RaidRechner
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] raidArray = new string[] { "Raid 0", "Raid 1", "Raid 5", "Raid 6" };
        public MainWindow()
        {
            InitializeComponent();
            cb_Raids.ItemsSource = raidArray;
            cb_Raids.SelectedIndex = 0;
        }

        private void tb_AnzahlPlatten_TextChanged(object sender, TextChangedEventArgs e) => RaidController();
        private void tb_GroessePlatten_TextChanged(object sender, TextChangedEventArgs e) => RaidController();
        private void cb_Raids_SelectionChanged(object sender, SelectionChangedEventArgs e) => RaidController();

        private void RaidController()
        {
            int ausgewaehltesRaid = 0;
            if(tb_Brutto != null)
            try
            {
                
                tb_Brutto.Text = (int.Parse(tb_GroessePlatten.Text) * int.Parse(tb_AnzahlPlatten.Text)).ToString();
                    ausgewaehltesRaid = cb_Raids.SelectedIndex;
                    if (ausgewaehltesRaid == 0)
                    {
                        tb_Netto.Text = tb_Brutto.Text;
                    }
                    else if (ausgewaehltesRaid == 1)
                    {
                        tb_Netto.Text = tb_GroessePlatten.Text;
                    }
                    else if (ausgewaehltesRaid == 2)
                    {
                        tb_Netto.Text = ((int.Parse(tb_AnzahlPlatten.Text) - 1) * int.Parse(tb_GroessePlatten.Text)).ToString();
                    }
                    else
                    {
                        tb_Netto.Text = ((int.Parse(tb_AnzahlPlatten.Text) - 2) * int.Parse(tb_GroessePlatten.Text)).ToString();
                    }
                }
            catch (FormatException)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(tb_GroessePlatten.Text, "^[0-9]*$") ||
                !System.Text.RegularExpressions.Regex.IsMatch(tb_AnzahlPlatten.Text, "^[0-9]*$"))
                {
                    {
                        MessageBox.Show("Bitte nur Zahlen eingeben");
                    }
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Bitte Feld nicht leer lassen");
            }
            catch (Exception)
            {
                MessageBox.Show("Unbekannter Fehler");
            }

        }
    }
}
