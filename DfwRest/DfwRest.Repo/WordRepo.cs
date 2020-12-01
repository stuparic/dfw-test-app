using System.IO;
using System.Linq;
using DfwRest.Domain;

namespace DfwRest.Repo
{
    public class WordRepo : IWordRepo
    {
        private readonly WordContext _wordContext;

        public WordRepo(WordContext wordContext)
        {
            _wordContext = wordContext;
        }

        public Word GetFromFile()
        {
            var fileStream = new FileStream("storage.txt", FileMode.Open);
            using StreamReader reader = new StreamReader(fileStream);
            var model = new Word { Text = reader.ReadToEnd() };

            return model;
        }

        public Word GetFromDb()
        {
            var models = _wordContext.Texts.ToList();
            var dto = models.Select(DomainStoreMapper.ToDomain);

            return dto.FirstOrDefault();
        }
    }
}