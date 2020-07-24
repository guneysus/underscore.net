using System;
using System.Text;

namespace www.net
{
    public class UrlBuilder : IUrlBuilder
    {
        private Scheme _scheme;
        private string _host;
        private string _path;
        private int _port;

        public IHostBuilder SetScheme(Scheme scheme)
        {
            this._scheme = scheme;
            return this;
        }

        IPortBuilder IHostBuilder.SetHost(string host)
        {
            this._host = host;
            return this;
        }
        
        Uri IUrlBuilder.Build()
        {
            var sb = new StringBuilder();

            switch (_scheme)
            {
                case Scheme.Http:
                    sb.Append("http");
                    break;
                case Scheme.Https:
                    sb.Append("https");
                    break;
                case Scheme.Ftp:
                    sb.Append("ftp");
                    break;
                case Scheme.Websocket:
                    sb.Append("ws");
                    break;
                case Scheme.SecureWebsocket:
                    sb.Append("wss");
                    break;
                default:
                    throw new NotImplementedException();
            }

            sb.Append("://");
            sb.Append(_host);
            sb.Append($":{_port}");
            sb.Append(_path);

            Uri result = new Uri(sb.ToString());
            return result;
        }

        IHostBuilder ISchemeBuilder.SetScheme(Scheme scheme)
        {
            this.SetScheme(scheme);
            return this;
        }

        IUrlBuilder IPathBuilder.SetPath(string path)
        {
            this._path = path;
            return this;
        }

        IPathBuilder IPortBuilder.SetPort(int port)
        {
            this._port = port;
            return this;
        }
    }


}
