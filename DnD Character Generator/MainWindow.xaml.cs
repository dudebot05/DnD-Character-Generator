using Microsoft.Win32;
using System;
using System.IO;
using System.Text.Json;
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
using DnD_Character_Generator.Filesave;
using System.Diagnostics;

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
        ICharacter currentChar;

        private int charStrength;
        private int charDexterity;
        private int charConstitution;
        private int charIntelligence;
        private int charWisdom;
        private int charCharisma;
        private int hitDie;
        private string race;
        private string dndClass;
        private string name;

        Creator generator;
        SaveFileDialog saveDialog;
        OpenFileDialog openDialog;

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
            saveDialog = new SaveFileDialog();
            openDialog = new OpenFileDialog();
            generator = new CreateCharacter();

            Race_List.IsEnabled = false;


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
            Race_List.Items.Add("Tiefling");
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
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreChoice2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice2.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice2, Score2);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreChoice3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice3.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice3, Score3);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreChoice4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice4.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice4, Score4);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreChoice5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice5.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice5, Score5);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreChoice6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScoreChoice6.IsEnabled = false;
            string choice = dice.setScore(ScoreChoice6, Score6);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

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

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void Class_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Race_List.IsEnabled = true;
            dndClass = (string)Class_List.SelectedItem;
            hitDie = dice.setHitDie(Class_List);
            Hitpoints.Content = hitDie;

            currentChar = generator.createCharacter(dndClass);
            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void Race_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            race = (string)Race_List.SelectedItem;
            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
            currentChar.SetTraitsandProf(Traits, Equipment, Proficiencies);
        }

        private void Randomizer_Click(object sender, RoutedEventArgs e)
        {
            

            Random rnd = new Random();
            int y = rnd.Next(12);
            int z = rnd.Next(9);

            string[] RandomClass = { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            string[] RandomRace = { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };

            Class_List.Text = RandomClass[y];
            Race_List.Text = RandomRace[z];

            RandomAbiliities_Click( sender, e);
            Name_Button_Click(sender, e);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            saveDialog.Filter = "DnD Files |*.dnd";
            openDialog.Filter = "DnD Files |*.dnd";
            saveDialog.DefaultExt = "DnD Files |*.dnd";
            openDialog.DefaultExt = "DnD Files |*.dnd";

            if (saveDialog.ShowDialog() == true) currentChar.SaveCharacter(saveDialog);
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            name = NameBox.Text;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            saveDialog.Filter = "DnD Files |*.dnd";
            openDialog.Filter = "DnD Files |*.dnd";
            saveDialog.DefaultExt = "DnD Files |*.dnd";
            openDialog.DefaultExt = "DnD Files |*.dnd";

            if (openDialog.ShowDialog() == true)
            {
                using (Stream input = File.OpenRead(openDialog.FileName))
                using (BinaryReader reader = new BinaryReader(input))
                {
                    Load character = JsonSerializer.Deserialize<Load>(reader.ReadString());
                    Debug.WriteLine(character);
                    currentChar = generator.loadCharacter(character);
                    MessageBox.Show(character.charClass + " loaded from " + openDialog.FileName);
                }
            }

            currentChar.LoadChar(NameBox, Class_List, Race_List, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
            currentChar.SetTraitsandProf(Traits, Equipment, Proficiencies);
        }

        private void RandomAbiliities_Click(object sender, RoutedEventArgs e)
        {
            Ability_Dice.IsEnabled = false;
            RandomAbiliities.IsEnabled = false;

            Score1.Visibility = Visibility.Hidden;
            Score2.Visibility = Visibility.Hidden;
            Score3.Visibility = Visibility.Hidden;
            Score4.Visibility = Visibility.Hidden;
            Score5.Visibility = Visibility.Hidden;
            Score6.Visibility = Visibility.Hidden;

            int[] Scores = dice.rollAbilities();

            Strength.Content = Scores[0];
            Dexterity.Content = Scores[1];
            Constitution.Content = Scores[2];
            Intelligence.Content = Scores[3];
            Wisdom.Content = Scores[4];
            Charisma.Content = Scores[5];

            dice.setModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod);

            charStrength = int.Parse(Strength.Content.ToString());
            charDexterity = int.Parse(Dexterity.Content.ToString());
            charConstitution = int.Parse(Constitution.Content.ToString());
            charIntelligence = int.Parse(Intelligence.Content.ToString());
            charWisdom = int.Parse(Wisdom.Content.ToString());
            charCharisma = int.Parse(Charisma.Content.ToString());

            currentChar.InitChar(race, name, charStrength, charDexterity, charConstitution, charIntelligence, charWisdom, charCharisma);
            currentChar.InitRaceModifiers(strengthMod, dexterityMod, constitutionMod, intelligenceMod, wisdomMod, charismaMod, Speed);
        }

        private void ScoreDefault_Click(object sender, RoutedEventArgs e)
        {
            Ability_Dice.IsEnabled = false;
            RandomAbiliities.IsEnabled = false;

            int[] Scores = { 15, 14, 13, 12, 10, 8 };

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

        private void Name_Button_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            string[] Dwarfnames = { "Hjalgren Stronghand", "Regdal Bigbelly", "Hardur Giantbeard", "Garmir Everforce", "Dulrik Loudbrow", "Bromduhr Keeneye" };
            string[] Elfnames = { "Roven Thaldro", "Perren Yeshoth", "Tharen Winterspell", "Rojor Ultisk", "Cratorian Elderbell", "Belheim Merne" };
            string[] Halflingnames = { "Arfer Stoutwhistle", "Danos Thornwillow", "Ricton Heartmeadow", "Teric Thistledancer", "Idobul Tosshand", "Zalkin Goodbottle" };
            string[] Humannames = { "Kahrul Chosk", "Tuethe Duke", "Fadol Bloodrunner", "Relvom Tuu", "Lang Kau", "Frarth Whistlewind" };
            string[] Dragonbornnames = { "Drithuur Calugar", "Xuatis Eragrax", "Dremres Vrakquiroth", "Keldol Shavroth", "Sheogorath Wraciar", "Uthtak Aligonth" };
            string[] Gnomenames = { "Tokas Finefall", "Alji Wobblepot", "Arixim Bottomsweet", "Raszul Tabblenabble", "Yejin Kindhelm", "Eniros Gimblehand" };
            string[] HalfElfnames = { "Yornan", "Xavxior", "Horizor", "Halanes", "Riword", "Belaxion" };
            string[] HalfOrcnames = { "Drug The Filthy", "Dragon The Mutilator", "Zudson Heart Eater", "Ahrakk The Berserker", "Drakkon Head Collector", "Jadrug The Brute" };
            string[] Tieflingnames = { "Iamira", "Horlyx", "Ozxius", "Kildons", "Skeezer", "Garomong" };
            int x = rand.Next(7);

            switch (race)
            {
                case "Dwarf":
                    name = Dwarfnames[x];
                    break;

                case "Elf":
                    name = Elfnames[x];
                    break;

                case "Halfling":
                    name = Halflingnames[x];
                    break;

                case "Human":
                    name = Humannames[x];
                    break;

                case "Dragonborn":
                    name = Dragonbornnames[x];
                    break;

                case "Gnome":
                    name = Gnomenames[x];
                    break;

                case "Half-Elf":
                    name = HalfElfnames[x];
                    break;

                case "Half-Orc":
                    name = HalfOrcnames[x];
                    break;

                case "Tiefling":
                    name = Tieflingnames[x];
                    break;
            }

            NameBox.Text = name;
        }
    }
}
