using DfwRest.Domain;

namespace DfwRest
{
    public static class DtoDomainMapper
    {
        public static TextDto ToDto(Word domain)
        {
            return new TextDto
            {
                Text = domain.Text,
                NumberOfWords = domain.NumberOfWords
            };
        }

        public static Word ToDomain(TextDto domain)
        {
            return new Word
            {
                Text = domain.Text,
                NumberOfWords = domain.NumberOfWords
            };
        }
    }
}
