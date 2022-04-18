using DnD_Character_Generator.Filesave;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;


class Monk : ICharacter
{
    private int Strength = 0;
    private int Dexterity = 0;
    private int Constitution = 0;
    private int Intelligence = 0;
    private int Wisdom = 0;
    private int Charisma = 0;
    private string Race;
    private string Name;

    public Monk(string race, string name, int Str, int Dex, int Const, int Int, int Wis, int Char)
    {

        Strength = Str;
        Dexterity = Dex;
        Constitution = Const;
        Intelligence = Int;
        Wisdom = Wis;
        Charisma = Char;
        Race = race;
        Name = name;

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

    public void SaveCharacter(SaveFileDialog saveDialog)
    {
        Load save = new Load
        {
            strength = Strength,
            constitution = Constitution,
            intelligence = Intelligence,
            wisdom = Wisdom,
            charisma = Charisma,
            race = Race,
            name = Name
        };
        using (Stream output = File.Create(saveDialog.FileName))
        using (BinaryWriter writer = new BinaryWriter(output))
        {
            var jsonChar = JsonSerializer.Serialize<Load>(save);
            Debug.WriteLine(jsonChar);
            writer.Write(jsonChar);
            MessageBox.Show("Barbarian saved at " + saveDialog.FileName);
        }
    }
}

