using System;
using System.Collections.Generic;
using System.Text;

namespace DnD_Character_Generator.Creator
{
    abstract class Creator
    {
        public abstract ICharacter createCharacter(string dndclass, string race, int Strength, int Dexterity, int Constituition, int Intelligence, int Wisdom, int Charisma);
    }

    class CreateCharacter : Creator
    {
        public override ICharacter createCharacter(string dndclass, string race, int Strength, int Dexterity, int Constituition, int Intelligence, int Wisdom, int Charisma)
        {
            switch (dndclass) {

                case "Bard":
                    return new Bard(race,Strength,Dexterity,Constituition,Intelligence,Wisdom,Charisma);
                case "Rogue":
                    return new Rogue(race,Strength, Dexterity, Constituition, Intelligence, Wisdom, Charisma);
                default: 
                    throw new ArgumentException("invalid type");
            }
        }
    }
}
