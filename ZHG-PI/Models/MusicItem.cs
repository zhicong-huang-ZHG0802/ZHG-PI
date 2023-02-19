using Azure;
using Azure.Data.Tables;

namespace ZHG_PI.Models
{
    public class MusicItem : ITableEntity
    {
        public string? PartitionKey { get; set; }
        // RowKey utilisé comme ID
        public string? RowKey { get; set; }
        
        //titre du chanson
        public string? Title { get; set; }
        //autor du chanson
        public string? Autor { get; set; }
        //durée du chanson
        public Int32 Duration { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}