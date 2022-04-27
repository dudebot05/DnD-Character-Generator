using DnD_Character_Generator.Filesave;
using System;
using System.Collections.Generic;
using System.Text;


public abstract class Creator
{
    public abstract ICharacter createCharacter(string dndclass);
    public abstract ICharacter loadCharacter(string charClass, Load character);
}

class CreateCharacter : Creator
{
    public override ICharacter createCharacter(string dndclass)
    {
        switch (dndclass)
        {
            case "Barbarian":
                return new Barbarian();
            case "Bard":
                return new Bard();
            case "Cleric":
                return new Cleric();
            case "Druid":
                return new Druid();
            case "Fighter":
                return new Fighter();
            case "Monk":
                return new Monk();
            case "Paladin":
                return new Paladin();
            case "Ranger":
                return new Ranger();
            case "Rogue":
                return new Rogue();
            case "Sorcerer":
                return new Sorcerer();
            case "Warlock":
                return new Warlock();
            case "Wizard":
                return new Wizard();
            default:
                throw new ArgumentException("invalid type");
        }
    }

    public override ICharacter loadCharacter(string charClass, Load character)
    {
        switch (charClass)
        {
            case "Barbarian":
                return new Barbarian(character);
            case "Bard":
                return new Bard(character);
            case "Cleric":
                return new Cleric(character);
            case "Druid":
                return new Druid(character);
            case "Fighter":
                return new Fighter(character);
            case "Monk":
                return new Monk(character);
            case "Paladin":
                return new Paladin(character);
            case "Ranger":
                return new Ranger(character);
            case "Rogue":
                return new Rogue(character);
            case "Sorcerer":
                return new Sorcerer(character);
            case "Warlock":
                return new Warlock(character);
            case "Wizard":
                return new Wizard(character);
            default:
                throw new ArgumentException("invalid type");
        }
    }
}

