using System.ComponentModel.DataAnnotations;

namespace DfwRest.Repo
{
    public class WordModel
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
