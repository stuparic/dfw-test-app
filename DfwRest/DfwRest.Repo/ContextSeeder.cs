namespace DfwRest.Repo
{
    public class ContextSeeder
    {
        private const string LoremIpsum =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque tristique mattis nibh, quis suscipit dolor. Curabitur hendrerit arcu at ipsum sodales, vitae dignissim sapien tristique. Praesent laoreet libero et velit imperdiet, vitae congue ante tincidunt. Suspendisse sagittis rhoncus sapien hendrerit malesuada. Vivamus sed justo tristique, ornare velit sit amet, auctor nisl. Morbi condimentum, tortor eu pulvinar placerat, nunc felis ultricies libero, et aliquet neque sem quis purus. Proin quis dui velit. Donec ornare, nibh ac placerat fermentum, nunc mauris dictum diam, nec accumsan diam lacus eget nulla. Fusce faucibus dolor eget maximus lacinia. Vivamus rhoncus congue lacus, in sollicitudin urna. Vivamus gravida enim vel tempor congue.";

        private readonly WordContext _wordContext;

        public ContextSeeder(WordContext wordContext)
        {
            _wordContext = wordContext;
        }

        public void Seed()
        {
            _wordContext.Texts.Add(new WordModel { Id = 1, Text = LoremIpsum });

            _wordContext.SaveChanges();
        }
    }
}
