namespace Rusell.Test.Shared.Domain;

public class WordMother
{
    public static string Random()
    {
        return MotherCreator.Random().Word();
    }
}
