using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DnD_Character_Generator
{
    class Dice
    {
        private Random dice;
        private Label Strength;
        private Label Dexterity;
        private Label Constitution;
        private Label Intelligence;
        private Label Wisdom;
        private Label Charisma;

        public Dice(Label strength, Label dexterity, Label constitution, Label intelligence, Label wisdom, Label charisma)
        {
            dice = new Random();
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Charisma = charisma;
            Wisdom = wisdom;
        }

        public int[] rollAbilities()
        {
            int[] Scores = new int[6];
            for (int i = 0; i < 6; i++)
            {
                int num1 = dice.Next(1, 6);
                int num2 = dice.Next(1, 6);
                int num3 = dice.Next(1, 6);
                int num4 = dice.Next(1, 6);

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

            return Scores;
        }

        public int setHitDie(ComboBox classChoice)
        {
            int hitDie = 0;

            switch (classChoice.SelectedItem)
            {
                case "Barbarian":
                    hitDie = 12;
                    break;
                case "Bard":
                    hitDie = 8;
                    break;
                case "Cleric":
                    hitDie = 8;
                    break;
                case "Druid":
                    hitDie = 8;
                    break;
                case "Fighter":
                    hitDie = 10;
                    break;
                case "Monk":
                    hitDie = 8;
                    break;
                case "Paladin":
                    hitDie = 10;
                    break;
                case "Ranger":
                    hitDie = 10;
                    break;
                case "Rogue":
                    hitDie = 8;
                    break;
                case "Sorcerer":
                    hitDie = 6;
                    break;
                case "Warlock":
                    hitDie = 8;
                    break;
                case "Wizard":
                    hitDie = 6;
                    break;
            }

            return hitDie;
        }

        public String setScore(ComboBox scoreChoice, Label score)
        {
            switch (scoreChoice.SelectedItem)
            {
                case "Strength":
                    Strength.Content = score.Content;
                    break;
                case "Dexterity":
                    Dexterity.Content = score.Content;
                    break;
                case "Constitution":
                    Constitution.Content = score.Content;
                    break;
                case "Intelligence":
                    Intelligence.Content = score.Content;
                    break;
                case "Wisdom":
                    Wisdom.Content = score.Content;
                    break;
                case "Charisma":
                    Charisma.Content = score.Content;
                    break;
            }

            return (string)scoreChoice.SelectedItem;
        }

        public void setModifiers(Label strMod, Label dexMod, Label conMod, Label intMod, Label wisMod, Label chrMod)
        {
            strMod.Content = (int.Parse(Strength.Content.ToString()) - 10) / 2;
            dexMod.Content = (int.Parse(Dexterity.Content.ToString()) - 10) / 2;
            conMod.Content = (int.Parse(Constitution.Content.ToString()) - 10) / 2;
            intMod.Content = (int.Parse(Intelligence.Content.ToString()) - 10) / 2;
            wisMod.Content = (int.Parse(Wisdom.Content.ToString()) - 10) / 2;
            chrMod.Content = (int.Parse(Charisma.Content.ToString()) - 10) / 2;
        }
    }
}
