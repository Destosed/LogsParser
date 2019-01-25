namespace MinecraftDialogParser
{
    public class ChatEntry
    {
        public ChatEntry(string author, string message)
        {
            this.author = author;
            this.message = message;
        }

        public string author { get; set; }
        public string message { get; set; }
    }
}