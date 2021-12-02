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

namespace Galgje_v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Declareren variables
        /// </summary>
        private int aantalLevens = 10;
        private string juisteLetters;
        private string fouteLetters;
        private string geheimWoord;

        public MainWindow()
        {
            InitializeComponent();
            MSG_Label.Content = "Druk op  ' Nieuw Spel '  om te starten";
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_NieuwSpel_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_NieuwSpel.Background = Brushes.Black;
            BTN_NieuwSpel.Foreground = Brushes.GhostWhite;
            BTN_NieuwSpel.BorderBrush = Brushes.GhostWhite;
        }

        /// <summary>
        /// <code>
        /// Event Handler 'Nieuw Spel'-knop.
        /// --------------------------------
        /// Input enablen en tonen.
        /// 'Nieuw Spel'-knop verbergen, 'Verberg woord'-knop tonen.
        /// Instructie voor speler 1.
        /// </code>
        /// </summary>
        private void BTN_NieuwSpel_MouseDown(object sender, RoutedEventArgs e)
        {
            Input.IsEnabled = true;
            Input.Visibility = Visibility.Visible;
            BTN_NieuwSpel.Visibility = Visibility.Hidden;
            BTN_Verberg.Visibility = Visibility.Visible;
            MSG_Label.Content = "Speler 1, geef een geheim woord in en verberg het.";
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_NieuwSpel_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_NieuwSpel.Background = Brushes.Transparent;
            BTN_NieuwSpel.Foreground = (Brush)new BrushConverter().ConvertFrom("#B51424");
            BTN_NieuwSpel.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_Verberg_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_Verberg.Background = Brushes.Black;
            BTN_Verberg.Foreground = Brushes.GhostWhite;
            BTN_Verberg.BorderBrush = Brushes.GhostWhite;
        }

        /// <summary>
        /// <code>
        /// Event Handler 'Verberg'-knop.
        /// -----------------------------
        /// Spelerinput opslaan en 'verbergen'.
        /// 'Verberg'-knop verbergen, 'Start opnieuw'-knop tonen, 'Raad'-knop tonen.
        /// Instructie voor speler 1.
        /// Methode OutputTekst oproepen.
        /// </code>
        /// </summary>
        private void BTN_Verberg_MouseDown(object sender, RoutedEventArgs e)
        {
            geheimWoord = Input.Text.ToLower();
            Input.Text = "";
            BTN_Verberg.Visibility = Visibility.Hidden;
            BTN_StartOpnieuw.Visibility = Visibility.Visible;
            BTN_Raad.Visibility = Visibility.Visible;
            MSG_Label.Content = "Speler 2, begin met raden.";
            OutputText();
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_Verberg_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_Verberg.Background = Brushes.Transparent;
            BTN_Verberg.Foreground = (Brush)new BrushConverter().ConvertFrom("#B51424");
            BTN_Verberg.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_Raad_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_Raad.Background = Brushes.Black;
            BTN_Raad.Foreground = Brushes.GhostWhite;
            BTN_Raad.BorderBrush = Brushes.GhostWhite;
        }

        /// <summary>
        /// <code>
        /// Event Handler 'Raad'-knop.
        /// --------------------------
        /// Instructies verbergen.
        /// Controle op aantal levens.
        /// Indien levens niet op zijn, input controleren op lengte.
        /// Indien input 1 char is, overeenkomst met char's van variable controleren.
        /// Indien overeenkomst, input toevoegen aan juiste letters. Indien geen overeenkomst, input toevoegen aan foute letters, -1 leven.
        /// Indien input meerdere char's is, input controleren op overeenkomst variable.
        /// Indien overeenkomst, instructie tonen. Indien geen overeenkomst, - 1 leven.
        /// Instructie indien levens op zijn.
        /// </code>
        /// </summary>
        private void BTN_Raad_MouseDown(object sender, RoutedEventArgs e)
        {
            MSG_Label.Content = "";

            if (aantalLevens != 0)
            {
                if (Input.Text.Length == 1)
                {
                    if (geheimWoord.Contains(Input.Text.ToLower()))
                    {
                        juisteLetters += Input.Text;
                        OutputText();
                    }
                    else
                    {
                        fouteLetters += Input.Text;
                        aantalLevens--;
                        OutputText();
                    }
                }
                else if (Input.Text.ToLower() == geheimWoord)
                {
                    MSG_Label.Content = $"Proficiat speler 2, je hebt het geheime woord  ' {geheimWoord} '  geraden !!!";
                }
                else
                {
                    aantalLevens--;
                    OutputText();
                }
            }
            else
            {
                MSG_Label.Content = $"Sorry, je hebt geen levens meer over... Het geheime woord was ' {geheimWoord} ' .";
            }
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_Raad_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_Raad.Background = Brushes.Transparent;
            BTN_Raad.Foreground = (Brush)new BrushConverter().ConvertFrom("#B51424");
            BTN_Raad.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_StartOpnieuw_MouseEnter(object sender, MouseEventArgs e)
        {
            BTN_StartOpnieuw.Background = Brushes.Black;
            BTN_StartOpnieuw.Foreground = Brushes.GhostWhite;
            BTN_StartOpnieuw.BorderBrush = Brushes.GhostWhite;
        }

        /// <summary>
        /// <code>
        /// Event handler 'Start Opnieuw'-knop.
        /// -----------------------------------
        /// Resetten aantal levens.
        /// Clearen juiste en foute letters.
        /// Clearen input en output.
        /// 'Start Opnieuw'-knop verbergen, 'Raad'-knop verbergen, 'Nieuw Spel'-knop tonen.
        /// Input disablen en verbergen.
        /// Instructie tonen.
        /// </code>
        /// </summary>
        private void BTN_StartOpnieuw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            aantalLevens = 10;
            juisteLetters = "";
            fouteLetters = "";
            Input.Text = "";
            Output.Text = "";
            BTN_StartOpnieuw.Visibility = Visibility.Hidden;
            BTN_Raad.Visibility = Visibility.Hidden;
            BTN_NieuwSpel.Visibility = Visibility.Visible;
            Input.IsEnabled = false;
            Input.Visibility = Visibility.Hidden;
            MSG_Label.Content = "Druk op  ' Nieuw Spel '  om te starten";
        }

        /// <summary>
        /// Styling aanpassen.
        /// </summary>
        private void BTN_StartOpnieuw_MouseLeave(object sender, MouseEventArgs e)
        {
            BTN_StartOpnieuw.Background = Brushes.Transparent;
            BTN_StartOpnieuw.Foreground = (Brush)new BrushConverter().ConvertFrom("#B51424");
            BTN_StartOpnieuw.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Methode om aantal levens, juist letters en foute letters te tonen.
        /// </summary>
        private void OutputText()
        {
            Output.Text = $"Aantal levens: {aantalLevens}\n\r" +
                          $"Juiste letters: {juisteLetters }\n\r" +
                          $"Foute letters: {fouteLetters }";
            Input.Text = "";
        }

        /// <summary>
        /// 'Play'-knop functioneel maken.
        /// </summary>
        private void BTN_Play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        /// <summary>
        /// 'Stop'-knop functioneel maken.
        /// </summary>
        private void BTN_Stop_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}