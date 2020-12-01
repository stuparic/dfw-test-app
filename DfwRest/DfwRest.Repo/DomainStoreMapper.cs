using DfwRest.Domain;

namespace DfwRest.Repo
{
    internal static class DomainStoreMapper
    {
        public static Word ToDomain(WordModel model)
        {
            return new Word { Text = model.Text };
        }
    }
}
