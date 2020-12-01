namespace DfwRest.Domain
{
    public interface IWordRepo
    {
        Word GetFromFile();
        Word GetFromDb();
    }
}