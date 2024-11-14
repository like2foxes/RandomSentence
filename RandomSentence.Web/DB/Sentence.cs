namespace RandomSentence.Web
{
    public class Sentence
    {
        public Sentence(string text)
        {
            Text = text;
        }

        public int Id { get; set; }
        public string Text { get; set; }
    }
}
