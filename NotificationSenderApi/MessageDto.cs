namespace NotificationSenderApi
{
    public class MessageDto
    {
        public string Topic { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
