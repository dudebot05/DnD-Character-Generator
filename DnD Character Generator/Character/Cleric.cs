using DnD_Character_Generator.Filesave;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

class Cleric : ICharacter
{
    private int Strength = 0;
    private int Dexterity = 0;
    private int Constitution = 0;
    private int Intelligence = 0;
    private int Wisdom = 0;
    private int Charisma = 0;
    private string Race;
    private string Name;
    private string charClass = "Cleric";

    public Cleric(Load character)
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

    public Cleric() { }

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

    public void InitRaceModifiers(Label Str, Label Dex, Label Const, Label Int, Label Wis, Label Char, Label Speed)
    {
        switch (Race)
        {
            case "Dwarf":
                Const.Content = int.Parse(Const.Content.ToString()) + 2;
                Speed.Content = 25;
                break;
            case "Elf":
                Dex.Content = int.Parse(Dex.Content.ToString()) + 2;
                Speed.Content = 30;
                break;
            case "Halfling":
                Dex.Content = int.Parse(Dex.Content.ToString()) + 2;
                Speed.Content = 25;
                break;
            case "Human":
                Char.Content = int.Parse(Char.Content.ToString()) + 1;
                Speed.Content = 30;
                break;
            case "Dragonborn":
                Str.Content = int.Parse(Str.Content.ToString()) + 2;
                Char.Content = int.Parse(Char.Content.ToString()) + 1;
                Speed.Content = 30;
                break;
            case "Gnome":
                Int.Content = int.Parse(Int.Content.ToString()) + 2;
                Speed.Content = 25;
                break;
            case "Half-Elf":
                Char.Content = int.Parse(Char.Content.ToString()) + 2;
                //Int.Content = int.Parse(Int.Content.ToString()) + 1; //Could be a stat chosen by player -- 
                //Wis.Content = int.Parse(Wis.Content.ToString()) + 1; Program made to set to paper, info provided to user in proficiency box - Eli
                Speed.Content = 30;
                break;
            case "Half-Orc":
                Str.Content = int.Parse(Str.Content.ToString()) + 2;
                Const.Content = int.Parse(Const.Content.ToString()) + 1;
                Speed.Content = 30;
                break;
            case "Tiefling":
                Int.Content = int.Parse(Int.Content.ToString()) + 1;
                Char.Content = int.Parse(Char.Content.ToString()) + 2;
                Speed.Content = 30;
                break;

        }
    }

    public void SetTraitsandProf(ListView traits, ListView prof, ListView equipment)
    {
        traits.Items.Add("Spellcasting");
        traits.Items.Add("Divine Domain");
        prof.Items.Add("Armor: Light armor, Medium armor, Shields");
        prof.Items.Add("Weapons: All Simple weapons");
        prof.Items.Add("Tools: None");
        prof.Items.Add("Saving Throws: Wisdom, Charisma");
        prof.Items.Add("Skills: Choose two from History, Insight, Medicine, Persuasion, and Religion");
        equipment.Items.Add("(A) Mace or (B) Warhammer-proficiency required");
        equipment.Items.Add("(A) Scale mail (B) Leather armor (C) Chain mail-proficiency required");
        equipment.Items.Add("(A) Light crossbow and 20 bolts or (B) Any Simple weapon");
        equipment.Items.Add("(A) Priest's pack or (B) Explorer's pack");
        equipment.Items.Add("A Shield and a Holy symbol");
        switch (Race)
        {
            case "Dwarf":
                traits.Items.Add("Darkvision");
                traits.Items.Add("Dwarven Resilience");
                prof.Items.Add("Dwarven Combat Training");
                prof.Items.Add("Tool Proficiency");
                traits.Items.Add("Stonecunning");
                prof.Items.Add("Common Language");
                prof.Items.Add("Dwarvish Language");
                break;
            case "Elf":
                traits.Items.Add("Darkvision");
                prof.Items.Add("Keen Senses: Perception");
                traits.Items.Add("Fey Ancestry");
                traits.Items.Add("Trance");
                prof.Items.Add("Common Language");
                prof.Items.Add("Elvish Language");
                break;
            case "Halfling":
                traits.Items.Add("Lucky");
                traits.Items.Add("Brave");
                traits.Items.Add("Halfling Nimbleness");
                prof.Items.Add("Common Language");
                prof.Items.Add("Halfling Language");
                break;
            case "Human":
                prof.Items.Add("Common Language");
                prof.Items.Add("'Extra' Language");
                break;
            case "Dragonborn":
                traits.Items.Add("Draconic Ancestry");
                traits.Items.Add("Breath Weapon");
                traits.Items.Add("Damage Resistance");
                prof.Items.Add("Common Language");
                prof.Items.Add("Draconic Language");
                break;
            case "Gnome":
                traits.Items.Add("Darkvision");
                traits.Items.Add("Gnome Cunning");
                prof.Items.Add("Common Language");
                prof.Items.Add("Gnomish Language");
                break;
            case "Half-Elf":
                traits.Items.Add("Darkvision");
                traits.Items.Add("Fey Ancestry");
                prof.Items.Add("Skill Versatility: Proficiency and +1 increase in two skills of your choice");
                prof.Items.Add("Common Language");
                prof.Items.Add("Elvish Language");
                prof.Items.Add("'Extra' Language");
                break;
            case "Half-Orc":
                traits.Items.Add("Darkvision");
                prof.Items.Add("Menacing: Intimidation");
                traits.Items.Add("Relentless Endurance");
                traits.Items.Add("Savage Attacks");
                prof.Items.Add("Common Language");
                prof.Items.Add("Orc Language");
                break;
            case "Tiefling":
                traits.Items.Add("Darkvision");
                traits.Items.Add("Hellish Resistance");
                traits.Items.Add("Infernal Legacy");
                prof.Items.Add("Common Language");
                prof.Items.Add("Infernal Language");
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
            dexterity = Dexterity,
            constitution = Constitution,
            intelligence = Intelligence,
            wisdom = Wisdom,
            charisma = Charisma,
            race = Race,
            name = Name,
            charClass = "Cleric"
        };
        using (Stream output = File.Create(saveDialog.FileName))
        using (BinaryWriter writer = new BinaryWriter(output))
        {
            var jsonChar = JsonSerializer.Serialize<Load>(save);
            Debug.WriteLine(jsonChar);
            writer.Write(jsonChar);
            MessageBox.Show("Cleric saved at " + saveDialog.FileName);
        }
    }
}
