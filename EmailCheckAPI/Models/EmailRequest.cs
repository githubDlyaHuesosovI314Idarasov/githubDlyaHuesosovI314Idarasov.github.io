namespace EmailCheckAPI.Models
{
    public sealed class EmailRequest
    {
        private String _toEmail;
        private String _subject;
        private String _body;

        public EmailRequest() { }

        public EmailRequest (String toEmail, String subject, String body) {
            
            _toEmail = toEmail;
            _subject = subject;
            _body = body;
        }

        public String ToEmail { get { return _toEmail; } set { _toEmail = value; } }
        public String Subject { get { return _subject; } set { _subject = value; } }
        public String Body { get { return _body; } set { _body = value; } }


    }
}
