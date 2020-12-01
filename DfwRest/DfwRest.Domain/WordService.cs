using System;

namespace DfwRest.Domain
{
    public class WordService : IWordService
    {
        private readonly IWordRepo _wordRepo;

        public WordService(IWordRepo wordRepo)
        {
            _wordRepo = wordRepo;
        }

        public Word GetWords(StorageOption storageOption)
        {
            Word result;

            switch (storageOption)
            {
                case StorageOption.File:
                    result = _wordRepo.GetFromFile();
                    break;
                case StorageOption.Db:
                    result = _wordRepo.GetFromDb();
                    break;
                default:
                    throw new Exception("Error");
            }

            CalculateNumberOfWords(result);

            return result;
        }

        public void CalculateNumberOfWords(Word word)
        {
            if (word?.Text == null)
                return;

            char[] delimiters = { ' ', '\r', '\n' };
            word.NumberOfWords = word.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
