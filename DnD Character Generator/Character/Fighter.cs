using DnD_Character_Generator.Filesave;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

class Fighter : ICharacter
{
    private int Strength = 0;
    private int Dexterity = 0;
    private int Constitution = 0;
    private int Intelligence = 0;
    private int Wisdom = 0;
    private int Charisma = 0;
    private string Race;
    private string Name;
    private string charClass = "Fighter";

    public Fighter(Load character)
    {
        Strength = character.strength;
        Dexterity = character.dexterity;
        Constitution = character.constitution;
        Intelligence = character.intelligence;
        Wisdom = character.wisdom;
        Charisma = character.charisma;
        Race = character.race;
        Name = character.name;
    }

    public Fighter() { }

    public void InitChar(string race, string name, int Str, int Dex, int Const, int Int, int Wis, int Char)
    {
        Strength = Str;
        Dexterity = Dex;
        Constitution = Const;
        Intelligence = Int;
        Wisdom = Wis;
        Charisma = Char;
        Race = race;
        Name = name;
    }

    public void InitRaceModifiers(Label Str, Label Dex, Label Const, Label Int, Label Wis, Label Char)
    {
        switch (Race)
        {
            case "Dwarf":
                Const.Content = int.Parse(Const.Content.ToString()) + 2;
                break;
            case "Elf":
                Dex.Content = int.Parse(Dex.Content.ToString()) + 2;
                break;
            case "Halfling":
                Dex.Content = int.Parse(Dex.Content.ToString()) + 2;
                break;
            case "Human":
                Char.Content = int.Parse(Char.Content.ToString()) + 1;
                break;
            case "Dragonborn":
                Str.Content = int.Parse(Str.Content.ToString()) + 2;
                Char.Content = int.Parse(Char.Content.ToString()) + 1;
                break;
            case "Gnome":
                Int.Content = int.Parse(Int.Content.ToString()) + 2;
                break;
            case "Half-Elf":
                Char.Content = int.Parse(Char.Content.ToString()) + 2;
                Int.Content = int.Parse(Int.Content.ToString()) + 1; //Could be a stat chosen by player
                Wis.Content = int.Parse(Wis.Content.ToString()) + 1; //Could be a stat chosen by player
                break;
            case "Half-Orc":
                Str.Content = int.Parse(Str.Content.ToString()) + 2;
                Const.Content = int.Parse(Const.Content.ToString()) + 1;
                break;
            case "Tiefling":
                Int.Content = int.Parse(Int.Content.ToString()) + 1;
                Char.Content = int.Parse(Char.Content.ToString()) + 2;
                break;

        }
    }

    public void LoadChar(TextBox Name, ComboBox charClass, ComboBox Race, Label Str, Label Dex, Label Const, Label Int, Label Wis, Label Char)
    {
        Name.Text = this.Name;
        Race.SelectedItem = this.Race;
        charClass.SelectedItem = this.charClass;
        Str.Content = Strength;
        Dex.Content = Dexterity;
        Const.Content = Constitution;
        Int.Content = Intelligence;
        Wis.Content = Wisdom;
        Char.Content = Charisma;
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
            name = Name,
            charClass = "Fighter"
        };
        using (Stream output = File.Create(saveDialog.FileName))
        using (BinaryWriter writer = new BinaryWriter(output))
        {
            var jsonChar = JsonSerializer.Serialize<Load>(save);
            Debug.WriteLine(jsonChar);
            writer.Write(jsonChar);
            MessageBox.Show("Fighter saved at " + saveDialog.FileName);
        }
    }
}

