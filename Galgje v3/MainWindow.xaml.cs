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
using Microsoft.VisualBasic;

namespace Galgje_v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Declareren variables.
        /// </summary>
        private bool hint = false;
        private int aantalLevens = 10, aantalLevensOpgebruikt, countdown, countdownInput, countdownTwee = 1;
        private string fouteLetters, geheimWoord, tempOutput, spelerNaam, scoreSpeler;
        private string[] galgjeWoorden = new string[] { "grafeem", "tjiftjaf", "maquette", "kitsch", "pochet", "convocaat", "jakkeren", "collaps", "zuivel", "cesium", "voyant", "spitten", "pancake", "gietlepel", "karwats", "dehydreren", "viswijf", "flater", "cretonne", "sennhut", "tichel", "wijten", "cadeau", "trotyl", "chopper", "pielen", "vigeren", "vrijuit", "dimorf", "kolchoz", "janhen", "plexus", "borium", "ontweien", "quiche", "ijverig", "mecenaat", "falset", "telexen", "hieruit", "femelaar", "cohesie", "exogeen", "plebejer", "opbouw", "zodiak", "volder", "vrezen", "convex", "verzenden", "ijstijd", "fetisj", "gerekt", "necrose", "conclaaf", "clipper", "poppetjes", "looikuip", "hinten", "inbreng", "arbitraal", "dewijl", "kapzaag", "welletjes", "bissen", "catgut", "oxymoron", "heerschaar", "ureter", "kijkbuis", "dryade", "grofweg", "laudanum", "excitatie", "revolte", "heugel", "geroerd", "hierbij", "glazig", "pussen", "liquide", "aquarium", "formol", "kwelder", "zwager", "vuldop", "halfaap", "hansop", "windvaan", "bewogen", "vulstuk", "efemeer", "decisief", "omslag", "prairie", "schuit", "weivlies", "ontzeggen", "schijn", "sousafoon" };
        private string[] alfabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private char[] geheimWoordTemp, outputGeheimWoord;
        private List<string> scorebord = new List<string>();
        private List<char> alfabetTemp = new List<char>();
        private StringBuilder score = new StringBuilder();
        private MediaPlayer achtergrondMuziek = new MediaPlayer();
        private MediaPlayer verliesLeven = new MediaPlayer();
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer timerTwee = new DispatcherTimer();
        private Color accent = new Color();

        /// <summary>
        /// <code>
        /// Componenten initialiseren.
        /// Standaard methode's initialiseren.
        /// Instructie tonen.
        /// </code>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InstellenAccentKleur();
            UpdateGalg();
            InstellenTimers();
            InstellenAchtergrondmuziek();
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
            MSG_Label.Content = "Wil je tegen de computer spelen of tegen iemand anders ?";
            BTN_NieuwSpel.Visibility = Visibility.Hidden;
            BTN_Singleplayer.Visibility = Visibility.Visible;
            BTN_Multiplayer.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Oproepen 
        /// </summary>
        private void NieuwSpel_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            BTN_NieuwSpel_MouseDown(sender, e);
        }

        /// <summary>
        /// Methode om Singleplayer-modus te starten.
        /// </summary>

        private void BTN_Singleplayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimerInstellen();
            TB_Timer.Text = countdown.ToString();
            timer.Start();
            BTN_Singleplayer.Visibility = Visibility.Hidden;
            BTN_Multiplayer.Visibility = Visibility.Hidden;
            Random rng = new Random();
            geheimWoord = galgjeWoorden[rng.Next(galgjeWoorden.Length)];
            BTN_StartOpnieuw.Visibility = Visibility.Visible;
            BTN_Raad.Visibility = Visibility.Visible;
            TB_Input.Visibility = Visibility.Visible;
            TB_Input.IsEnabled = true;
            Hint.IsEnabled = true;
            MSG_Label.Content = "Begin met raden.";
            OutputGeheimWoord();
            OutputText();

        }

        /// <summary>
        /// Methode om Multiplayer-modus te starten.
        /// </summary>
        private void BTN_Multiplayer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TimerInstellen();
            BTN_Singleplayer.Visibility = Visibility.Hidden;
            BTN_Multiplayer.Visibility = Visibility.Hidden;
            BTN_Verberg.Visibility = Visibility.Visible;
            TB_Input.Visibility = Visibility.Visible;
            TB_Input.IsEnabled = true;
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
            if (!String.IsNullOrEmpty(TB_Input.Text))
            {
                TB_Timer.Text = countdown.ToString();
                timer.Start();
                geheimWoord = TB_Input.Text.ToLower();
                Hint.IsEnabled = true;
                TB_Input.Text = "";
                BTN_Verberg.Visibility = Visibility.Hidden;
                BTN_StartOpnieuw.Visibility = Visibility.Visible;
                BTN_Raad.Visibility = Visibility.Visible;
                MSG_Label.Content = "Speler 2, begin met raden.";
                OutputGeheimWoord();
                OutputText();
            }
            else
            {
                MessageBox.Show("Het lijkt er op dat je geen woord hebt ingegeven om te verbergen...", "Geen input...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                if (TB_Input.Text.Length == 1)
                {
                    if (geheimWoord.Contains(TB_Input.Text.ToLower()))
                    {
                        TimerResetCorrect();
                        VervangMetCorrecteLetters();
                        OutputText();
                    }
                    else if (!geheimWoord.Contains(TB_Input.Text.ToLower()))
                    {
                        FouteGok();
                        fouteLetters += $"{TB_Input.Text.ToLower()} ";
                        OutputText();
                    }
                }
                else if (TB_Input.Text.ToLower() == geheimWoord || String.Join("", outputGeheimWoord) == geheimWoord)
                {
                    BTN_Raad.Visibility = Visibility.Hidden;
                    TB_Input.IsEnabled = false;
                    TB_Input.Visibility = Visibility.Hidden;
                    Hint.IsEnabled = false;
                    TimerReset();
                    VervangMetCorrectWoord();
                    OutputText();
                    MSG_Label.Content = $"Proficiat, je hebt het geheime woord  ' {geheimWoord} '  geraden !!!";
                    ScoreOpslaan();
                }
                else
                {
                    FouteGok();
                    OutputText();
                }
            }
            else
            {
                TimerReset();
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
            timer.Stop();
            aantalLevens = 10;
            countdown = countdownInput;
            countdownTwee = 1;
            UpdateGalg();
            ClearAlleInputEnOutput();
            VolledigScherm.Background = Brushes.Transparent;
            BTN_StartOpnieuw.Visibility = Visibility.Hidden;
            BTN_Raad.Visibility = Visibility.Hidden;
            BTN_NieuwSpel.Visibility = Visibility.Visible;
            TB_Input.IsEnabled = false;
            TB_Input.Visibility = Visibility.Hidden;
            MSG_Label.Content = "Druk op  ' Nieuw Spel '  om te starten";
        }

        /// <summary>
        /// <code>
        /// Methode om correct geraden letters te tonen op correcte positie in array.
        /// -------------------------------------------------------------------------
        /// Aanmaken char.
        /// Indien input overeenkomt met char, karakter in array vervangen door char.
        /// </code>
        /// </summary>
        private void VervangMetCorrecteLetters()
        {
            char a = char.Parse(TB_Input.Text.ToLower());

            for (int i = 0; i < geheimWoord.Length; i++)
            {
                if (geheimWoordTemp[i] == a)
                {
                    outputGeheimWoord[i] = a;
                }
            }
        }

        /// <summary>
        /// Methode om correct geraden woord te tonen.
        /// </summary>
        private void VervangMetCorrectWoord()
        {
            outputGeheimWoord = geheimWoord.ToCharArray();
        }

        /// <summary>
        /// <code>
        /// Methode om foute gok te behandelen
        /// ----------------------------------
        /// -1 leven.
        /// Scherm krijgt rode overlay.
        /// Countdown 2 initialiseren.
        /// Timer 2 starten.
        /// </code>
        /// </summary>
        private void FouteGok()
        {
            VolledigScherm.Background = new SolidColorBrush(accent);
            VerliesLeven();
            countdownTwee = 1;
            timerTwee.Start();
        }

        /// <summary>
        /// <code>
        /// Methode om het ingegeven geheim woord gemaskeerd weer te geven.
        /// ---------------------------------------------------------------
        /// Aanmaken van array's.
        /// Karakters vervangen met behulp van for-loop.
        /// </code>
        /// </summary>
        private void OutputGeheimWoord()
        {
            geheimWoordTemp = new char[geheimWoord.Length];
            outputGeheimWoord = new char[geheimWoordTemp.Length];

            for (int i = 0; i < geheimWoord.Length; i++)
            {
                geheimWoordTemp[i] = geheimWoord[i];
                outputGeheimWoord[i] = '-';
            }
        }

        /// <summary>
        /// <code>
        /// Methode om output te tonen.
        /// ---------------------------
        /// Toont aantal levens.
        /// Toont (gemaskeerd) geheim woord.
        /// Toont fout geraden letters.
        /// </code>
        /// </summary>
        private void OutputText()
        {
            tempOutput = String.Join(" ", outputGeheimWoord);

            Output.Text = $"Aantal levens: {aantalLevens}\n\r" +
                          $"Geheim Woord: {tempOutput}\n\r" +
                          $"Foute letters: {fouteLetters}";
            TB_Input.Text = "";
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
        /// Aanmaken TimeSpans en Events.
        /// </summary>
        private void InstellenTimers()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timerTwee.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += TimerTick;
            timerTwee.Tick += TimerTickTwee;
        }

        /// <summary>
        /// <code>
        /// Methode voor timer.
        /// -------------------
        /// Indien countdown 0 is, diss tonen, scherm flasht rood.
        /// Indien countdown onder 0 gaat, TimerReset oproepen.
        /// Indien aantal levens 0 is, timer stoppen en textbox clearen.
        /// </code>
        /// </summary>
        private void TimerTick(object sender, EventArgs e)
        {
            countdown--;
            TB_Timer.Text = countdown.ToString();

            if (countdown == 0)
            {
                VerliesLeven();
                VolledigScherm.Background = new SolidColorBrush(accent);
            }
            else if (countdown < 0)
            {
                TimerResetFout();
            }
        }

        /// <summary>
        /// <code>
        /// Methode voor timer twee.
        /// ------------------------
        /// Indien countdown twee 0 is,
        /// timer en timer twee stoppen,
        /// countdown resetten,
        /// timer herstarten.
        /// Scherm kleur (achtergrond) resetten.
        /// </code>
        /// </summary>
        private void TimerTickTwee(object sender, EventArgs e)
        {
            countdownTwee--;

            if (countdownTwee == 0)
            {
                UpdateGalg();
                TimerReset();
                timerTwee.Stop();
                countdown = countdownInput;
                timer.Start();
                TB_Timer.Text = countdown.ToString();
                VolledigScherm.Background = Brushes.Transparent;
            }
        }

        private void TimerReset()
        {
            timer.Stop();
            countdown = 0;
            TB_Timer.Text = countdown.ToString();
        }

        /// <summary>
        /// Methode om timer resetten bij correcte gok.
        /// </summary>
        private void TimerResetCorrect()
        {
            timer.Stop();
            countdown = countdownInput;
            timer.Start();
            TB_Timer.Text = countdown.ToString();
        }

        /// <summary>
        /// Methode om timer te resetten bij foute gok.
        /// </summary>
        private void TimerResetFout()
        {
            MSG_Label.Content = "";
            UpdateGalg();
            OutputText();
            countdown--;
            timer.Stop();
            countdown = countdownInput;
            timer.Start();
            VolledigScherm.Background = Brushes.Transparent;
            TB_Timer.Text = countdown.ToString();
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
        /// Methode om accent kleur in te stellen.
        /// </summary>
        private void InstellenAccentKleur()
        {
            accent.R = 181;
            accent.G = 20;
            accent.B = 36;
            accent.A = 77;
        }

        /// <summary>
        /// Methode om alle input en output te clearen.
        /// </summary>
        private void ClearAlleInputEnOutput()
        {
            fouteLetters = "";
            TB_Input.Text = "";
            Output.Text = "";
            TB_Timer.Text = "";
        }

        /// <summary>
        /// Methode om achtergrondmuziek in te stellen.
        /// </summary>
        private void InstellenAchtergrondmuziek()
        {
            achtergrondMuziek.Open(new Uri(@"Resources/unseenhorrors.mp3", UriKind.Relative));
            achtergrondMuziek.Play();
            achtergrondMuziek.MediaEnded += new EventHandler(MediaEnded);
        }
        private void VerliesLeven()
        {
            aantalLevens--;
            verliesLeven.Open(new Uri(@"Resources/demonicscream.mp3", UriKind.Relative));
            verliesLeven.Play();

            if (aantalLevens == 0)
            {
                VolledigScherm.Background = new SolidColorBrush(accent);
                UpdateGalg();
                OutputText();
                TimerReset();
                BTN_Raad.Visibility = Visibility.Hidden;
                TB_Input.Visibility = Visibility.Hidden;
                TB_Input.IsEnabled = false;
                MSG_Label.Content = $"Sorry, je hebt geen levens meer over... Het geheime woord was ' {geheimWoord} ' .";
            }
        }
        /// <summary>
        /// Methode om speler timer te laten instellen.
        /// </summary>
        private void TimerInstellen()
        {
            try
            {
                countdownInput = int.Parse(Interaction.InputBox("Hoe lang wil je de tijd hebben om te raden?\n\rGeef een getal tussen 5 en 25.", "Timer", "10"));
                countdown = countdownInput;

                if (countdown < 5 || countdown > 25)
                {
                    if (MessageBox.Show("Het ingegeven getal bevind zich buiten het gevraagde bereik, probeer opnieuw...") == MessageBoxResult.OK)
                    {
                        TimerInstellen();
                    }
                }


            }
            catch (Exception)
            {
                if (MessageBox.Show("De input is geen getal tussen 5 en 25, probeer opnieuw...") == MessageBoxResult.OK)
                {
                    TimerInstellen();
                }
            }
        }

        /// <summary>
        /// Methode om speler hint te geven.
        /// </summary>
        private void mnuHint_Click(object sender, RoutedEventArgs e)
        {
            hint = true;
            Random rng = new Random();
            string hintLetter = alfabet[rng.Next(0, alfabet.Length)];

            if (geheimWoord.Contains(hintLetter))
            {
                hintLetter = alfabet[rng.Next(0, alfabet.Length)];
            }
            else if (!geheimWoord.Contains(hintLetter))
            {
                timer.Stop();
                VolledigScherm.Background = new SolidColorBrush(accent);
                MessageBoxResult resultaat = MessageBox.Show($"Het geheim woord bevat NIET de letter '{hintLetter}'...", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

                switch (resultaat)
                {
                    case MessageBoxResult.OK:
                        VolledigScherm.Background = Brushes.Transparent;
                        alfabetTemp.Add(char.Parse(hintLetter));
                        OutputText();
                        countdown = 11;
                        timer.Start();
                        break;
                    default:
                        break;
                }
            }
            else if (alfabetTemp.Contains(char.Parse(hintLetter)))
            {
                hintLetter = alfabet[rng.Next(0, alfabet.Length)];
            }
            else
            {
                timer.Stop();
                VolledigScherm.Background = new SolidColorBrush(accent);
                MessageBoxResult resultaat = MessageBox.Show($"Het geheim woord bevat NIET de letter '{hintLetter}'...", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

                switch (resultaat)
                {
                    case MessageBoxResult.OK:
                        VolledigScherm.Background = Brushes.Transparent;
                        alfabetTemp.Add(char.Parse(hintLetter));
                        OutputText();
                        countdown = 11;
                        timer.Start();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Methode om score op te slaan in list.
        /// </summary>
        private void ScoreOpslaan()
        {
            if (hint)
            {
                return;
            }
            else
            {
                spelerNaam = Interaction.InputBox("Wat is je naam?", "Nieuwe hoogste score !!!", spelerNaam);
                aantalLevensOpgebruikt = 10 - aantalLevens;
                string huidigeTijd = DateTime.Now.ToLongTimeString();
                scoreSpeler = $"{aantalLevensOpgebruikt}{spelerNaam} - {aantalLevensOpgebruikt} levens ({huidigeTijd})";
                scorebord.Add(scoreSpeler);
                scorebord.Sort();
            }
        }

        /// <summary>
        /// Methode om scorebord weer te geven.
        /// </summary>
        private void mnuScorebord_Click(object sender, RoutedEventArgs e)
        {
            score.Clear();

            foreach (string str in scorebord)
            {
                score.AppendLine(str.ToString().Remove(0, 1));
            }
            MessageBox.Show(score.ToString());
        }

        /// <summary>
        /// Methode om achtergrondmuziek continue te laten spelen.
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

        /// <summary>
        /// Methode voor aflsuiten applicatie.
        /// </summary>
        private void mnuAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult resultaat = MessageBox.Show("Ben je zeker dat je wilt afsluiten?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            switch (resultaat)
            {
                case MessageBoxResult.OK:
                    Close();
                    break;
                case MessageBoxResult.Cancel:
                    return;
                default:
                    break;
            }
        }
    }

    /*
                    _/_/_/    _/    _/
                   _/    _/  _/  _/   
                  _/    _/  _/_/      
                 _/    _/  _/  _/     
                _/_/_/    _/    _/    
    */

}
