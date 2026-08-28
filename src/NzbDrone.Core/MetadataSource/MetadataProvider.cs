using System;

namespace NzbDrone.Core.MetadataSource
{
    // The provider is part of an external identifier.  Hardcover and Goodreads
    // happen to use the same numeric-shaped ids, but they are not interchangeable.
    public enum MetadataProvider
    {
        Hardcover,
        Goodreads
    }

    public static class MetadataProviderIds
    {
        private const string GoodreadsPrefix = "goodreads:";

        public static string ToStoredId(MetadataProvider provider, string id)
        {
            return provider == MetadataProvider.Goodreads && !id.StartsWith(GoodreadsPrefix, StringComparison.Ordinal)
                ? GoodreadsPrefix + id
                : id;
        }

        public static MetadataProvider FromStoredId(string id)
        {
            return id?.StartsWith(GoodreadsPrefix, StringComparison.Ordinal) == true
                ? MetadataProvider.Goodreads
                : MetadataProvider.Hardcover;
        }

        public static string ToProviderId(string id)
        {
            return FromStoredId(id) == MetadataProvider.Goodreads
                ? id.Substring(GoodreadsPrefix.Length)
                : id;
        }
    }
}
