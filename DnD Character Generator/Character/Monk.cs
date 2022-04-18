using System;
using System.Collections.Generic;
using System.Text;


class Monk : ICharacter
{
    private int Strength = 0;
    private int Dexterity = 0;
    private int Constitution = 0;
    private int Intelligence = 0;
    private int Wisdom = 0;
    private int Charisma = 0;

    public Monk(string race, int Str, int Dex, int Const, int Int, int Wis, int Char)
    {

        Strength = Str;
        Dexterity = Dex;
        Constitution = Const;
        Intelligence = Int;
        Wisdom = Wis;
        Charisma = Char;

        switch (race)
        {
            case "Dwarf":
                Constitution += 2;
                break;
            case "Elf":
                Dexterity += 2;
                break;
            case "Halfling":
                Dexterity += 2;
                break;
            case "Human":
                Charisma += 1;
                break;
            case "Dragonborn":
                Strength += 2;
                Charisma += 1;
                break;
            case "Gnome":
                Intelligence += 2;
                break;
            case "Half-Elf":
                Charisma += 2;
                Intelligence += 1; //Could be a stat chosen by player
                Wisdom += 1; //Could be a stat chosen by player
                break;
            case "Half-Orc":
                Strength += 2;
                Constitution += 1;
                break;
            case "Tiefling":
                Intelligence += 1;
                Charisma += 2;
                break;

        }
    }
}

