using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DnD_Character_Generator
{
    public partial class MainWindow : Window
    {
        //Initialize necessary variables
        List<string> Abilities = new List<string>
        {
            "Strength",
            "Dexterity",
            "Constitution",
            "Intelligence",
            "Wisdom",
            "Charisma"
        };
        Dice dice;

        public MainWindow()
        {
            InitializeComponent();
            //Set combobox itemssource
            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            dice = new Dice(Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
        }

        public void Mod()
        {
            if (int.Parse(Strength.Content.ToString()) != 0) strengthMod.Content = (int.Parse(Strength.Content.ToString()) - 10) / 2;
            if (int.Parse(Dexterity.Content.ToString()) != 0) dexterityMod.Content = (int.Parse(Dexterity.Content.ToString()) - 10) / 2;
            if (int.Parse(Constitution.Content.ToString()) != 0) constitutionMod.Content = (int.Parse(Constitution.Content.ToString()) - 10) / 2;
            if (int.Parse(Intelligence.Content.ToString()) != 0) intelligenceMod.Content = (int.Parse(Intelligence.Content.ToString()) - 10) / 2;
            if (int.Parse(Wisdom.Content.ToString()) != 0) wisdomMod.Content = (int.Parse(Wisdom.Content.ToString()) - 10) / 2;
            if (int.Parse(Charisma.Content.ToString()) != 0) charismaMod.Content = (int.Parse(Charisma.Content.ToString()) - 10) / 2;
        }

        private void Class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Ability_Dice_Click(object sender, RoutedEventArgs e)
        {
            //When Roll Dice is clicked, loop through 4 dice rolls six times,
            //and take the sum of the three highest values to set the scores 
            //to use for the abilities
            Ability_Dice.IsEnabled = false;
            RandomAbiliities.IsEnabled = false;

            int[] Scores = dice.rollAbilities();

            //bind the score values to the window display
            Score1.Content = Scores[0];
            Score2.Content = Scores[1];
            Score3.Content = Scores[2];
            Score4.Content = Scores[3];
            Score5.Content = Scores[4];
            Score6.Content = Scores[5];

            ScoreChoice1.IsEnabled = true;
            ScoreChoice2.IsEnabled = true;
            ScoreChoice3.IsEnabled = true;
            ScoreChoice4.IsEnabled = true;
            ScoreChoice5.IsEnabled = true;
            ScoreChoice6.IsEnabled = true;
        }

        private void ScoreChoice1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice1.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice1, Score1);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score1.Visibility = Visibility.Hidden;
        }

        private void ScoreChoice2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice2.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice2, Score2);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score2.Visibility = Visibility.Hidden;
        }

        private void ScoreChoice3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice3.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice3, Score3);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score3.Visibility = Visibility.Hidden;
        }

        private void ScoreChoice4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice4.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice4, Score4);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score4.Visibility = Visibility.Hidden;
        }

        private void ScoreChoice5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice5.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice5, Score5);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score5.Visibility = Visibility.Hidden;
        }

        private void ScoreChoice6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice6.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice6, Score6);
            Mod();

            for (int i = 0; i < Abilities.Count; i++)
            {
                if (Abilities[i].Equals(choice))
                    Abilities.Remove(Abilities[i]);
            }

            ScoreChoice1.ItemsSource = Abilities;
            ScoreChoice2.ItemsSource = Abilities;
            ScoreChoice3.ItemsSource = Abilities;
            ScoreChoice4.ItemsSource = Abilities;
            ScoreChoice5.ItemsSource = Abilities;
            ScoreChoice6.ItemsSource = Abilities;
            Score6.Visibility = Visibility.Hidden;
        }
    }
}
