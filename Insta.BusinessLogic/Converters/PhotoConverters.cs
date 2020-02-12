using Insta.BusinessLogic.Entities;
using Insta.DataAccess.Records;

namespace Insta.BusinessLogic.Converters
{
    public static class PhotoConverters
    {
        public static PhotoRecord ToRecord(this PhotoEntity entity)
        {
            return new PhotoRecord
            {
                CloudUrl = entity.CloudUrl,
                CreatedAt = entity.CreatedAt,
                EntityId = entity.EntityId,
                Order = entity.Order,
                Height = entity.Height,
                Width = entity.Width
            };
        }

        public static PhotoEntity ToEntity(this PhotoRecord record)
        {
            return new PhotoEntity
            {
                Id = record.PhotoId,
                CloudUrl = record.CloudUrl,
                CreatedAt = record.CreatedAt,
                EntityId = record.EntityId,
                Order = record.Order,
                Height = record.Height,
                Width = record.Width
            };
        }
    }
}
