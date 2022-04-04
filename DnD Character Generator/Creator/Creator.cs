using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Generator.Creator
{
    abstract class Creator
    {
        public abstract ICharacter createCharacter(string dndclass, string race, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma);
    }

    class CreateCharacter : Creator
    {
        public override ICharacter createCharacter(string dndclass, string race, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma)
        {
            switch (dndclass)
            {
                case "Barbarian":
                    return new Barbarian(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Bard":
                    return new Bard(race,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma);
                case "Cleric":
                    return new Cleric(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Druid":
                    return new Druid(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Fighter":
                    return new Fighter(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Monk":
                    return new Monk(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Ranger":
                    return new Ranger(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Rogue":
                    return new Rogue(race,Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Sorcerer":
                    return new Sorcerer(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Warlock":
                    return new Warlock(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Wizard":
                    return new Wizard(race, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                default: 
                    throw new ArgumentException("invalid type");
            }
        }
    }
}
