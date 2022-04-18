using System;
using System.Collections.Generic;
using System.Text;


    public abstract class Creator
    {
        public abstract ICharacter createCharacter(string dndclass, string race, string name, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma);
    }

    class CreateCharacter : Creator
    {
        public override ICharacter createCharacter(string dndclass, string race, string name, int Strength, int Dexterity, int Constitution, int Intelligence, int Wisdom, int Charisma)
        {
            switch (dndclass)
            {
                case "Barbarian":
                    return new Barbarian(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Bard":
                    return new Bard(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Cleric":
                    return new Cleric(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Druid":
                    return new Druid(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Fighter":
                    return new Fighter(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Monk":
                    return new Monk(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Ranger":
                    return new Ranger(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Rogue":
                    return new Rogue(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Sorcerer":
                    return new Sorcerer(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Warlock":
                    return new Warlock(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                case "Wizard":
                    return new Wizard(race, name, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                default: 
                    throw new ArgumentException("invalid type");
            }
        }
    }

