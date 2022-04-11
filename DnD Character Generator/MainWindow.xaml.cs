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

        private int charStrength;
        private int charDexterity;
        private int charConstitution;
        private int charIntelligence;
        private int charWisdom;
        private int charCharisma;
        private int hitDie;
        private string race;
        private string dndClass;

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

            //ComboBox Selections
            Class_List.Items.Add("Barbarian");
            Class_List.Items.Add("Bard");
            Class_List.Items.Add("Cleric");
            Class_List.Items.Add("Druid");
            Class_List.Items.Add("Fighter");
            Class_List.Items.Add("Monk");
            Class_List.Items.Add("Paladin");
            Class_List.Items.Add("Ranger");
            Class_List.Items.Add("Rogue");
            Class_List.Items.Add("Sorcerer");
            Class_List.Items.Add("Warlock");
            Class_List.Items.Add("Wizard");

            Race_List.Items.Add("Dwarf");
            Race_List.Items.Add("Elf");
            Race_List.Items.Add("Halfling");
            Race_List.Items.Add("Human");
            Race_List.Items.Add("Dragonborn");
            Race_List.Items.Add("Gnome");
            Race_List.Items.Add("Half-Elf");
            Race_List.Items.Add("Half-Orc");
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

        private void Class_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dndClass = Class_List.Text;
            hitDie = dice.setHitDie(Class_List);
            Hitpoints.Content = hitDie;
        }

        private void Race_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            race = Race_List.Text;
        }

        private void Randomizer_Click(object sender, RoutedEventArgs e)
        {
            
            charStrength = Int32.Parse(Strength.Content.ToString());
            charDexterity = Int32.Parse(Dexterity.Content.ToString());
            charConstitution = Int32.Parse(Constitution.Content.ToString());
            charIntelligence = Int32.Parse(Intelligence.Content.ToString());
            charWisdom = Int32.Parse(Wisdom.Content.ToString());
            charCharisma = Int32.Parse(Charisma.Content.ToString());

            Creator generator = new CreateCharacter();

            ICharacter myCharacter = generator.createCharacter(dndClass, race, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
        }
    }
}
