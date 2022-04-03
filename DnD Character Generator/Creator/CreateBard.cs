/* public class CreateBard : ICreator
{
    private string race;

    private int Strength;
    private int Dexterity;
    private int Constitution;
    private int Intelligence;
    private int Wisdom;
    private int Charisma;

    public override ICharacter createCharacter(int Strength, int Dexterity, int Constituition, int Intelligence, int Wisdom, int Charisma, string race)
    {
        Strength = this.Strength;
        Dexterity = this.Dexterity;
        Constituition = this.Constitution;
        Intelligence = this.Intelligence;
        Wisdom = this.Wisdom;
        Charisma = this.Charisma;
        race = this.race;


        switch (race) {
            case "Dwarf":
                Constituition += 2;
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
            case "Dragonbborn":
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
                Constituition += 1;
                break;
            
        }

        return new Bard(Strength,Dexterity,Constituition,Intelligence,Wisdom,Charisma);

    }
} */