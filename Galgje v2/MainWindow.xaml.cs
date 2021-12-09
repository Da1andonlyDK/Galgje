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
using System.Windows.Threading;

namespace Galgje_v2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Declareren variables
        /// Aanmaken mediaplayer voor achtergrondmuziek
        /// Aanmaken timer
        /// Aanmaken accentkleur
        /// </summary>
        private int aantalLevens = 10, countdown = 11;
        private string fouteLetters, geheimWoord, geheimWoordTemp;
        private MediaPlayer achtergrondMuziek = new MediaPlayer();
        private DispatcherTimer timer = new DispatcherTimer();
        private Color accent = new Color();

        /// <summary>
        /// <code>
        /// Componenten initialiseren.
        /// UpdateGalg uitvoeren.
        /// Timer interval instellen.
        /// Timertick event aanmaken.
        /// Path naar achtergrondmuziek geven.
        /// Achtergrondmuziek starten.
        /// Event handler maken voor wanneer muziek afloopt.
        /// Waardes voor accentkleur declareren
        /// Instructie tonen.
        /// </code>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            UpdateGalg();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += TimerTick;
            achtergrondMuziek.Open(new Uri(@"Resources/unseenhorrors.mp3", UriKind.Relative));
            achtergrondMuziek.Play();
            achtergrondMuziek.MediaEnded += new EventHandler(MediaEnded);
            accent.R = 181;
            accent.G = 20;
            accent.B = 36;
            accent.A = 128;
            MSG_Label.Content = "Druk op  ' Nieuw Spel '  om te starten";
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
        /// <code>
        /// Event Handler 'Verberg'-knop.
        /// -----------------------------
        /// Timer starten.
        /// Spelerinput opslaan en 'verbergen'.
        /// 'Verberg'-knop verbergen, 'Start opnieuw'-knop tonen, 'Raad'-knop tonen.
        /// Instructie voor speler 1.
        /// Methode OutputTekst oproepen.
        /// </code>
        /// </summary>
        private void BTN_Verberg_MouseDown(object sender, RoutedEventArgs e)
        {
            timer.Start();
            geheimWoord = Input.Text.ToLower();
            Input.Text = "";
            BTN_Verberg.Visibility = Visibility.Hidden;
            BTN_StartOpnieuw.Visibility = Visibility.Visible;
            BTN_Raad.Visibility = Visibility.Visible;
            MSG_Label.Content = "Speler 2, begin met raden.";
            geheimWoordTemp = TempGeheimWoord();
            OutputText();
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
                        OutputText();
                    }
                    else
                    {
                        fouteLetters += $"{Input.Text} ";
                        TimerReset();
                    }
                }
                else if (Input.Text.ToLower() == geheimWoord)
                {
                    MSG_Label.Content = $"Proficiat speler 2, je hebt het geheime woord  ' {geheimWoord} '  geraden !!!";
                }
                else
                {
                    aantalLevens--;
                    TimerReset();
                }
            }
            else
            {
                timer.Stop();
                TB_Timer.Text = "";
            }
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
            UpdateGalg();
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

        private string TempGeheimWoord()
        {
            string temp = "";

            for (int i = 0; i < geheimWoord.Length; i++)
            {
                if (geheimWoord[i] == ' ')
                {
                    temp += "  ";
                }
                else
                {
                    temp += "- ";
                }
            }
            return temp;
        }

        /// <summary>
        /// Methode om aantal levens, juist letters en foute letters te tonen.
        /// </summary>
        private void OutputText()
        {
            Output.Text = $"Aantal levens: {aantalLevens}\n\r" +
                          $"Geheim Woord: {geheimWoordTemp}\n\r" +
                          $"Foute letters: {fouteLetters}";
            Input.Text = "";
        }

        /// <summary>
        /// Methode om galg afbeeldingen te updaten
        /// </summary>
        private void UpdateGalg()
        {
            BitmapImage galg = new BitmapImage();
            galg.BeginInit();
            galg.UriSource = new Uri($"/Resources/galg{aantalLevens}.png", UriKind.RelativeOrAbsolute);
            galg.EndInit();
            IMG_Galg.Source = galg;
        }

        /// <summary>
        /// Methode om styling van elk label aan te passen bij MouseEnter event.
        /// </summary>
        private void LBL_MouseEnter(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Background = Brushes.Black;
            lbl.Foreground = Brushes.GhostWhite;
            lbl.BorderBrush = Brushes.GhostWhite;
        }

        /// <summary>
        /// methode om styling van elk label aan te passen bij MouseLeave event.
        /// </summary>
        private void LBL_MouseLeave(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Background = Brushes.Transparent;
            lbl.Foreground = (Brush)new BrushConverter().ConvertFrom("#B51424");
            lbl.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Methode om af te tellen.
        /// Indien countdown onder 0 gaat, TimerReset oproepen.
        /// Indien levens op zijn, timer stoppen en textbox clearen.
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            countdown--;
            TB_Timer.Text = countdown.ToString();

            if (countdown == 0)
            {
                VolledigScherm.Background = new SolidColorBrush(accent);
            }
            else if (countdown < 0)
            {
                TimerReset();
            }
            else if (aantalLevens == 0)
            {
                timer.Stop();
                TB_Timer.Text = "0";
                MSG_Label.Content = $"Sorry, je hebt geen levens meer over... Het geheime woord was ' {geheimWoord} ' .";
            }
        }

        private void TimerReset()
        {
            VolledigScherm.Background = new SolidColorBrush(accent);
            aantalLevens--;
            UpdateGalg();
            OutputText();
            countdown--;
            timer.Stop();
            countdown = 10;
            timer.Start();
            VolledigScherm.Background = Brushes.Transparent;
            TB_Timer.Text = countdown.ToString();
        }

        /// <summary>
        /// Methode om achtergrondmuziek continue te laten spelen
        /// </summary>
        private void MediaEnded(object sender, EventArgs e)
        {
            achtergrondMuziek.Open(new Uri(@"Resources/unseenhorrors.mp3", UriKind.Relative));
            achtergrondMuziek.Play();
        }

        /// <summary>
        /// 'Play'-knop functioneel maken.
        /// </summary>
        private void BTN_Play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            achtergrondMuziek.Play();
        }

        /// <summary>
        /// 'Stop'-knop functioneel maken.
        /// </summary>
        private void BTN_Stop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            achtergrondMuziek.Pause();
        }
    }
}
