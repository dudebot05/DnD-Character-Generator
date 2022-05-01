using Microsoft.Win32;
using System.Windows.Controls;

public interface ICharacter
{
    void InitChar(string race, string name, int Str, int Dex, int Const, int Int, int Wis, int Char);

    void InitRaceModifiers(Label Str, Label Dex, Label Const, Label Int, Label Wis, Label Char, Label Speed);

    void SetTraitsandProf(ListView traits, ListView prof, ListView equipment);

    void LoadChar(TextBox Name, ComboBox charClass, ComboBox Race, Label Str, Label Dex, Label Const, Label Int, Label Wis, Label Char);

    //GenerateName(){}

    //GenerateSkills(){}

    //GenerateEquipment(){}

    void SaveCharacter(SaveFileDialog saveDialog);
}