using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EmailCheckAPI.Models
{
    public sealed class SMTPSettings
    {
        private String? _host;
        private String? _port;
        private String? _enableSSL;
        private String? _username;
        private String? _password;
        private String _from;

        public SMTPSettings()
        {
        }

        public SMTPSettings(String host, String port, String enableSSL, String username, String from, String password)
        {

            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _username = username;
            _password = password;
            _from = from;
        }

        public SMTPSettings(IConfiguration configuration) {

            var config = configuration.GetSection("SmtpSettings");
            _host = config["Host"];
            _port = config["Port"];
            _enableSSL = config["EnableSsl"];
            _username = config["Username"];
            _from = config["From"];
            _password = config["Password"];


        }
        public String? Host { get { return _host; } set { _host = value; } }
        public String? Port { get { return _port; } set { _port = value; } }
        public String? EnableSSL { get { return _enableSSL; } set { _enableSSL = value; } }
        public String? Username { get { return _username; } set { _username = value; } }
        public String? Password { get { return _password; } set { _password = value; } }
        public String From { get { return _from; } set { _from = value; } }
    }
}
