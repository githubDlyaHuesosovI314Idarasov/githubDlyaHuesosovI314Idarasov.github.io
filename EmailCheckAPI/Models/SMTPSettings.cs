using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace EmailCheckAPI.Models
{
    public sealed class SMTPSettings
    {
        private String? _host;
        private Int32 _port;
        private Boolean _enableSSL;
        private String? _username;
        private String? _password;
        private String _from;



        public String? Host { get { return _host; } set { _host = value; } }
        public Int32 Port { get { return _port; } set { _port = value; } }
        public Boolean EnableSSL { get { return _enableSSL; } set { _enableSSL = value; } }
        public String? Username { get { return _username; } set { _username = value; } }
        public String? Password { get { return _password; } set { _password = value; } }
        public String From { get { return _from; } set { _from = value; } }
    }
}
