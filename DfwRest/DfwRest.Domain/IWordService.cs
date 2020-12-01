namespace DfwRest.Domain
{
    public interface IWordService
    {
        Word GetWords(StorageOption storageOption);
        void CalculateNumberOfWords(Word word);
    }
}
