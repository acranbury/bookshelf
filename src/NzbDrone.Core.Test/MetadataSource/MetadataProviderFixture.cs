using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.MetadataSource;

namespace NzbDrone.Core.Test.MetadataSource
{
    [TestFixture]
    public class MetadataProviderFixture
    {
        [Test]
        public void should_namespace_goodreads_ids_without_changing_hardcover_ids()
        {
            MetadataProviderIds.ToStoredId(MetadataProvider.Hardcover, "123").Should().Be("123");
            MetadataProviderIds.ToStoredId(MetadataProvider.Goodreads, "123").Should().Be("goodreads:123");
            MetadataProviderIds.ToProviderId("goodreads:123").Should().Be("123");
            MetadataProviderIds.FromStoredId("goodreads:123").Should().Be(MetadataProvider.Goodreads);
        }
    }
}
