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
        Random abilityDice = new Random();
        Random hitDie = new Random();
        List<string> Abilities = new List<string>
        {
            "Strength",
            "Dexterity",
            "Constitution",
            "Intelligence",
            "Wisdom",
            "Charisma"
        };

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
        }

        private void Class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Ability_Dice_Click(object sender, RoutedEventArgs e)
        {
            //When Roll Dice is clicked, loop through 4 dice rolls six times,
            //and take the sum of the three highest values to set the scores 
            //to use for the abilities
            int[] Scores = new int[6];
            for (int i = 0; i < 5; i++) {
                int num1 = abilityDice.Next(0, 6);
                int num2 = abilityDice.Next(0, 6);
                int num3 = abilityDice.Next(0, 6);
                int num4 = abilityDice.Next(0, 6);

                if (num1 < num2 && num1 < num3 && num1 < num4)
                {
                    Scores[i] = num2 + num3 + num4;
                }
                else if (num2 < num1 && num2 < num3 && num2 < num4)
                {
                    Scores[i] = num1 + num3 + num4;
                }
                else if (num3 < num2 && num3 < num1 && num3 < num4)
                {
                    Scores[i] = num2 + num1 + num4;
                }
                else
                {
                    Scores[i] = num2 + num3 + num1;
                }
            }

            //bind the score values to the window display
            Score1.Content = "{Binding Path = Scores[0]}";
            Score2.Content = "{Binding Path = Scores[1]}";
            Score3.Content = "{Binding Path = Scores[2]}";
            Score4.Content = "{Binding Path = Scores[3]}";
            Score5.Content = "{Binding Path = Scores[4]}";
            Score6.Content = "{Binding Path = Scores[5]}";
        }
    }
}
