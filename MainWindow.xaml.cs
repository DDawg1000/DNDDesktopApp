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

using System.Diagnostics;

namespace DnD_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxGunScore = 6;
        int gunScore;

        int maxEngineScore = 6;
        int engineScore;

        int maxHullScore = 6;
        int hullScore;

        int maxShieldsScore = 6;
        int shieldsScore;

        int maxFTLScore = 6;
        int FTLScore;

        int maxCommsScore = 6;
        int commsScore;

        int hp = 80;
        int maxHp = 120;

        int shields = 80;
        int maxShields = 120;

        public MainWindow()
        {
            InitializeComponent();

            gunScore = 0;
            engineScore = 0;
            hullScore = 0;
            shieldsScore = 0;
            FTLScore = 0;
            commsScore = 0;

            drawGunsBar();
            drawEnginesBar();
            drawHullBar();
            drawShieldsPowerBar();
            drawFTLBar();
            drawCommsBar();

            AdjustHealthBar();
            AdjustShieldHealthBar();

            HPText.Text = "HP: " + hp + "/" + maxHp;
            ShieldText.Text = "Shield HP: " + shields + "/" + maxShields;
        }

        private void AdjustShieldHealthBar()
        {
            Trace.WriteLine((float)shields / (float)maxShields);
            ShieldTotalBar.Width = new GridLength((float)shields / (float)maxShields, GridUnitType.Star);
            MissingShieldBar.Width = new GridLength(1 - ((float)shields / (float)maxShields), GridUnitType.Star);
            ShieldText.Text = "Shield HP: " + shields + "/" + maxShields;
        }

        private void ShieldHealthUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (shields < maxShields)
            {
                shields++;
            }

            Trace.WriteLine(shields.ToString());
            AdjustShieldHealthBar();
        }
        private void ShieldHealthDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (shields > 0)
            {
                shields--;
            }

            Trace.WriteLine(hp.ToString());
            AdjustShieldHealthBar();
        }

        private void AdjustHealthBar()
        {
            Trace.WriteLine((float)hp / (float)maxHp);
            HealthBar.Width = new GridLength((float)hp / (float)maxHp, GridUnitType.Star);
            MissingHealthBar.Width = new GridLength(1 - ((float)hp / (float)maxHp), GridUnitType.Star);
            HPText.Text = "HP: " + hp + "/" + maxHp;
        }

        private void HealthUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (hp < maxHp)
            {
                hp++;
            }

            Trace.WriteLine(hp.ToString());
            AdjustHealthBar();
        }
        private void HealthDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (hp > 0)
            {
                hp--;
            }

            Trace.WriteLine(hp.ToString());
            AdjustHealthBar();
        }

        private void GunsUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (gunScore < maxGunScore)
            {
                gunScore++;
            }

            Trace.WriteLine(gunScore.ToString());
            drawGunsBar();
        }

        private void EngineUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (engineScore < maxEngineScore)
            {
                engineScore++;
            }

            Trace.WriteLine(engineScore.ToString());
            drawEnginesBar();
        }

        private void HullUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (hullScore < maxHullScore)
            {
                hullScore++;
            }

            Trace.WriteLine(hullScore.ToString());
            drawHullBar();
        }

        private void ShieldsUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (shieldsScore < maxShieldsScore)
            {
                shieldsScore++;
            }

            Trace.WriteLine(shieldsScore.ToString());
            drawShieldsPowerBar();
        }

        private void FTLUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (FTLScore < maxFTLScore)
            {
                FTLScore++;
            }

            Trace.WriteLine(FTLScore.ToString());
            drawFTLBar();
        }

        private void CommsUpButtonPressed(object sender, RoutedEventArgs e)
        {
            if (commsScore < maxCommsScore)
            {
                commsScore++;
            }

            Trace.WriteLine(commsScore.ToString());
            drawCommsBar();
        }

        private void GunsDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (gunScore > 0)
            {
                gunScore--;
            }

            Trace.WriteLine(gunScore.ToString());
            drawGunsBar();
        }

        private void EngineDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (engineScore > 0)
            {
                engineScore--;
            }

            Trace.WriteLine(engineScore.ToString());
            drawEnginesBar();
        }

        private void HullDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (hullScore > 0)
            {
                hullScore--;
            }

            Trace.WriteLine(hullScore.ToString());
            drawHullBar();
        }

        private void ShieldsDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (shieldsScore > 0)
            {
                shieldsScore--;
            }

            Trace.WriteLine(shieldsScore.ToString());
            drawShieldsPowerBar();
        }

        private void FTLDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (FTLScore > 0)
            {
                FTLScore--;
            }

            Trace.WriteLine(FTLScore.ToString());
            drawFTLBar();
        }

        private void CommsDownButtonPressed(object sender, RoutedEventArgs e)
        {
            if (commsScore > 0)
            {
                commsScore--;
            }

            Trace.WriteLine(commsScore.ToString());
            drawCommsBar();
        }



        private void drawGunsBar()
        {
            for (int level = 0; level < GunsPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < gunScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                GunsPowerBar.Children.Add(b);
            }
        }

        private void drawEnginesBar()
        {
            for (int level = 0; level < EnginesPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < engineScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                EnginesPowerBar.Children.Add(b);
            }
        }

        private void drawHullBar()
        {
            for (int level = 0; level < HullPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < hullScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                HullPowerBar.Children.Add(b);
            }
        }

        private void drawShieldsPowerBar()
        {
            for (int level = 0; level < ShieldsPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < shieldsScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                ShieldsPowerBar.Children.Add(b);
            }
        }

        private void drawFTLBar()
        {
            for (int level = 0; level < FTLPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < FTLScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                FTLPowerBar.Children.Add(b);
            }
        }

        private void drawCommsBar()
        {
            for (int level = 0; level < CommsPowerBar.RowDefinitions.Count; level++)
            {
                Border b = new Border();
                Grid.SetRow(b, level);
                Debug.WriteLine(level);
                b.BorderBrush = Brushes.Black;
                b.BorderThickness = new Thickness(2);

                if (5 - level < commsScore)
                {
                    b.Background = Brushes.Green;
                }
                else
                {
                    b.Background = Brushes.Gray;
                }

                CommsPowerBar.Children.Add(b);
            }
        }
    }
}
