using FluentMigrator;
using NzbDrone.Core.Datastore.Migration.Framework;

namespace NzbDrone.Core.Datastore.Migration
{
    [Migration(41)]
    public class AddMetadataProvider : NzbDroneMigrationBase
    {
        protected override void MainDbUpgrade()
        {
            // Existing databases running this image came from the Hardcover
            // image. Goodreads ids are stored with a prefix as an additional
            // guard against collisions with Hardcover numeric ids.
            Alter.Table("AuthorMetadata").AddColumn("MetadataProvider").AsInt32().WithDefaultValue(0);
            Alter.Table("Books").AddColumn("MetadataProvider").AsInt32().WithDefaultValue(0);
            Alter.Table("Editions").AddColumn("MetadataProvider").AsInt32().WithDefaultValue(0);
            Alter.Table("Series").AddColumn("MetadataProvider").AsInt32().WithDefaultValue(0);
        }
    }
}
