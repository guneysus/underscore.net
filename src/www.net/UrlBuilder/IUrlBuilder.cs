using System;

namespace www.net
{
    public interface IUrlBuilder : ISchemeBuilder, IHostBuilder, IPathBuilder, IPortBuilder
    {
        Uri Build();
    }
}