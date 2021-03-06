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
    }
}
