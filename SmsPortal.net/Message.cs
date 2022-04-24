namespace SmsPortal.net
{
    public class Message
    {
        public string Body { get; set; }

        public string MobileNumber { get; set; }

        public Message(string mobileNumber, string body)
        {
            Body = body;

            MobileNumber = mobileNumber;
        }
    }
}
