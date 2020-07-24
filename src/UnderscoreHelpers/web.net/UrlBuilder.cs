using System;
using System.Collections.Generic;
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

    public interface IUrlBuilder : ISchemeBuilder, IHostBuilder, IPathBuilder, IPortBuilder
    {
        Uri Build();
    }

    public enum Scheme
    {
        Http = 0,
        Https = 1,
        Ftp = 2,
        Websocket = 3,
        SecureWebsocket = 4
    }

    public interface IHostBuilder
    {
        IPortBuilder SetHost(string host);
    }

    public interface IPortBuilder
    {
        IPathBuilder SetPort(int port);
    }

    public interface ISchemeBuilder
    {
        IHostBuilder SetScheme(Scheme scheme);
    }

    public interface IPathBuilder
    {
        IUrlBuilder SetPath(string path);
    }



}
