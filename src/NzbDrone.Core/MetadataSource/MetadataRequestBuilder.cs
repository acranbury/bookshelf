using NzbDrone.Common.Extensions;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;

namespace NzbDrone.Core.MetadataSource
{
    public interface IMetadataRequestBuilder
    {
        IHttpRequestBuilderFactory GetRequestBuilder(MetadataProvider? provider = null);
    }

    public class MetadataRequestBuilder : IMetadataRequestBuilder
    {
        private readonly IConfigService _configService;

        public MetadataRequestBuilder(IConfigService configService)
        {
            _configService = configService;
        }

        public IHttpRequestBuilderFactory GetRequestBuilder(MetadataProvider? provider = null)
        {
            var source = provider == MetadataProvider.Goodreads
                ? _configService.GoodreadsMetadataSource
                : _configService.MetadataSource;

            return new HttpRequestBuilder(source.TrimEnd("/") + "/{route}").KeepAlive().CreateFactory();
        }
    }
}
